using System;
using Repository.Repository;
using Repository.Model;

namespace Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _products;

        public ProductService(IRepository<Product> products)
        {
            _products = products;
        }

        public virtual Product Create(Product product)
        {
            try
            {
                if (ValidateProduct(product))
                    return _products.Create(product);
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        
        public Product Read(Guid id)
            => _products.Read(id);

        public Product Update(Product product)
            => _products.Update(product);

        public void Delete(Guid id)
            => _products.Delete(id);

        #region Private
        private bool ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Description)) throw new Exception("Empty description");
            if (string.IsNullOrWhiteSpace(product.Name)) throw new Exception("Empty name");
            return true;
        }

        #endregion
    }
}
