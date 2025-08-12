using AutoMapper;
using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Identity;
using eCommerce.Application.Services.Interfaces.Authentication;
using eCommerce.Application.Services.Interfaces.Logging;
using eCommerce.Application.Validations;
using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Interfaces.Authentication;
using FluentValidation;

namespace eCommerce.Application.Services.Authentication
{
    public class AuthenticationService(
        ITokenManagement tokenManagement,
        IUserManagement userManagement,
        IRoleManagement roleManagement,
        IMapper mapper,
        IAppLogger<AuthenticationService> logger,
        IValidator<CreateUser> createUserValidator,
        IValidator<LoginUser> loginUserValidator,
        IValidationService validationService) : IAuthenticationService
    {
        public async Task<ServiceResponse> CreateUser(CreateUser user)
        {
            var validationResult = await validationService.ValidateAsync(user, createUserValidator);
            if (!validationResult.Success) return validationResult;

            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.UserName = user.Email.Split("@")[0];
            mappedModel.PasswordHash = user.Password;

            var result = await userManagement.CreateUser(mappedModel);
            if (!result) return new ServiceResponse { Message = "Email address might be already in use or unknown error occured" };

            var _user = await userManagement.GetUserByEmail(user.Email);
            var users = await userManagement.GetAllUsers();
            bool assignedResult = await roleManagement.AddUserToRole(_user, users!.Count() > 1 ? "User" : "Admin");
            if (!assignedResult)
            {
                int removeUserResult = await userManagement.RemoveUserByEmail(user.Email);
                if (removeUserResult <= 0)
                {
                    logger.LogError(new Exception($"User with Email as {_user.Email} failed to be removed as a result of role assigning issue"), "User could not be assigned a role");
                    return new ServiceResponse { Message = "Error occured while creating account" };
                }
            }
            return new ServiceResponse { Success = true, Message = "Account Created" };
        }

        public async Task<LoginResponse> LoginUser(LoginUser user)
        {
            var validationResult = await validationService.ValidateAsync(user, loginUserValidator);
            if (!validationResult.Success)
                return new LoginResponse(Message: validationResult.Message);

            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.PasswordHash = user.Password;

            bool loginResult = await userManagement.LoginUser(mappedModel);
            if (!loginResult)
                return new LoginResponse(Message: "Email not found or invalid credentials");

            var _user = await userManagement.GetUserByEmail(user.Email);
            var claims = await userManagement.GetUserClaims(_user!.Email!);

            string jwtToken = tokenManagement.GenerateToken(claims);
            string refreshToken = tokenManagement.GetRefreshToken();

            int saveTokenResult = 0;
            bool userTokencheck = await tokenManagement.ValidateRefreshTokenById(_user.Id);
            if (userTokencheck)
                saveTokenResult = await tokenManagement.UpdateRefreshToken(_user.Id, refreshToken);
            else
                saveTokenResult = await tokenManagement.AddRefreshToken(_user.Id, refreshToken);

            return saveTokenResult <= 0 ? new LoginResponse(Message: "Internal error occured while authenticating") : new LoginResponse(Success: true, Token: jwtToken, RefreshToken: refreshToken);
        }

        public async Task<LoginResponse> RefreshToken(string refreshToken)
        {
            bool validateTokenResult = await tokenManagement.ValidateRefreshToken(refreshToken);
            if (!validateTokenResult) return new LoginResponse(Message: "Invalid Token");

            string userId = await tokenManagement.GetUserIdByRefreshToken(refreshToken);
            var user = await userManagement.GetUserById(userId);
            var claims = await userManagement.GetUserClaims(user!.Email!);
            string newJWTToken = tokenManagement.GenerateToken(claims);
            string newRefreshToken = tokenManagement.GetRefreshToken();
            await tokenManagement.UpdateRefreshToken(userId, newRefreshToken);
            return new LoginResponse(Success: true, Token: newJWTToken, RefreshToken: newRefreshToken);
        }
    }
}
