using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Data;
using HopNExplore.Models;

namespace HopNExplore.Controllers;

public class BookingController : Controller
{
    private readonly ApplicationDbContext _db;

    // constructor injection
    public BookingController(ApplicationDbContext db, IWebHostEnvironment env)
    {
        _db = db;
    }

    public ActionResult AddSubmitted(Booking obj)
    {
        Console.WriteLine(obj.Name);

        foreach (var error in ModelState)
        {
            foreach (var subError in error.Value.Errors)
            {
                Console.WriteLine($"Field: {error.Key}, Error: {subError.ErrorMessage}");
            }
        }

        if (ModelState.IsValid)
        {
            var booking = new Booking
            {
                TourPackageId = obj.TourPackageId,
                Name = obj.Name,

                Email = obj.Email,

                Phone = obj.Phone,

                NumberOfTravelers = obj.NumberOfTravelers,

                Address = obj.Address,
                PreferredDates = obj.PreferredDates,
                SpecialRequests = obj.SpecialRequests


            };
            _db.Bookings.Add(booking);
            _db.SaveChanges(); // Saved to database

            //Using TempData for alerts
            TempData["success"] = "Flower Added Successfully!";

            //After saving data redirect to index action of Author
            return RedirectToAction("Index","Home");
        }
        return View(obj);
    }




}