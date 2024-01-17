using ManagementApp.Data.Database;
using ManagementApp.Data.Entities;
using ManagementApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Data.Repositories;

public class UserRepository : IUserRepository
{
	public ManagementContext _managementContext { get; set; }

	public UserRepository(ManagementContext managementContext)
	{
		_managementContext = managementContext;
	}

	public async Task<IEnumerable<User>> GetAllUsersAsync()
	{
		return await _managementContext.Users.ToListAsync();
	}

	public async Task<int> CreateUser(User user)
	{
		_managementContext.Users.Add(user);
		await _managementContext.SaveChangesAsync();

		return user.Id;
	}

	public async Task<User> UpdateUser(User user)
	{
		_managementContext.Users.Update(user);
		await _managementContext.SaveChangesAsync();

		return user;
	}

	public async Task<bool> DeleteUser(int id)
	{
		var userToDelete = await _managementContext.Users.FindAsync(id);

		if(userToDelete is not null) 
		{
			_managementContext.Users.Remove(userToDelete);
			await _managementContext.SaveChangesAsync();

			return true;
		}

		return false;
	}

	public async Task<User> GetUserById(int id)
	{
		var user = await _managementContext.Users.FirstOrDefaultAsync(u => u.Id == id);

		return user;
	}
}
