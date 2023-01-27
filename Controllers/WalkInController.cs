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
    public Task<int> CreateUser([FromBody] CreateUser user)
    {
        DBConnect db = new DBConnect(Configuration);
        var query = new QueryHelper(db);
        var Result = query.CreateUser(user);
        return Result;
    }
}
