using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseApp.DesktopUI.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            SetStyle();
        }

        private void SetStyle()
        {
            this.BackColor = Color.Thistle;
            this.Font = new Font("Arial", 18, FontStyle.Regular);
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        protected virtual void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnList_Click(object sender, EventArgs e)
        {

        }
    }
}
