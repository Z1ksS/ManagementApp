using ManagementApp.Data.Entities;

namespace ManagementApp.Data.Interfaces;

public interface IBookingRepository
{
	Task<int> CreateBooking(Booking booking); 
}
