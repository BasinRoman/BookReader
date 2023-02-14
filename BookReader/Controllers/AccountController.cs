using Azure;
using BookReader.Domain.ViewModel;
using BookReader.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace BookReader.Controllers
{ //test git
    public class AccountController : Controller
    {
        private readonly IAccountInterface accountService;
        public AccountController(IAccountInterface _accountService)
        {
            accountService = _accountService;
        }

        [HttpGet]
        public async Task<IActionResult> LoginTry(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await accountService.LoginTry(model);
                if (response.statusCode == Domain.Enum.StatusCode.ok)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));
                    return RedirectToAction("Index", "Home");
                }
				TempData["Error"] = response.Description;
			}
            
            return PartialView("ModalLoginRegister");
        }

        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> IfLoginExist(string input_login)
        {
            var response = await accountService.IfLoginExist(input_login);
            if (response.statusCode == Domain.Enum.StatusCode.ok)
            {
                return Json(response);
            }
            return BadRequest(response.Description);
        }
        

        [HttpGet]
        public ActionResult CreateNewUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resposne = await accountService.Register(model);
                if (resposne.statusCode == Domain.Enum.StatusCode.ok)
                {
                    return View(model);
                }
                ModelState.Clear();
                return PartialView("_RegisterBody");
            }
            return PartialView("_RegisterBody", model);
        }

        [HttpGet]
        [ActionName("ModalLoginRegister")]
        public ActionResult ModalLoginRegister()
        {
            return PartialView("ModalLoginRegister");
        }

        //Profile section starts here//
        public ActionResult ProfileInfo(string login)
        {

            return View();
        }


        
        //Profile section ends here//
	}
}
