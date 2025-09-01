using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HopNExplore.Models;


namespace HopNExplore.Controllers;
public class ContactController : Controller
{
    public IActionResult Index() => View();
}