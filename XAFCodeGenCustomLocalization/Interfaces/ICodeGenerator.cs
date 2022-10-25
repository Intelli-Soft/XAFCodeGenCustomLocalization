using System;
using System.Collections.Generic;
using System.Linq;

namespace XAFCodeGenCustomLocalization.Interfaces
{
    internal interface ICodeGenerator : IDisposable
    {
        void GenerateCode(IGeneratorProperty codeProperty, List<INode> data);
        string GetCode();
    }
}
