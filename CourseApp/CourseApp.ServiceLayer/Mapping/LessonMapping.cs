using AutoMapper;
using CourseApp.EntityLayer.Dto.InstructorDto;
using CourseApp.EntityLayer.Dto.LessonDto;
using CourseApp.EntityLayer.Entity;

namespace CourseApp.ServiceLayer.Mapping;

public class LessonMapping:Profile
{
    public LessonMapping()
    {
        CreateMap<Lesson, GetAllLessonDto>().ReverseMap();
        CreateMap<Instructor, GetByIdLessonDto>().ReverseMap();
        CreateMap<Instructor, CreateLessonDto>().ReverseMap();
        CreateMap<Instructor, DeleteLessonDto>().ReverseMap();
        CreateMap<Instructor, UpdateLessonDto>().ReverseMap();
    }
}
