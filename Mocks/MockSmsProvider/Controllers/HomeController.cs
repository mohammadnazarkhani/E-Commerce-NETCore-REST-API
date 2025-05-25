using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Data;
using MockSmsProvider.Models;

namespace MockSmsProvider.Controllers;

/// <summary>
/// MVC controller for handling default home (i.e. {domain}/) and privacy page (at {domain}/privacy)
/// </summary>
public class HomeController(ILogger<HomeController> logger, ApplicationDbContext context) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private ApplicationDbContext _context = context;

    public IActionResult Index()
    {
        return View();
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
