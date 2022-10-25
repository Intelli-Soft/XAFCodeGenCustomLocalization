using System;
using System.Collections.Generic;
using System.Linq;

namespace XAFCodeGenCustomLocalization.Context
{
    internal class Group : Notify
    {
        private string myName;

        public string Name
        {
            get => myName;
            set
            {
                if (value != myName)
                {
                    myName = value;
                    NotifyPropertyChanged();
                }
                ;
            }
        }

        public List<Group> ChildGroups { get; set; }

        public List<Property> Properties { get; set; }
    }
}
