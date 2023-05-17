using ApplicationsManager.DTO;
using CustomerClub.Infrastracture.Utilities.TokenAuthorizationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly AppManagerContext appManagerContext;


        public UsersController(AppManagerContext appManagerContext)
        {
            this.appManagerContext = appManagerContext;
        }
        [HttpGet("GetToken")]
        public async Task<ActionResult<UserTokenDTO>> GetToken(string username, string password)
        {
           // var user = await appManagerContext.Users.FindAsync(username, password);
            var user = await appManagerContext.Users
               .Where(u => u.Username == username && u.Password == password)
               .FirstOrDefaultAsync();
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Invalid username or password.");
            }
            return Ok(new UserTokenDTO
            {
                Token = TokenAuthorizationService.MakeToken(username, password),
                UserId = user.Id,
            });
        }

    }
}
