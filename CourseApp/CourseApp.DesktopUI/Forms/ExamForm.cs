using CourseApp.DesktopUI.Utilities;
using CourseApp.EntityLayer.Dto.ExamDto;
using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms;

public partial class ExamForm : BaseForm
{
    private readonly IExamService _examService;
    public ExamForm(IExamService examService)
    {
        InitializeComponent();
        _examService = examService;

        lstListe.SelectedIndexChanged += lstListe_SelectedIndexChanged!;
    }

    private void ExamForm_Load(object sender, EventArgs e)
    {

    }

    private async void lstListe_SelectedIndexChanged(object sender, EventArgs e)
    {
        string studentId = lstListe.SelectedValue.ToString();

        var student = await _examService.GetByIdAsync(studentId);

        if (student.IsSuccess)
        {
            txtLessonName.Text = student.Data.Name;
            dtLessonDate.Text = student.Data.Date.ToString("dd.MM.yyyy");
        }
    }

    private async Task LoadExamListAsync()
    {
        var examListResult = await _examService.GetAllAsync();
        if (examListResult.IsSuccess)
        {
            lstListe.DataSource = examListResult.Data;
            lstListe.DisplayMember = "Name";
            lstListe.ValueMember = "Id";
        }
        else
        {
            MessageBox.Show(examListResult.Message);
        }
    }
    protected override async void btnList_Click(object sender, EventArgs e)
    {
        try
        {
            await LoadExamListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception(string.Format(UIMessages.DatabaseFetchError,ex.Message));
        }
    }

    protected override async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            CreateExamDto createExamDto = new()
            {
                Name = txtLessonName.Text,
                Date = DateTime.Parse(dtLessonDate.Text),
            };

            var result = await _examService.CreateAsync(createExamDto);
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

    protected override async void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstListe.SelectedItem != null)
            {
                UpdateExamDto updateExamDto = new()
                {
                    Id = lstListe.SelectedValue.ToString(),
                    Name = txtLessonName.Text,
                    Date = DateTime.Parse(dtLessonDate.Text)
                };

                var result = await _examService.Update(updateExamDto);
                if (result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Güncellenecek sınavı seçin");
            }
        }
        catch (Exception ex)
        {

            throw new Exception(string.Format(UIMessages.OperationFailed,"Güncelleme"));
        }
    }

    protected override async void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstListe.SelectedItem != null)
            {
                DeleteExamDto deleteExamDto = new()
                {
                    Id = lstListe.SelectedValue.ToString(),
                    Name = txtLessonName.Text,
                    Date = DateTime.Parse(dtLessonDate.Text),

                };

                var result = await _examService.Remove(deleteExamDto);
                if (result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek sınavı seçin");
            }
        }
        catch (Exception ex)
        {

            throw new Exception(string.Format(UIMessages.OperationFailed,"Silme"));
        }
    }
}
