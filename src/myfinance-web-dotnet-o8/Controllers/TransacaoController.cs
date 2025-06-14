using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet_o8.Domain;
using myfinance_web_dotnet_o8.Infraestructure;
using myfinance_web_dotnet_o8.Models;
using myfinance_web_dotnet_o8.Services;

namespace myfinance_web_dotnet_o8.Controllers;

[Route("[controller]")]
public class TransacaoController(ILogger<TransacaoController> logger, ITransacaoService TransacaoService, IPlanoContaService PlanoContaService) : Controller
{
    private readonly ILogger<TransacaoController> _logger = logger;
    private readonly ITransacaoService _TransacaoService = TransacaoService;
    private readonly IPlanoContaService _PlanoContaService = PlanoContaService;

    [Route("Index")]
    public IActionResult Index()
    {
        ViewBag.Lista = _TransacaoService.ListarRegistros();
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
    public IActionResult Cadastro(TransacaoModel? model, int? id)
    {
        if (id != null && !ModelState.IsValid)
        {
            var registro = _TransacaoService.RetornarRegistro((int)id);

            var transacaoModel = new TransacaoModel()
            {
                Id = registro.Id,
                Historico = registro.Historico,
                Tipo = registro.PlanoConta.Tipo,
                Data = registro.Data,
                Valor = registro.Valor
            };

            return View(transacaoModel);
        }
        else if (model != null && ModelState.IsValid)
        {
            var transacao = new Transacao
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
            };
            _TransacaoService.Salvar(transacao);

            return RedirectToAction("Index");
        }
        else
        {
            var listarPlanoConta = _PlanoContaService.ListarRegistros();
            var planoContaSelectItens = new SelectList(listarPlanoConta, "Id", "Nome");
            var transacaoModel = new TransacaoModel
            {
                PlanoConta = planoContaSelectItens
            };
            return View(transacaoModel);
        }
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _TransacaoService.Excluir(id);
        return RedirectToAction("Index");
    }
}
