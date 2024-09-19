
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {

    public UserController(){

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




