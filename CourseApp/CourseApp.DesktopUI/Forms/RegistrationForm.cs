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

        private async void RegistrationForm_Load(object sender, EventArgs e)
        {
            await StudentDataLoad();
            await CourseDataLoad();
            await RegistrationDataLoad();
        }


        private async Task StudentDataLoad()
        {
            var studentData = await _studentService.GetAllAsync(false);
            cmbOgrenci.DataSource = studentData.Data;
            cmbOgrenci.DisplayMember = "Name";
            cmbOgrenci.ValueMember = "Id";
        }

        private async Task CourseDataLoad()
        {
            var courseData = await _courseService.GetAllAsync(false);
            cmbKurs.DataSource = courseData.Data;
            cmbKurs.DisplayMember = "CourseName";
            cmbKurs.ValueMember = "Id";    
        }

        private async Task RegistrationDataLoad()
        {
            var registrationData = await _registrationService.GetAllRegistrationDetailAsync(false);
            lstListe.DataSource = registrationData.Data;
            lstListe.DisplayMember = "RegistrationDetail";
            lstListe.ValueMember = "Id";
            
        }

        protected override async void btnList_Click(object sender, EventArgs e)
        {
            await RegistrationDataLoad();
        }

        private async void lstListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string registrationId = lstListe.SelectedValue!.ToString()!;
            var registration = await _registrationService.GetByIdRegistrationDetailAsync(registrationId);
            if(lstListe.SelectedItem != null)
            {
                cmbKurs.DisplayMember = registration.Data.CourseName;
                cmbKurs.ValueMember = registration.Data.CourseID!;

                cmbOgrenci.DisplayMember = registration.Data.StudentName;
                cmbOgrenci.ValueMember = registration.Data.StudentID!;

                txtFiyat.Text = registration.Data.Price.ToString();
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

        protected override async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdatedRegistrationDto updatedRegistrationDto = new()
                {
                    Id = lstListe.SelectedValue!.ToString()!,
                    CourseID = cmbKurs.SelectedValue!.ToString(),
                    StudentID = cmbOgrenci.SelectedValue!.ToString(),
                    Price = decimal.Parse(txtFiyat.Text),
                    RegistrationDate = DateTime.Now,
                };
                
                var result = await _registrationService.Update(updatedRegistrationDto);
                if (result.IsSuccess)
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

                throw new Exception(string.Format(UIMessages.OperationFailed,"Güncelleme"));
            }
        }
    }
}
