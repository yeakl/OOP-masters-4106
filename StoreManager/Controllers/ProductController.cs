using Microsoft.AspNetCore.Mvc;
using StoreManager.BLL;
using StoreManager.Dto;

namespace StoreManager.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController(ProductService service): ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] ProductCreateDto productCreateDto)
    {
        await service.Add(productCreateDto);
        return Ok("Товар добавлен");
    }
}