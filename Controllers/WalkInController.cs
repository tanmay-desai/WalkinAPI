using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using WalkinAPI.Models;

namespace WalkinAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WalkInController : ControllerBase
{

    private IConfiguration Configuration;

    public WalkInController(IConfiguration _configuration)
    {
        Configuration = _configuration;
    }


    [HttpGet]
    public Task<Prefetch> GetPrefetchData()
    {
        DBConnect db = new DBConnect(Configuration);
        var query = new QueryHelper(db);
        var Result = query.GetData();
        return Result;
    }

    [HttpPost("/createUser")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUser user)
    {

        DBConnect db = new DBConnect(Configuration);
        QueryHelper query = new QueryHelper(db);
        int Result = await query.CreateUser(user);
        if (Result == -1)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error in the details");
        }
        else
        {
            return Ok($"user created sucessfully: {Result}");
        }
    }
}
