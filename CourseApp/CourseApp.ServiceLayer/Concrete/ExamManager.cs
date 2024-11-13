using AutoMapper;
using CourseApp.DataAccessLayer.UnitOfWork;
using CourseApp.EntityLayer.Dto.ExamDto;
using CourseApp.EntityLayer.Entity;
using CourseApp.ServiceLayer.Abstract;
using CourseApp.ServiceLayer.Utilities.Constants;
using CourseApp.ServiceLayer.Utilities.Result;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.ServiceLayer.Concrete;

public class ExamManager : IExamService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExamManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IDataResult<IEnumerable<GetAllExamDto>>> GetAllAsync(bool track = true)
    {
        var examList = await _unitOfWork.Exams.GetAll(false).ToListAsync();
        var examtListMapping = _mapper.Map<IEnumerable<GetAllExamDto>>(examList);
        if (!examList.Any())
        {
            return new ErrorDataResult<IEnumerable<GetAllExamDto>>(null, ConstantsMessages.ExamListFailedMessage);
        }
        return new SuccessDataResult<IEnumerable<GetAllExamDto>>(examtListMapping, ConstantsMessages.ExamListSuccessMessage);

    }

    public async Task<IDataResult<GetByIdExamDto>> GetByIdAsync(string id, bool track = true)
    {
        var hasExam = await _unitOfWork.Exams.GetByIdAsync(id, false);
        if (hasExam != null)
        {
            var examResultMapping = _mapper.Map<GetByIdExamDto>(hasExam);
            return new SuccessDataResult<GetByIdExamDto>(examResultMapping, ConstantsMessages.ExamGetByIdSuccessMessage);
        }
        return new ErrorDataResult<GetByIdExamDto>(null, ConstantsMessages.ExamGetByIdFailedMessage);
    }
    public async Task<IResult> CreateAsync(CreateExamDto entity)
    {
        var addedExamMapping = _mapper.Map<Exam>(entity);
        await _unitOfWork.Exams.CreateAsync(addedExamMapping);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.ExamCreateSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.ExamCreateFailedMessage);
    }

    public async Task<IResult> Remove(DeleteExamDto entity)
    {
        var deletedExamMapping = _mapper.Map<Exam>(entity);
        _unitOfWork.Exams.Remove(deletedExamMapping);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.ExamDeleteSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.ExamDeleteFailedMessage);
    }

    public async Task<IResult> Update(UpdateExamDto entity)
    {
        var updatedExamMapping = _mapper.Map<Exam>(entity);
        _unitOfWork.Exams.Update(updatedExamMapping);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.ExamUpdateSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.ExamUpdateFailedMessage);
    }
}
