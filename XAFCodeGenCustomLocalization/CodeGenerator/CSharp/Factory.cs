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
            if(!string.IsNullOrEmpty(codeProperty.Namespace))
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
            foreach(string locGroupName in locGetGroupedGroupNames)
            {
                var locClassNames = locGroupName.Split('\\').ToArray();

                locStreamWriter.WriteLine(@$"namespace {string.Join(".", locClassNames)}");
                locStreamWriter.WriteLine(@"{");

                //Generating partial Class
                locStreamWriter.WriteLine($@"    internal partial class {locClassNames.Last()}");
                locStreamWriter.WriteLine(@"    {");

                //Generating Readonly Properties
                foreach(LocalizationNaming locName in locGetFlattenNames.Where(
                    locFlatName => locFlatName.GroupName == locGroupName))
                {
                    if(!string.IsNullOrEmpty(locName.PropertyName))
                    {
                        var locGetPropertyName = Domain.Rename.PropertyName(locName.PropertyName, codeProperty);

                        var locStartRegion = @$"     #region Readonly Property {locGetPropertyName}";
                        var locPropertyText = @$"       public static string {locGetPropertyName} ";
                        var locOpenBracket = @"{";
                        var locGetterText = @"get => CaptionHelper.GetLocalizedText(@""";
                        var locGroupPropertyName = $@"\{locName.GroupName}"", ";
                        var locItemName = $@"""{locName.PropertyName}"")";
                        var locCloseBracket = @"; }";
                        var locEndRegion = "     #endregion";

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

                locStreamWriter.WriteLine(@"    }");
                locStreamWriter.WriteLine(@"}");
            }

            if(!string.IsNullOrEmpty(codeProperty.Namespace))
            {
                locStreamWriter.WriteLine(@"}");
            }

            locStreamWriter.Close();
            locStreamWriter.Dispose();
        }

        public string GetCode() => File.ReadAllText(myFileName);
    }
}
