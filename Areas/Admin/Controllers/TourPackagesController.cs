using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
namespace HopNExplore.Areas.Admin.Controllers;

[Area("Admin")]
public class TourPackagesController : Controller
{
    private readonly ILogger<TourPackagesController> _logger;

    public TourPackagesController(ILogger<TourPackagesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
