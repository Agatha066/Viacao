using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viacaoCalango.Domain.Interfaces.Service;

namespace viacaoCalango.Domain.Entity
{
	public class Pagamento
	{
		public Pagamento(IPagamentoService @object)
		{
			Object = @object;
		}

		public int IdPassageiro { get; set; }
		public double Valor { get; set; }
		public DateTime Data { get; set; }
		public IPagamentoService Object { get; }


		public Pagamento(int id, double valor, DateTime data)
		{
			IdPassageiro = id;
			Valor = valor;
			Data = data;
		}

		public double vendaPassagens(Pagamento pagamento, Passageiro passageiro, Onibus onibus, Rota rota)
		{
			if (onibus.QtdPassageiros < onibus.CapMax)
			{
				return Calculo(pagamento, passageiro, rota);
			}
            return 0;
		}
		
		public double Calculo(Pagamento pagamento, Passageiro passageiro, Rota rota)
        {
			if (passageiro.TipoPoltrona == "Executivo")
			{
				return pagamento.Valor *= 1.1;
			}
			if (passageiro.TipoPoltrona == "Leito")
			{
				return pagamento.Valor = rota.Km * 0.8;
			}
			if (passageiro.TipoPoltrona == "semiLeito")
			{
				return pagamento.Valor = rota.Km * 0.75;
			}
			return -1;
		}
	}
}
