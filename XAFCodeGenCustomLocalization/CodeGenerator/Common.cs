using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XAFCodeGenCustomLocalization.CodeGenerator
{
    public static class Common
    {
        internal static string GetTempFile()
        {
            string locTempPath = Path.GetTempPath();
            string locFileName = Path.ChangeExtension(Guid.NewGuid().ToString(), "IS");
            return Path.Combine(locTempPath, locFileName);
        }

        internal static void DeleteTempFile(string tempFile)
        {
            if (File.Exists(tempFile))
            {
                try { File.Delete(tempFile); } catch (Exception locException) { Console.WriteLine(locException.Message); return; }
            }
        }

        internal static List<LocalizationNaming> GetNames(List<Interfaces.INode> data)
        {
            List<LocalizationNaming> locReturnList = new List<LocalizationNaming>();



            foreach (Interfaces.INode locNode in data)
            {
                List<string> locGroupNames = new List<string>();

                locReturnList.AddRange(GetLocalizationNaming(locNode, String.Empty));


            }

            return locReturnList;
        }


        static IEnumerable<LocalizationNaming> GetLocalizationNaming(Interfaces.INode nodeData, string GroupName)
        {
            LocalizationNaming locLocalizationNaming = null;
            if (nodeData.ChildNodes.Count == 0 || nodeData.NodeData != null)
            {
                foreach (Interfaces.INodeData locPropertyName in nodeData.NodeData)
                {
                    if (locPropertyName.IsAllowedToExport)
                    {
                        locLocalizationNaming = new LocalizationNaming();

                        locLocalizationNaming.GroupName = string.Format(@$"{GroupName}\{nodeData.NodeName}");
                        locLocalizationNaming.PropertyName = locPropertyName.PropertyName;
                        yield return locLocalizationNaming;
                    }

                }
            }
            if (nodeData.ChildNodes.Count > 0)
            {
                foreach (Interfaces.INode locGroupNode in nodeData.ChildNodes)
                {
                    var locGroupName = string.Format(@$"{GroupName}{(String.IsNullOrEmpty(GroupName) ? String.Empty : @"\")}{nodeData.NodeName}").Trim();
                    foreach (var locDescant in GetLocalizationNaming(locGroupNode, locGroupName))
                    {
                        yield return locDescant;
                    }

                }
            }


        }


    }

}

