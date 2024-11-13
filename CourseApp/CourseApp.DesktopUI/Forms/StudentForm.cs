using AutoMapper;
using CourseApp.DesktopUI.Utilities;
using CourseApp.EntityLayer.Dto.StudentDto;
using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms
{
    public partial class StudentForm : BaseForm
    {

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentForm(IStudentService studentService, IMapper mapper)
        {
            InitializeComponent();
            _studentService = studentService;
            _mapper = mapper;
            lstListe.SelectedIndexChanged += lstListe_SelectedIndexChanged!;
        }

        private async void StudentForm_Load(object sender, EventArgs e)
        {

            var students = await _studentService.GetAllAsync();
            lstListe.DataSource = students.Data;
            lstListe.DisplayMember = "FullName";
            lstListe.ValueMember = "Id";
        }

        private async Task<string> GetStudentId(string Name)
        {
            var students = await _studentService.GetAllAsync(false);
            return students.Data.FirstOrDefault(x => x.Name == Name)?.Id ?? "-1";

        }

        private async void lstListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studentId = (lstListe.SelectedValue!.ToString())!;

            var student = await _studentService.GetByIdAsync(studentId, false);

            if (student.IsSuccess)
            {
                txtAd.Text = student.Data.Name;
                txtSoyad.Text = student.Data.Surname;
                txtTC.Text = student.Data.TC;
                txtDTarihi.Text = student.Data.BirthDate.ToString("dd.MM.yyyy");
            }
        }

        protected override async void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                var studentListResult = await _studentService.GetAllAsync(false);
                if (studentListResult.IsSuccess)
                {
                    MessageBox.Show(studentListResult.Message);
                    lstListe.DataSource = studentListResult.Data;
                    lstListe.DisplayMember = "FullName";
                    lstListe.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show(studentListResult.Message);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format(UIMessages.DatabaseFetchError,ex.Message));
            }
        }

        protected async override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string studentName = txtAd.Text;
                string studentSurname = txtSoyad.Text;
                string studentTC = txtTC.Text;
                DateTime studentBirthDate = DateTime.Parse(txtDTarihi.Text);

                CreateStudentDto createStudentDto = new CreateStudentDto
                {
                    Name = studentName,
                    Surname = studentSurname,
                    TC = studentTC,
                    BirthDate = studentBirthDate
                };

                var result = await _studentService.CreateAsync(createStudentDto);
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

                throw new Exception(string.Format(UIMessages.OperationFailed,"Ekleme"));
            }
        }

        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
           if(lstListe.SelectedItem != null)
            {
                try
                {
                    DeleteStudentDto deleteStudentDto = new()
                    {
                        Id = lstListe.SelectedValue.ToString(),
                        Name = txtAd.Text,
                        BirthDate = DateTime.Parse(txtDTarihi.Text),
                        Surname = txtSoyad.Text,
                        TC = txtTC.Text,
                    };
                    var result = await _studentService.Remove(deleteStudentDto);
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

                    throw new Exception(string.Format(UIMessages.OperationFailed, "Silme"));
                }
            }
           else
            {
                MessageBox.Show(UIMessages.ItemNotSelected, "Öğrenci");
            }
        }

        protected override async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstListe.SelectedItem != null)
            {
                try
                {
                    UpdateStudentDto updateStudentDto = new()
                    {
                        Id = lstListe.SelectedValue.ToString(),
                        Name = txtAd.Text,
                        Surname= txtSoyad.Text,
                        BirthDate = DateTime.Parse(txtDTarihi.Text),
                        TC = txtTC.Text,
                    };

                    var result = await _studentService.Update(updateStudentDto);
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

                    throw new Exception(string.Format(UIMessages.OperationFailed, "Güncelleme"));
                }
            }
            else
            {
                MessageBox.Show(UIMessages.ItemNotSelected,"Öğrenci");
            }
        }
    }
}
