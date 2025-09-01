using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;
namespace HopNExplore.Areas.Admin.Controllers;


[Area("Admin")]
public class ManageBlogController : Controller
{
    private readonly ILogger<ManageBlogController> _logger;

    public ManageBlogController(ILogger<ManageBlogController> logger)
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
