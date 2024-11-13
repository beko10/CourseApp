using AutoMapper;
using CourseApp.DataAccessLayer.UnitOfWork;
using CourseApp.EntityLayer.Dto.RegistrationDto;
using CourseApp.EntityLayer.Dto.StudentDto;
using CourseApp.EntityLayer.Entity;
using CourseApp.ServiceLayer.Abstract;
using CourseApp.ServiceLayer.Utilities.Constants;
using CourseApp.ServiceLayer.Utilities.Result;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.ServiceLayer.Concrete;

public class StudentManager : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public StudentManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IDataResult<IEnumerable<GetAllStudentDto>>> GetAllAsync(bool track = true)
    {
        var studentList = await _unitOfWork.Students.GetAll(false).ToListAsync();
        var studentListMapping = _mapper.Map<IEnumerable<GetAllStudentDto>>(studentList);
        if (!studentList.Any())
        {
            return new ErrorDataResult<IEnumerable<GetAllStudentDto>>(null, ConstantsMessages.StudentListFailedMessage);
        }
        return new SuccessDataResult<IEnumerable<GetAllStudentDto>>(studentListMapping, ConstantsMessages.StudentListSuccessMessage);
    }

    public async Task<IDataResult<GetByIdStudentDto>> GetByIdAsync(string id, bool track = true)
    {
        var hasStudent = await _unitOfWork.Students.GetByIdAsync(id, false);
        if (hasStudent != null)
        {
            var hasStudentMapping = _mapper.Map<GetByIdStudentDto>(hasStudent);
            return new SuccessDataResult<GetByIdStudentDto>(hasStudentMapping, ConstantsMessages.StudentGetByIdSuccessMessage);

        }

        return new ErrorDataResult<GetByIdStudentDto>(null, ConstantsMessages.StudentGetByIdFailedMessage);
    }

    public async Task<IResult> CreateAsync(CreateStudentDto entity)
    {
        var createdStudent = _mapper.Map<Student>(entity);
        await _unitOfWork.Students.CreateAsync(createdStudent);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.StudentCreateSuccessMessage);
        }

        return new ErrorResult(ConstantsMessages.StudentCreateFailedMessage);
    }

    public async Task<IResult> Remove(DeleteStudentDto entity)
    {
        var deletedStudent = _mapper.Map<Student>(entity);
        _unitOfWork.Students.Remove(deletedStudent);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.StudentDeleteSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.StudentDeleteFailedMessage);
    }

    public async Task<IResult> Update(UpdateStudentDto entity)
    {
        var updatedStudent = _mapper.Map<Student>(entity);
        _unitOfWork.Students.Update(updatedStudent);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.StudentListSuccessMessage);
        }
        return new SuccessResult(ConstantsMessages.StudentUpdateFailedMessage);
    }
}
