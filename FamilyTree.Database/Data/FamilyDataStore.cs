using FamilyTree.Database.Models;

namespace FamilyTree.Database.Data;

public class FamilyDataStore
{
    private static readonly List<FamilyMember> _familyMembers = new()
    {
        // Generation 0 - Great Grandparents (8 ROOT people)
        new FamilyMember { Id = 1, FirstName = "William", LastName = "Johnson", BirthDate = new DateTime(1920, 3, 15), Gender = "M", Generation = 0 },
        new FamilyMember { Id = 2, FirstName = "Elizabeth", LastName = "Wilson", BirthDate = new DateTime(1922, 7, 22), Gender = "F", Generation = 0 },
        new FamilyMember { Id = 3, FirstName = "Robert", LastName = "Miller", BirthDate = new DateTime(1918, 5, 10), Gender = "M", Generation = 0 },
        new FamilyMember { Id = 4, FirstName = "Margaret", LastName = "Davis", BirthDate = new DateTime(1921, 9, 18), Gender = "F", Generation = 0 },
        new FamilyMember { Id = 5, FirstName = "Thomas", LastName = "Brown", BirthDate = new DateTime(1919, 11, 3), Gender = "M", Generation = 0 },
        new FamilyMember { Id = 6, FirstName = "Helen", LastName = "Moore", BirthDate = new DateTime(1923, 2, 28), Gender = "F", Generation = 0 },
        new FamilyMember { Id = 7, FirstName = "Charles", LastName = "Taylor", BirthDate = new DateTime(1917, 8, 12), Gender = "M", Generation = 0 },
        new FamilyMember { Id = 8, FirstName = "Anne", LastName = "Anderson", BirthDate = new DateTime(1920, 12, 5), Gender = "F", Generation = 0 },
        
        // Generation 1 - Grandparents (4 people)
        // Edward Johnson → parents: William (1) & Elizabeth (2)
        new FamilyMember { Id = 9, FirstName = "Edward", LastName = "Johnson", BirthDate = new DateTime(1945, 5, 10), Gender = "M", Generation = 1, FatherId = 1, MotherId = 2 },
        // Susan Miller → parents: Robert (3) & Margaret (4)
        new FamilyMember { Id = 10, FirstName = "Susan", LastName = "Miller", BirthDate = new DateTime(1947, 9, 18), Gender = "F", Generation = 1, FatherId = 3, MotherId = 4 },
        // Frank Brown → parents: Thomas (5) & Helen (6)
        new FamilyMember { Id = 11, FirstName = "Frank", LastName = "Brown", BirthDate = new DateTime(1946, 3, 22), Gender = "M", Generation = 1, FatherId = 5, MotherId = 6 },
        // Laura Taylor → parents: Charles (7) & Anne (8)
        new FamilyMember { Id = 12, FirstName = "Laura", LastName = "Taylor", BirthDate = new DateTime(1948, 7, 15), Gender = "F", Generation = 1, FatherId = 7, MotherId = 8 },
        
        // Generation 2 - Parents (2 people)
        // Michael Johnson → parents: Edward (9) & Susan (10)
        new FamilyMember { Id = 13, FirstName = "Michael", LastName = "Johnson", BirthDate = new DateTime(1970, 2, 14), Gender = "M", Generation = 2, FatherId = 9, MotherId = 10 },
        // Sarah Brown → parents: Frank (11) & Laura (12)
        new FamilyMember { Id = 14, FirstName = "Sarah", LastName = "Brown", BirthDate = new DateTime(1972, 11, 30), Gender = "F", Generation = 2, FatherId = 11, MotherId = 12 },
        
        // Generation 3 - Children (2 sisters)
        // Emma Johnson → parents: Michael (13) & Sarah (14)
        new FamilyMember { Id = 15, FirstName = "Emma", LastName = "Johnson", BirthDate = new DateTime(2000, 1, 15), Gender = "F", Generation = 3, FatherId = 13, MotherId = 14 },
        // Olivia Johnson → parents: Michael (13) & Sarah (14)
        new FamilyMember { Id = 16, FirstName = "Olivia", LastName = "Johnson", BirthDate = new DateTime(2002, 3, 22), Gender = "F", Generation = 3, FatherId = 13, MotherId = 14 },
    };

    public List<FamilyMember> GetAllFamilyMembers()
    {
        var members = _familyMembers.OrderBy(m => m.Generation).ThenBy(m => m.Id).ToList();
        var memberDict = members.ToDictionary(m => m.Id);
        
        foreach (var member in members)
        {
            if (member.FatherId.HasValue && memberDict.ContainsKey(member.FatherId.Value))
            {
                member.Father = memberDict[member.FatherId.Value];
                member.Father.Children.Add(member);
            }
            
            if (member.MotherId.HasValue && memberDict.ContainsKey(member.MotherId.Value))
            {
                member.Mother = memberDict[member.MotherId.Value];
                if (!member.Mother.Children.Contains(member))
                {
                    member.Mother.Children.Add(member);
                }
            }
        }
        
        return members;
    }

    public List<FamilyMember> GetFamilyTree()
    {
        var allMembers = GetAllFamilyMembers();
        return allMembers.Where(m => !m.FatherId.HasValue && !m.MotherId.HasValue).ToList();
    }
}
