using Azure;
using BookReader.Domain.ViewModel;
using BookReader.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
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
