using CourseApp.DesktopUI.Utilities;
using CourseApp.EntityLayer.Dto.CourseDto;
using CourseApp.EntityLayer.Dto.RegistrationDto;
using CourseApp.ServiceLayer.Abstract;
using Microsoft.VisualBasic;

namespace CourseApp.DesktopUI.Forms
{
    public partial class RegistrationForm : BaseForm
    {
       
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IRegistrationService _registrationService;
        public RegistrationForm(ICourseService courseService, IStudentService studentService, IRegistrationService registrationService)
        {
            InitializeComponent();
            _courseService = courseService;
            _studentService = studentService;
            _registrationService = registrationService;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }


        private async Task StudentDataLoad()
        {
            var studentData = await _studentService.GetAllAsync(false);
            cmbKurs.DataSource = studentData.Data;
            cmbKurs.DisplayMember = "Name";
            cmbKurs.SelectedValue = "Id";
        }

        private async Task CourseDataLoad()
        {
            var courseData = await _courseService.GetAllAsync(false);
            cmbOgrenci.DataSource = courseData.Data;
            cmbOgrenci.DisplayMember = "Name";
            cmbOgrenci.SelectedValue = "Id";    
        }

        private async Task RegistrationDataLoad()
        {
            var registrationData = await _registrationService.GetAllRegistrationDetailAsync(false);
            lstListe.DataSource = registrationData.Data;
            lstListe.DisplayMember = "RegistrationDetail";
            lstListe.SelectedValue = "Id";
            
        }

        protected override async void btnList_Click(object sender, EventArgs e)
        {
            await RegistrationDataLoad();
        }

        private async void lstListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstListe.SelectedItem != null)
            {

            }
        }
        protected override async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CreateRegistrationDto createRegistrationDto = new()
                {
                    Price = decimal.Parse(txtFiyat.Text),
                    CourseID = cmbKurs.SelectedValue!.ToString(),
                    StudentID = cmbOgrenci.SelectedValue!.ToString(),
                    RegistrationDate = DateTime.Now,
                };
                var result = await _registrationService.CreateAsync(createRegistrationDto); 
                if(result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format(UIMessages.OperationFailed,ex.Message));
            }
        }

        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRegistrationDto deleteRegistrationDto = new()
                {
                    Id = lstListe.SelectedValue.ToString(),
                    CourseID = cmbKurs.SelectedValue.ToString(),
                    StudentID = cmbOgrenci.SelectedValue.ToString(),
                };

                var result = await _registrationService.Remove(deleteRegistrationDto);
                if(result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format(UIMessages.OperationFailed,ex.Message));
            }
        }

        protected override void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }
    }
}
