namespace forge_energy.Entities;

public class DistributionSite
{
    public int Id { get; set; }
    public string SiteCode { get; set; }
    public string SiteName { get; set; }
    public string Capacity { get; set; }
    public string ServiceArea { get; set; }
    public string Operator { get; set; }
    public DateOnly LastInspectionDate { get; set; }
    public string AddressLine { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
}
