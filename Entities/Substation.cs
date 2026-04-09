namespace forge_energy.Entities;

public class Substation
{
    public int Id { get; set; }
    public string Location { get; set; }
    public bool IsOnline { get; set; }
    public SubstationType Type { get; set; }
}
