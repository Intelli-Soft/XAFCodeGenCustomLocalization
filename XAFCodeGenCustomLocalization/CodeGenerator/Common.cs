using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XAFCodeGenCustomLocalization.CodeGenerator
{
    public static class Common
    {
        static IEnumerable<LocalizationNaming> GetLocalizationNaming(Interfaces.INode nodeData, string GroupName)
        {
            LocalizationNaming locLocalizationNaming = null;
            if(nodeData.ChildNodes.Count == 0 || nodeData.NodeData != null)
            {
                foreach(Interfaces.INodeData locPropertyName in nodeData.NodeData)
                {
                    if(locPropertyName.IsAllowedToExport)
                    {
                        locLocalizationNaming = new LocalizationNaming();

                        var locGroupName = RemoveWhiteSpacesAndSetFirstLetterUppercase(GroupName);
                        var locNodeName = RemoveWhiteSpacesAndSetFirstLetterUppercase(nodeData.NodeName);

                        locLocalizationNaming.GroupName = string.Format(@$"{locGroupName}\{locNodeName}");
                        locLocalizationNaming.PropertyName = locPropertyName.PropertyName;
                        yield return locLocalizationNaming;
                    }
                }
            }
            if(nodeData.ChildNodes.Count > 0)
            {
                foreach(Interfaces.INode locGroupNode in nodeData.ChildNodes)
                {
                    var locGroupName = string.Format(
                        @$"{GroupName}{(String.IsNullOrEmpty(GroupName) ? String.Empty : @"\")}{nodeData.NodeName}")
                        .Trim();
                    foreach(var locDescant in GetLocalizationNaming(locGroupNode, locGroupName))
                    {
                        yield return locDescant;
                    }
                }
            }
        }

        internal static void DeleteTempFile(string tempFile)
        {
            if(File.Exists(tempFile))
            {
                try
                {
                    File.Delete(tempFile);
                } catch(Exception locException)
                {
                    Console.WriteLine(locException.Message);
                    return;
                }
            }
        }

        internal static List<LocalizationNaming> GetNames(List<Interfaces.INode> data)
        {
            List<LocalizationNaming> locReturnList = new List<LocalizationNaming>();


            foreach(Interfaces.INode locNode in data)
            {
                List<string> locGroupNames = new List<string>();

                locReturnList.AddRange(GetLocalizationNaming(locNode, String.Empty));
            }

            return locReturnList;
        }

        internal static string RemoveWhiteSpacesAndSetFirstLetterUppercase(string name)
        {
            var locStrings = name.Trim().Split(" ");
            
            if (locStrings.Length > 1 ) {
                //Let the first letter as the user wants - maybe it should be lowercase
                for (int locItem = 1; locItem < locStrings.Count(); locItem++)
                {
                    if (locStrings[locItem].Length == 0)
                        throw new Exception("Empty word?");
                    else if (locStrings[locItem].Length == 1)
                        locStrings[locItem] = char.ToUpper(locStrings[locItem][0]).ToString();
                    else
                        locStrings[locItem] = char.ToUpper(locStrings[locItem][0]) + locStrings[locItem].Substring(1);
                }

            }

            return string.Join("", locStrings);


        }

        internal static string GetTempFile()
        {
            string locTempPath = Path.GetTempPath();
            string locFileName = Path.ChangeExtension(Guid.NewGuid().ToString(), "IS");
            return Path.Combine(locTempPath, locFileName);
        }
    }
}

