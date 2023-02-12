using BookReader.DAL.Interfaces;
using BookReader.Domain.Response;
using BookReader.Domain.ViewModel;
using BookReader.Service.Interfaces;
using System;
using System.Linq;

namespace BookReader.Service.Implementations
{
	public class ProfileService : IProfileInterface
	{
		private readonly IProfileRepository _profileRepository;
		public ProfileService(IProfileRepository profileRepository)
		{
			_profileRepository = profileRepository;
		}

		public async Task<IBaseResponse<ProfileViewModel>> GetProfile(string userLogin)
		{
			var baseResponse = new BaseResponse<ProfileViewModel>();
			try
			{
				var profile = await _profileRepository.GetByLogin(userLogin);
				baseResponse.Description = $"Profile for {userLogin} have been found";
				baseResponse.Data = new ProfileViewModel()
				{
					Age = profile.Age,
					Email = profile.Email,
					Sex = profile.Sex.ToString(),
					//UserName = profile.User.Id.ToString(),
				};
				baseResponse.statusCode = Domain.Enum.StatusCode.ok; 
				return baseResponse;
			}
			catch (Exception ex)
			{
				baseResponse.Description = ex.Message;
				baseResponse.statusCode = Domain.Enum.StatusCode.InternatlServiceError;
				//baseResponse.Data = new ProfileViewModel() { };
				return baseResponse;
			}
		}
	}
}
