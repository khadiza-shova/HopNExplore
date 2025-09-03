using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
using HopNExplore.Data;
namespace HopNExplore.Areas.Admin.Controllers;

[Area("Admin")]
public class BookingController : Controller
{
    private readonly ApplicationDbContext _db;

    public BookingController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var bookings = _db.Bookings.ToList();
        return View(bookings);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
