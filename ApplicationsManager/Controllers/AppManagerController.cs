using ApplicationsManager.Entitiy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppManagerController : ControllerBase
    {
        AppManagerContext appManagerContext;
        public AppManagerController(AppManagerContext appManagerContext)
        {
            this.appManagerContext = appManagerContext;

        }
        //[HttpGet("getApplication")]
        //public async Task<ActionResult<ApplicationType>> GetToken(long appId)
        //{



        //    var application = await appManagerContext.ApplicationTypes
        //    .Where(u => u.Id == appId)
        //    .Include(u => u.applicationType_Customers)
        //    .FirstOrDefaultAsync();


        //    if (application == null)
        //    {
        //        // throw new InvalidOperationException("Invalid username or password.");
        //        return StatusCode(StatusCodes.Status404NotFound, "Invalid application code.");
        //    }
        //    return Ok(application);
        //}


    }
}
