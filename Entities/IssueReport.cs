namespace forge_energy.Entities;

public class IssueReport
{
    public int Id { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.Now;
    public string Description { get; set; }
    // Lägg till kund och kundId när det finns
}
