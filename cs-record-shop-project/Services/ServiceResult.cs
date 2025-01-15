namespace cs_record_shop_project.Services;

public class ServiceResult<T>
{
    public ServiceResult(bool isSuccess, T? data = default, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }

    public static ServiceResult<T> Success(T? data) => new ServiceResult<T>(true, data);
    public static ServiceResult<T> Error(string errorMessage) => new ServiceResult<T>(false, default, errorMessage);
}
