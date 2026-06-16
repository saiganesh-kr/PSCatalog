using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClassRegistration.Models;

namespace ClassRegistration.Controllers;

public class HomeController : Controller
{
    private ClassContext context { get; set; }

    public HomeController(ClassContext ctx) => context = ctx;

    public IActionResult Index()
    {
        var classes = context.GSUClasses.OrderBy(c => c.Name).ToList();
        return View(classes);
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
