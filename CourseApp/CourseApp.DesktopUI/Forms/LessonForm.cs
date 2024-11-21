using CourseApp.DesktopUI.Utilities;
using CourseApp.EntityLayer.Dto.LessonDto;
using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms
{
    public partial class LessonForm : BaseForm
    {
        private readonly ILessonService _lessonService;
        private readonly ICourseService _courseService;

        public LessonForm(ILessonService lessonService, ICourseService courseService)
        {
            InitializeComponent();
            _lessonService = lessonService;
            _courseService = courseService;
            
        }

        private async void LessonForm_Load(object sender, EventArgs e)
        {
            await CourseDataLoad();
            await LessonDataLoad();
            lstLessonList.SelectedIndexChanged += lstListe_SelectedIndexChanged!;
            btn_DersiKursaAta.Click += new EventHandler(BtnDersiKursaAta_Click!);


        }

        private async Task CourseDataLoad()
        {
            var courseData = await _courseService.GetAllAsync(false);
            cmbCourse.DataSource = courseData.Data;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "Id";
        }

        private async Task LessonDataLoad()
        {
            var lessonData = await _lessonService.GetAllLessonDetailAsync(false);
            lstLessonList.DataSource = lessonData.Data;  
            lstLessonList.DisplayMember = "Title";       
            lstLessonList.ValueMember = "Id";           
        }



        private async void lstListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = lstLessonList.SelectedValue!.ToString()!;
            var lesson = await _lessonService.GetByIdLessonDetailAsync(id, false);
            if (lstLessonList.SelectedItem is not null)
            {
                cmbCourse.DisplayMember = lesson.Data.CourseName!;
                cmbCourse.SelectedValue = lesson.Data.CourseID;
                txtLessonContent.Text = lesson.Data.Content;
                txtLessonName.Text = lesson.Data.Title;
                txtLessonTime.Text = lesson.Data.Time;
                txtLessonDuration.Text = lesson.Data.Duration.ToString();
                dtLessonDate.Text = lesson.Data?.Date.ToString();

            }
        }

        private async void btnDersiKursaAta_Click(object sender, EventArgs e)
        {
            try
            {

                if (lstLessonList.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen bir ders seçiniz.");
                    return;
                }

                if (cmbCourse.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen bir kurs seçiniz.");
                    return;
                }


                string lessonId = lstLessonList.SelectedValue.ToString()!;
                string courseId = cmbCourse.SelectedValue.ToString()!;

                UpdateLessonDto updateLessonDto = new()
                {
                    Id = lessonId,
                    CourseID = courseId,
                    Title = txtLessonName.Text,
                    Date = dtLessonDate.Value,
                    Time = txtLessonTime.Text,
                    Content = txtLessonContent.Text,
                    Duration = byte.Parse(txtLessonDuration.Text)
                };

                
                var result = await _lessonService.Update(updateLessonDto);

                if (result.IsSuccess)
                {
                    MessageBox.Show("Ders kursa başarıyla atandı.");
                    await LessonDataLoad(); 
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }


        protected override async void btnList_Click(object sender, EventArgs e)
        {

            await LessonDataLoad();
        }

        protected override async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CreateLessonDto createLessonDto = new()
                {
                    CourseID = cmbCourse.SelectedValue!.ToString(),
                    Title = txtLessonName.Text,
                    Date = dtLessonDate.Value,
                    Time = txtLessonTime.Text,
                    Content = txtLessonContent.Text,
                    Duration = byte.Parse(txtLessonDuration.Text),
                    

                };
                var result = await _lessonService.CreateAsync(createLessonDto);
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

                throw new Exception(string.Format(UIMessages.OperationFailed, ex.Message));
            }
        }

        protected override async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateLessonDto updateLessonDto = new()
                {
                    Content = txtLessonContent.Text,
                    CourseID = cmbCourse.SelectedValue!.ToString(),
                    Title = txtLessonName.Text,
                    Date = dtLessonDate.Value,
                    Time = txtLessonTime.Text,
                    Duration = byte.Parse(txtLessonDuration.Text),
                    Id = lstLessonList.SelectedValue!.ToString()!
                };
                var result = await _lessonService.Update(updateLessonDto);
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

                throw new Exception(string.Format(UIMessages.OperationFailed, ex.Message));
            }
        }

        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteLessonDto deleteLessonDto = new()
                {
                    Content = txtLessonContent.Text,
                    CourseID = cmbCourse.SelectedValue!.ToString(),
                    Title = txtLessonName.Text,
                    Date = dtLessonDate.Value,
                    Time = txtLessonTime.Text,
                    Duration = byte.Parse(txtLessonDuration.Text),
                    Id = lstLessonList.SelectedValue?.ToString()!
                };
                var result = await _lessonService.Remove(deleteLessonDto);
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

                throw new Exception(string.Format(UIMessages.OperationFailed,ex.Message));
            }
        }


        

    }
}
