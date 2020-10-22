using Microsoft.AspNetCore.Mvc;
using UserProject.Core.Interfaces;
using UserProject.API.Models;
using UserProject.Core.Models;
using UserProject.Data.Infrastructures;
using UserProject.Core.Entities;

namespace UserProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        IUnitOfWork _uow;
        public AuthController(IAuthService authService, IUnitOfWork uow)
        {
            _authService = authService;
            _uow = uow;
        }

        [HttpPost("token")]
        public ActionResult<AuthData> Post([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _uow.Users.GetSingle(u => u.Email == model.Email);

            if (user == null)
            {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid)
            {
                return BadRequest(new { password = "invalid password" });
            }

            return _authService.GetAuthData(user.Id.ToString());
        }

        [HttpPost("register")]
        public ActionResult<AuthData> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUniq = _uow.Users.isEmailUniq(model.Email);
            if (!emailUniq) return BadRequest(new { email = "user with this email already exists" });
            var usernameUniq = _uow.Users.IsUsernameUniq(model.Username);
            if (!usernameUniq) return BadRequest(new { username = "user with this email already exists" });

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = _authService.HashPassword(model.Password)
            };
            _uow.Users.Add(user);
            _uow.Users.Commit();

            return _authService.GetAuthData(user.Id.ToString());
        }

    }
}
