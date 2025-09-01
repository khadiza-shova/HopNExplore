using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
namespace HopNExplore.Areas.Admin.Controllers;


[Area("Admin")]
public class CreatePackageController : Controller
{
    private readonly ILogger<CreatePackageController> _logger;

    public CreatePackageController(ILogger<CreatePackageController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult addSubmitted(TourPackage obj)
    {
        Console.WriteLine(obj.TourName);
        if (ModelState.IsValid) {
            return View();
        }
        else {
            return View();
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
