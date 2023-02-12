using BookReader.Domain.ViewModel;
using BookReader.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Controllers
{
	public class ProfileController : Controller
	{
		private readonly IProfileInterface profileInterface;
		public ProfileController(IProfileInterface profileInterface)
		{
			this.profileInterface = profileInterface;	
		}
		public async Task<IActionResult> GetProfile() // https://localhost:7138/profile/GetProfile?userName=admin 
        {
			var currentUser = User.Identity.Name;
			var response = await profileInterface.GetProfile(currentUser);
			return View(response.Data);
		}
	}
}
