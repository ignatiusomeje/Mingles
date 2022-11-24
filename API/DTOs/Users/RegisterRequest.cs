using System.ComponentModel.DataAnnotations;
using API.DTOs.Users.Validation;

namespace API.DTOs.Users;

public class RegisterRequest
  {
    private string? _firstname;
    private string? _lastname;

    [Required(ErrorMessage = "{0} is required")]
    [MinLength(3, ErrorMessage = "{0} should be atleast 3 Characters")]
      public string? Firstname {get => _firstname; set => _firstname = value?.Trim();}
      [Required(ErrorMessage = "{0} is required")]
    [MinLength(3, ErrorMessage = "{0} should be atleast 3 Characters")]
      public string? Lastname { get => _lastname; set => _lastname = value?.Trim(); }
      [Required(ErrorMessage = "{0} is required")]
    [Gender(ErrorMessage = "{0} should either be a Male or 'Female'")]
      public string? Gender { get; set; }
      [Required(ErrorMessage = "{0} is required")]
      public DateTime DateOfBirth { get; set; }
      [Required(ErrorMessage = "{0} is required")]
      [RegularExpression("^[0-9]*$", ErrorMessage ="{0} not a valid Phonenumber")]
      public string? Phonenumber {get; set;}
      [Required(ErrorMessage = "{0} is required")]
      [EmailAddress(ErrorMessage = "{0} is invalid")]
      public string? Email { get; set; }
      [Required(ErrorMessage = "{0} is required")]
      [MinLength(3, ErrorMessage = "{0} should be atleast 3 Characters")]
      public string? Username { get; set; }
      [Required(ErrorMessage = "{0} is required")]
      [MinLength(3, ErrorMessage = "{0} should be atleast 3 Characters")]
      public string? City { get; set; }
      [Required(ErrorMessage = "{0} is required")]
      [MinLength(3, ErrorMessage = "{0} should be atleast 3 Characters")]
      public string? Country { get; set; }
      [Required(ErrorMessage = "{0} is required")]
      [MinLength(6, ErrorMessage = "{0} should be atleast 6 Characters")]
      public string? Password { get; set; }
      [Required(ErrorMessage = "{0} is required")]
      [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
      public string? ConfirmPassword { get; set; }
  }