using Moq;
using System;
using System.Collections.Generic;
using viacaoCalango.Application;
using viacaoCalango.Application.ViewModel;
using viacaoCalango.Domain.Entity;
using viacaoCalango.Domain.Interfaces.Service;
using Xunit;

namespace testeViacao
{
    public class ReservaTeste
    {
        [Fact]
        public void OnibusDisponiveis()
        {
            string[,] rota1 = new string[4, 2];
            rota1[0, 0] = "ES";
            rota1[0, 1] = "6:00h";
            rota1[1, 0] = "BA";
            rota1[1, 1] = "8:00h";
            rota1[2, 0] = "SE";
            rota1[2, 1] = "10:00h";
            rota1[3, 0] = "AL";
            rota1[3, 1] = "12:00h";

            string[,] rota2 = new string[3, 2];
            rota2[0, 0] = "MT";
            rota2[0, 1] = "10:00h";
            rota2[1, 0] = "GO";
            rota2[1, 1] = "11:45h";
            rota2[2, 0] = "MG";
            rota2[2, 1] = "13:00h";
			
			string[,] rota3 = new string[2, 2];
            rota3[0, 0] = "RJ";
            rota3[0, 1] = "6:00h";
            rota3[1, 0] = "SP";
            rota3[1, 1] = "8:00h";
			
			//adicionando na lista de onibus
            Onibus bus = new Onibus(625, 32, 0, "Executivo", rota1, null);
            List<Onibus> lOnibus = new List<Onibus>();
			lOnibus.Add(bus);
			
			bus = new Onibus(455, 28, 0, "semiLeito", rota2, null);
            lOnibus.Add(bus);
			
			bus = new Onibus(238, 23, 0, "Leito", rota3, null);
            lOnibus.Add(bus);
			
			//adicionando na lista de rota
			Rota rt = new Rota(1, "ES-AL", "AL",rota1, 475.23);
			List<Rota> lRota = new List<Rota>();
			lRota.Add(rt);
			
			rt = new Rota(2, "MT-MG", "MG",rota2, 335.1 );
			lRota.Add(rt);
			
			rt = new Rota(3, "RJ-SP", "SP",rota3, 200.6 );
			lRota.Add(rt);

            //ConsultaRotasViewModel consulta = new ConsultaRotasViewModel("RJ", "SP", 2, lOnibus, rota3);
            ConsultaRotasViewModel consulta = new ConsultaRotasViewModel(bus);
            
			Mock<IReservaService> mock = new Mock<IReservaService>();
            mock.Setup(m => m.GetOnibusDisponiveis(bus));
            ReservaAppService reservaApp = new ReservaAppService();
            
            // Act
            List<string> x = reservaApp.GetOnibusDisponiveis(bus);

            List<string> esperado = new List<String>();
            esperado.Add("horaSaida: 6:00h horaChegada: 8:00h Onibus: 238");

            // Assert
            Assert.Equal(esperado, x);

        }
		
		[Fact]
        public void validarPagamento()
        {
            // Arrange
            string[,] rota1 = new string[4, 2];
            rota1[0, 0] = "ES";
            rota1[0, 1] = "6:00";
            rota1[1, 0] = "BA";
            rota1[1, 1] = "8:00";
            rota1[2, 0] = "SE";
            rota1[2, 1] = "10:00";
            rota1[3, 0] = "AL";
            rota1[3, 1] = "12:00";

            Passageiro passageiro = new Passageiro(20, "Ana" ,"132.554.764-55","ES", "BA", "Executivo");
            List<Passageiro> lPassageiros = new List<Passageiro>();
            lPassageiros.Add(passageiro);

            Onibus bus = new Onibus(625, 32, 26, "Executivo", rota1, lPassageiros);

            Rota rt = new Rota(1, "ES-AL", "BA", rota1, 452.32);
            
            Mock<IPagamentoService> mock = new Mock<IPagamentoService>();
            mock.Setup(m => m.vendaPassagens(passageiro, bus, rt)).Returns(173.58);

            Pagamento pagamento = new Pagamento(mock.Object)
            {
                IdPassageiro = 20,
                Valor = 157.80,
                Data = DateTime.Now.AddDays(2)
            };

            // Act
            double resultado = pagamento.vendaPassagens(pagamento, passageiro, bus, rt);
			double esperado = 173.58 ;
            
            // Assert
            Assert.Equal(esperado, resultado);
			
        }
		
		[Fact]
        public void saidaPassageiro()
        {
           //calcular capacidade maxima com vagas e quant pessoas
		   string[,] rota1 = new string[4, 2];
            rota1[0, 0] = "ES";
            rota1[0, 1] = "6:00";
            rota1[1, 0] = "BA";
            rota1[1, 1] = "8:00";
            rota1[2, 0] = "SE";
            rota1[2, 1] = "10:00";
            rota1[3, 0] = "AL";
            rota1[3, 1] = "12:00";
			
			Passageiro p = new Passageiro(19, "Bruna", "123.456.789-01","ES", "BA", "semiLeito"); 
            List<Passageiro> lPassageiros = new List<Passageiro>();
			lPassageiros.Add(p);
			
			Passageiro p1 = new Passageiro(21, "Marcio", "345.876.546-87","BA", "AL", "semiLeito"); 
            lPassageiros.Add(p1);
			
			Passageiro p2 = new Passageiro(25, "Joao", "234.978.772-33","SE", "AL", "semiLeito"); 
            
			lPassageiros.Add(p2);
			
			Onibus bus = new Onibus(325, 28, 3, "semiLeito", rota1, lPassageiros);
            List<Onibus> lOnibus = new List<Onibus>();
			lOnibus.Add(bus);
			
			Rota rt = new Rota(1, "ES-AL", "AL", rota1, 475.23);
			
			//tinha 28 agr tem 26
			int esperado = 26;
			var resultado = bus.pontoSaida(bus, rt, p);
			
			Assert.Equal(resultado, esperado);

        }
		
		[Fact]
        public void entradaPassageiro()
        {
			string[,] rota1 = new string[4, 2];
            rota1[0, 0] = "ES";
            rota1[0, 1] = "6:00";
            rota1[1, 0] = "BA";
            rota1[1, 1] = "8:00";
            rota1[2, 0] = "SE";
            rota1[2, 1] = "10:00";
            rota1[3, 0] = "AL";
            rota1[3, 1] = "12:00";


            List<Passageiro> lPassageiros = new List<Passageiro>();
            Passageiro p1 = new Passageiro(30, "Julia", "234.244.435-65","BA", "SE", "semiLeito"); 
            lPassageiros.Add(p1);
			
			Passageiro p2 = new Passageiro(31, "Bernardo", "234.332.465-87", "SE", "AL", "semiLeito"); 
            lPassageiros.Add(p2);
			
			Onibus bus = new Onibus(325, 28, 25, "semiLeito", rota1, lPassageiros);
            
			Rota rt = new Rota(1, "ES-AL", "AL", rota1, 475.23);
			
			Mock<IPagamentoService> mock = new Mock<IPagamentoService>();
            mock.Setup(m => m.vendaPassagens(p1, bus, rt)).Returns(173.58);
            Pagamento pagamento = new Pagamento(mock.Object)
            {
                IdPassageiro = 30,
				Valor = 2.5,
				Data = DateTime.Now.AddDays(2)	
            };
			
			double esperado = 356.4225; 
			double resultado = pagamento.vendaPassagens(pagamento, p1, bus, rt);

			Assert.Equal(esperado, resultado);
		}
    }
}
