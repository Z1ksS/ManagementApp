using AutoMapper;
using ManagementApp.Data.Entities;
using ManagementApp.Service.Entities;

namespace ManagementApp.Service.Profiles;

public class MappingProfileService : Profile
{
	public MappingProfileService() 
	{
		CreateMap<UserDto, User>().ReverseMap();
		CreateMap<BookingDto, Booking>().ReverseMap();	
	}
}
