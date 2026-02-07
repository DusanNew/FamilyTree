using FamilyTree.Database.Data;
using FamilyTree.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FamilyController : ControllerBase
{
    private readonly FamilyDataStore _dataStore;

    public FamilyController()
    {
        _dataStore = new FamilyDataStore();
    }

    [HttpGet]
    public ActionResult<List<FamilyMember>> GetAllFamilyMembers()
    {
        var members = _dataStore.GetAllFamilyMembers();
        return Ok(members);
    }

    [HttpGet("tree")]
    public ActionResult<List<FamilyMember>> GetFamilyTree()
    {
        var tree = _dataStore.GetFamilyTree();
        return Ok(tree);
    }
}
