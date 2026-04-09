using forge_energy.Data;
using forge_energy.DTOs.IssueReports;
using forge_energy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forge_energy.Controllers;

[Route("api/issues")]
[ApiController]
public class IssueReportsController(ForgeEnergyContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ListAllIssues()
    {
        var issueReports = await context.IssueReports.ToListAsync();
        return Ok(new { Success = true, StatusCode = 200, Items = issueReports.Count, Data = issueReports });
    }
    [HttpPost]
    public async Task<ActionResult> AddIssue(PostIssueDto model)
    {
        IssueReport issueReport = new()
        {
            Description = model.Description
        };

        context.IssueReports.Add(issueReport);
        await context.SaveChangesAsync();
        return StatusCode(201, issueReport);
    }
}