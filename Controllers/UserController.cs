using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DotnetAssignmentBackEnd.Services;
using DotnetAssignmentBackEnd.Models;

namespace DotnetAssignmentBackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase{
    IUserService _userService;
    public UserController(IUserService service) {
        _userService = service;
    }

    // [HttpGet]
    // [Route("[action]")]
    // public IActionResult GetAllUsers() {
    //     try {
    //         var users = _userService.;
    //         if (issues == null) return NotFound();
    //         return Ok(issues);
    //     } catch (Exception e) {
    //         return BadRequest();
    //     }
    // }

    // [HttpGet]
    // [Route("[action]/id")]
    // public IActionResult GetUserById(int id) {
    //     try {
    //         var user = _userService.GetUserById(id);
    //         if (user == null) return NotFound();
    //         return Ok(user);
    //     } catch (Exception) {
    //         return BadRequest();
    //     }
    // }
    
    [HttpPost]
    [Route("[action]")]
    public IActionResult SignUp(UserDTO userModel) {
        try {
            var model = _userService.SaveUser(userModel);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }

    // [HttpDelete]
    // [Route("[action]")]
    // public IActionResult DeleteUser(int id) {
    //     try {
    //         var model = _userService.DeleteUser(id);
    //         return Ok(model);
    //     } catch (Exception) {
    //         return BadRequest();
    //     }
    // }
}