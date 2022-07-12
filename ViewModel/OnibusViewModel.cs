using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viacaoCalango.Application.ViewModel
{
    public class OnibusViewModel
    {
        public int Id { get; set; }
        public int IdOnibus { get; set; }
        public int CapacidadeMax { get; set; }
        public string TipoPoltrona { get; set; }
        public double Valor { get; set; }
        public string Local { get; set; }
        public DateTimeOffset Hora { get; set; }

        public OnibusViewModel(int id, int onibus, int qtd, string classif, double valor, string local, DateTimeOffset hora)
        {
            this.Id = id;
            this.IdOnibus = onibus;
            this.CapacidadeMax = qtd;
            this.TipoPoltrona = classif;
            this.Valor = valor;
            this.Local = local;
            this.Hora = hora;
        }

    }
}
