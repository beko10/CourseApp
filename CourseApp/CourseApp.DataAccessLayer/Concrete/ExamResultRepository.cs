using CourseApp.DataAccessLayer.Abstract;
using CourseApp.EntityLayer.Entity;

namespace CourseApp.DataAccessLayer.Concrete;

public class ExamResultRepository : GenericRepository<ExamResult>, IExamResultRepository
{
    public ExamResultRepository(AppDbContext context) : base(context)
    {
    }
}
