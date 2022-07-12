using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viacaoCalango.Domain.Entity;
using viacaoCalango.Domain.Services;

namespace viacaoCalango.Domain.Interfaces.Service
{
    public interface IOnibusService 
    {
        public string BuscaRota(string inicio, string fim);
        public string BuscaOnibus(string inicio, string fim, int vagas);
        public int pontoSaida(Onibus onibus, Rota rota, Passageiro passageiro);
		
    }
}
