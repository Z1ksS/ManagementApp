using AutoMapper;
using ManagementApp.Data.Entities;
using ManagementApp.Presentation.Models;
using ManagementApp.Service.Entities;

namespace ManagementApp.Presentation.Profiles;

public class MappingProfilePresentation : Profile
{
	public MappingProfilePresentation()
	{
		CreateMap<UserModelPresentation, UserDto>().ReverseMap();
		CreateMap<BookingModelPresentation, BookingDto>().ReverseMap();
	}
}
