
namespace Domain.DataTransferObject.Response
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
    public class BaseResponse<T> : BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}
