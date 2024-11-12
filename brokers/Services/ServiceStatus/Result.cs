namespace ConsoleApp1.Services;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; } // e.g., 200, 400, 500
    public string Message { get; set; }
    public T Data { get; set; }

    public static Result<T> Success(T data, string message = null)
    {
        return new Result<T>
        {
            IsSuccess = true,
            StatusCode = 200,
            Message = message,
            Data = data
        };
    }

    public static Result<T> Failure(int statusCode, string message)
    {
        return new Result<T>
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Message = message,
            Data = default
        };
    }
}

public class Result
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; } // e.g., 200, 400, 500
    public string Message { get; set; }

    public static Result Success(string message = null)
    {
        return new Result
        {
            IsSuccess = true,
            StatusCode = 200,
            Message = message
        };
    }

    public static Result Failure(int statusCode, string message)
    {
        return new Result
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Message = message
        };
    }
}


