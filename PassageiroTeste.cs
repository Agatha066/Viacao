using Moq;
using System;
using System.Collections.Generic;
using viacaoCalango.Application.ViewModel;
using viacaoCalango.Domain.Entity;
using viacaoCalango.Domain.Interfaces.Service;
using Xunit;

namespace testeViacao
{
    public class PassageiroTeste
    {
        //nome
        [Fact]
        public void TesteValidarNomePassageiro()
        {
            //Arrage
            Passageiro passageiro = new Passageiro(1, "Lu", "123.234.235-09", "RJ", "SP", "Leito");

            //Act
            passageiro.QuantidadeLetras("Lu");

            //Assert
            Assert.Equal("false", passageiro.QuantidadeLetras("Lu"));
        }

        [Fact]
        public void TesteValidarCaractere()
        {
            //Arrage
            Passageiro passageiro = new Passageiro(1, "Lu1", "123.234.235-09", "RJ", "SP", "Leito");

            //Act
            passageiro.ValidaCaractere("Lu1");
            bool esperado = false;
            //Assert
            Assert.Equal(esperado, passageiro.ValidaCaractere("Lu1"));
        }

        //id
        [Fact]
        public void TesteValidarID()
        {
            //Arrage
            Passageiro passageiro = new Passageiro(0, "Luciana", "123.234.235-09", "RJ", "SP", "Leito");

            //Act
            passageiro.ValidaId(0);
            bool esperado = false;
            //Assert
            Assert.Equal(esperado, passageiro.ValidaId(0));
        }

        //local  ****refazer
        [Fact]
        public void TesteValidaLocalInicio()
        {
            //Arrage
            Passageiro passageiro = new Passageiro(1, "Luciana", "123.234.235-09", "RJ", "SP", "Leito");

            //Act
            Passageiro.ValidaLocalInicio("RJ");
            //tem que da true
            bool esperado = true;
            //Assert
            Assert.Equal(esperado, Passageiro.ValidaLocalInicio("RJ"));
        }

        [Fact]
        public void TesteValidaLocalFim()
        {
            //Arrage
            Passageiro passageiro = new Passageiro(1, "Luciana", "123.234.235-09", "RJ", "SP", "Leito");

            //Act
            passageiro.ValidaLocalFim("RJ", "SP");
            //tem que da true
            bool esperado = true;
            //Assert
            Assert.Equal(esperado, passageiro.ValidaLocalFim("RJ", "SP"));
        }

        //tipo
        [Fact]
        public void TesteValidaTipoPoltrona()
        {
            //Arrage
            Passageiro passageiro = new Passageiro(1, "Luciana", "123.234.235-09", "RJ", "SP", "Leito");

            //Act
            passageiro.ValidaTipo("Semi-leito");
            bool esperado = true;
            //Assert
            Assert.Equal(esperado, passageiro.ValidaTipo("Semi-Leito"));
        }

        //cpf
        [Fact]
        public void TesteValidaCPF()
        {
            //Arrage
            Passageiro passageiro = new Passageiro(1, "Luciana", "123.234.235-09", "RJ", "SP", "Leito");

            //Act
            passageiro.ValidaCpf("123.234.235-09");
            bool esperado = false;
            //Assert
            Assert.Equal(esperado, passageiro.ValidaCpf("123.234.235-09"));
        }
		
    }
}
