using forge_energy.Data;
using forge_energy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forge_energy.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeesController(ForgeEnergyContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ListAllEmployees()
    {
        var employees = await context.Employees.ToListAsync();

        var dto = employees.Select(e => new 
        {
            e.Id,
            FullName = $"{e.FirstName} {e.LastName}",
            e.Email,
            e.WorkRole,
            Type = e is FieldOperator ? "Field Operator" : "Staff"
        });

        return Ok(new
        {
            Success = true,
            Items = dto.Count(),
            Data = dto
        });
    }
}