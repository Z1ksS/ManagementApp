using AutoMapper;
using ManagementApp.Presentation.Models;
using ManagementApp.Service.Entities;
using ManagementApp.Service.Interfaces;
using ManagementApp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : Controller
{
	private readonly IBookingService _bookingService;
	private readonly IMapper _mapper;

	public BookingController(IBookingService bookingService, IMapper mapper)
	{
		_bookingService = bookingService;
		_mapper = mapper;
	}

	[HttpPost]
	public async Task<IActionResult> CreateBooking([FromBody] BookingModelPresentation bookingModel)
	{
		var mapped = _mapper.Map<BookingDto>(bookingModel);

		var result = await _bookingService.CreateBooking(mapped);

		return result.Match<IActionResult>(
			resultValue =>
			{
				return Ok($"Booking created ID: {resultValue}");
			},
			error => BadRequest(error.Message)
		);
	}
}
