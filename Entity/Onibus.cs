using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viacaoCalango.Domain.Entity
{
    public class Onibus
    {
        public int Id { get; set; }
        public int CapMax { get; set; }
        public int QtdPassageiros { get; set; }
        public string TipoPoltrona { get; set; }
        public string[,] Rota { get; set; }
		public List<Passageiro> Passageiros { get; set; }
      

        public Onibus(int id, int max, int qtd, string tipo, string[,] rota, List<Passageiro> passageiros)
        {
            Id = id;
            CapMax = max;
            QtdPassageiros = qtd;
            TipoPoltrona = tipo;
            Rota = rota;
			Passageiros = passageiros;
        }

        public string BuscaRota(string inicio, string fim, string[,] rota)
        {
            int i = 0;
            int j = 0;
            foreach (var v in rota)
            {
                if (v == inicio)
                {
                    
                    //string r = rota[j, 1];

                    foreach (var y in rota)
                    {
                        if(y == fim)
                        {
                            i++;
                            string r = rota[j, 1];
                            j++;
                            //return v + "-" + y;
                            return "horaSaida: " +r+ " horaChegada: "+rota[i,1];
                        }
                    }

                }
            }

            return "Onibus não encontrado";
        }

        public string LOnibus(string inicio, string fim, int vagas, string[,] rota, int QtdPassageiros, int CapMax)
        {
            string hora = BuscaRota(inicio, fim, rota);
            
            if (hora != null  && CapMax - QtdPassageiros >= vagas)
            {
                string resp = "" + (hora) + " " + "Onibus: " +Id;
                return resp;
            }
            return "Lista vazia - sem rotas no momento";
        }
		
		public int pontoSaida(Onibus onibus, Rota rota, Passageiro passageiro) 
		{
			if(passageiro.LocalFim == rota.Destino) {
				onibus.Passageiros.Remove(passageiro);
				QtdPassageiros = QtdPassageiros-1;
				int vagas = CapMax - QtdPassageiros ;
                return vagas;
            }
			else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (rota.Paradas[i, 0] == passageiro.LocalFim)
                    {
                        onibus.Passageiros.Remove(passageiro);
                        QtdPassageiros = QtdPassageiros - 1;
                        int vagas = CapMax - QtdPassageiros;
                        return vagas;
                    }
                }
			}
			return QtdPassageiros;
		}
    }
}


