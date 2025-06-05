using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_o8.Infraestructure;
using myfinance_web_dotnet_o8.Models;

namespace myfinance_web_dotnet_o8.Controllers;

public class PlanoContaController(ILogger<PlanoContaController> logger, MyFinanceDbContext banco) : Controller
{
    private readonly ILogger<PlanoContaController> _logger = logger;
    private readonly MyFinanceDbContext _banco = banco;

  public IActionResult Index()
    {
        ViewBag.Lista = _banco.PlanoConta.ToList();
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
