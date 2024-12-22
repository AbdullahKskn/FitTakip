using System;

namespace FitTakip.Application.Common;

public class Result
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public Result(bool success, string message, object? data = null)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}
