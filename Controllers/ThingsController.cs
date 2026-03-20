using forge_energy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forge_energy.Controllers;

[Route("api/things")]
[ApiController]
public class ThingsController(ForgeEnergyContext context) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> ListAllThings()
    {
        var things = await context.Things.ToListAsync();

        return Ok(new
        {
            Success = true,
            StatusCode = 200,
            Items = things.Count,
            Data = things
        });
    }
}
