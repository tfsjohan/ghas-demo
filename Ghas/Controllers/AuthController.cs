using Microsoft.AspNetCore.Mvc;

namespace Ghas.Controllers;

public class AuthController : Controller
{
    public ActionResult Login(string username, string password, string returnUrl)
    {
        if (IsAuthenticated(username, password))
        {
            return Redirect(returnUrl);
        }

        // ReSharper disable once Mvc.ViewNotResolved
        return View("Login");
    }

    private bool IsAuthenticated(string username, string password)
    {
        // Assume authentication logic here
        return true;
    }
}