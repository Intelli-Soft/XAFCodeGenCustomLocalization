
using System.Linq;
using XAFCodeGenCustomLocalization.Interfaces;

namespace XAFCodeGenCustomLocalization.CodeGenerator.CSharp
{
    public struct ReservedWords : IReservedWords
    {

        public string GetPropertyName(string propertyName)
        {
            string locReturnValue = propertyName;
            var locReservedNames = new string[] { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };

            var locReservedNamesToLower = locReservedNames.Select(locString => locString.ToLower()).ToArray();
            if (locReservedNamesToLower.Where(locString => locString.Contains(propertyName.ToLower())).Any() == true)
            {
                locReturnValue = $"@{locReturnValue}";
            }
            return locReturnValue;
        }
    }
}