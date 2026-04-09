namespace forge_energy.DTOs.DistributionSites;

public class GetDistributionSiteDto : BaseDistributionSiteDto
{
    public string AddressLine { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
}