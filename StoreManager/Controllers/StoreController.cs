using Microsoft.AspNetCore.Mvc;
using StoreManager.BLL;
using StoreManager.BLL.Exceptions;
using StoreManager.Dto;

namespace StoreManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController(
    StoreService storeService,
    StockService stockService
) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] StoreDto store)
    {
        await storeService.AddStoreAsync(store);
        return Ok("Магазин добавлен");
    }

    [HttpPost("{code}/stock/add")]
    public async Task<IActionResult> AddProductInStock(
        [FromRoute] string code,
        [FromBody] List<StoreStockRequestDto> stockRequest
    )
    {
        var store = await storeService.GetStoreByCode(code);
        if (store == null)
        {
            return new BadRequestResult();
        }

        //todo: тут еще надо проверить, что продукты существуют

        await storeService.AddProductsToStore(store, stockRequest);
        return Ok("Товары загружены");
    }


    [HttpGet("stock/cheapest/{sku}")]
    public async Task<IActionResult> FindCheapestProduct([FromRoute] string sku)
    {
        var store = await stockService.FindStoreWithCheapestProduct(sku);
        if (store == null)
        {
            return new NotFoundResult();
        }

        return Ok(store);
    }

    [HttpGet("{code}/stock/affordable")]
    public async Task<IActionResult> FindAffordableProducts([FromRoute] string code, [FromQuery] decimal money)
    {
        var store = await storeService.GetStoreByCode(code);
        if (store == null)
        {
            return new NotFoundResult();
        }

        var items = await storeService.GetAffordableProductsByMoneyAmount(store, money);
        return Ok(items);
    }

    [HttpPost("{code}/stock/buy")]
    public async Task<IActionResult> BuyProductsInStore([FromRoute] string code,
        [FromBody] List<PurchaseRequestDto> purchaseRequest)
    {
        var store = await storeService.GetStoreByCode(code);
        if (store == null)
        {
            return new NotFoundResult();
        }

        try
        {
            var sum = await storeService.Buy(store, purchaseRequest);
            return Ok(sum);
        }
        catch (Exception exception) when (exception is InsufficientProductsInStoreException
                                              or UnavailableProductsInStoreException)
        {
            return new BadRequestObjectResult(new
                { exception.Message, ExceptionType = exception.GetType().Name, });
        }
    }

    [HttpPost("stock/combo/cheapest")]
    public async Task<IActionResult> FindStoreWithCheapestCombination(
        [FromBody] List<PurchaseRequestDto> purchaseRequest)
    {
        try
        {
            var store = await storeService.FindStoreWithCheapestProductCombination(purchaseRequest);
            return Ok(store);
        }
        catch (ProductCombinationUnavailableException exception)
        {
            return new BadRequestObjectResult(new
                { exception.Message, ExceptionType = exception.GetType().Name, });
        }
    }
}