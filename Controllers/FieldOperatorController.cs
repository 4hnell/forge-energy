using forge_energy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using forge_energy.DTOs;

namespace forge_energy.Controllers;

[Route("api/fieldoperators")]
[ApiController]
public class FieldOperatorController(ForgeEnergyContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ListAllFieldOperators()
    {
        
        var operators = await context.FieldOperators.ToListAsync();

      
        var dto = operators.Select(op => new GetFieldOperatorDto
        {
            Id = op.Id,
            FullName = $"{op.FirstName} {op.LastName}", 
            Email = op.Email,
            WorkRole = op.WorkRole,
            Area = op.Area,
            Competence = op.Competence
        }).ToList();

      
        return Ok(new
        {
            Success = true,
            StatusCode = 200,
            Items = dto.Count,
            Data = dto
        });
    }
}
