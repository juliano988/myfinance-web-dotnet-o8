using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_o8.Domain;
using myfinance_web_dotnet_o8.Infraestructure;
using myfinance_web_dotnet_o8.Models;
using myfinance_web_dotnet_o8.Services;

namespace myfinance_web_dotnet_o8.Controllers;

[Route("[controller]")]
public class PlanoContaController(ILogger<PlanoContaController> logger, IPlanoContaService PlanoContaService) : Controller
{
    private readonly ILogger<PlanoContaController> _logger = logger;
    private readonly IPlanoContaService _PlanoContaService = PlanoContaService;

    [Route("Index")]
    public IActionResult Index()
    {
        ViewBag.Lista = _PlanoContaService.ListarRegistros();
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

    [HttpPost]
    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id?}")]
    public IActionResult Cadastro(PlanoContaModel? model, int? id)
    {
        if (id != null && !ModelState.IsValid)
        {
            var registro = _PlanoContaService.RetornarRegistro((int)id);

            var planoContaModel = new PlanoContaModel()
            {
                Id = registro.Id,
                Nome = registro.Nome,
                Tipo = registro.Tipo
            };

            return View(planoContaModel);
        }
        else if (model != null && ModelState.IsValid)
        {
            var planoConta = new PlanoConta
            {
                Id = model.Id,
                Nome = model.Nome,
                Tipo = model.Tipo
            };
            _PlanoContaService.Salvar(planoConta);

            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _PlanoContaService.Excluir(id);
        return RedirectToAction("Index");
    }
}
