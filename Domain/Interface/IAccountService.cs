using Domain.DataTransferObject.Response;   
using Domain.DataTransferObject.Request;

namespace Domain.Interface
{
    public interface IAccountService
    {
        Task<BaseResponse<String>> VerifyUser(String email , String password);
        Task<BaseResponse> RegisterUser(RegisterUserRequest request);
    }
}
 