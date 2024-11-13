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
            // Veritabanýndan tüm verileri çek
            var instructors = await _instructorService.GetAllAsync();
            var students = await _studentService.GetAllAsync();
            var courses = await _courseService.GetAllAsync();
            var exams = await _examService.GetAllAsync();
            var examResults = await _examResultService.GetAllAsync();
            var lessons = await _lessonService.GetAllAsync();

            // Null kontrolleri yaparak etiketleri güncelle
            lblInstructorCount.Text = "Eðitmen Sayýsý: " + (instructors?.Data?.Count().ToString() ?? "0");
            lblStudentCount.Text = "Öðrenci Sayýsý: " + (students?.Data?.Count().ToString() ?? "0");
            lblCourseCount.Text = "Kurs Sayýsý: " + (courses?.Data?.Count().ToString() ?? "0");
            lblExamCount.Text = "Sýnav Sayýsý: " + (exams?.Data?.Count().ToString() ?? "0");
            lblExamResultCount.Text = "Sýnav Sonucu Sayýsý: " + (examResults?.Data?.Count().ToString() ?? "0");
            lblLessonCount.Text = "Ders Sayýsý: " + (lessons?.Data?.Count().ToString() ?? "0");

        }



        private void öÐRENCÝKAYITÝÞLEMLERÝToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _studentForm.StartPosition = FormStartPosition.CenterScreen;
            _studentForm.Show();
        }

        private void öðrenciTanýmlarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _registrationForm.StartPosition = FormStartPosition.CenterScreen;
            _registrationForm.Show();
        }

        private void kursTanýmlarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _courseForm.StartPosition = FormStartPosition.CenterScreen;
            _courseForm.Show();
        }

        private void eðitmenTanýmlarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _instructorForm.StartPosition = FormStartPosition.CenterScreen;
            _instructorForm.Show();
        }

        private void dersTanýmlarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lessonForm.StartPosition = FormStartPosition.CenterScreen;
            _lessonForm.Show();
        }

        private void sýnavTanýmlarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _examForm.StartPosition = FormStartPosition.CenterScreen;
            _examForm.Show();
        }

        private void sýnavSonuçTanýmlarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _examResultForm.StartPosition = FormStartPosition.CenterScreen;
            _examResultForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
