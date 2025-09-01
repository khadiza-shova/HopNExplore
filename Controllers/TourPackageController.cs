using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HopNExplore.Controllers;

public class TourPackageController : Controller
{
    private readonly IWebHostEnvironment _env;
    // constructor injection
    public TourPackageController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public ActionResult Index()
    {
        return View();
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