using AutoMapper;
using CourseApp.DataAccessLayer.UnitOfWork;
using CourseApp.EntityLayer.Dto.LessonDto;
using CourseApp.EntityLayer.Entity;
using CourseApp.ServiceLayer.Abstract;
using CourseApp.ServiceLayer.Utilities.Constants;
using CourseApp.ServiceLayer.Utilities.Result;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.ServiceLayer.Concrete;

public class LessonsManager : ILessonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LessonsManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IDataResult<IEnumerable<GetAllLessonDto>>> GetAllAsync(bool track = true)
    {
        var lessonList = await _unitOfWork.Lessons.GetAll(false).ToListAsync();
        var lessonListMapping = _mapper.Map<IEnumerable<GetAllLessonDto>>(lessonList);
        if (!lessonList.Any())
        {
            return new ErrorDataResult<IEnumerable<GetAllLessonDto>>(null, ConstantsMessages.LessonListFailedMessage);
        }
        return new SuccessDataResult<IEnumerable<GetAllLessonDto>>(lessonListMapping, ConstantsMessages.LessonListSuccessMessage);
    }

    public async Task<IDataResult<GetByIdLessonDto>> GetByIdAsync(string id, bool track = true)
    {
        var hasLesson = await _unitOfWork.Lessons.GetByIdAsync(id, false);
        if (hasLesson != null)
        {
            var hasLessonMapping = _mapper.Map<GetByIdLessonDto>(hasLesson);
            return new SuccessDataResult<GetByIdLessonDto>(hasLessonMapping, ConstantsMessages.InstructorGetByIdSuccessMessage);

        }

        return new ErrorDataResult<GetByIdLessonDto>(null, ConstantsMessages.InstructorGetByIdFailedMessage);
    }

    public async Task<IResult> CreateAsync(CreateLessonDto entity)
    {
        var createdLesson = _mapper.Map<Lesson>(entity);
        await _unitOfWork.Lessons.CreateAsync(createdLesson);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.LessonCreateSuccessMessage);
        }

        return new ErrorResult(ConstantsMessages.LessonCreateFailedMessage);
    }

    public async Task<IResult> Remove(DeleteLessonDto entity)
    {
        var deletedLesson = _mapper.Map<Lesson>(entity);
        _unitOfWork.Lessons.Remove(deletedLesson);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.LessonDeleteSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.LessonDeleteFailedMessage);
    }

    public async Task<IResult> Update(UpdateLessonDto entity)
    {
        var updatedLesson = _mapper.Map<Lesson>(entity);
        _unitOfWork.Lessons.Update(updatedLesson);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.LessonUpdateSuccessMessage);
        }
        return new SuccessResult(ConstantsMessages.LessonUpdateFailedMessage);
    }
}
