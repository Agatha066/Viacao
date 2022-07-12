using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viacaoCalango.Domain.Entity
{
    public class Reserva
    {
        public int Id { get; set; }
        public int QtdPassageiros { get; set; }
        public string TipoPoltrona { get; set; }
        public DateTime Data { get; set; }
        public DateTimeOffset Hora { get; set; }
    }
}
