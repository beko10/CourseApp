using CourseApp.DataAccessLayer.Abstract;
using CourseApp.EntityLayer.Entity;

namespace CourseApp.DataAccessLayer.Concrete;

public class RegistrationRepository : GenericRepository<Registration>, IRegistrationRepository
{
    public RegistrationRepository(AppDbContext context) : base(context)
    {
    }
}
