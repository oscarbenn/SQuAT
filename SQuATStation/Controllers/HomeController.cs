using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQuATStation.Data;
using SQuATStation.Models;

namespace SQuATStation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SQuATStationContext _context;

    public HomeController(ILogger<HomeController> logger, SQuATStationContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return _context.TestCase != null ? 
            View(await _context.TestCase.ToListAsync()) :
            Problem("Entity set 'SQuATStationContext.TestCase'  is null.");
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
