using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamestown
{
    public partial class Rename : Form
    {
        public string NewName
        {
            get { return newNameBox_.Text; }
            set { newNameBox_.Text = value; }
        }

        public Rename()
        {
            InitializeComponent();
        }

        private void okButton__Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static bool DoRename(ref string name)
        {
            Rename form = new Rename() { NewName = name };
            if(form.ShowDialog() == DialogResult.OK)
            {
                name = form.NewName;
                return true;
            }

            return false;
        }
    }
}
