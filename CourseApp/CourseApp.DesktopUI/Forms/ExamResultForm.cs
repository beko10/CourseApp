using CourseApp.DesktopUI.Utilities;
using CourseApp.EntityLayer.Dto.ExamResultDto;
using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms
{
    public partial class ExamResultForm : BaseForm
    {
        private readonly IExamResultService _examResultService;
        private readonly IExamService _examService;
        private readonly IStudentService _studentService;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public ExamResultForm(IExamResultService examResultService, IExamService examService, IStudentService studentService)
        {
            InitializeComponent();
            _examResultService = examResultService;
            _examService = examService;
            _studentService = studentService;


        }

        private async void ExamResultForm_Load(object sender, EventArgs e)
        {
            await LoadStudent();
            await LoadExam();
            await LoadExamResult();
            lstListe.SelectedIndexChanged += lstListe_SelectedIndexChanged;
        }

        private async Task LoadStudent()
        {
            var studentListResult = await _studentService.GetAllAsync(false);

            cmbOgrenci.DataSource = studentListResult.Data;
            cmbOgrenci.DisplayMember = "Fullname";
            cmbOgrenci.ValueMember = "Id";

        }

        private async Task LoadExam()
        {
            var examListResult = await _examService.GetAllAsync(false);

            cmbSinav.DataSource = examListResult.Data;
            cmbSinav.DisplayMember = "Name";
            cmbSinav.ValueMember = "Id";

         

        }

        private async Task LoadExamResult()
        {
            var examResultList = await _examResultService.GetAllExamResultDetailAsync(false);

            lstListe.DataSource = examResultList.Data;
            lstListe.DisplayMember = "StudentFullName";
            lstListe.ValueMember = "Id";

            lstListe.Format += (sender, eventArgs) =>
            {
                if (eventArgs.ListItem != null)
                {
                    var item = (GetAllExamResultDetailDto)eventArgs.ListItem;
                    eventArgs.Value = $"{item.StudentFullName} - Not: {item.Grade}";
                }
            };

        }

        private void lstListRefresh(object sender, EventArgs e)
        {
            lstListe.Refresh();
        }

        private async void lstListe_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstListe.SelectedItem != null)
            {
                string examResultId = lstListe.SelectedValue.ToString();

                var examResult = await _examResultService.GetByIdExamResultDetailAsync(examResultId);

                if (examResult.IsSuccess)
                {
                    cmbOgrenci.DisplayMember = examResult.Data.StudentFullName;
                    cmbOgrenci.SelectedValue = examResult.Data.StudentID;

                    cmbSinav.DisplayMember = examResult.Data.ExamName;
                    cmbSinav.SelectedValue = examResult.Data.ExamID;

                    txtNot.Text = examResult.Data.Grade.ToString();
                }
            }

        }

        protected override async void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadExamResult();
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format(UIMessages.DatabaseFetchError, ex.Message));
            }
        }

        protected override async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CreateExamResultDto createExamResultDto = new()
                {
                    ExamID = cmbSinav.SelectedValue!.ToString(),
                    StudentID = cmbOgrenci.SelectedValue!.ToString(),
                    Grade = byte.Parse(txtNot.Text),
                };

                var result = await _examResultService.CreateAsync(createExamResultDto);

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

                throw new Exception(string.Format(UIMessages.OperationFailed, "Ekleme"));
            }
        }

        protected override async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateExamResultDto updateExamResultDto = new()
                {
                    Id = lstListe.SelectedValue.ToString(),
                    ExamID = cmbSinav.SelectedValue.ToString(),
                    StudentID = cmbOgrenci.SelectedValue.ToString(),
                    Grade = byte.Parse(txtNot.Text),
                };

                var result = await _examResultService.Update(updateExamResultDto);
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

        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteExamResultDto deleteExamResultDto = new()
                {

                    Id = lstListe.SelectedValue.ToString(),
                    ExamID = cmbSinav.SelectedValue.ToString(),
                    StudentID = cmbOgrenci.SelectedValue.ToString(),
                    Grade = byte.Parse(txtNot.Text),
                };

                var result = await _examResultService.Remove(deleteExamResultDto);
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
