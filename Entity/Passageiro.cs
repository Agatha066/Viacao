using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace viacaoCalango.Domain.Entity
{
    public class Passageiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string LocalInicio { get; set; }
        public string LocalFim { get; set; }
        public string TipoPoltrona { get; set; }
        

        public Passageiro(int id, string nome, string cpf, string inicio, string fim, string tipo)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            LocalInicio = inicio;
            LocalFim = fim;
            TipoPoltrona = tipo;
        }

        //id
        public bool ValidaId(int Id) {
            if (Id < 1) {
                return false;
            }
            return true;
        }

        //nome
        public string QuantidadeLetras(string Nome)
        {
            if (Nome.Length >= 3)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public bool ValidaCaractere(string nome)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(nome))
                isValid = false;
            else
            {
                //processo 1 
                isValid = Regex.IsMatch(nome, @"^[a-zA-Z]+$");

                //processo 2 
                foreach (char c in nome)
                {
                    if (!Char.IsLetter(c))
                        isValid = false;
                }

            }
            return isValid;
        }

        //cpf
        public bool ValidaCpf(string cpf)
        {
            
                cpf = cpf.Replace(".", "");
                cpf = cpf.Replace("-", "");
                int[] num = new int[11];
                int soma;
                int i;
                int resultado1;
                int resultado2;
                if (cpf.Length == 11)
                {
                    for (i = 0; i <= num.Length - 1; i++)
                    {
                        num[i] = Convert.ToInt32(cpf.Substring(i, 1));
                    }
                    soma = num[0] * 10 + num[1] * 9 + num[2] * 8 + num[3] * 7 + num[4] * 6 + num[5] * 5 + num[6] * 4 + num[7] * 3 + num[8] * 2;
                    soma = soma - (11 * ((int)(soma / 11)));
                    if (soma == 0 | soma == 1)
                    {
                        resultado1 = 0;
                    }
                    else
                    {
                        resultado1 = 11 - soma;
                    }
                    if (resultado1 == num[9])
                    {
                        soma = num[0] * 11 + num[1] * 10 + num[2] * 9 + num[3] * 8 + num[4] * 7 + num[5] * 6 + num[6] * 5 + num[7] * 4 + num[8] * 3 + num[9] * 2;
                        soma = soma - (11 * ((int)(soma / 11)));
                        if (soma == 0 | soma == 1)
                        {
                            resultado2 = 0;
                        }
                        else
                        {
                            resultado2 = 11 - soma;
                        }
                        if (resultado2 == num[10])
                        {
                            if (cpf == "11111111111" | cpf == "22222222222" | cpf == "33333333333" | cpf == "44444444444" | cpf == "55555555555" | cpf == "66666666666" | cpf == "77777777777" | cpf == "88888888888" | cpf == "99999999999" | cpf == "00000000000")
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                
            return false;
            
        }

        //local inicio
        public static bool ValidaLocalInicio(string LocalInicio) {

            string[] uf = new string[] { "MG", "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            
            foreach (string v in uf)
            {
                if (LocalInicio == v)
                {
                    return true;
                }
            }
            return false;
        }

        //local fim
        public bool ValidaLocalFim(string LocalInicio, string LocalFim) {

            string[] uf = new string[] { "MG", "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "PA", "PB", "PR", "PE", "PI","RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };

            if (LocalInicio != LocalFim) 
            {
                foreach (string v in uf)
                {
                    if (LocalFim == v)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //tipo
        public bool ValidaTipo(string TipoPoltrona) {

            if (TipoPoltrona == "Executivo") {
                return true;
            }
            else if (TipoPoltrona == "Leito") {
                return true;
            }
            else if (TipoPoltrona == "SemiLeito" || TipoPoltrona == "Semi-Leito") {
                return true;
            }
            else {
                return false;
            }

        }
    }
		
}
