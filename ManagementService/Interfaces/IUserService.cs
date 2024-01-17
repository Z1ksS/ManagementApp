using ManagementApp.Data.Entities;
using ManagementApp.Data.Results;
using ManagementApp.Service.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Service.Interfaces;

public interface IUserService
{
	Task<IEnumerable<UserDto>> GetAllUsersAsync();
	Task<Result<int, ValidationException>> CreateUser(UserDto user);
	Task<Result<UserDto, ValidationException>> UpdateUser(int id, UserDto user);
	Task<Result<bool, ValidationException>> DeleteUser(int id);
}
