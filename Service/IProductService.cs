using Repository.Model;
using System;

namespace Service
{
    public interface IProductService
    {
        Product Create(Product product);
        void Delete(Guid id);
        Product Read(Guid id);
        Product Update(Product product);
    }
}