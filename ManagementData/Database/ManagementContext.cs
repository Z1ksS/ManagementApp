using ManagementApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Data.Database;

public class ManagementContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<MeetingRoom> MeetingRooms { get; set; }
	public DbSet<Booking> Bookings { get; set; }

	public ManagementContext(DbContextOptions<ManagementContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>()
			.Property(u => u.FirstName)
			.HasMaxLength(100);

		modelBuilder.Entity<User>()
			.Property(u => u.LastName)
			.HasMaxLength(100);

		modelBuilder.Entity<MeetingRoom>()
			.Property(mr => mr.RoomName)
			.HasMaxLength(50);

		modelBuilder.Entity<Booking>()
			.HasOne(b => b.User)
			.WithMany(u => u.Bookings)
			.HasForeignKey(b => b.UserId);

		modelBuilder.Entity<Booking>()
			.HasOne(b => b.MeetingRoom)
			.WithMany()
			.HasForeignKey(b => b.RoomId);

		modelBuilder.Entity<User>().HasData(
			new User {Id = 1, FirstName = "Bob", LastName="Johnson", Email="bob.johnson@gmail.com"}
		);

		modelBuilder.Entity<MeetingRoom>().HasData(
			new MeetingRoom {Id = 1, RoomName="Test", Capacity=1}
		);
	}
}
