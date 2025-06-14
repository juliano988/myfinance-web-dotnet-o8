using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet_o8.Models;

public class TransacaoModel
{
  public int? Id { get; set; }
  public string Historico { get; set; }
  public string Tipo { get; set; }
  public DateTime Data { get; set; }
  public int? PlanoContaId { get; set; }
  public IEnumerable<SelectListItem> PlanoConta { get; set; }
  public decimal Valor { get; set; }
}