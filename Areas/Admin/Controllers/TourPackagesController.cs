using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
using HopNExplore.Data;
namespace HopNExplore.Areas.Admin.Controllers;

[Area("Admin")]
public class TourPackagesController : Controller
{

    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _env;
    public TourPackagesController(ApplicationDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Display()
    {
        var packages = _db.TourPackages.ToList(); // Fetch all tour packages
        return View(packages); // Pass the list to the view
    }


    public IActionResult GetThumbnail(int id)
    {
        var tourPackage = _db.TourPackages.FirstOrDefault(t => t.Id == id);

        if (tourPackage == null || tourPackage.Thumbnail == null)
        {
            return NotFound();
        }

        // Return the byte[] as an image
        return File(tourPackage.Thumbnail, "image/jpg");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
