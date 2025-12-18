using Microsoft.AspNetCore.Mvc;
using FoodOrderingSystem.Services;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    private readonly RestaurantService _service;

    public RestaurantsController(RestaurantService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }
}
