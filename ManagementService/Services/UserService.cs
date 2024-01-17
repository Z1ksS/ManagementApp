using AutoMapper;
using ManagementApp.Data.Entities;
using ManagementApp.Data.Interfaces;
using ManagementApp.Data.Results;
using ManagementApp.Service.Entities;
using ManagementApp.Service.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Service.Services;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public UserService(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
	{
		var users = await _userRepository.GetAllUsersAsync();

		return _mapper.Map<IEnumerable<UserDto>>(users);
	}

	public async Task<Result<int, ValidationException>> CreateUser(UserDto user)
	{
		if(user.FirstName.Length < 2 || user.LastName.Length < 2)
		{
			return new ValidationException("The first name or the last name must have at least 2 symbols!");
		}

		var userToCreate = _mapper.Map<User>(user);

		var userId = await _userRepository.CreateUser(userToCreate);

		return userId;
	}

	public async Task<Result<bool, ValidationException>> DeleteUser(int id)
	{
		var userToDelete = await _userRepository.GetUserById(id);

		if(userToDelete is null) 
		{
			return new ValidationException($"There is no such user with ID {id}");
		}

		var deleteUser = await _userRepository.DeleteUser(id);

		return deleteUser;
	}

	public async Task<Result<UserDto, ValidationException>> UpdateUser(int id, UserDto user)
	{
		if (user.FirstName.Length < 2 || user.LastName.Length < 2)
		{
			return new ValidationException("The first name or the last name must have at least 2 symbols!");
		}

		var existingUser = await _userRepository.GetUserById(id);

		if(existingUser is null)
		{
			return new ValidationException($"There is no such user with ID {id}");
		}

		existingUser.Email = user.Email;
		existingUser.FirstName = user.FirstName;
		existingUser.LastName = user.LastName;

		await _userRepository.UpdateUser(existingUser);

		var mappedUser = _mapper.Map<UserDto>(existingUser);

		return mappedUser;
	}
}
