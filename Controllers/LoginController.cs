using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HopNExplore.Controllers;


public class LoginController : Controller
{
    // private readonly ILogger<LoginController> _logger;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;


    // public LoginController(ILogger<LoginController> logger)
    // {
    //     _logger = logger;
    // }

    public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> AddSubmitted(LoginModel obj)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"Username: '{obj.Email}', Password: '{obj.Password}'");
            var user = await userManager.FindByEmailAsync(obj.Email);

            if (user == null)
            {
                Console.WriteLine("Username", user);
                ModelState.AddModelError("", "Email or password is incorrect.");
                return View(obj);
            }

            var result = await signInManager.PasswordSignInAsync(
                user.UserName,   // use the actual UserName
        obj.Password,
        isPersistent: false,
        lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Email or password is incorrect.");
                return View(obj);
            }
        }
        return View(obj);

    }


    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Login");
        
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
