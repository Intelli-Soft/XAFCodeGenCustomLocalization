using System;
using System.Collections.Generic;
using System.Linq;
using XAFCodeGenCustomLocalization.Interfaces;

namespace XAFCodeGenCustomLocalization.Context
{
    internal class XAFMLNode : INode

    {
        private List<INode> myChildNodes = new List<INode>();
        private List<INodeData> myNodeData;

        private String myNodeName;

        public List<INode> ChildNodes { get => myChildNodes; set => myChildNodes = value; }

        public List<INodeData> NodeData { get => myNodeData; set => myNodeData = value; }


        public string NodeName { get => myNodeName; set => myNodeName = value; }
    }
}

