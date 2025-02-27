using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Common.DTOs.UserDtos;
using Common.ViewModels.UserVMs;
using COMP1640.WebAPI.Services.Files;

namespace COMP1640.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly UserService _userService;
    private readonly IFileService _fileService;

    public UserController(UserService userService, IFileService fileService)
    {
        _userService = userService;
        _fileService = fileService;
    }

    //Get all users
    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersDto dto)
    {
        IEnumerable<UserVM> users = await _userService.GetAllUsers(dto);
        return Ok(users);
    }

    //Get user by id
    [HttpGet("get-user-by-id")]
    public async Task<IActionResult> GetUserById([FromQuery] int id)
    {
        if (id == 0)
        {
            return BadRequest("User Id cannot be empty");
        }
        UserDetailVM user = await _userService.GetUserById(id);
        return Ok(user);
    }

    //Create user
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromForm] CreateUserDto dto, [FromForm] IFormFile avatar)
    {
        if (dto.FirstName == null)
        {
            return BadRequest("First Name cannot be empty");
        }
        if (dto.LastName == null)
        {
            return BadRequest("Last Name cannot be empty");
        }
        if (dto.Email == null)
        {
            return BadRequest("Email cannot be empty");
        }
        if (dto.Password == null)
        {
            return BadRequest("Password cannot be empty");
        }

        // check xem no co phai la image khong
        if (!_fileService.IsImageFile(avatar))
        {
            return BadRequest("Avatar must be an image");
        }

        // luu anh vao system
        string avatarPath = await _fileService.SaveImageAsync(avatar, ImageSizeConstants.MaxWidthAvatar, ImageSizeConstants.MaxHeightAvatar);

        // assign path
        dto.Avatar = avatarPath;

        // neu muon xoa anh
        //await _fileService.DeleteImage(dto.Avatar);

        //if (avatar != null && avatar.Length > 0)
        //{
        //    var filePath = Path.Combine("wwwroot/images", avatar.FileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await avatar.CopyToAsync(stream);
        //    }
        //    dto.Avatar = $"/images/{avatar.FileName}"; // Store the relative path to the image
        //}

        await _userService.CreateUser(dto);
        return Ok();
    }


    //Update user
    [HttpPut("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto, IFormFile avatar)
    {
        if (dto.Id == 0)
        {
            return BadRequest("User Id cannot be empty");
        }
        if (dto.FirstName == null)
        {
            return BadRequest("First Name cannot be empty");
        }
        if (dto.LastName == null)
        {
            return BadRequest("Last Name cannot be empty");
        }
        if (dto.Email == null)
        {
            return BadRequest("Email cannot be empty");
        }
        if (dto.Password == null)
        {
            return BadRequest("Password cannot be empty");
        }

        if (avatar != null && avatar.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await avatar.CopyToAsync(memoryStream);
                dto.Avatar = memoryStream.ToArray();
            }
        }
        await _userService.UpdateUser(dto);
        return Ok();
    }

    //Delete user
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDto dto)
    {
        if (dto.Id == 0)
        {
            return BadRequest("User Id cannot be empty");
        }
        await _userService.DeleteUser(dto);
        return Ok();
    }
}
