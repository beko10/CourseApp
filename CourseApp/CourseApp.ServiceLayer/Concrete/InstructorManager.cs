using AutoMapper;
using CourseApp.DataAccessLayer.UnitOfWork;
using CourseApp.EntityLayer.Dto.InstructorDto;
using CourseApp.EntityLayer.Entity;
using CourseApp.ServiceLayer.Abstract;
using CourseApp.ServiceLayer.Utilities.Constants;
using CourseApp.ServiceLayer.Utilities.Result;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.ServiceLayer.Concrete;

public class InstructorManager : IInstructorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public InstructorManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IDataResult<IEnumerable<GetAllInstructorDto>>> GetAllAsync(bool track = true)
    {
        var instructorList = await _unitOfWork.Instructors.GetAll(false).ToListAsync();
        var instructorListMapping = _mapper.Map<IEnumerable<GetAllInstructorDto>>(instructorList);
        if (!instructorList.Any())
        {
            return new ErrorDataResult<IEnumerable<GetAllInstructorDto>>(null, ConstantsMessages.InstructorListFailedMessage);
        }
        return new SuccessDataResult<IEnumerable<GetAllInstructorDto>>(instructorListMapping, ConstantsMessages.InstructorListSuccessMessage);
    }

    public async Task<IDataResult<GetByIdInstructorDto>> GetByIdAsync(string id, bool track = true)
    {
        var hasInstructor = await _unitOfWork.Instructors.GetByIdAsync(id, false);
        if (hasInstructor != null)
        {
            var hasInstructorMapping = _mapper.Map<GetByIdInstructorDto>(hasInstructor);
            return new SuccessDataResult<GetByIdInstructorDto>(hasInstructorMapping, ConstantsMessages.InstructorGetByIdSuccessMessage);

        }

        return new ErrorDataResult<GetByIdInstructorDto>(null, ConstantsMessages.InstructorGetByIdFailedMessage);
    }

    public async Task<IResult> CreateAsync(CreatedInstructorDto entity)
    {
        var createdInstructor = _mapper.Map<Instructor>(entity);
        await _unitOfWork.Instructors.CreateAsync(createdInstructor);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.InstructorCreateSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.InstructorCreateFailedMessage);
    }

    public async Task<IResult> Remove(DeletedInstructorDto entity)
    {
        var deletedInstructor = _mapper.Map<Instructor>(entity);
        _unitOfWork.Instructors.Remove(deletedInstructor);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.InstructorDeleteSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.InstructorDeleteFailedMessage);
    }

    public async Task<IResult> Update(UpdatedInstructorDto entity)
    {
        var updatedInstructor = _mapper.Map<Instructor>(entity);
        _unitOfWork.Instructors.Update(updatedInstructor);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.InstructorUpdateSuccessMessage);
        }
        return new SuccessResult(ConstantsMessages.InstructorUpdateFailedMessage);
    }
}
