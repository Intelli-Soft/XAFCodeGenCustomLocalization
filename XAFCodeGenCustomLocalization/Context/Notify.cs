using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace XAFCodeGenCustomLocalization.Context
{
    internal abstract class Notify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
