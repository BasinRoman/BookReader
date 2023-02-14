using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReader.DAL.Interfaces;
using BookReader.DAL.Repositories;
using BookReader.Domain.Entity;
using BookReader.Domain.Response;
using BookReader.Service.Interfaces;
using BookReader.Domain.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using BookReader.Domain.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Tracing;
using BookReader.Domain.Enum;

namespace BookReader.Service.Implementations
{
	public class AccountService : IAccountInterface
	{

		private readonly IAccountRepository _userRepository;

		public AccountService(IAccountRepository AccountRepository)
		{
			_userRepository= AccountRepository;
		}

        public Task<IBaseResponse<User>> GetUserByLogin(LoginViewModel LoginViewModel)
        {
            throw new NotImplementedException();
        }

		//CHECK IF LOGIN EXIST IN DB
        public async Task<IBaseResponse<bool>> IfLoginExist(string login)
        {
			var baseResponse = new BaseResponse<bool>();
			try
			{
				var IfLoginExist = await _userRepository.IfLoginExist(login);
				if (IfLoginExist)
				{
					baseResponse.Description = "This login already exist";
					baseResponse.statusCode = StatusCode.ok;
					baseResponse.Data = true;
					return baseResponse;
				}
				baseResponse.statusCode= StatusCode.ok;
				baseResponse.Data = false;
				baseResponse.Description = "This login is not exist in DB";
				return baseResponse;

			}
			catch (Exception ex)
			{
				baseResponse.Description = ex.Message;
				baseResponse.statusCode = StatusCode.InternatlServiceError;
				return baseResponse;
			}
        }

		//LOGIN
		public async Task<IBaseResponse<ClaimsIdentity>> LoginTry(LoginViewModel loginViewModel)
		{
			var baseResponse = new BaseResponse<ClaimsIdentity>();
			var LoginExist = await IfLoginExist(loginViewModel.Login);
            try
			{
				if (!LoginExist.Data)
				{
                    baseResponse.statusCode = StatusCode.InternatlServiceError;
					baseResponse.Description = "Login not found!";
					return baseResponse;
                }
				var loginTry = await _userRepository.LoginTry(loginViewModel);
				if (loginTry != null)
				{
					baseResponse.statusCode = StatusCode.ok;
					baseResponse.Description = "Authentication succeeded";
					var result = Authenticate(loginTry);
					baseResponse.Data = result;
                    return baseResponse;
				}
				baseResponse.statusCode = StatusCode.InternatlServiceError;
				baseResponse.Description = "Wrong password";
				return baseResponse;
			}
			
			catch (Exception ex)
			{
                baseResponse.Description = ex.Message;
                baseResponse.statusCode = StatusCode.InternatlServiceError;
                return baseResponse;
            }
		}


		//REGISTER 
        public async Task<IBaseResponse<ClaimsIdentity>> Register(RegisterViewModel userViewModel)
		{
			var baseResponse = new BaseResponse<ClaimsIdentity>();
			try
			{
				var user_to_create = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Login == userViewModel.Login);
				if (user_to_create != null)
				{
					baseResponse.Description = "User with this name already exist";
					baseResponse.statusCode = Domain.Enum.StatusCode.InternatlServiceError;
					return baseResponse;
				}

				user_to_create = new User()
				{
					Login = userViewModel.Login,
					Password = HashPasswordExtension.HashPassword(userViewModel.Password),
					UserRole = Domain.Enum.UserRole.user,
					UserProfile = new UserProfile()
					{
						Gender = userViewModel.Gender
					}
				
				};
				bool request = await _userRepository.Create(user_to_create);

				if (!request)
				{
					baseResponse.statusCode = Domain.Enum.StatusCode.InternatlServiceError;
					baseResponse.Description = $"A try to create user with login {user_to_create.Login} failed";
					return baseResponse;

				}

				var result = Authenticate(user_to_create);

				baseResponse.Data = result;
				baseResponse.statusCode = Domain.Enum.StatusCode.ok;
				baseResponse.Description = $"A try to create user with login {user_to_create.Login} succesful";
				return baseResponse;

			}
			catch (Exception ex)
			{
				return new BaseResponse<ClaimsIdentity>()
				{
					Description = $"{ex.Message}"
				};
			}
		}

		
	
	private ClaimsIdentity Authenticate(User user)
		{
			var claimsIdentity = new List<Claim>()
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole.ToString())
				
			};
			return new ClaimsIdentity(claimsIdentity, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
		}

    }
}
