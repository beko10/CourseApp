﻿namespace CourseApp.EntityLayer.Dto.ExamResultDto;

public class UpdateExamResultDto
{
    public string Id { get; set; } = null!;
    public byte Grade { get; set; }
    public string? ExamID { get; set; }
    public string? StudentID { get; set; }
}