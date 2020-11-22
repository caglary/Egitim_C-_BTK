using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.FluentValidation;
using Northwind.Business.Utilities;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using Nortwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Delete(product);


        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));

        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Update(product);
        }
    }
}
