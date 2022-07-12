using System;
using System.Collections.Generic;
using viacaoCalango.Application.Interface;
using viacaoCalango.Application.ViewModel;
using viacaoCalango.Domain.Entity;

namespace viacaoCalango.Application
{
    public class ReservaAppService : IReservaAppService
    {
       
        public ReservaAppService()
        {
          
        }

        public List<string> GetOnibusDisponiveis(Onibus consulta)
        {
            string onibus = consulta.LOnibus("RJ", "SP", 2, consulta.Rota, consulta.QtdPassageiros, 23);

            List<string> lstonibus = new List<string>();
            lstonibus.Add(onibus);

            return lstonibus;
        }
    }
}
