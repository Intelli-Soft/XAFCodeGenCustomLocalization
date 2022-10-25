using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XAFCodeGenCustomLocalization.Context;
using XAFCodeGenCustomLocalization.UI;

namespace XAFCodeGenCustomLocalization
{
    public partial class frmMainForm : DirectXForm
    {
        private Domain.NodePreparation myNodePreparation;
        private String myXAFMLFileName = string.Empty;

        private CodeProperty myCodeProperty = null;

        public String XAFMLFileName
        {
            get => myXAFMLFileName;
            set
            {
                if (!object.Equals(myXAFMLFileName, value))
                {
                    myXAFMLFileName = value;
                    txtPath.Text = Path.GetDirectoryName(myXAFMLFileName);
                    txtPath.Refresh();
                }
            }
        }

        public frmMainForm()
        {
            InitializeComponent();
            BindCodeGenerationProperties();

            rdgCodeGeneration.EditValue = 0;
            rdgTextOptions.EditValue = 0;

        }

        private void cmdOpenXAFMLFile_Click(object sender, EventArgs e)
        {
            ActivateGroup(false);

            var locGetFileName = GetFileName();

            if (locGetFileName != string.Empty)
            {
                if (OpenXAFMLFile())
                {
                    PrepareUI(myNodePreparation.GetNodes(), grdMain);
                }
            }
        }

        private string GetFileName()
        {
            try
            {
                if (XAFMLFileName != string.Empty)
                    OpenFileDialog.InitialDirectory = XAFMLFileName;

                OpenFileDialog.DefaultExt = "xafml";
                OpenFileDialog.Filter = "XAFML Files (xafml)|*.xafml";

                DialogResult locShowDialogResult = OpenFileDialog.ShowDialog();

                if (locShowDialogResult == DialogResult.OK | locShowDialogResult == DialogResult.Yes)
                {
                    XAFMLFileName = OpenFileDialog.FileName;
                    return OpenFileDialog.SafeFileName;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private void txtPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        { GetFileName(); }


        private bool OpenXAFMLFile()
        {
            if (!File.Exists(XAFMLFileName))
            {
                return false;
            }
            try
            {
                myNodePreparation = new Domain.NodePreparation(XAFMLFileName);
                return myNodePreparation.FileIsXAFMLFile;
            }
            catch
            {
                return false;
            }
        }

        private void PrepareUI(List<Interfaces.INode> listOfNodes, GridControl gridControl)
        {
            AddGridViewHandlers(gridControl);
            gridControl.DataSource = CreateGroup(listOfNodes).ToArray();
            ActivateGroup(true);
        }

        private void AddGridViewHandlers(GridControl gridControl)
        {
            DeleteGridViewHandlers(gridControl);
            gridControl.ViewRegistered += GridControl_ViewRegistered;
            rdgTextOptions.Properties.EditValueChanging += Properties_EditValueChanging;
            rdgCodeGeneration.Properties.EditValueChanging += Properties_EditValueChanging;
        }

        private void GridControl_ViewRegistered(object sender, ViewOperationEventArgs e)
        {
            var locView = (e.View as GridView);
            if (locView != null)
            {
                if (locView.Columns[nameof(Property.ExportName)] != null)
                {
                    locView.Columns[nameof(Property.ExportName)].OptionsColumn.ReadOnly = true;
                }
            }
        }

        private void DeleteGridViewHandlers(GridControl gridControl)
        {
            gridControl.ViewRegistered -= GridControl_ViewRegistered;
            rdgTextOptions.Properties.EditValueChanging -= Properties_EditValueChanging;
            rdgCodeGeneration.Properties.EditValueChanging -= Properties_EditValueChanging;
        }


        private List<Group> CreateGroup(List<Interfaces.INode> listOfNodes)
        {
            var locReturnGroup = new List<Group>();
            foreach (var locNode in listOfNodes)
            {
                var locGroup = new Group();
                locGroup.Name = locNode.NodeName;
                locGroup.ChildGroups = CreateGroup(locNode.ChildNodes);

                if (locNode.NodeData != null)
                {
                    foreach (var locNodeData in locNode.NodeData)
                    {
                        if (locGroup.Properties == null)
                            locGroup.Properties = new List<Property>();

                        locGroup.Properties
                            .Add(
                                new Property()
                                {
                                    IsAllowedToExport = locNodeData.IsAllowedToExport,
                                    Name = locNodeData.PropertyName
                                });
                    }
                }
                locReturnGroup.Add(locGroup);
            }

            return locReturnGroup;
        }

        private void ActivateGroup(bool isActive)
        {
            this.grpCode.Enabled = isActive;
            this.grpCode.Refresh();
        }

        private void BindCodeGenerationProperties()
        {
            if (myCodeProperty == null)
            {
                myCodeProperty = new();
                txtNamespace.DataBindings
                    .Add(nameof(txtNamespace.Text), myCodeProperty, nameof(myCodeProperty.Namespace));
                txtPraefix.DataBindings.Add(nameof(txtPraefix.Text), myCodeProperty, nameof(myCodeProperty.Praefix));
                txtPostfix.DataBindings.Add(nameof(txtPostfix.Text), myCodeProperty, nameof(myCodeProperty.Postfix));



                //rdgTextOptions.DataBindings.Add(new Binding(nameof(rdgTextOptions.EditValue), myCodeProperty, nameof(myCodeProperty.TextChange)));               
                //rdgCodeGeneration.DataBindings.Add(nameof(rdgCodeGeneration.SelectedIndex), myCodeProperty, nameof(myCodeProperty.CodeGenerator));
            }
        }

        private void Properties_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            switch (((RadioGroup)sender).Name)
            {
                case nameof(rdgCodeGeneration):
                    myCodeProperty.CodeGenerator = (Enums.TypeOfCodeGenerator)e.NewValue;
                    break;
                case nameof(rdgTextOptions):
                    myCodeProperty.TextChange = (Enums.TypeOfTextChange)e.NewValue;
                    break;
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e) { DeleteGridViewHandlers(this.grdMain); }


        private void cmdShowCode_Click(object sender, EventArgs e)
        {
            using (frmShowCode locFrmShowCode = new())
            {
                locFrmShowCode.Owner = this;
                locFrmShowCode.SetCode(StartCodeGenerationAndGetBackFileContent());
                locFrmShowCode.ShowDialog();

            }
        }

        private string StartCodeGenerationAndGetBackFileContent()
        {



            Interfaces.ICodeGenerator locCodeGenerator = null;
            if (myCodeProperty.CodeGenerator == Enums.TypeOfCodeGenerator.C)
                locCodeGenerator = new CodeGenerator.CSharp.Factory();
            else
                locCodeGenerator = new CodeGenerator.VisualBasic.Factory();

            locCodeGenerator.GenerateCode(myCodeProperty, myNodePreparation.GetNodes());
            var locReturn = locCodeGenerator.GetCode();
            locCodeGenerator.Dispose();
            return locReturn;


        }

        private void cmdCreateFile_Click(object sender, EventArgs e)
        {
            string locExtension = string.Empty;
            string locFilter = string.Empty;

            switch (myCodeProperty.CodeGenerator)
            {
                case Enums.TypeOfCodeGenerator.C:
                    locFilter = "C# files (*.cs)|*.cs";
                    locExtension = ".cs";
                    break;
                case Enums.TypeOfCodeGenerator.VB:
                    locFilter = "Visual Basic .Net files (*.vb*)|*.vb";
                    locExtension = ".vb";
                    break;
            }

            SaveFileDialog.AddExtension = true;
            SaveFileDialog.Filter = locFilter;
            SaveFileDialog.DefaultExt = locExtension;
            SaveFileDialog.InitialDirectory = OpenFileDialog.InitialDirectory;
            SaveFileDialog.SupportMultiDottedExtensions = false;
            var locAnswer = SaveFileDialog.ShowDialog();
            if (locAnswer == DialogResult.OK)
            {
                var locMemoStream = SaveFileDialog.OpenFile();
                var locStreamWriter = new StreamWriter(locMemoStream);
                locStreamWriter.Write(StartCodeGenerationAndGetBackFileContent());
                locStreamWriter.Flush();
                locMemoStream.Close();
            }


        }
    }
}
