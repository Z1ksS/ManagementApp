using ManagementApp.Data.Database;
using ManagementApp.Data.Entities;
using ManagementApp.Data.Interfaces;

namespace ManagementApp.Data.Repositories;

public class BookingRepository : IBookingRepository
{
	public ManagementContext _managementContext { get; set; }

	public BookingRepository(ManagementContext managementContext)
	{
		_managementContext = managementContext;
	}

	public async Task<int> CreateBooking(Booking booking)
	{
		_managementContext.Bookings.Add(booking);
		await _managementContext.SaveChangesAsync();

		return booking.Id;
	}
}
