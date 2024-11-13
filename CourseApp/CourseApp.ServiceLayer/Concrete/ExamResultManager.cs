using AutoMapper;
using CourseApp.DataAccessLayer.UnitOfWork;
using CourseApp.EntityLayer.Dto.ExamResultDto;
using CourseApp.EntityLayer.Entity;
using CourseApp.ServiceLayer.Abstract;
using CourseApp.ServiceLayer.Utilities.Constants;
using CourseApp.ServiceLayer.Utilities.Result;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CourseApp.ServiceLayer.Concrete;

public class ExamResultManager : IExamResultService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExamResultManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IDataResult<IEnumerable<GetAllExamResultDto>>> GetAllAsync(bool track = true)
    {
        var examResultList = await _unitOfWork.ExamResults.GetAll(false).ToListAsync();
        var examResultListMapping = _mapper.Map<IEnumerable<GetAllExamResultDto>>(examResultList);
        if (!examResultList.Any())
        {
            return new ErrorDataResult<IEnumerable<GetAllExamResultDto>>(null, ConstantsMessages.ExamResultListFailedMessage);
        }
        return new SuccessDataResult<IEnumerable<GetAllExamResultDto>>(examResultListMapping, ConstantsMessages.ExamResultListSuccessMessage);

    }

    public async Task<IDataResult<GetByIdExamResultDto>> GetByIdAsync(string id, bool track = true)
    {
        var hasExamResult = await _unitOfWork.ExamResults.GetByIdAsync(id, false);
        if (hasExamResult != null)
        {
            var examResultMapping = _mapper.Map<GetByIdExamResultDto>(hasExamResult);
            return new SuccessDataResult<GetByIdExamResultDto>(examResultMapping, ConstantsMessages.ExamResultListSuccessMessage);
        }
        return new ErrorDataResult<GetByIdExamResultDto>(null, ConstantsMessages.ExamResultListFailedMessage);
    }

    public async Task<IResult> CreateAsync(CreateExamResultDto entity)
    {
        var addedExamResultMapping = _mapper.Map<ExamResult>(entity);
        await _unitOfWork.ExamResults.CreateAsync(addedExamResultMapping);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.ExamResultCreateSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.ExamResultCreateFailedMessage);
    }

    public async Task<IResult> Remove(DeleteExamResultDto entity)
    {
        var deletedExamResultMapping = _mapper.Map<ExamResult>(entity);
        _unitOfWork.ExamResults.Remove(deletedExamResultMapping);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.ExamResultDeleteSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.ExamResultDeleteFailedMessage);
    }

    public async Task<IResult> Update(UpdateExamResultDto entity)
    {
        var updatedExamResultMapping = _mapper.Map<ExamResult>(entity);
        _unitOfWork.ExamResults.Update(updatedExamResultMapping);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            return new SuccessResult(ConstantsMessages.ExamResultUpdateSuccessMessage);
        }
        return new ErrorResult(ConstantsMessages.ExamResultUpdateFailedMessage);
    }

    public async Task<IDataResult<IEnumerable<GetAllExamResultDetailDto>>> GetAllExamResultDetailAsync(bool track = true)
    {
        var examResultList = await _unitOfWork.ExamResults.GetAllExamResultDetail(false).ToListAsync();
        if (!examResultList.Any())
        {
            return new ErrorDataResult<IEnumerable<GetAllExamResultDetailDto>>(null, ConstantsMessages.ExamResultListFailedMessage);
        }

        var examResultListMapping = _mapper.Map<IEnumerable<GetAllExamResultDetailDto>>(examResultList);
        return new SuccessDataResult<IEnumerable<GetAllExamResultDetailDto>>(examResultListMapping, ConstantsMessages.ExamResultListSuccessMessage);
    }

    public async Task<IDataResult<GetByIdExamResultDetailDto>> GetByIdExamResultDetailAsync(string id, bool track = true)
    {
        var examResult = await _unitOfWork.ExamResults.GetByIdExamResultDetailAsync(id, false);
        if (examResult == null)
        {
            return new ErrorDataResult<GetByIdExamResultDetailDto>(null, ConstantsMessages.ExamResultGetByIdFailedMessage);
        }

        var examResultMapping = _mapper.Map<GetByIdExamResultDetailDto>(examResult);
        return new SuccessDataResult<GetByIdExamResultDetailDto>(examResultMapping, ConstantsMessages.CourseListSuccessMessage);

    }
}
