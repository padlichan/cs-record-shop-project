namespace cs_record_shop_project.Services;

public class ServiceResult<T>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public string? ErrorMessage { get; }

    private ServiceResult(bool isSuccess, T? data, string? errorMessage = null)
    {
        if (isSuccess && data == null && errorMessage == null) Data = default; 
        
        else if (isSuccess && data == null)
        {
            throw new InvalidOperationException("Data cannot be null when operation is successful.");
        }

        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
    }

    // Static factory methods
    public static ServiceResult<T> Success(T data) => new ServiceResult<T>(true, data);
    public static ServiceResult<T> SuccessNoData() => new ServiceResult<T>(true, default); 
    public static ServiceResult<T> Error(string errorMessage) => new ServiceResult<T>(false, default, errorMessage);
}