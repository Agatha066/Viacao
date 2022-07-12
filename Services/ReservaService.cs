using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viacaoCalango.Domain.Entity;
using viacaoCalango.Domain.Interfaces.Service;

namespace viacaoCalango.Domain.Services
{
    public class ReservaService : IReservaService
    {
        public string GetOnibusDisponiveis(Onibus bus)
        {
       
            string resp = bus.LOnibus("RJ","RJ",2, bus.Rota, bus.QtdPassageiros, 23);
           
            return resp;
        }
    }
}
