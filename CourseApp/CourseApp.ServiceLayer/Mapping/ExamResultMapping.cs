using AutoMapper;
using CourseApp.EntityLayer.Dto.ExamResultDto;
using CourseApp.EntityLayer.Entity;

namespace CourseApp.ServiceLayer.Mapping;

public class ExamResultMapping:Profile
{
    public ExamResultMapping()
    {
        CreateMap<ExamResult,GetAllExamResultDto>().ReverseMap();
        CreateMap<ExamResult,GetByIdExamResultDto>().ReverseMap();
        CreateMap<ExamResult,CreateExamResultDto>().ReverseMap();
        CreateMap<ExamResult,UpdateExamResultDto>().ReverseMap();
        CreateMap<ExamResult,DeleteExamResultDto>().ReverseMap();
    }
}
