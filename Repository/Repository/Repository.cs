using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private IList<T> _fakeDb = new List<T>();

        public T Create(T entity)
        {
            _fakeDb.Add(entity);
            return entity;
        }

        public void Delete(Guid id)
        {
            try
            {
                var item = Read(id);
                if (item != null) _fakeDb.Remove(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Read(Guid id) =>
            _fakeDb.First(t => t.Id.Equals(id)); // will throw if NULL

        public T Update(T entity)
        {
            try
            {
                var item = Read(entity.Id);
                _fakeDb.Remove(item);
                return Create(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
