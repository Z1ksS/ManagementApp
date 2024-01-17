namespace ManagementApp.Presentation.Models;

public class BookingModelPresentation
{
	public int UserId { get; set; }
	public int RoomId { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
}
