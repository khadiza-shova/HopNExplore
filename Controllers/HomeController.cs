using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
namespace HopNExplore.Controllers;

using HopNExplore.Data;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _env;
    // constructor injection
    public HomeController(ApplicationDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }
    public IActionResult Index()
    {

        var packages = _db.TourPackages.Take(6).ToList();
        return View(packages);
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
