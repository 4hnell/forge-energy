namespace forge_energy.DTOs.DistributionSites;

public class PutDistributionSiteDto : PostDistributionSiteDto
{
    public DateOnly LastInspectionDate { get; set; }
}