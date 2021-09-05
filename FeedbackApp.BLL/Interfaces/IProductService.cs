using FeedbackApp.BLL.VMs.Product;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(CreateProduct product); 
        List<CreateProduct> FindProductsByFunc(Func<Product, bool> func);
    }
}
