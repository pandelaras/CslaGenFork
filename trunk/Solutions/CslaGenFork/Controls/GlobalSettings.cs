using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using CslaGenerator.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Controls
{
    internal partial class GlobalSettings : DockContent
    {
        #region Fix for form flicker

        // http://www.angryhacker.com/blog/archive/2010/07/21/how-to-get-rid-of-flicker-on-windows-forms-applications.aspx

        int _originalExStyle = -1;
        private bool _enableFormLevelDoubleBuffering = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (_originalExStyle == -1)
                    _originalExStyle = base.CreateParams.ExStyle;
                CreateParams cp = base.CreateParams;
                if (_enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                else
                    cp.ExStyle = _originalExStyle;
                return cp;
            }
        }

        internal void TurnOnFormLevelDoubleBuffering()
        {
            _enableFormLevelDoubleBuffering = true;
        }

        internal void TurnOffFormLevelDoubleBuffering()
        {
            _enableFormLevelDoubleBuffering = false;
            MaximizeBox = true;
        }

        private void GlobalSettings_Shown(object sender, EventArgs e)
        {
            TurnOffFormLevelDoubleBuffering();
        }

        private void GlobalSettings_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
            TurnOnFormLevelDoubleBuffering();
        }

        private void GlobalSettings_ResizeEnd(object sender, EventArgs e)
        {
            TurnOffFormLevelDoubleBuffering();
            ResumeLayout(true);
        }

        #endregion

        #region Fields and properties

        private GeneratorController Controller
        {
            get { return GeneratorController.Current; }
        }

        private static GlobalParameters _globalParams;

        public static GlobalParameters GlobalParams
        {
            get { return _globalParams; }
        }

        #endregion

        #region Constructor

        internal GlobalSettings()
        {
            InitializeComponent();

            FillEncodingComboBox(cboCodeEncoding);
            FillEncodingComboBox(cboSprocEncoding);
        }

        private void FillEncodingComboBox(ComboBox cbo)
        {
            var encodings = Encoding.GetEncodings();
            foreach (var encoding in encodings)
            {
                cbo.Items.Add(encoding.Name);
            }
            cbo.Tag = typeof(string);
        }

        #endregion

        internal void LoadInfo()
        {
            _globalParams = Controller.GlobalParameters.Clone();
            globalParametersBindingSource.DataSource = _globalParams;
        }

        internal void SaveInfo()
        {
            if (_globalParams.Dirty)
                Controller.GlobalParameters = _globalParams.Clone();
            LoadInfo();
        }

        internal void GlobalParamsInitialLoad()
        {
            ImportGlobalParameters(ConfigTools.GlobalXml);
        }

        private void CmdSaveClick(object sender, EventArgs e)
        {
            ExportGlobalParameters(ConfigTools.GlobalXml);
            SaveInfo();
        }

        private void CmdCancelClick(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void CmdExportClick(object sender, EventArgs e)
        {
            using (var fileSave = new OpenFileDialog())
            {
                fileSave.Title = @"Export Global Settings - Select an existing file or type a new file name";
                fileSave.Filter = @"Global Settings files (*.xml) | *.xml";
                fileSave.DefaultExt = "xml";
                fileSave.Multiselect = false;
                fileSave.CheckFileExists = false;
                fileSave.CheckPathExists = true;
                fileSave.AddExtension = true;
                var result = fileSave.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                Application.DoEvents();
                ExportGlobalParameters(fileSave.FileName);
            }
        }

        private void CmdResetToFactoryClick(object sender, EventArgs e)
        {
            ImportGlobalParameters(Application.StartupPath + @"\Global.xml");
            CmdSaveClick(this, EventArgs.Empty);
        }

        private void CmdImportClick(object sender, EventArgs e)
        {
            using (var fileLoad = new OpenFileDialog())
            {
                fileLoad.Title = @"Import project settings - Select an existing file";
                fileLoad.Filter = @"CSLA Gen files (*.xml) | *.xml";
                fileLoad.DefaultExt = "xml";
                fileLoad.CheckFileExists = true;
                fileLoad.CheckPathExists = true;
                fileLoad.Multiselect = false;
                var result = fileLoad.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                Application.DoEvents();
                ImportGlobalParameters(fileLoad.FileName);
            }
        }

        private void ImportGlobalParameters(string filename)
        {
            GlobalParams.DbProviderCollection.Clear();
            var currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GlobalParameters globalParameters;
                using (var fs = File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    var s = new XmlSerializer(typeof(GlobalParameters));
                    globalParameters = (GlobalParameters) s.Deserialize(fs);
                }
                if (globalParameters != null)
                {
                    Controller.GlobalParameters = globalParameters;
                    LoadInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error occurred while trying to import: " + Environment.NewLine + ex.Message,
                    @"Import Error");
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
        }

        internal void ExportGlobalParameters(string fileName)
        {
            var globalParams = _globalParams.Clone();
            FileStream fs = null;
            var tempFile = Path.GetTempPath() + Guid.NewGuid() + ".globalparameters";
            var success = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fs = File.Open(tempFile, FileMode.Create);
                var s = new XmlSerializer(typeof(GlobalParameters));
                s.Serialize(fs, globalParams);
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error occurred while trying to export: " + Environment.NewLine + ex.Message,
                    @"Export Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

            if (success)
            {
                File.Delete(fileName);
                File.Move(tempFile, fileName);
            }
        }

        private void GlobalParametersBindingSourceCurrentItemChanged(object sender, EventArgs e)
        {
            if (IsDirty)
                TabText = @"Global Settings *";
            else
                TabText = @"Global Settings";
        }

        internal bool IsDirty
        {
            // otherwise crashes on open and immediate close
            get
            {
                if (_globalParams != null)
                    return _globalParams.Dirty;

                return false;
            }
        }

        internal bool ForceSaveGlobalSettings()
        {
            if (IsDirty)
            {
                cmdSave.PerformClick();
            }
            return true;
        }

        private void EditDbProvidersClick(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Owner = Controller.MainForm;
                DbProviderTypeEditor.EditValue(form, _globalParams, "DbProviderCollection");
                GlobalParametersBindingSourceCurrentItemChanged(this, EventArgs.Empty);
            }
        }

        #region Manage state

        internal void GetState()
        {
            TabPage mainTabPage = null;
            TabPage subTabPage = null;

            foreach (var control1 in Controls)
            {
                if (control1.GetType() == typeof(TabControl))
                {
                    var mainTabControl = control1 as TabControl;
                    if (mainTabControl != null)
                    {
                        foreach (var subControl1 in mainTabControl.TabPages)
                        {
                            mainTabPage = subControl1 as TabPage;
                            if (mainTabPage != null && (mainTabPage.ContainsFocus || mainTabPage.Visible))
                            {
                                foreach (var control2 in mainTabPage.Controls)
                                {
                                    if (control2.GetType() == typeof(TabControl))
                                    {
                                        var subTabControl = control2 as TabControl;
                                        if (subTabControl != null)
                                        {
                                            foreach (var subControl2 in subTabControl.TabPages)
                                            {
                                                subTabPage = subControl2 as TabPage;
                                                if (subTabPage != null &&
                                                    (subTabPage.ContainsFocus || subTabPage.Visible))
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;
                }
            }

            if (mainTabPage != null)
            {
                GeneratorController.Current.CurrentUnitLayout.GlobalSettingsMainTab = mainTabPage.Name;
                GeneratorController.Current.CurrentUnitLayout.GlobalSettingsMainTabHidden = false;
            }
            else
                GeneratorController.Current.CurrentUnitLayout.GlobalSettingsMainTab = string.Empty;

            if (subTabPage != null)
                GeneratorController.Current.CurrentUnitLayout.GlobalSettingsSubTab = subTabPage.Name;
            else
                GeneratorController.Current.CurrentUnitLayout.GlobalSettingsSubTab = string.Empty;
        }

        internal void SetState()
        {
            foreach (var control1 in Controls)
            {
                if (control1.GetType() == typeof(TabControl))
                {
                    var tabControl1 = control1 as TabControl;
                    if (tabControl1 != null)
                    {
                        ScrollControlIntoView(tabControl1);
                        tabControl1.Visible = true;
                        tabControl1.Focus();
                        for (var index1 = 0; index1 < tabControl1.TabPages.Count; index1++)
                        {
                            var tabPage1 = tabControl1.TabPages[index1];
                            if (tabPage1.Name == GeneratorController.Current.CurrentUnitLayout.GlobalSettingsMainTab)
                            {
                                tabControl1.SelectedIndex = index1;
                                tabPage1.Focus();
                                foreach (var control2 in tabPage1.Controls)
                                {
                                    if (control2.GetType() == typeof(TabControl))
                                    {
                                        var tabControl2 = control2 as TabControl;
                                        if (tabControl2 != null)
                                        {
                                            tabPage1.ScrollControlIntoView(tabControl2);
                                            tabControl2.Visible = true;
                                            tabControl2.Focus();
                                            for (var index2 = 0; index2 < tabControl2.TabPages.Count; index2++)
                                            {
                                                var tabPage2 = tabControl2.TabPages[index2];
                                                if (tabPage2.Name ==
                                                    GeneratorController.Current.CurrentUnitLayout.GlobalSettingsSubTab)
                                                {
                                                    tabControl2.SelectedIndex = index2;
                                                    tabPage2.Focus();
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }

        #endregion
    }
}