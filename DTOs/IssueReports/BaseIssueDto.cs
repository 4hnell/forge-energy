using System.ComponentModel.DataAnnotations;

namespace forge_energy.DTOs.IssueReports;

public class BaseIssueDto
{
    public required string Description { get; set; }
}
