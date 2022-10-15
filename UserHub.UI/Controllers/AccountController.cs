using Microsoft.AspNetCore.Mvc;
using UserHub.Models.User;
using UserHub.Services.Interfaces;

namespace UserHub.UI.Controllers
{
    public class AccountController : Controller
    {
        IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            this._authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            UserModel user = _authService.ValidateUser(loginViewModel.Email, loginViewModel.Password);
            if (user != null)
            {
                //we can use claim identity here for further login.
                //redirection part as per the our flow.
            }
            return View();
        }

    }
}
