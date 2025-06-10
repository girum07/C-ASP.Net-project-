using Domain.Interface;
using Infrastructure.Constantvalues;
using Domain.DataTransferObject.Response;
using Domain.Entity; // Assuming you have a User entity defined in your domain
using Domain.DataTransferObject.Request;
using Microsoft.AspNetCore.Identity; // Assuming you are using ASP.NET Core Identity for user management

public class AccountService : IAccountService

{
    private readonly SignInManager<User> signInManager; // Inject UserManager for user operations
    public AccountService(SignInManager<User> signInManager)
    {
        this.signInManager = signInManager;
    }
    public async Task<BaseResponse<string>> VerifyUser(string email, string password)
    {
        var user = await signInManager.UserManager.FindByEmailAsync(email);
        if (user == null)
        {
            return new BaseResponse<string>
            {
                IsSuccess = false,
                ErrorMessage = "User not found."
            };
        }
        var result = await signInManager.UserManager.CheckPasswordAsync(user, password);
        if (!result)
        {
            return new BaseResponse<string>
            {
                IsSuccess = false,
                ErrorMessage = "Invalid password."
            };
        }
        return new BaseResponse<string>
        {
            IsSuccess = true,
            Data = user.UserName //
        };
    }
    public async Task<BaseResponse> RegisterUser(RegisterUserRequest request)
    {
        var user = new User
        {
            Email = request.Email,
            UserName = request.Email,
            // Assuming username is the same as email
            // Set other properties as needed
            AccountConfirmed = false, // Assuming you want to set this to false initially
        };
        string Password = Constants.Password;

        var result = await signInManager.UserManager.CreateAsync(user,Password); // Assuming you have a password in the request
        if (!result.Succeeded)
        {
            return new BaseResponse
            {
                IsSuccess = false,
                ErrorMessage = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }
        return new BaseResponse { IsSuccess = true };
    }


}
