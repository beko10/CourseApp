using CourseApp.DataAccessLayer.Abstract;
using CourseApp.EntityLayer.Entity;

namespace CourseApp.DataAccessLayer.Concrete;

public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
{
    public LessonRepository(AppDbContext context) : base(context)
    {
    }
}
