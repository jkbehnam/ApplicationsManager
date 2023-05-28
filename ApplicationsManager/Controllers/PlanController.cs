using Api.Endpoint.Helpers.Authorizations;
using ApplicationsManager.Entitiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        readonly AppManagerContext appManagerContext;
        public PlanController(AppManagerContext appManagerContext)
        {
            this.appManagerContext = appManagerContext;
        }
        [HttpGet("GetAllPlan")]
        public async Task<ActionResult<List<SubscriptionPlan>>> GetPlans()
        {
            return Ok(await appManagerContext.SubscriptionPlans.ToListAsync());

        }
     //om   [BasicAuthenticationFilter(UserRole.Admin)]
        [HttpPost]
        public IActionResult CreatePlan(SubscriptionPlan subscriptionPlan, string userId)
        {


            appManagerContext.SubscriptionPlans.Add(subscriptionPlan);
            appManagerContext.SaveChanges();

            return Ok(subscriptionPlan);


        }
    }
}
