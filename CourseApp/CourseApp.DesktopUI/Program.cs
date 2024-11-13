using CourseApp.DataAccessLayer.Abstract;
using CourseApp.DataAccessLayer.Concrete;
using CourseApp.DataAccessLayer.UnitOfWork;
using CourseApp.DesktopUI.Forms;
using CourseApp.ServiceLayer.Abstract;
using CourseApp.ServiceLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.DesktopUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // DbContext kayd� ve ba�lant� dizesi
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer("Data Source=MS�\\SQLEXPRESS;Initial Catalog=CourseAppDesktopDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")); 

                    // UnitOfWork kayd�
                    services.AddScoped<IUnitOfWork, UnitOfWork>();

                    // AutoMapper kayd�
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                    // Repository kay�tlar�
                    services.AddScoped<ICourseRepository, CourseRepository>(); 
                    services.AddScoped<IExamRepository, ExamRepository>();
                    services.AddScoped<IExamResultRepository, ExamResultRepository>();
                    services.AddScoped<IInstructorRepository, InstructorRepository>(); 
                    services.AddScoped<IRegistrationRepository, RegistrationRepository>();
                    services.AddScoped<IStudentRepository, StudentRepository>();
                    services.AddScoped<ILessonRepository, LessonRepository>();

                    // Service kay�tlar�
                    services.AddScoped<ICourseService, CourseManager>();
                    services.AddScoped<IExamService, ExamManager>();
                    services.AddScoped<IExamResultService, ExamResultManager>();
                    services.AddScoped<IInstructorService, InstructorManager>();
                    services.AddScoped<ILessonService, LessonsManager>();
                    services.AddScoped<IRegistrationService, RegistrationManager>();
                    services.AddScoped<IStudentService, StudentManager>();

                    // Form kay�tlar�
                    services.AddTransient<MainForm>();
                    services.AddTransient<CourseForm>();
                    services.AddTransient<ExamForm>();
                    services.AddTransient<ExamResultForm>();
                    services.AddTransient<InstructorForm>();
                    services.AddTransient<LessonForm>();
                    services.AddTransient<RegistrationForm>();
                    services.AddTransient<StudentForm>();
                });
        }
    }
}
