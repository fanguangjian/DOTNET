
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {

    DataContextDapper _dapper;

    public UserController(IConfiguration config){
        _dapper = new DataContextDapper(config);
        // Console.WriteLine(config.GetConnectionString("DefaultConnection"));
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection(){
        return _dapper.LoadDataSing<DateTime>("SELECT GETDATE()");
    }
   
    [HttpGet("GetUsers/{testValue}")]
    // http://localhost:5121/user/test?testValue=%22AAA%22
    public string[] GetUsers(string testValue){
        Console.WriteLine(testValue);
         string[] responseArr = new string[] {
            "test1",
            "test2",
            testValue
         };
         return responseArr;
    }

 
}




