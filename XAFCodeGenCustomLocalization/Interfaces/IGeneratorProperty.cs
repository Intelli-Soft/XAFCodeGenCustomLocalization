using System;
using System.Linq;
using XAFCodeGenCustomLocalization.Enums;

namespace XAFCodeGenCustomLocalization.Interfaces
{
    internal interface IGeneratorProperty

    {
        TypeOfCodeGenerator CodeGenerator { get; set; }
        string Namespace { get; set; }
        string Postfix { get; set; }
        string Praefix { get; set; }
        TypeOfTextChange TextChange { get; set; }
        TypeOfVersion FrameworkVersion { get; set; }
    }
}
