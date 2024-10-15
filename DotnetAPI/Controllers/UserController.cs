
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
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }
   
    // [HttpGet("GetUsers/{testValue}")]
    // // http://localhost:5121/user/test?testValue=%22AAA%22
    // public string[] GetUsers(string testValue){
    //     Console.WriteLine(testValue);
    //      string[] responseArr = new string[] {
    //         "test1",
    //         "test2",
    //         testValue
    //      };
    //      return responseArr;
    // }

    [HttpGet("GetUsers")]
    // http://localhost:5121/user/test?testValue=%22AAA%22
    public IEnumerable<User>GetUsers(){
        string sql = @"
            SELECT [UserId]
                ,[FirstName]
                ,[LastName]
                ,[Email]
                ,[Gender]
                ,[Active]
            FROM [DotNetCourseDatabase].[TutorialAppSchema].[Users]       
        ";
        IEnumerable<User> users = _dapper.LoadData<User>(sql);
        return users;
       
    }

    [HttpGet("GetUser/{userId}")]
    // http://localhost:5121/user/test?testValue=%22AAA%22
    public User GetSingleUser(int userId){
        string sql = @"
            SELECT [UserId]
                ,[FirstName]
                ,[LastName]
                ,[Email]
                ,[Gender]
                ,[Active]
            FROM [DotNetCourseDatabase].[TutorialAppSchema].[Users]
            WHERE  [UserId] = " + userId.ToString();
        User user = _dapper.LoadDataSingle<User>(sql);
        return user;
       
    }

 
}




