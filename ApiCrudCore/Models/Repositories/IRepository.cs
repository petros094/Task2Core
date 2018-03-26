using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudCore.Models.Repositories
{
    public interface IRepository<TEntity, U> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        TEntity Get(U id);
        void Add(TEntity b);
        void Update(TEntity b);
        void Delete(U id);
    }
}
