namespace danskeND.Domain.Model.Common;

public class Result<T> where T : class
{
    private IEnumerable<T>? ResultModel;
    private Exception Exception;
    private string Message;
    
    public bool Success { get; }
    
    public Result(IEnumerable<T>? resultModel, bool success, Exception exception = null, string message = null)
    {
        Exception = exception;
        Success = success;
        ResultModel = resultModel;
        Message = message;
    }
}