using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viacaoCalango.Application.ViewModel;
using viacaoCalango.Domain.Entity;

namespace viacaoCalango.Application.Interface
{
    public interface IReservaAppService
    {
        public List<string> GetOnibusDisponiveis(Onibus onibus);
    }
}
