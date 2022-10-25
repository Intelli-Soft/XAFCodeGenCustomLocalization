using System;
using System.Collections.Generic;
using System.Linq;

namespace XAFCodeGenCustomLocalization.Interfaces
{
    internal interface INode
    {
        string NodeName { get; set; }
        List<INode> ChildNodes { get; set; }
        List<INodeData> NodeData { get; set; }

    }
}
