using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_dotnet_o8.Domain;
using myfinance_web_dotnet_o8.Infraestructure;

namespace myfinance_web_dotnet_o8.Services;

public class PlanoContaservice(MyFinanceDbContext banco) : IPlanoContaService
{

    private readonly MyFinanceDbContext _banco = banco;

    public void Excluir(int id)
    {
        var item = _banco.PlanoConta.Where(x => x.Id == id);
        _banco.Attach(item);
        _banco.Remove(item);
        _banco.SaveChanges();
    }

    public List<PlanoConta> ListarRegistros()
    {
        var item = _banco.PlanoConta.ToList();
        return item;
    }

    public PlanoConta RetornarRegistro(int id)
    {
        var item = _banco.PlanoConta.Where(x => x.Id == id).FirstOrDefault();
        return item;
    }

    public void Salvar(PlanoConta registro)
    {
        if (registro.Id == null)
        {
            _banco.PlanoConta.Add(registro);
        }
        else
        {
            _banco.Attach(registro);
            _banco.Entry(registro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        _banco.SaveChanges();
    }
}
