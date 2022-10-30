using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XAFCodeGenCustomLocalization.Domain
{
    internal class NodePreparation
    {
        private bool myFileIsXAFMLFile = true;

        private IEnumerable<XElement> myNodeElements;

        public NodePreparation(string fileName)
        {
            try
            {
                myNodeElements = XElement.Load(fileName).Elements(Predefinitions.XAFMLLocalizationNode);
            } catch
            {
                myFileIsXAFMLFile = false;
            }
        }


        private List<Interfaces.INodeData> GetListOfNodeData(IEnumerable<XElement> xmlNodeData)
        {
            List<Interfaces.INodeData> locListOfNodeData = new List<Interfaces.INodeData>();
            foreach(XElement locXMLNodeData in xmlNodeData)
            {
                Context.XAFMLNodeData locNodeData = new Context.XAFMLNodeData();
                if(locXMLNodeData.Name.ToString() == Predefinitions.XAFMLLocalizationItem)
                {
                    if(locXMLNodeData.FirstAttribute.Name.ToString() == Predefinitions.XAFMLLocalizationItemAttribute)
                    {
                        locNodeData.PropertyName = locXMLNodeData.FirstAttribute.Value;
                        locNodeData.IsAllowedToExport = true;
                    }
                }

                locListOfNodeData.Add(locNodeData);
            }
            return locListOfNodeData;
        }

        private Interfaces.INode GetNode(XElement xmlNode)
        {
            Context.XAFMLNode locNode = new Context.XAFMLNode();
            if(xmlNode != null)
            {
                locNode.NodeName = xmlNode.Attribute(Predefinitions.XAFMLLocalizationGroupAttribute).Value.ToString();

                if(xmlNode.Elements(Predefinitions.XAFMLLocalizationGroup).Count() > 0)
                {
                    foreach(XElement locNodeElement in xmlNode.Elements(Predefinitions.XAFMLLocalizationGroup))
                    {
                        var locChildNode = GetNode(locNodeElement);
                        locNode.ChildNodes.Add(locChildNode);
                        if(locNodeElement.Elements(Predefinitions.XAFMLLocalizationItem).Count() > 0)
                        {
                            locChildNode.NodeData = GetListOfNodeData(
                                locNodeElement.Elements(Predefinitions.XAFMLLocalizationItem));
                        }
                    }
                }
            }
            return locNode;
        }

        public List<Interfaces.INode> GetNodes()
        {
            List<Interfaces.INode> locNodes = new List<Interfaces.INode>();
            foreach(XElement locNodeElement in myNodeElements.Elements(Predefinitions.XAFMLLocalizationGroup))
            {
                locNodes.Add(GetNode(locNodeElement));
            }

            return locNodes;
        }

        public bool FileIsXAFMLFile { get { return myFileIsXAFMLFile; } }
    }
}
