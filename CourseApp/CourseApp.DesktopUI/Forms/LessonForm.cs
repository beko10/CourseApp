using CourseApp.EntityLayer.Dto.LessonDto;
using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms
{
    public partial class LessonForm : BaseForm
    {
        private readonly ILessonService _lessonService;
        private readonly ICourseService _courseService;
        private string selectedLessonId;

        public LessonForm(ILessonService lessonService, ICourseService courseService)
        {
            InitializeComponent();
            _lessonService = lessonService;
            _courseService = courseService;
        }

        private async void LessonForm_Load(object sender, EventArgs e)
        {
            await LoadCourses();
        }

        private async Task LoadCourses()
        {
            var courses = await _courseService.GetAllAsync();
            if (courses.IsSuccess && courses.Data != null)
            {
                comboBox1.DataSource = courses.Data;
                comboBox1.DisplayMember = "CourseName";
                comboBox1.ValueMember = "Id";
            }
        }

        protected override async void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || string.IsNullOrWhiteSpace(txtLessonName.Text))
            {
                MessageBox.Show("Lütfen kurs ve ders adını giriniz.");
                return;
            }

            if (!byte.TryParse(txtLessonDuration.Text, out byte duration))
            {
                MessageBox.Show("Lütfen geçerli bir süre giriniz.");
                return;
            }

            CreateLessonDto createLessonDto = new CreateLessonDto
            {
                Title = txtLessonName.Text,
                Date = dtLessonDate.Value,
                Time = txtLessonTime.Text,
                Duration = duration,
                Content = txtLessonContent.Text,
                CourseID = comboBox1.SelectedValue.ToString()
            };

            var result = await _lessonService.CreateAsync(createLessonDto);
            MessageBox.Show(result.Message);
            if (result.IsSuccess)
            {
                ClearForm();
                await LoadLessons();
            }
        }

        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedLessonId))
            {
                MessageBox.Show("Lütfen silinecek dersi seçiniz.");
                return;
            }

            DeleteLessonDto deleteLessonDto = new DeleteLessonDto
            {
                Id = selectedLessonId,
                Title = txtLessonName.Text,
                Date = dtLessonDate.Value,
                Time = txtLessonTime.Text,
                Duration = byte.Parse(txtLessonDuration.Text),
                Content = txtLessonContent.Text,
                CourseID = comboBox1.SelectedValue.ToString()
            };

            var result = await _lessonService.Remove(deleteLessonDto);
            MessageBox.Show(result.Message);
            if (result.IsSuccess)
            {
                ClearForm();
                await LoadLessons();
            }
        }

        protected override async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedLessonId))
            {
                MessageBox.Show("Lütfen güncellenecek dersi seçiniz.");
                return;
            }

            if (!byte.TryParse(txtLessonDuration.Text, out byte duration))
            {
                MessageBox.Show("Lütfen geçerli bir süre giriniz.");
                return;
            }

            UpdateLessonDto updateLessonDto = new UpdateLessonDto
            {
                Id = selectedLessonId,
                Title = txtLessonName.Text,
                Date = dtLessonDate.Value,
                Time = txtLessonTime.Text,
                Duration = duration,
                Content = txtLessonContent.Text,
                CourseID = comboBox1.SelectedValue.ToString()
            };

            var result = await _lessonService.Update(updateLessonDto);
            MessageBox.Show(result.Message);
            if (result.IsSuccess)
            {
                ClearForm();
                await LoadLessons();
            }
        }

        protected override async void btnList_Click(object sender, EventArgs e)
        {
            await LoadLessons();
        }

        private async Task LoadLessons()
        {
            var lessons = await _lessonService.GetAllAsync();
            lstLessonList.Items.Clear();

            if (lessons.IsSuccess && lessons.Data != null)
            {
                foreach (var lesson in lessons.Data)
                {
                    // Kurs adını almak için
                    var course = await _courseService.GetByIdAsync(lesson.CourseID);
                    string courseName = course.IsSuccess && course.Data != null ? course.Data.CourseName : "Bilinmeyen Kurs";

                    lstLessonList.Items.Add($"ID: {lesson.Id} - Kurs: {courseName} - Ders: {lesson.Title} - Tarih: {lesson.Date.ToShortDateString()} - Saat: {lesson.Time} - Süre: {lesson.Duration}dk");
                }
            }
        }

        private void lstListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLessonList.SelectedItem != null)
            {
                string selectedItem = lstLessonList.SelectedItem.ToString();
                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                selectedLessonId = parts[0].Replace("ID:", "").Trim();

                var lessons = _lessonService.GetAllAsync().Result;
                var selectedLesson = lessons.Data?.FirstOrDefault(l => l.Id == selectedLessonId);

                if (selectedLesson != null)
                {
                    comboBox1.SelectedValue = selectedLesson.CourseID;
                    txtLessonName.Text = selectedLesson.Title;
                    dtLessonDate.Value = selectedLesson.Date;
                    txtLessonTime.Text = selectedLesson.Time;
                    txtLessonDuration.Text = selectedLesson.Duration.ToString();
                    txtLessonContent.Text = selectedLesson.Content;
                }
            }
        }

        private void ClearForm()
        {
            comboBox1.SelectedIndex = -1;
            txtLessonName.Text = string.Empty;
            dtLessonDate.Value = DateTime.Now;
            txtLessonTime.Text = string.Empty;
            txtLessonDuration.Text = string.Empty;
            txtLessonContent.Text = string.Empty;
            selectedLessonId = null;
        }

        private void txtLessonDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
