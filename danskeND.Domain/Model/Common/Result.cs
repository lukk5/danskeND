namespace danskeND.Domain.Model.Common;

public class Result<T> where T : class
{
    public IEnumerable<T>? ResultModel { get; }
    public Exception Exception { get; }
    public string Message { get; }
    public bool Success { get; }
    
    public Result(IEnumerable<T>? resultModel, bool success, Exception exception = null, string message = null)
    {
        Exception = exception;
        Success = success;
        ResultModel = resultModel;
        Message = message;
    }
}