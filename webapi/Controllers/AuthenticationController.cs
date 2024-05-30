
using Microsoft.AspNetCore.Mvc;
using webapi.Model;

namespace Ecommerce_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepository _authService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthRepository authService, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _logger = logger;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _authService.Login(model);
                if (status == 0)
                    return BadRequest(message); // Return error message if login failed
                return Ok(new { message = "Login successful", token = message }); // Return success message and token
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the login request");
            }
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                //var (status, message) = await _authService.Registeration(model, UserRoles.User);
                var (status, message) = await _authService.Registeration(model, UserRoles.Admin);
                if (status == 0)
                {
                    return BadRequest(message); // Return error message if registration failed
                }
                return CreatedAtAction(nameof(Register), new { message = "User registered successfully" }); // Return success message
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the registration request");
            }


        }
       

    }
}
