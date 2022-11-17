namespace XAFCodeGenCustomLocalization
{
    partial class frmShowCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowCode));
            this.directXFormContainerControl1 = new DevExpress.XtraEditors.DirectXFormContainerControl();
            this.recCode = new DevExpress.XtraRichEdit.RichEditControl();
            this.directXFormContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // directXFormContainerControl1
            // 
            this.directXFormContainerControl1.Controls.Add(this.recCode);
            this.directXFormContainerControl1.Location = new System.Drawing.Point(1, 31);
            this.directXFormContainerControl1.Name = "directXFormContainerControl1";
            this.directXFormContainerControl1.Size = new System.Drawing.Size(1164, 746);
            this.directXFormContainerControl1.TabIndex = 0;
            // 
            // recCode
            // 
            this.recCode.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.recCode.Appearance.Text.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recCode.Appearance.Text.Options.UseFont = true;
            this.recCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recCode.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.recCode.Location = new System.Drawing.Point(0, 0);
            this.recCode.Name = "recCode";
            this.recCode.Size = new System.Drawing.Size(1164, 746);
            this.recCode.TabIndex = 0;
            this.recCode.Text = "richEditControl1";
            this.recCode.Views.SimpleView.AllowDisplayLineNumbers = true;
            // 
            // frmShowCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 778);
            this.Controls.Add(this.directXFormContainerControl1);
            this.DoubleBuffered = true;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmShowCode.IconOptions.SvgImage")));
            this.MinimizeBox = false;
            this.Name = "frmShowCode";
            this.Text = "Generated Code";
            this.directXFormContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DirectXFormContainerControl directXFormContainerControl1;
        private DevExpress.XtraRichEdit.RichEditControl recCode;
    }
}