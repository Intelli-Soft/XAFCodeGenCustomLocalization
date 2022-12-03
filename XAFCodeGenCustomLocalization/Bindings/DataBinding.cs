using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace XAFCodeGenCustomLocalization.Bindings
{
    internal static class DataBinding<T> where T : Enum
    {

        private static void Binding_Format(object sender, ConvertEventArgs e) => e.Value =
            (int)Enum.Parse(typeof(T), e.Value.ToString());

        private static void Binding_Parse(object sender, ConvertEventArgs e) => e.Value =
           Enum.Parse(typeof(T), Enum.GetName(typeof(T), Int32.Parse(e.Value.ToString())));

        public static void AddEnumBindingToRadioGroup(RadioGroup radioGroup, object dataSource, string dataMember)
        {
            var locBinding = new Binding(
                nameof(RadioGroup.EditValue),
                dataSource,
                dataMember,
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            locBinding.Parse += Binding_Parse;
            locBinding.Format += Binding_Format;
            radioGroup.DataBindings.Add(locBinding);
        }

    }
}
