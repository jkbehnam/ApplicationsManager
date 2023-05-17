using Api.Endpoint.Helpers.Authorizations;
using ApplicationsManager.DTO;
using ApplicationsManager.Entitiy;
using CustomerClub.Infrastracture.Utilities.TokenAuthorizationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly AppManagerContext appManagerContext;
        public CustomerController(AppManagerContext appManagerContext)
        {
            this.appManagerContext = appManagerContext;
        }
        [HttpGet("GetApplications")]
        public async Task<ActionResult<List<Customer>>> GetApplications()
        {
            return Ok(await appManagerContext.Customers.ToListAsync());

        }
        // کاربر توکن خود را دریافت میکند. یعنی ورود موفقیت آمیز بوده است
        [HttpGet("GetToken")]
        public async Task<ActionResult<UserTokenDTO>> GetToken(string username, string password)
        {
            var user = await appManagerContext.Customers
            .Where(u => u.Username == username && u.Password == password)
            .FirstOrDefaultAsync();
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Invalid username or password.");
            }
            return Ok(new UserTokenDTO
            {
                Token = TokenAuthorizationService.MakeToken(username,password),
                UserId = user.Id,
            });
        }
        //بررسی میکنیم اشتراکی با آیدی کاربر و آیدی اپلیکیشن وجود دارد
        //[BasicAuthenticationFilter]
        [HttpGet("CheckLicence")]
        public ActionResult<LicenceCheckResultDTO> CheckLicence(long CustomerId,long ApplicationId,string DeviceCode,string DeviceModel,string AppVersionCode)
        {

            var subscription= appManagerContext.Subscriptions
             .Where(ua => ua.CustomerId == CustomerId && ua.ApplicationTypeId== ApplicationId && ua.EndTime>DateTime.Now && ua.StartTime<DateTime.Now && ua.IsActive==true)
             .FirstOrDefault();

            if (subscription == null)
            {
                return NotFound(new LicenceCheckResultDTO { Message=".اشتراک ندارید"});
            }
            // اطلاعات ورود را در جدول اکتیویتی ذخیره میکنیم
            var activity = appManagerContext.SubscriptionActivities.FirstOrDefault(x => x.SubscriptionId == subscription.Id && x.DeviceCode == DeviceCode);
            if (activity != null)
            {
                activity.LastUseTime = DateTime.Now;
                activity.VersionCode = AppVersionCode;
                activity.DeviceModel = DeviceModel;
                activity.DeviceCode = DeviceCode;
                appManagerContext.SubscriptionActivities.Update(activity);
            }
            else
            {
                var newActivity = new SubscriptionActivity {SubscriptionId=subscription.Id,DeviceCode=DeviceCode,DeviceModel=DeviceModel,VersionCode=AppVersionCode };
                appManagerContext.SubscriptionActivities.Add(newActivity);
            }
            appManagerContext.SaveChanges();
            //---------------------------------------------
            TimeSpan difference = subscription.EndTime.Subtract(DateTime.Now);
            return Ok(new LicenceCheckResultDTO {
            Message = ".اشتراک فعال دارید",
            DateRemainig= difference.Days
            });
            
        }

    }
}
