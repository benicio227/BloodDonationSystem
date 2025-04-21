namespace BloodDonationSystem.Application.Models;
public class ResultViewModel
{
    public ResultViewModel(bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
        Warnings = new List<string>();
    }

    public bool IsSuccess {  get; private set; }
    public string Message {  get; private set; }

    public List<string> Warnings { get; private set; }
    public static ResultViewModel Success()
    {
        return new ResultViewModel();
    }

    public static ResultViewModel Error(string message)
    {
        return new ResultViewModel(false, message);
    }
}

public class ResultViewModel<T> : ResultViewModel
{
    public ResultViewModel(T? data, bool isSuccess = true, string message = "") : base(isSuccess, message)
    {
        Data = data;
    }
    public T? Data { get; private set; }

    public static ResultViewModel<T> Success(T data)
    {
        return new ResultViewModel<T>(data);
    }

    public static ResultViewModel<T> SuccessWithWarnings(T data, List<string> warnings)
    {
        var result = new ResultViewModel<T>(data);

        result.Warnings.AddRange(warnings);

        return result;
    }

    public static ResultViewModel<T> Error(string message)
    {
        return new ResultViewModel<T>(default, false, message);
    }
}
