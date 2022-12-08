using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XAFCodeGenCustomLocalization.Interfaces;

namespace XAFCodeGenCustomLocalization.CodeGenerator.VisualBasic
{
    internal class Factory : ICodeGenerator
    {
        string myFileName;


        public void Dispose()
        {
            if (File.Exists(myFileName))
                Common.DeleteTempFile(myFileName);
        }

        public void GenerateCode(IGeneratorProperty codeProperty, List<Interfaces.INode> data)
        {
            myFileName = Common.GetTempFile();
            StreamWriter locStreamWriter = new(myFileName);
            Header.AddHeader(ref locStreamWriter);

            locStreamWriter.WriteLine(@"Imports DevExpress.ExpressApp.Utils");
            locStreamWriter.WriteLine(string.Empty);

            //Generating Namespace
            if (!string.IsNullOrEmpty(codeProperty.Namespace))
            {
                locStreamWriter.WriteLine(@$"Namespace {codeProperty.Namespace}");
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
                var locCountClasses = 0;


                //Generating partial Class

                foreach (var locClassName in locClassNames)
                {
                    locStreamWriter.WriteLine(
                        $@"{new string('\t', locCountClasses + 1)}Partial Friend Class {Domain.Rename.PropertyName(locClassName, locGeneratorPropertyForNamespacesAndClasses)}");
                    locCountClasses++;
                }

                //Generating Readonly Properties or Functions
                foreach (LocalizationNaming locName in locGetFlattenNames.Where(
                    locFlatName => locFlatName.GroupName == locGroupName))
                {
                    if (!string.IsNullOrEmpty(locName.PropertyName))
                    {
                        var locGetPropertyName = Domain.Rename.PropertyName(locName.PropertyName, codeProperty);

                        var locPlaceholder = new PlaceholderRemover(locGetPropertyName);
                        if (locPlaceholder.HasPlaceholder() |
                            codeProperty.FrameworkVersion == Enums.TypeOfVersion.DotNetSixPlus)
                        {
                            var locFunctionSettItems = string.Empty;
                            var locPropertyForMemberSetter = string.Empty;

                            for (int locIndex = 0; locIndex < locPlaceholder.GetListOfPlaceHolders().Count(); locIndex++)
                            {
                                locFunctionSettItems += $@"Item{locIndex + 1} As String, ".ToString();
                                locPropertyForMemberSetter += $@"Item{locIndex + 1}, ".ToString();
                            }
                            if (!(locFunctionSettItems == string.Empty))
                                locFunctionSettItems = locFunctionSettItems.TrimEnd()
                                    .Remove(locFunctionSettItems.TrimEnd().Length - 1, 1);
                            if (!(locPropertyForMemberSetter == string.Empty))
                                locPropertyForMemberSetter = locPropertyForMemberSetter.TrimEnd()
                                    .Remove(locPropertyForMemberSetter.TrimEnd().Length - 1, 1);

                            if (codeProperty.FrameworkVersion == Enums.TypeOfVersion.DotNetSixPlus)
                            {
                                var locAddServiceProviderInterface = "serviceProvider As IServiceProvider";
                                if (!(locFunctionSettItems == string.Empty))
                                {
                                    locFunctionSettItems = $@"{locAddServiceProviderInterface}, {locFunctionSettItems}";
                                }
                                else
                                {
                                    locFunctionSettItems = locAddServiceProviderInterface;
                                }
                                ;
                            }


                            var locStartRegion = @$"{new string('\t', locCountClasses + 2)}#Region ""Function {locGetPropertyName}""";
                            var locPropertyText = @$"{new string('\t', locCountClasses + 3)} Public Shared Function {locPlaceholder.ToString()}({locFunctionSettItems}) As String";
                            var locGetterText = string.Empty;

                            switch (codeProperty.FrameworkVersion)
                            {
                                case Enums.TypeOfVersion.DotNetFive:
                                    locGetterText = @$"{new string('\t', locCountClasses + 4)}Return CaptionHelper.GetLocalizedText(""";
                                    break;
                                case Enums.TypeOfVersion.DotNetSixPlus:
                                    locGetterText = @$"{new string('\t', locCountClasses + 4)}Return CaptionHelper.GetService(serviceProvider).GetLocalizedText(""";
                                    break;
                            }


                            var locGroupPropertyName = $@"\{locName.GroupName}"", ";
                            var locItemName = $@"""{locName.PropertyName}""";
                            if (!(locPropertyForMemberSetter == string.Empty))
                                locItemName += $@",{locPropertyForMemberSetter}";
                            locItemName += ")";
                            var locEndProperty = @$"{new string('\t', locCountClasses + 3)}End Function";
                            var locEndRegion = @$"{new string('\t', locCountClasses + 2)}#End Region";

                            locStreamWriter.WriteLine(locStartRegion);
                            locStreamWriter.WriteLine(locPropertyText);
                            locStreamWriter.WriteLine(locGetterText + locGroupPropertyName + locItemName);
                            locStreamWriter.WriteLine(locEndProperty);
                            locStreamWriter.WriteLine(locEndRegion);
                            locStreamWriter.WriteLine(string.Empty);
                        }
                        else
                        {
                            var locStartRegion = @$"{new string('\t', locCountClasses + 2)}#Region ""Readonly Property {locGetPropertyName}""";
                            var locPropertyText = @$"{new string('\t', locCountClasses + 3)} Public Shared ReadOnly Property {locGetPropertyName} As String";
                            var locOpenGet = @$"{new string('\t', locCountClasses + 3)}Get";
                            var locGetterText = @$"{new string('\t', locCountClasses + 4)}Return CaptionHelper.GetLocalizedText(""";
                            var locGroupPropertyName = $@"\{locName.GroupName}"", ";
                            var locItemName = $@"""{locName.PropertyName}"")";
                            var locCloseGet = @$"{new string('\t', locCountClasses + 4)}End Get";
                            var locEndProperty = @$"{new string('\t', locCountClasses + 3)}End Property";
                            var locEndRegion = @$"{new string('\t', locCountClasses + 2)}#End Region";

                            locStreamWriter.WriteLine(locStartRegion);
                            locStreamWriter.WriteLine(locPropertyText);
                            locStreamWriter.WriteLine(locOpenGet);
                            locStreamWriter.WriteLine(locGetterText + locGroupPropertyName + locItemName);
                            locStreamWriter.WriteLine(locCloseGet);
                            locStreamWriter.WriteLine(locEndProperty);
                            locStreamWriter.WriteLine(locEndRegion);
                            locStreamWriter.WriteLine(string.Empty);
                        }
                    }
                }

                for (int locIndex = locCountClasses; locIndex > 0; locIndex--)
                {
                    locStreamWriter.WriteLine(@$"{new string('\t', locIndex)}End Class");
                }
            }
            if (!string.IsNullOrEmpty(codeProperty.Namespace))
            {
                locStreamWriter.WriteLine(@"End Namespace");
            }

            locStreamWriter.Close();
            locStreamWriter.Dispose();
        }

        public string GetCode() => File.ReadAllText(myFileName);
    }
}
