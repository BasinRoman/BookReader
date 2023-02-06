using Azure;
using BookReader.Domain.ViewModel;
using BookReader.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace BookReader.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
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
            //testing GIT//
        }

        [HttpGet]
        [ActionName("ModalLoginRegister")]
        public ActionResult ModalLoginRegister()
        {
            return PartialView("ModalLoginRegister");
        }

    }
}
