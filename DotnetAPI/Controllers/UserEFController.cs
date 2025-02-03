
using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase {

    DataContextEF _entityFramework;

    public UserEFController(IConfiguration config){
        _entityFramework = new DataContextEF(config);
        // Console.WriteLine(config.GetConnectionString("DefaultConnection"));
    }


    [HttpGet("GetUsers")]
    // http://localhost:5121/user/test?testValue=%22AAA%22
    public IEnumerable<User>GetUsers(){
       
        IEnumerable<User> users = _entityFramework.Users.ToList<User>();
        return users;
       
    }

    [HttpGet("GetUser/{userId}")]
    // http://localhost:5121/user/test?testValue=%22AAA%22
    public User GetSingleUser(int userId){
      
        User? user = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();
        if (user != null){
            return user;
        }
        throw new Exception("Failed to find user");     
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user){    

        User? userDb = _entityFramework.Users.Where(u => u.UserId == user.UserId).FirstOrDefault<User>();
        if(userDb != null){
            userDb.Active = user.Active;
            userDb.LastName = user.LastName;
            userDb.FirstName = user.FirstName;
            userDb.Email = user.Email;
            userDb.Gender = user.Gender;
            if (_entityFramework.SaveChanges() > 0){
                return Ok();
            }
            throw new Exception("Failed to Update User");            
        }
        throw new Exception("Failed to find user");     


    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserToAddDto user){
        User userDb = new User();

        userDb.Active = user.Active;
        userDb.LastName = user.LastName;
        userDb.FirstName = user.FirstName;
        userDb.Email = user.Email;
        userDb.Gender = user.Gender;

        _entityFramework.Add(userDb);
        if (_entityFramework.SaveChanges() > 0){
            return Ok();
        }
        throw new Exception("Failed to Add User");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId){
        User? userDb = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();
        if (userDb != null){
            _entityFramework.Users.Remove(userDb);
            if(_entityFramework.SaveChanges() > 0) {
                return Ok();
            }
            throw new Exception("Failed to Delete User");

        }
        throw new Exception("Failed to find user");     
       
    }

 
}




