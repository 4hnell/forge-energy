namespace forge_energy.DTOs.DistributionSites;

public abstract class BaseDistributionSiteDto
{
    public string SiteCode { get; set; }
    public string SiteName { get; set; }
    public string Capacity { get; set; }
    public string ServiceArea { get; set; }
    public string Operator { get; set; }
    public DateOnly LastInspectionDate { get; set; }
}