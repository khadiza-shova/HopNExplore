using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HopNExplore.Controllers;

public class RegisterController : Controller
{
    // private readonly ILogger<RegisterController> _logger;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;
    // public RegisterController(ILogger<RegisterController> logger)
    // {
    //     _logger = logger;
    // }
    public RegisterController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> addSubmitted(RegisterModel obj)
    {
        Console.WriteLine($"Username: {obj.UserName}, Email: {obj.Email}, Password: {obj.Password}");


        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                UserName = obj.UserName,
                Email = obj.Email,
            };
            Console.WriteLine(user.Email);

            var result = await userManager.CreateAsync(user, obj.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // 🔎 Show errors in the View
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    Console.WriteLine($"Identity Error: {error.Description}"); // 👈 log in console
                }
                return View(obj);
            }
        }

        // This means your RegisterModel failed validation
        foreach (var state in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine($"ModelState Error: {state.ErrorMessage}");
        }

        return View(obj);
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
