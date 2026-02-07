namespace FamilyTree.Database.Models;

public class FamilyMember
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }
    public int Generation { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public List<FamilyMember> Children { get; set; } = new();
    public FamilyMember? Father { get; set; }
    public FamilyMember? Mother { get; set; }
}
