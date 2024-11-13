﻿namespace CourseApp.ServiceLayer.Utilities.Result;

public interface IDataResult<T> : IResult
{
    T Data { get; }   
}