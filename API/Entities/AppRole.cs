using Microsoft.AspNetCore.Identity;

namespace API.Entities;

public class AppRole : IdentityRole<int> // the int in the anchor bracket makes the id to be a hint // identityRole works on assigning roles to user
  {
      public ICollection<AppUserRole>? UserRoles{get; set;}
  }