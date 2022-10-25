using System;
using System.Linq;
using XAFCodeGenCustomLocalization.Interfaces;

namespace XAFCodeGenCustomLocalization.Domain
{
    internal class Rename
    {

        public static string PropertyName(string originalName, IGeneratorProperty generatorProperty)
        {
            if (string.IsNullOrEmpty(originalName)) return string.Empty;

            string locReturnName = originalName.Trim();
            switch (generatorProperty.TextChange)
            {
                case Enums.TypeOfTextChange.None:
                    break;

                case Enums.TypeOfTextChange.FirstToUpper:
                    if (locReturnName.Length == 0) Console.WriteLine("Empty string can not be capitalized");
                    else if (locReturnName.Length == 1) char.ToUpper(locReturnName[0]);
                    else locReturnName = char.ToUpper(locReturnName[0]) + locReturnName.Substring(1);
                    break;

                case Enums.TypeOfTextChange.ToLower:
                    if (locReturnName.Length == 0) Console.WriteLine("Empty string can not be changed to lower");
                    else locReturnName = locReturnName.ToLower();
                    break;
                case Enums.TypeOfTextChange.ToUpper:
                    if (locReturnName.Length == 0) Console.WriteLine("Empty string can not be changed to upper");
                    else locReturnName = locReturnName.ToUpper();
                    break;

            }

            if (!string.IsNullOrEmpty(generatorProperty.Praefix))
            {
                locReturnName = generatorProperty.Praefix.Trim() + locReturnName;
            }
            if (!string.IsNullOrEmpty(generatorProperty.Postfix))
            {
                locReturnName = locReturnName + generatorProperty.Postfix.Trim();
            }

            return locReturnName;

        }
    }
}
