using System;
using System.Linq;

namespace XAFCodeGenCustomLocalization.Interfaces
{
    internal interface INodeData
    {
        bool IsAllowedToExport { get; set; }
        string PropertyName { get; set; }

    }
}
