using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_o8.Infraestructure;
using myfinance_web_dotnet_o8.Models;

namespace myfinance_web_dotnet_o8.Controllers;

public class HomeController(ILogger<HomeController> logger, MyFinanceDbContext banco) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

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
