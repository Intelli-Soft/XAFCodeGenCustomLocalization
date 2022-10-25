using System;
using System.Linq;

namespace XAFCodeGenCustomLocalization.Context
{
    internal class XAFMLNodeData : Interfaces.INodeData
    {
        private bool myIsAllowedToExport;
        private string myPropertyName;

        public bool IsAllowedToExport { get => myIsAllowedToExport; set => myIsAllowedToExport = value; }
        public string PropertyName { get => myPropertyName; set => myPropertyName = value; }
    }
}
