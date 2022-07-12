using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viacaoCalango.Domain.Entity;

namespace viacaoCalango.Application.ViewModel
{
    public class ConsultaRotasViewModel
    {
        private Onibus bus;

        public string LocalInicio { get; set; }

        public string LocalFinal { get; set; }

        public int Vagas { get; set; }

        public List<Onibus> Onibus { get; set; }
		
        public string[,] lRota { get; set; }
		
        public ConsultaRotasViewModel(string inicio, string fim, int vagas, List<Onibus> lOnibus, string[,] Rota)
        {
            LocalInicio = inicio;
            LocalFinal = fim;
            Vagas = vagas;
            Onibus = lOnibus;
            lRota = Rota;
        }

        public ConsultaRotasViewModel(Onibus bus)
        {
            this.bus = bus;
        }
    }
}
