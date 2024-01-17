using AutoMapper;
using ManagementApp.Data.Entities;
using ManagementApp.Data.Interfaces;
using ManagementApp.Data.Results;
using ManagementApp.Service.Entities;
using ManagementApp.Service.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Service.Services;

public class BookingService : IBookingService
{
	private readonly IBookingRepository _bookingRepository;
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public BookingService(IBookingRepository bookingRepository, IUserRepository userRepository, IMapper mapper)
	{
		_bookingRepository = bookingRepository;
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<Result<int, ValidationException>> CreateBooking(BookingDto booking)
	{
		var existingUser = await _userRepository.GetUserById(booking.UserId);

		if (existingUser is null) 
		{
			return new ValidationException($"There is no such user with ID {booking.UserId}");
		}

		var mapped = _mapper.Map<Booking>(booking);

		var bookingId = await _bookingRepository.CreateBooking(mapped);

		return bookingId;
	}
}
