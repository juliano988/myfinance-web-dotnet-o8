using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_o8.Domain;
using myfinance_web_dotnet_o8.Infraestructure;

namespace myfinance_web_dotnet_o8.Services;

public class TransacaoService(MyFinanceDbContext banco) : ITransacaoService
{

    private readonly MyFinanceDbContext _banco = banco;

    public void Excluir(int id)
    {
        var item = RetornarRegistro(id);
        _banco.Attach(item);
        _banco.Remove(item);
        _banco.SaveChanges();
    }

    public List<Transacao> ListarRegistros()
    {
        var item = _banco.Transacao.Include(x => x.PlanoConta).ToList();
        return item;
    }

    public Transacao RetornarRegistro(int id)
    {
        var item = _banco.Transacao.Where(x => x.Id == id).FirstOrDefault();
        return item;
    }

    public void Salvar(Transacao registro)
    {
        if (registro.Id == null)
        {
            _banco.Transacao.Add(registro);
        }
        else
        {
            _banco.Attach(registro);
            _banco.Entry(registro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        _banco.SaveChanges();
    }
}
