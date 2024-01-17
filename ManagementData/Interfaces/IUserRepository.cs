using ManagementApp.Data.Entities;

namespace ManagementApp.Data.Interfaces;

public interface IUserRepository
{
	Task<IEnumerable<User>> GetAllUsersAsync();
	Task<int> CreateUser(User user);
	Task<User> UpdateUser(User user);
	Task<bool> DeleteUser(int id);
	Task<User> GetUserById(int id);
}
