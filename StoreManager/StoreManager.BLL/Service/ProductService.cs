using StoreManager.BLL.Contracts;
using StoreManager.Shared.Dto;
using StoreManager.Shared.Models;

namespace StoreManager.BLL.Service;

public class ProductService(IProductRepository repository)
{
    public async Task Add(ProductCreateDto productCreateDto)
    {
        var product = new Product(
            productCreateDto.Sku,
            productCreateDto.Name
        );
        
       await repository.AddProductAsync(product);
    }
}