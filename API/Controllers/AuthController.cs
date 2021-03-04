using System.Threading.Tasks;
using API.DTO;
using API.Utilities;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly TokenHelper _tokenHelper;
        public AuthController(UserManager<User> userManager,
        SignInManager<User> signInManager,
        
        TokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
    {
        var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
        if (user == null)
        {
            return Unauthorized();
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);
        if (result.Succeeded)
        {
            return new UserDto { FirstName = user.UserName, Token = _tokenHelper.CreateToken(user), Image = null };
        }

        return Unauthorized();


    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(UserRegisterDto userRegisterDto)
    {
        if (await _userManager.Users.AnyAsync(a => a.Email == userRegisterDto.Email))
        {
            return BadRequest("Bu Email var");
        }
        var user = new User
        {
            Email = userRegisterDto.Email,
            UserName = userRegisterDto.UserName
        };
        var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
        if (result.Succeeded)
        {
            return new UserDto { FirstName = user.UserName, Token = _tokenHelper.CreateToken(user), Image = null };
        }
        return BadRequest("olmadı");
    }
}
}