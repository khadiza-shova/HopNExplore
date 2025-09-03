using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using HopNExplore.Data;

namespace HopNExplore.Controllers;

public class TourPackageController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _env;
    // constructor injection
    public TourPackageController(ApplicationDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    public ActionResult Index()
    {
        var packages = _db.TourPackages.ToList();
        return View(packages);
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


    public ActionResult Details(int id)
    {
        var singlepackage = _db.TourPackages.FirstOrDefault(t => t.Id == id);
        if (singlepackage == null)
        {
            return NotFound();
        }
        return View(singlepackage);
    }

    public ActionResult Booking(int id)
    {
        var bookingData = _db.TourPackages.FirstOrDefault(t => t.Id == id);
        if (bookingData == null)
        {
            return NotFound();
        }
        return View(bookingData);
    }


    // public ActionResult Index()
    // {
    //     // correct path in ASP.NET Core
    //     string filePath = Path.Combine(_env.ContentRootPath, "JsonData", "tourpackages.json");
    //     // read json file   
    //     string jsonData = System.IO.File.ReadAllText(filePath);

    //     // deserialize JSON
    //     var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
    //     var packages = JsonConvert.DeserializeObject<List<TourPackage>>(jsonObject["tour_packages"].ToString());

    //     return View(packages);


    // }

    // public class PackageWrapper
    // {
    //     public List<TourPackage> package_details { get; set; }
    // }

    // public ActionResult Details(int id)
    // {
    //     // JSON file path
    //     string filePath = Path.Combine(_env.ContentRootPath, "JsonData", "packages_details.json");
    //     string jsonData = System.IO.File.ReadAllText(filePath);

    //     // Deserialize to wrapper
    //     var wrapper = JsonConvert.DeserializeObject<PackageWrapper>(jsonData);

    //     // Find the package
    //     // Find the package
    //     var package = wrapper.package_details.FirstOrDefault(p => p.Id == id);
    //     if (package == null)
    //     {
    //         return NotFound(); // return 404 if id not found
    //     }

    //     return View(package); // send single package to Details.cshtml
    // }

    // public ActionResult Booking(int packageId)
    // {
    //     // JSON file path
    //     string filePath = Path.Combine(_env.ContentRootPath, "JsonData", "packages_details.json");
    //     string jsonData = System.IO.File.ReadAllText(filePath);

    //     // Deserialize to wrapper
    //     var wrapper = JsonConvert.DeserializeObject<PackageWrapper>(jsonData);

    //     // Find the package
    //     // Find the package
    //     var package = wrapper.package_details.FirstOrDefault(p => p.Id == packageId);
    //     if (package == null)
    //     {
    //         return NotFound(); // return 404 if id not found
    //     }

    //     return View(package); // send single package to Details.cshtml
    // }


}