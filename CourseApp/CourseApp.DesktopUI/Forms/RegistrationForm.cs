using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms
{
    public partial class RegistrationForm : BaseForm
    {
       
        public RegistrationForm(ICourseService courseService)
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
        protected override void btnList_Click(object sender, EventArgs e)
        {
            base.btnList_Click(sender, e);
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            base.btnSave_Click(sender, e);
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            base.btnDelete_Click(sender, e);
        }

        protected override void btnUpdate_Click(object sender, EventArgs e)
        {
            base.btnUpdate_Click(sender, e);
        }
    }
}
