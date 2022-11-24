using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Users.Validation;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]//allowMultiple makes it impossibble for the attribute to be repeated more than once while the AttributeTargets.Property tells where you want to add the attribute
public class GenderAttribute : ValidationAttribute
{
  private const string male = "MALE";
  private const string female = "FEMALE";
  public override bool IsValid(object? value)
  {
    if (value is not string gender)
    {
      return false;
    }
    return gender.ToLower() == male.ToLower() || gender.ToLower() == female.ToLower();
  }
}