using System.Net;

namespace Backend.Class.Records;

public enum ReturnStatus
{
    Success,
    BadRequest,
    NotFound,
}

public record ApiStatus
{
    public ApiStatus()
    {
    }

    public ApiStatus(ReturnStatus Status, string? Message = null)
    {
        this.Status = Status;
        this.Message = Message;
    }

    public ReturnStatus Status { get; set; }
    public string? Message { get; set; }
}