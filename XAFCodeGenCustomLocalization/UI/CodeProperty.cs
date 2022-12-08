using System;
using System.Linq;
using XAFCodeGenCustomLocalization.Context;
using XAFCodeGenCustomLocalization.Enums;
using XAFCodeGenCustomLocalization.Interfaces;

namespace XAFCodeGenCustomLocalization.UI
{
    internal class CodeProperty : Notify, IGeneratorProperty
    {
        private string myPraefix;
        private string myPostfix;
        private TypeOfTextChange myTypeOfTextChange;
        private TypeOfCodeGenerator myTypeOfCodeGenerator;
        private TypeOfVersion myTypeOfVersion;
        private string myNamespace;

        public string Praefix
        {
            get => myPraefix;
            set
            {
                if (myPraefix != value)
                {
                    myPraefix = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Postfix
        {
            get => myPostfix;
            set
            {
                if (myPostfix != value)
                {
                    myPostfix = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TypeOfTextChange TextChange
        {
            get => myTypeOfTextChange;
            set
            {
                if (myTypeOfTextChange != value)
                {
                    myTypeOfTextChange = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TypeOfCodeGenerator CodeGenerator
        {
            get => myTypeOfCodeGenerator;
            set
            {
                if (myTypeOfCodeGenerator != value)
                {
                    myTypeOfCodeGenerator = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Namespace
        {
            get => myNamespace;
            set
            {
                if (myNamespace != value)
                {
                    myNamespace = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TypeOfVersion FrameworkVersion
        {
            get => myTypeOfVersion; set
            {
                if (myTypeOfVersion != value)
                {
                    myTypeOfVersion = value;
                    NotifyPropertyChanged();
                };
            }
        }
    }
}
