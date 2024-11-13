using AutoMapper;
using CourseApp.EntityLayer.Dto.CourseDto;
using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms;

public partial class CourseForm : BaseForm
{
    private readonly ICourseService _courseService;
    private readonly IInstructorService _instructorService;
    private readonly IMapper _mapper;
    public CourseForm(ICourseService courseService, IInstructorService instructorService, IMapper mapper)
    {
        InitializeComponent();
        _courseService = courseService;
        _instructorService = instructorService;
        _instructorService = instructorService;
        _mapper = mapper;
    }

    private async void CourseForm_Load(object sender, EventArgs e)
    {
        var instructors = await _instructorService.GetAllAsync();
        cmbInstructor.DataSource = instructors.Data;
        cmbInstructor.DisplayMember = "FullName";
        cmbInstructor.ValueMember = "Id";
    }

    private async Task<string> GetCourseId(string CourseName)
    {
        var courses = await _courseService.GetAllAsync();
        return courses.Data.FirstOrDefault(c => c.CourseName == CourseName)?.Id ?? "-1";
    }

    protected override async void btnList_Click(object sender, EventArgs e)
    {
        var courses = await _courseService.GetAllAsync();
        lstCourseList.Items.Clear();
        if( courses.IsSuccess)
        {
            MessageBox.Show(courses.Message);
            foreach (var course in courses.Data)
            {
               
                lstCourseList.Items.Add(course.CourseName!);
            }
        }
        else
        {
            MessageBox.Show(courses.Message);   
        }
    }

    protected override async void btnSave_Click(object sender, EventArgs e)
    {
        string courseName = txtCourseName.Text;
        DateTime startDate = dtStartDate.Value;
        DateTime endDate = dtEndDate.Value;
        string id = cmbInstructor.SelectedValue.ToString();

        var addedCourse = new CreateCourseDto
        {
            CourseName = courseName,
            StartDate = startDate,
            EndDate = endDate,
            InstructorID = id,
        };

       var result = await _courseService.CreateAsync(addedCourse);

        if(result.IsSuccess)
        {
            MessageBox.Show(result.Message);
        }
        else
        {
            MessageBox.Show(result.Message);
        }
    }

    protected override async void btnDelete_Click(object sender, EventArgs e)
    {
        if(lstCourseList.SelectedItem != null)
        {
            string courseName = (lstCourseList.SelectedItem.ToString())!;
            string courseId = await GetCourseId(courseName);

            var hasDeletedCourse = await _courseService.GetByIdAsync(courseId);

            if(hasDeletedCourse.IsSuccess)
            {
                var deletedCourse = new DeleteCourseDto
                {
                    CourseName = hasDeletedCourse.Data.CourseName,
                    CreatedDate = hasDeletedCourse.Data.CreatedDate,
                    EndDate = hasDeletedCourse.Data.EndDate,
                    IsActive = hasDeletedCourse.Data.IsActive,
                    InstructorID = hasDeletedCourse.Data.InstructorID,
                    StartDate = hasDeletedCourse.Data.StartDate,
                    Id = hasDeletedCourse.Data.Id
                };
                var result = await _courseService.Remove(deletedCourse);
                if(result.IsSuccess)
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
                MessageBox.Show(hasDeletedCourse.Message);  
            }
        }
    }

    protected override void btnUpdate_Click(object sender, EventArgs e)
    {
        base.btnUpdate_Click(sender, e);
    }

    private void txtCourseName_TextChanged(object sender, EventArgs e)
    {

    }
}
