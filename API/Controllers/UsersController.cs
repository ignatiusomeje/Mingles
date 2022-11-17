using API.DTOs.Users;
using API.Interfaces.Users;
using API.Utility;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUserRepository _userRepository;
  public UsersController(IUserRepository userRepository){
    _userRepository = userRepository;
  }
  [HttpGet]
  public async Task<ActionResult<UserDto>> GetAllUsers([FromQuery] UserParams userParams)
  {
    var userDto = await _userRepository.GetAllUsersAsync(userParams);
    return Ok(userDto);
    // return Ok(new
    // {
    //   minAge = userParams.MinAge,
    //   maxAge = userParams.MaxAge,
    //   currentUsername = userParams.CurrentUsername ?? "Default",
    //   gender = userParams.Gender,
    //   orderBy = userParams.OrderBy
    // });
  }
}