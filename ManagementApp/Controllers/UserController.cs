using AutoMapper;
using ManagementApp.Presentation.Models;
using ManagementApp.Service.Entities;
using ManagementApp.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
	private readonly IUserService _userService;
	private readonly IMapper _mapper;

	public UserController(IUserService userService, IMapper mapper)
	{
		_userService = userService;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetUsers()
	{
		var users = await _userService.GetAllUsersAsync();

		return Ok(users);
	}

	[HttpPost]
	public async Task<IActionResult> CreateUser([FromBody] UserModelPresentation userModel)
	{
		var mappedUser = _mapper.Map<UserDto>(userModel);

		var result = await _userService.CreateUser(mappedUser);

		return result.Match<IActionResult>(
			resultValue =>
			{
				return Ok($"User created ID: {resultValue}");
			},
			error => BadRequest(error.Message)
		);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateUser(int id, [FromBody] UserModelPresentation userModel)
	{
		var mappedUser = _mapper.Map<UserDto>(userModel);

		var result = await _userService.UpdateUser(id, mappedUser);

		return result.Match<IActionResult>(
			resultValue =>
			{
				return Ok($"User updated");
			},
			error => BadRequest(error.Message)
		);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteUser(int id)
	{
		var deletedUser = await _userService.DeleteUser(id);

		return deletedUser.Match<IActionResult>(
			_ => NoContent(),
			error => BadRequest(error.Message)
		);
	}
}
