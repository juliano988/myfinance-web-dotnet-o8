using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_dotnet_o8.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Historico { get; set; }
        public DateOnly Data { get; set; }
        public double Valor { get; set; }
        public int PlanoContaId { get; set; }
        public PlanoConta PlanoConta { get; set; }
    }
}