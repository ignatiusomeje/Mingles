using API.Utility;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
  [HttpGet]
  public ActionResult GetAllUsers([FromQuery] UserParams userParams)
  {
    return Ok(new
    {
      minAge = userParams.MinAge,
      maxAge = userParams.MaxAge,
      currentUsername = userParams.CurrentUsername ?? "Default",
      gender = userParams.Gender,
      orderBy = userParams.OrderBy
    });
  }
}