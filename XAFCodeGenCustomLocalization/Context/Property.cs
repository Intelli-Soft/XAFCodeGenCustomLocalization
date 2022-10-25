using System;
using System.Linq;

namespace XAFCodeGenCustomLocalization.Context
{
    internal class Property : Notify
    {
        private string myName;
        private bool myIsAllowedToExport;
        private string myExportName;

        public string Name
        {
            get => myName;
            set
            {
                if (myName != value)
                {
                    myName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsAllowedToExport
        {
            get => myIsAllowedToExport;
            set
            {
                if (myIsAllowedToExport != value)
                {
                    myIsAllowedToExport = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ExportName
        {
            get => myExportName;
            set
            {
                if (myExportName != value)
                {
                    myExportName = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
