using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CslaGenerator.Design
{
    /// <summary>
    /// A file name editor to be used by the master template.
    /// </summary>
    public class XmlFileNameEditor : FileNameEditor
    {
        public XmlFileNameEditor()
        {
        }

        protected override void InitializeDialog(OpenFileDialog fileDialog)
        {
            fileDialog.Filter = @"CslaGenerator Xml files (*.xml) | *.xml" +
                @"|All Files (*.*) | *.*";
            fileDialog.RestoreDirectory = true;
        }
    }
}