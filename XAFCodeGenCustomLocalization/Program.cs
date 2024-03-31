//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Sonntag, 31. März 2024 @ 31.03.2024 20:13:24
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using XAFCodeGenCustomLocalization.Domain;
using XAFCodeGenCustomLocalization.UI;

namespace XAFCodeGenCustomLocalization
{
    internal static class Program
    {
        private const int ATTACH_PARENT_PROCESS = -1;

        static private string myDestinationArgument;
        static private string myFrameworkArgument;
        static private string myLanguageArgument;

        static private string myNameSpaceArgument;

        static private NodePreparation myNodePreparation = null;
        static private string myPostFixArgument;
        static private string myPrefixArgument;
        static private string myTextOptionsArgument;
        static private Enums.TypeOfCodeGenerator myTypeOfCodeGenerator;
        static private Enums.TypeOfTextChange myTypeOfTextChange;

        static private Enums.TypeOfVersion myTypeOfVersion;
        static private string myXafmlArgument;


        [DllImport("kernel32.dll")] static extern bool AttachConsole(int dwProcessId);

        private static bool CheckArgumentsAreCorrect(string[] args)
        {
            var locReturnValue = true;

            myNameSpaceArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/n:"))?.Replace(
                "/n:",
                string.Empty);
            myDestinationArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/d:"))?.Replace(
                "/d:",
                string.Empty);
            myXafmlArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/x:"))?.Replace(
                "/x:",
                string.Empty);
            myLanguageArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/l:"))?.Replace(
                "/l:",
                string.Empty);
            myTextOptionsArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/t:"))?.Replace(
                "/t:",
                string.Empty);
            myFrameworkArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/f:"))?.Replace(
                "/f:",
                string.Empty);
            myPrefixArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/pre:"))?.Replace(
                "/pre:",
                string.Empty);
            myPostFixArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/post:"))?.Replace(
                "/post:",
                string.Empty);

            if(myNameSpaceArgument == null)
            {
                Console.WriteLine("Missing argument: /n:namespace");
                locReturnValue = false;
            }

            if(myDestinationArgument == null)
            {
                Console.WriteLine("Missing argument: /d:destination");
                locReturnValue = false;
            }

            if(myXafmlArgument == null)
            {
                Console.WriteLine("Missing argument: /x:xafml file");
                locReturnValue = false;
            }

            if(myLanguageArgument == null)
            {
                Console.WriteLine("Missing argument: /l:language");
                locReturnValue = false;
            }

            if(myTextOptionsArgument == null)
            {
                Console.WriteLine("Missing argument: /t:textoptions");
                locReturnValue = false;
            }

            if(myFrameworkArgument == null)
            {
                Console.WriteLine("Missing argument: /f:framework");
                locReturnValue = false;
            }

            return locReturnValue;
        }

        private static bool CheckXAFMLFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                return false;
            }
            try
            {
                myNodePreparation = new NodePreparation(fileName);
                return myNodePreparation.FileIsXAFMLFile;
            } catch
            {
                return false;
            }
        }

        private static bool ConvertArgumentToEnumAreCorrect()
        {
            var locReturnValue = true;
            if(Enum.TryParse(myLanguageArgument, out myTypeOfCodeGenerator) == false)
            {
                Console.WriteLine("Wrong argument: /l:language");
                locReturnValue = false;
            }

            if(Enum.TryParse(myTextOptionsArgument, out myTypeOfTextChange) == false)
            {
                Console.WriteLine("Wrong argument: /t:textoptions");
                locReturnValue = false;
            }

            if(Enum.TryParse(myFrameworkArgument, out myTypeOfVersion) == false)
            {
                Console.WriteLine("Wrong argument: /f:framework");
                locReturnValue = false;
            }


            return locReturnValue;
        }

        private static bool GenerateCode()
        {
            if(!CheckXAFMLFile(myXafmlArgument))
            {
                Console.WriteLine("Wrong argument: /x:xafml file does not exist or is not a xafml file");
                return false;
            }

            CodeProperty locCodeProperty = new()
            {
                CodeGenerator = myTypeOfCodeGenerator,
                Namespace = myNameSpaceArgument,
                FrameworkVersion = myTypeOfVersion,
                TextChange = myTypeOfTextChange,
                Postfix = myPostFixArgument,
                Praefix = myPrefixArgument
            };

            Interfaces.ICodeGenerator locCodeGenerator = null;
            if(locCodeProperty.CodeGenerator == Enums.TypeOfCodeGenerator.C)
                locCodeGenerator = new CodeGenerator.CSharp.Factory();
            else
                locCodeGenerator = new CodeGenerator.VisualBasic.Factory();

            locCodeGenerator.GenerateCode(locCodeProperty, myNodePreparation.GetNodes());
            var locReturn = locCodeGenerator.GetCode();
            File.WriteAllText(myDestinationArgument, locReturn, Encoding.UTF8);
            locCodeGenerator.Dispose();
            return true;
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if(args.Length > 0 && args[0] == "/?")
            {
                ShowHelp();
                return;
            } else if(args.Length >= 6 && args.Length <= 8)
            {
                ShowHeaderGenerator();

                if(CheckArgumentsAreCorrect(args) == false)
                    return;

                if(ConvertArgumentToEnumAreCorrect() == false)
                    return;
                try

                {
                    if(GenerateCode())
                    {
                        Console.WriteLine("Code generation done successfully.");
                        Console.WriteLine("Have fun using strong typed localization now!");
                        Environment.Exit(0);
                        return;
                    } else
                    {
                        Console.WriteLine("Code generation failed.");
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            } else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMainForm());
            }
        }

        private static void ShowHeaderGenerator()
        {
            Console.WriteLine();
            Console.WriteLine(
                @"//|------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine(
                @"//| This software generates type safe localization code             ╭━━┳━╮╱╭┳━━━━┳━━━┳╮╱╱╭╮╱╱╭┳━━━┳━━━┳━━━┳━━━━╮     |");
            Console.WriteLine(
                @"//|                                                                 ╰┫┣┫┃╰╮┃┃╭╮╭╮┃╭━━┫┃╱╱┃┃╱╱┃┃╭━╮┃╭━╮┃╭━━┫╭╮╭╮┃     |");
            Console.WriteLine(
                @"//| This software comes without warranty                            ╱┃┃┃╭╮╰╯┣╯┃┃╰┫╰━━┫┃╱╱┃┃╱╱┃┃╰━━┫┃╱┃┃╰━━╋╯┃┃╰╯     |");
            Console.WriteLine(
                @"//| (c) by Intell!Soft / Harald Bacik, All rights reserved.         ╱┃┃┃┃╰╮┃┃╱┃┃╱┃╭━━┫┃╱╭┫┃╱╭╋┻━━╮┃┃╱┃┃╭━━╯╱┃┃       |");
            Console.WriteLine(
                $"//| Created: {DateTime.Now.ToString()}                                    ╭┫┣┫┃╱┃┃┃╱┃┃╱┃╰━━┫╰━╯┃╰━╯┣┫╰━╯┃╰━╯┃┃╱╱╱╱┃┃       |");
            Console.WriteLine(
                @"//|                                                                 ╰━━┻╯╱╰━╯╱╰╯╱╰━━━┻━━━┻━━━┻┻━━━┻━━━┻╯╱╱╱╱╰╯       |");
            Console.WriteLine(
                "//|------------------------------------------------------------------------------------------------------------------|");
        }


        static private void ShowHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  XAFCodeGenCustomLocalization.exe [options]");
            Console.WriteLine(string.Empty);
            Console.WriteLine("   /?               - Show this help screen.");
            Console.WriteLine("   /n:namespace     - Namespace of the generated code.");
            Console.WriteLine("   /d:destination   - Filename of the generated code.");
            Console.WriteLine("   /x:xafml file    - Filename of the xafml file.");
            Console.WriteLine("   /l:language      - Language of the generated code.     Possible values: 'C', 'VB'");
            Console.WriteLine(
                "   /t:textoptions   - Text options of the generated code. Possible values: 'None', 'FirstToUpper', 'ToLower', 'ToUpper'");
            Console.WriteLine(
                "   /f:framework     - Framework of the generated code.    Possible values: 'DotNetFive', 'DotNetSixPlus'");
            Console.WriteLine(string.Empty);
            Console.WriteLine("  All of the above arguments are needed to execute the application correctly.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("  Optional arguments:");
            Console.WriteLine("   /pre:prefix      - Prefix of the generated code.");
            Console.WriteLine("   /post:suffix     - Suffix of the generated code.");
        }
    }
}
