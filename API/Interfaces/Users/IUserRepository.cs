using API.DTOs.Users;
using API.Utility;

namespace API.Interfaces.Users;

public interface IUserRepository
  {
      Task<List<UserDto>> GetAllUsersAsync(UserParams userParams);
  }