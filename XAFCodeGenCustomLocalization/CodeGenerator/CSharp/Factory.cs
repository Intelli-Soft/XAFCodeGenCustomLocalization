using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XAFCodeGenCustomLocalization.Interfaces;

namespace XAFCodeGenCustomLocalization.CodeGenerator.CSharp
{
    internal class Factory : ICodeGenerator
    {
        string myFileName;


        public void Dispose()
        {
            if(File.Exists(myFileName))
                Common.DeleteTempFile(myFileName);
        }

        public void GenerateCode(IGeneratorProperty codeProperty, List<Interfaces.INode> data)
        {
            myFileName = Common.GetTempFile();
            StreamWriter locStreamWriter = new(myFileName);
            Header.AddHeader(ref locStreamWriter);

            locStreamWriter.WriteLine(@"using DevExpress.ExpressApp.Utils;");
            locStreamWriter.WriteLine(string.Empty);

            //Generating Namespace
            if (!string.IsNullOrEmpty(codeProperty.Namespace))
            {
                locStreamWriter.WriteLine(@$"namespace {codeProperty.Namespace}");
                locStreamWriter.WriteLine(@"{");
            }


            //Generating ReadOnly Properties
            var locGetFlattenNames = Common.GetNames(data);

            var locGetGroupedGroupNames = locGetFlattenNames.AsEnumerable()
                .Select(locData => locData.GroupName)
                .Distinct()
                .ToList();

            //Namespace names and class names are not allowed to have whitespaces
            //XAF does allow to have property id's which include whitespaces
            //we need to make namespace/class names without whitespaces

            IGeneratorProperty locGeneratorPropertyForNamespacesAndClasses = codeProperty;
            locGeneratorPropertyForNamespacesAndClasses.TextChange = Enums.TypeOfTextChange.FirstToUpper;
            locGeneratorPropertyForNamespacesAndClasses.Postfix = string.Empty;
            locGeneratorPropertyForNamespacesAndClasses.Praefix = string.Empty;

            foreach (string locGroupName in locGetGroupedGroupNames)
            {
                var locClassNames = locGroupName.Split('\\').ToArray();
                var locCountBrackets = 0;

                //Generating partial Class

                foreach (var locClassName in locClassNames)
                {
                    locStreamWriter.WriteLine(

                    $@"{new string('\t', locCountBrackets + 1)}internal partial class {Domain.Rename.PropertyName(locClassName, locGeneratorPropertyForNamespacesAndClasses)}");
                    locStreamWriter.WriteLine(@$"{new string('\t', locCountBrackets + 1)}{{");
                    locCountBrackets++;
                }




                //Generating Readonly Properties
                foreach (LocalizationNaming locName in locGetFlattenNames.Where(
                    locFlatName => locFlatName.GroupName == locGroupName))
                {
                    if (!string.IsNullOrEmpty(locName.PropertyName))
                    {
                        var locGetPropertyName = Domain.Rename.PropertyName(locName.PropertyName, codeProperty);

                        var locStartRegion = @$"{new string('\t', locCountBrackets + 2)}#region Readonly Property {locGetPropertyName}";
                        var locPropertyText = @$"{new string('\t', locCountBrackets + 3)}public static string {locGetPropertyName} ";
                        var locOpenBracket = @"{";
                        var locGetterText = @"get => CaptionHelper.GetLocalizedText(@""";
                        var locGroupPropertyName = $@"\{locName.GroupName}"", ";
                        var locItemName = $@"""{locName.PropertyName}"")";
                        var locCloseBracket = @"; }";
                        var locEndRegion = @$"{new string('\t', locCountBrackets + 2)}#endregion";

                        locStreamWriter.WriteLine(locStartRegion);
                        locStreamWriter.WriteLine(
                            locPropertyText +
                                locOpenBracket +
                                locGetterText +
                                locGroupPropertyName +
                                locItemName +
                                locCloseBracket);
                        locStreamWriter.WriteLine(locEndRegion);
                        locStreamWriter.WriteLine(string.Empty);
                    }
                }

                WriteClosingBrackets(locStreamWriter, locCountBrackets);
            }
            WriteClosingBrackets(locStreamWriter, 1);
            locStreamWriter.Close();
            locStreamWriter.Dispose();
        }

        private static void WriteClosingBrackets(StreamWriter locStreamWriter, int CountOfClosingBrackets)
        {
            for (int i = CountOfClosingBrackets - 1; i >= 0; i--)
            {
                string locTabs = new string('\t', i);
                locStreamWriter.WriteLine(@$"{locTabs}}}");
            }
        }
        private static void WriteOpeningBrackets(StreamWriter locStreamWriter, int CountOfOpeningBrackets)
        {
            for (int i = 0; i < CountOfOpeningBrackets -1; i++)
            {
                string locTabs = new string('\t', i);
                locStreamWriter.WriteLine(@$"{locTabs}}}");
            }
        }


        public string GetCode() => File.ReadAllText(myFileName);
    }
}
