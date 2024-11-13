using CourseApp.DesktopUI.Forms;
using CourseApp.ServiceLayer.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Text;

namespace CourseApp.DesktopUI
{
    public partial class MainForm : Form
    {
        //servisler eklendi
        private readonly IInstructorService _instructorService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IExamService _examService;
        private readonly IExamResultService _examResultService;
        private readonly ILessonService _lessonService;

        //formlar eklendi
        private readonly StudentForm _studentForm;
        private readonly CourseForm _courseForm;
        private readonly ExamForm _examForm;
        private readonly ExamResultForm _examResultForm;
        private readonly LessonForm _lessonForm;
        private readonly InstructorForm _instructorForm;
        private readonly RegistrationForm _registrationForm;

        public MainForm(IInstructorService instructorService, IStudentService studentService, ICourseService courseService, IExamService examService, IExamResultService examResultService, ILessonService lessonService, StudentForm studentForm, IServiceProvider serviceProvider, CourseForm courseForm, ExamForm examForm, ExamResultForm examResultForm, LessonForm lessonForm, InstructorForm instructorForm, RegistrationForm registrationForm)
        {
            InitializeComponent();
            _instructorService = instructorService;
            _studentService = studentService;
            _courseService = courseService;
            _examService = examService;
            _examResultService = examResultService;
            _lessonService = lessonService;


            _studentForm = studentForm;
            _courseForm = courseForm;
            _examForm = examForm;
            _examResultForm = examResultForm;
            _lessonForm = lessonForm;
            _instructorForm = instructorForm;
            _registrationForm = registrationForm;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadCounts(); 
        }

        private async Task LoadCounts()
        {
            // Veritaban�ndan t�m verileri �ek
            var instructors = await _instructorService.GetAllAsync();
            var students = await _studentService.GetAllAsync();
            var courses = await _courseService.GetAllAsync();
            var exams = await _examService.GetAllAsync();
            var examResults = await _examResultService.GetAllAsync();
            var lessons = await _lessonService.GetAllAsync();

            // Null kontrolleri yaparak etiketleri g�ncelle
            lblInstructorCount.Text = "E�itmen Say�s�: " + (instructors?.Data?.Count().ToString() ?? "0");
            lblStudentCount.Text = "��renci Say�s�: " + (students?.Data?.Count().ToString() ?? "0");
            lblCourseCount.Text = "Kurs Say�s�: " + (courses?.Data?.Count().ToString() ?? "0");
            lblExamCount.Text = "S�nav Say�s�: " + (exams?.Data?.Count().ToString() ?? "0");
            lblExamResultCount.Text = "S�nav Sonucu Say�s�: " + (examResults?.Data?.Count().ToString() ?? "0");
            lblLessonCount.Text = "Ders Say�s�: " + (lessons?.Data?.Count().ToString() ?? "0");

        }



        private void ��RENC�KAYIT��LEMLER�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _studentForm.StartPosition = FormStartPosition.CenterScreen;
            _studentForm.Show();
        }

        private void ��renciTan�mlar�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _registrationForm.StartPosition = FormStartPosition.CenterScreen;
            _registrationForm.Show();
        }

        private void kursTan�mlar�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _courseForm.StartPosition = FormStartPosition.CenterScreen;
            _courseForm.Show();
        }

        private void e�itmenTan�mlar�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _instructorForm.StartPosition = FormStartPosition.CenterScreen;
            _instructorForm.Show();
        }

        private void dersTan�mlar�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lessonForm.StartPosition = FormStartPosition.CenterScreen;
            _lessonForm.Show();
        }

        private void s�navTan�mlar�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _examForm.StartPosition = FormStartPosition.CenterScreen;
            _examForm.Show();
        }

        private void s�navSonu�Tan�mlar�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _examResultForm.StartPosition = FormStartPosition.CenterScreen;
            _examResultForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
