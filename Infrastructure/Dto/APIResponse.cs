namespace IRibeiroAPI.Infrastructure.Dto;

public class APIResponse<T>
{
    public string Message { get; set; } = string.Empty;
    public List<T> Data { get; set; }
    public int Status { get; set; }

    public void setResponse(List<T> data, int status) 
    {
        Data = data;
        Status = status;
    }

    public void setResponse(T data, int status)
    {
        Data = new List<T>{ data };
        Status = status;
    }

    public void setResponse(string message, int status) 
    {
        Message = message;
        Status = status;
    }
}
