using API.DTOs.Users;
using API.Entities;
using AutoMapper;

namespace API.Utility;

public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<RegisterRequest, AppUser>()// this is you mapping the source to the target;
    .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Username!.Trim().ToLower()))
    .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email!.Trim().ToLower()))
    .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.Phonenumber));
  }
}