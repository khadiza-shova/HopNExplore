using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
namespace HopNExplore.Areas.Admin.Controllers;
using HopNExplore.Data;

[Area("Admin")]
public class AdminController : Controller
{



    private readonly ApplicationDbContext _db;
    public AdminController(ApplicationDbContext db, IWebHostEnvironment env)
    {
        _db = db;
       
    }
    public IActionResult Index()
    {
        int totalTourPackage = _db.TourPackages.Count();
        ViewBag.TotalTourPackages = totalTourPackage;
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
