using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.Product;
using FeedbackApp.DAL.Patterns;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _db;

        public ProductService(IUnitOfWork db)
        {
            this._db = db;
        }

        public async Task<Guid> CreateProductAsync(CreateProduct product)
        {
            try
            {
                var dbProduct = new Product()
                {
                    Name = product.Name,
                    Category = product.Category
                };
                dbProduct = await _db.Products.CreateAsync(dbProduct);
                return dbProduct.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreateProduct> FindProductsByFunc(Func<Product, bool> func)
        {
            try
            {
                var dbProducts = _db.Products.GetAll().Where(func). //это чтобы превратить список Product в список CreateProduct
                                                      Select(m =>
                                                      {
                                                          return new CreateProduct()
                                                          {
                                                              Category = m.Category,
                                                              Name = m.Name
                                                          };
                                                      }).ToList();
                return dbProducts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
