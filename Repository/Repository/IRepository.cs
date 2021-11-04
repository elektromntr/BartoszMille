using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //C
        TEntity Create(TEntity entity);
        //R
        TEntity Read(Guid id);
        //U
        TEntity Update(TEntity entity);
        //D
        void Delete(Guid id);
    }
}
