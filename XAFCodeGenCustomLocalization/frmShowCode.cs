using System;
using System.Linq;

namespace XAFCodeGenCustomLocalization
{
    public partial class frmShowCode : DevExpress.XtraEditors.DirectXForm
    {
        public frmShowCode()
        {
            InitializeComponent();
        }

        public void SetCode(string codeContent)
        {

            this.recCode.Text = codeContent;
        }
    }
}