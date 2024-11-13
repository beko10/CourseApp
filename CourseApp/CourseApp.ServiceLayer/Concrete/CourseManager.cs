using CourseApp.DataAccessLayer.UnitOfWork;
using CourseApp.EntityLayer.Dto.CourseDto;
using CourseApp.EntityLayer.Entity;
using CourseApp.ServiceLayer.Abstract;
using CourseApp.ServiceLayer.Utilities.Constants;
using CourseApp.ServiceLayer.Utilities.Result;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.ServiceLayer.Concrete;

public class CourseManager : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IDataResult<IEnumerable<GetAllCourseDto>>> GetAllAsync(bool track = true)
    {
        var courseList = await _unitOfWork.Courses.GetAll(false).ToListAsync();
        var result = courseList.Select(course => new GetAllCourseDto
        {
            CourseName = course.CourseName,
            CreatedDate = course.CreatedDate,
            EndDate = course.EndDate,
            Id = course.ID,
            InstructorID = course.InstructorID,
            IsActive = course.IsActive,
            StartDate = course.StartDate
        });

        return new SuccessDataResult<IEnumerable<GetAllCourseDto>>(result, ConstantsMessages.CourseListSuccessMessage);
    }

    public async Task<IDataResult<GetByIdCourseDto>> GetByIdAsync(string id, bool track = true)
    {
        var hasCourse = await _unitOfWork.Courses.GetByIdAsync(id, false);

        if (hasCourse != null)
        {
            var course = new GetByIdCourseDto
            {
                CourseName = hasCourse.ID,
                CreatedDate = hasCourse.CreatedDate,
                EndDate = hasCourse.EndDate,
                InstructorID = hasCourse.InstructorID,
                IsActive = hasCourse.IsActive,
                StartDate = hasCourse.StartDate,

            };

            return new SuccessDataResult<GetByIdCourseDto>(course, ConstantsMessages.CourseGetByIdSuccessMessage);
        }

        return new ErrorDataResult<GetByIdCourseDto>(null, ConstantsMessages.CourseGetByIdFailedMessage);
    }
    public async Task<IResult> CreateAsync(CreateCourseDto entity)
    {
        var createdCourse = new Course
        {
            CourseName = entity.CourseName,
            CreatedDate = entity.CreatedDate,
            EndDate = entity.EndDate,
            InstructorID = entity.InstructorID,
            IsActive = entity.IsActive,
            StartDate = entity.StartDate,
        };

        await _unitOfWork.Courses.CreateAsync(createdCourse);

        var result = await _unitOfWork.CommitAsync();

        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.CourseCreateSuccessMessage);
        }

        return new ErrorResult(ConstantsMessages.CourseCreateFailedMessage);
    }
    public async Task<IResult> Remove(DeleteCourseDto entity)
    {
        var deletedCourse = new Course
        {
            CourseName = entity.CourseName,
            CreatedDate = entity.CreatedDate,
            EndDate = entity.EndDate,
            InstructorID = entity.InstructorID,
            IsActive = entity.IsActive,
            StartDate = entity.StartDate,
        };
        _unitOfWork.Courses.Remove(deletedCourse);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.CourseDeleteSuccessMessage);
        }

        return new ErrorResult(ConstantsMessages.CourseDeleteFailedMessage);
    }

    public async Task<IResult> Update(UpdateCourseDto entity)
    {
        var updatedCourse = await _unitOfWork.Courses.GetByIdAsync(entity.Id);
        if (updatedCourse == null)
        {
            return new ErrorResult(ConstantsMessages.CourseUpdateFailedMessage);
        }

        updatedCourse.CourseName = entity.CourseName;
        updatedCourse.StartDate = entity.StartDate;
        updatedCourse.EndDate = entity.EndDate;
        updatedCourse.InstructorID = entity.InstructorID;
        updatedCourse.IsActive = entity.IsActive;

        _unitOfWork.Courses.Update(updatedCourse);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.CourseUpdateSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.CourseUpdateFailedMessage);
    }

    public async Task<IDataResult<IEnumerable<GetAllCourseDetailDto>>> GetAllCourseDetail(bool track = true)
    {
        var courseListDetailList = await _unitOfWork.Courses.GetAllCourseDetail(false).ToListAsync();
        if (courseListDetailList != null)
        {
            var courseDetailDtoList  = courseListDetailList.Select(x => new GetAllCourseDetailDto
            {
                CourseName = x.CourseName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                CreatedDate = x.CreatedDate,
                Id = x.ID,
                InstructorID = x.InstructorID,
                InstructorName = x.Instructor.Name,
                IsActive = x.IsActive,
            });

            return new SuccessDataResult<IEnumerable<GetAllCourseDetailDto>>(courseDetailDtoList, ConstantsMessages.CourseDeleteSuccessMessage);
        }
        return new ErrorDataResult<IEnumerable<GetAllCourseDetailDto>>(null,ConstantsMessages.CourseDeleteFailedMessage);
    }
}
