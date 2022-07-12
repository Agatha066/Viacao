using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viacaoCalango.Domain.Entity;

namespace viacaoCalango.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
