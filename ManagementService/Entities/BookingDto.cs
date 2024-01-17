namespace ManagementApp.Service.Entities;

public class BookingDto
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public int RoomId { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
}
