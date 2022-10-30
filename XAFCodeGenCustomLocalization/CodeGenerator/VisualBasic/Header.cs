using System;
using System.IO;

namespace XAFCodeGenCustomLocalization.CodeGenerator.VisualBasic
{
    internal static class Header
    {
        internal static StreamWriter AddHeader(ref StreamWriter streamWriter)
        {
            streamWriter.WriteLine(@"'|----------------------------------------------------------------------------------------------------------------------------|");
            streamWriter.WriteLine(@"'| This file was created by software generation                              ╭━━┳━╮╱╭┳━━━━┳━━━┳╮╱╱╭╮╱╱╭┳━━━┳━━━┳━━━┳━━━━╮     |");
            streamWriter.WriteLine(@"'| Each change of code within this file,                                     ╰┫┣┫┃╰╮┃┃╭╮╭╮┃╭━━┫┃╱╱┃┃╱╱┃┃╭━╮┃╭━╮┃╭━━┫╭╮╭╮┃     |");
            streamWriter.WriteLine(@"'| will be rewritten, when a new build is done                               ╱┃┃┃╭╮╰╯┣╯┃┃╰┫╰━━┫┃╱╱┃┃╱╱┃┃╰━━┫┃╱┃┃╰━━╋╯┃┃╰╯     |");
            streamWriter.WriteLine(@"'| (c) by Intell!Soft / Harald Bacik, All rights reserved.                   ╱┃┃┃┃╰╮┃┃╱┃┃╱┃╭━━┫┃╱╭┫┃╱╭╋┻━━╮┃┃╱┃┃╭━━╯╱┃┃       |");
            streamWriter.WriteLine($"'| Created: {DateTime.Now.ToString()}                                              ╭┫┣┫┃╱┃┃┃╱┃┃╱┃╰━━┫╰━╯┃╰━╯┣┫╰━╯┃╰━╯┃┃╱╱╱╱┃┃       |");
            streamWriter.WriteLine(@"'|                                                                           ╰━━┻╯╱╰━╯╱╰╯╱╰━━━┻━━━┻━━━┻┻━━━┻━━━┻╯╱╱╱╱╰╯       |");
            streamWriter.WriteLine("'|----------------------------------------------------------------------------------------------------------------------------|");
            streamWriter.WriteLine(string.Empty);
            return streamWriter;
        }
    }
}
