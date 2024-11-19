using StoreManager.DAL.Contracts;
using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.BLL;

public class ProductService(IProductRepository repository)
{
    public async Task Add(ProductCreateDto productCreateDto)
    {
        var product = new Product {
            Sku = productCreateDto.Sku,
            Name = productCreateDto.Name,
        };
        
       await repository.AddProductAsync(product);
    }
}