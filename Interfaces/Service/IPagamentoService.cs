using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viacaoCalango.Domain.Entity;
using viacaoCalango.Domain.Services;

namespace viacaoCalango.Domain.Interfaces.Service
{
    public interface IPagamentoService 
    {
        public double vendaPassagens(Passageiro passageiro, Onibus onibus, Rota rota);
    }
}
