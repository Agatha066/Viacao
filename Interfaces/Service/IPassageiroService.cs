using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viacaoCalango.Domain.Entity;
using viacaoCalango.Domain.Services;

namespace viacaoCalango.Domain.Interfaces.Service
{
    public interface IPassageiroService 
    {
       public bool ValidaId(int Id);
	   public string QuantidadeLetras(string Nome);
	   public string ValidaCaractere(string nome);
	   public bool ValidaCpf(string cpf);
	   public bool ValidaLocalInicio(string LocalInicio);
	   public bool ValidaLocalFim(string LocalInicio, string LocalFim);
	   public bool ValidaTipo(string TipoPoltrona);
    }
}
