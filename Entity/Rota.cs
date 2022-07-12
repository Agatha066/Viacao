using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viacaoCalango.Domain.Entity
{
    public class Rota : Entity
    {
        public int Id { get; set; }
        public string Trageto { get; set; }
		public string Destino { get; set; }
		public double Km { get; set; }
        public string [,] Paradas { get; set; }
        
        public Rota(int id, string trageto, string destino,string[,] paradas, double km)
        {
            Id = id;
            Trageto = trageto;
			Destino = destino;
            Paradas = paradas;
			Km = km;
        }
    }
}
