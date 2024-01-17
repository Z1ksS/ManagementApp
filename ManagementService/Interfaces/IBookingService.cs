using ManagementApp.Data.Results;
using ManagementApp.Service.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Service.Interfaces;

public interface IBookingService
{
	Task<Result<int, ValidationException>> CreateBooking(BookingDto booking);
}
