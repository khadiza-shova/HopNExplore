using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
using HopNExplore.Data;




namespace HopNExplore.Areas.Admin.Controllers;


[Area("Admin")]
public class CreatePackageController : Controller
{
    // private readonly ILogger<CreatePackageController> _logger;

    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _env;
    public CreatePackageController(ApplicationDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    // public CreatePackageController(ILogger<CreatePackageController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult Index()
    {
        return View();
    }

    // public IActionResult addSubmitted(TourPackage obj, IFormFile Thumbnail)
    // {

    //     Console.WriteLine(obj.TourName);

    //     //Validate the object received
    //     if (ModelState.IsValid)
    //     {
    //         string fileName = null;
    //         if (Thumbnail != null && Thumbnail.Length > 0)
    //         {
    //             var uploads = Path.Combine(_env.WebRootPath, "uploads");
    //             Directory.CreateDirectory(uploads);

    //             fileName = Guid.NewGuid().ToString() + Path.GetExtension(Thumbnail.FileName);
    //             var filePath = Path.Combine(uploads, fileName);

    //             using (var stream = new FileStream(filePath, FileMode.Create))
    //             {
    //                 Thumbnail.CopyTo(stream);
    //             }
    //         }

    //         var tourPackage = new TourPackage
    //         {
    //             TourName = obj.TourName,
    //             Location = obj.Location,
    //             Destination = obj.Destination,
    //             Nights = obj.Nights,
    //             Price = obj.Price,
    //             MaxTravelers = obj.MaxTravelers,
    //             ShortDescription = obj.ShortDescription,
    //             DetailedDescription = obj.DetailedDescription,
    //             Inclusions = obj.Inclusions,
    //             Thumbnail = fileName
    //         };

    //         _db.TourPackages.Add(tourPackage);
    //         _db.SaveChanges();

    //         TempData["success"] = "TourPackage Added Successfully!";
    //         return RedirectToAction("Index");
    //     }

    //     return View("Index", obj);
    // }

    public IActionResult addSubmitted(TourPackage obj, IFormFile? ThumbnailFile)
    {
        foreach (var error in ModelState)
        {
            foreach (var subError in error.Value.Errors)
            {
                Console.WriteLine($"Field: {error.Key}, Error: {subError.ErrorMessage}");
            }
        }

        if (ModelState.IsValid)
        {
            byte[]? imageData = null;

            // ✅ If file is uploaded, convert it to byte[]
            if (ThumbnailFile != null && ThumbnailFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    ThumbnailFile.CopyTo(ms);
                    imageData = ms.ToArray();
                }
            }

            var tourPackage = new TourPackage
            {
                Id=obj.Id,
                TourName = obj.TourName,
                Destination = obj.Destination,
                Days = obj.Days,
                Nights = obj.Nights,
                Price = obj.Price,
                MaxTravelers = obj.MaxTravelers,
                ShortDescription = obj.ShortDescription,
                DetailedDescription = obj.DetailedDescription,
                Inclusions = obj.Inclusions,
                Thumbnail = imageData // ✅ store in DB
            };

            _db.TourPackages.Add(tourPackage);
            _db.SaveChanges();

            TempData["success"] = "TourPackage Added Successfully!";
            return RedirectToAction("Index");
        }

        // If model state is invalid
        return View("Index", obj);
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
