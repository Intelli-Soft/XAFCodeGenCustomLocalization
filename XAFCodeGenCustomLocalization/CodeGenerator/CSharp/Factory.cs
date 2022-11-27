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

            //Namespace names and class names are not allowed to have whitespaces
            //XAF does allow to have property id's which include whitespaces
            //we need to make namespace/class names without whitespaces

            IGeneratorProperty locGeneratorPropertyForNamespacesAndClasses = codeProperty;
            locGeneratorPropertyForNamespacesAndClasses.TextChange = Enums.TypeOfTextChange.FirstToUpper;
            locGeneratorPropertyForNamespacesAndClasses.Postfix = string.Empty;
            locGeneratorPropertyForNamespacesAndClasses.Praefix = string.Empty;


            foreach(string locGroupName in locGetGroupedGroupNames)
            {
                var locClassNames = locGroupName.Split('\\').ToArray();

                //We have to check, if the groups go deeper than only one child
                //the issue is, that a namespace and a class name is not allowed to be the same
                //within the same hierachy. This is, why 'locIsToSkipNamespace' is 
                //introduced here


                var locNamespace = string.Join(".", locClassNames.SkipLast(1));

                var locCountOfSameNameGroups = locGetGroupedGroupNames.Where(
                    locGroupNameToCheck => locGroupNameToCheck.StartsWith(
                            string.Join("\\", locClassNames.SkipLast(1)).ToString()) &
                        locGroupNameToCheck != string.Join("\\", locClassNames).ToString())
                    .Count();

                bool locIsToSkipNamespace = false;

                if(locCountOfSameNameGroups > 0)
                {
                    if((locGetGroupedGroupNames.Where(
                            locGroupNameToCheck => locGroupNameToCheck.StartsWith(
                                string.Join("\\", locClassNames.SkipLast(1)).ToString()))
                            .First()) !=
                        locGroupName)
                        locIsToSkipNamespace = true;
                }


                if(locIsToSkipNamespace == false)
                {
                    locStreamWriter.WriteLine(
                        @$"namespace {Domain.Rename.PropertyName(locNamespace, locGeneratorPropertyForNamespacesAndClasses)}");
                    locStreamWriter.WriteLine(@"{");
                }

                //Generating partial Class
                locStreamWriter.WriteLine(
                    $@"    internal partial class {Domain.Rename.PropertyName(locClassNames.Last(), locGeneratorPropertyForNamespacesAndClasses)}");
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
                if(locIsToSkipNamespace == false)
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
