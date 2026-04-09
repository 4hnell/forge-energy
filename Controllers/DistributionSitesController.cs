using forge_energy.Data;
using forge_energy.DTOs.DistributionSites;
using forge_energy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forge_energy.Controllers;

[Route("api/distributionsites")]
[ApiController]
public class DistributionSitesController(ForgeEnergyContext context) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> ListAllDistributionSites()
    {
        var ds = await context.DistributionSites.ToListAsync();

        List<GetAllDistributionSitesDto> dto = [.. ds
            .Select(d => new GetAllDistributionSitesDto(){
                Id = d.Id,
                SiteCode = d.SiteCode,
                SiteName = d.SiteName,
                Capacity = d.Capacity,
                ServiceArea = d.ServiceArea,
                Operator = d.Operator,
                LastInspectionDate = d.LastInspectionDate
            })];

        return Ok(new
        {
            Success = true,
            StatusCode = 200,
            Items = dto.Count,
            Data = dto
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindDistributionSite(int id)
    {
        var ds = await context.DistributionSites.FindAsync(id);

        GetDistributionSiteDto dto = new()
        {
            SiteCode = ds.SiteCode,
            SiteName = ds.SiteName,
            Capacity = ds.Capacity,
            ServiceArea = ds.ServiceArea,
            Operator = ds.Operator,
            LastInspectionDate = ds.LastInspectionDate,
            AddressLine = ds.AddressLine,
            PostalCode = ds.PostalCode,
            City = ds.City
        };

        return Ok(new
        {
            Success = true,
            StatusCode = 200,
            Items = 1,
            Data = dto
        });
    }

    [HttpPost()]
    public async Task<ActionResult> AddDistributionSite(PostDistributionSiteDto model)
    {
        DistributionSite ds = new()
        {
            SiteCode = model.SiteCode,
            SiteName = model.SiteName,
            Capacity = model.Capacity,
            ServiceArea = model.ServiceArea,
            Operator = model.Operator,
            AddressLine = model.AddressLine,
            PostalCode = model.PostalCode,
            City = model.City
        };

        context.DistributionSites.Add(ds);
        await context.SaveChangesAsync();
        
        return StatusCode(201, ds);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDistributionSite(int id, PutDistributionSiteDto model)
    {
        DistributionSite ds = await context.DistributionSites.FindAsync(id);

        if (ds is null) return NotFound();

        ds.SiteCode = model.SiteCode;
        ds.SiteName = model.SiteName;
        ds.Capacity = model.Capacity;
        ds.ServiceArea = model.ServiceArea;
        ds.Operator = model.Operator;
        ds.LastInspectionDate = model.LastInspectionDate;
        ds.AddressLine = model.AddressLine;
        ds.PostalCode = model.PostalCode;
        ds.City = model.City;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDistributionSite(int id)
    {
        DistributionSite ds = await context.DistributionSites.FindAsync(id);

        if (ds is not null)
        {
            context.DistributionSites.Remove(ds);
            await context.SaveChangesAsync();
        }

        return NoContent();
    }
}
