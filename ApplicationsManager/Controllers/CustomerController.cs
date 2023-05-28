using Api.Endpoint.Helpers.Authorizations;
using ApplicationsManager.DTO;
using ApplicationsManager.Entitiy;
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

        //[BasicAuthenticationFilter(UserRole.Admin)]
        [HttpGet("GetAllCutomers")]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await appManagerContext.Customers.ToListAsync());

        }
        // کاربر توکن خود را دریافت میکند. یعنی ورود موفقیت آمیز بوده است
        //[HttpGet("GetToken")]
        //public async Task<ActionResult<UserTokenDTO>> GetToken(string username, string password)
        //{
        //    var user = await appManagerContext.Customers
        //    .Where(u => u.Username == username && u.Password == password)
        //    .FirstOrDefaultAsync();
        //    if (user == null)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, "Invalid username or password.");
        //    }
        //    return Ok(new CustomerDTO
        //    {
        //        //Token = TokenAuthorizationService.MakeToken(username,password),
        //        Token = "fdgdfg",
        //        UserId = user.Id,
        //    });
        //}

        // [BasicAuthenticationFilter(UserRole.Admin)]
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer, string deviceCode, string appId)

        {

            Customer foundCustomer = appManagerContext.Customers.FirstOrDefault(e => e.OwnerName == customer.OwnerName && e.MarketName == customer.MarketName && e.State == customer.City && e.City == customer.City);

            if (foundCustomer == null)
            {
                if (appManagerContext.Subscriptions.Any(e => deviceCode == deviceCode && e.AppEName == appId && e.IsActive == true))
                {
                    BadRequest("دسنگاه فعالی برای این کاربر و این اپلیکیشن وجود دارد");
                }
                appManagerContext.Customers.Add(customer);


                Subscription subscription = new Subscription() { AppEName = appId, DeviceId = deviceCode, CustomerId = customer.Id, CreatedDate = new DateTime(), EndTime = DateTime.UtcNow.AddDays(30), IsActive = true };

                appManagerContext.Subscriptions.Add(subscription);
                appManagerContext.SaveChanges();
                return Ok();
            }
            else
            {
                List<Subscription> subscriptions = appManagerContext.Subscriptions.Where(e => e.DeviceId == deviceCode && e.AppEName == appId).ToList();
                if (subscriptions != null)
                {
                    Subscription subscription1 = subscriptions.FirstOrDefault((e => e.IsActive == true));
                    if (subscription1 != null)
                    {
                        if (subscription1.CustomerId == foundCustomer.Id)
                        {
                            if (subscription1.StartTime < DateTime.UtcNow && subscription1.EndTime > DateTime.UtcNow)
                            {
                                return Ok(foundCustomer.Id);

                            }
                            else
                            {
                                return BadRequest("زمان اشتراک به پایان رسیده است");
                            }
                        }
                        else return BadRequest("این دستگاه برای این اپلیکیشن برای کاربر دیگر فعال است");

                    }
                    else
                    {
                        if (appManagerContext.Subscriptions.Any((e => e.DeviceId == deviceCode && e.CustomerId == foundCustomer.Id && e.AppEName == appId && e.IsActive == false)))
                        {
                            BadRequest("این دستگاه برای این اپلیکیشن غیر فعال است");
                        }

                    }

                    appManagerContext.Subscriptions.Add(new Subscription() { AppEName = appId, DeviceId = deviceCode, CustomerId = foundCustomer.Id, CreatedDate = DateTime.UtcNow, PlanId = 1, StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow.AddDays(10), IsActive = true });
                    appManagerContext.SaveChanges();
                    return Ok(foundCustomer.Id);
                }

                return Ok(foundCustomer.Id);

            }

        }
        //  بررسی میکنیم اشتراکی با آیدی کاربر و آیدی اپلیکیشن وجود دارد
        //  [BasicAuthenticationFilter]
        [HttpGet("CheckLicence")]
        public ActionResult<LicenceCheckResultDTO> CheckLicence(Guid CustomerId, string appId, string DeviceCode, string DeviceModel, string AppVersionCode)
        {

            var subscription = appManagerContext.Subscriptions
             .Where(ua => ua.CustomerId == CustomerId && ua.AppEName == appId && ua.DeviceId == DeviceCode && ua.EndTime > DateTime.Now && ua.StartTime < DateTime.Now && ua.IsActive == true)
             .FirstOrDefault();

            if (subscription == null)
            {
                return NotFound(new LicenceCheckResultDTO { Message = ".اشتراک ندارید" });
            }
            ////  اطلاعات ورود را در جدول اکتیویتی ذخیره میکنیم
            //  var activity = appManagerContext.SubscriptionActivities.FirstOrDefault(x => x.SubscriptionId == subscription.Id && x.DeviceCode == DeviceCode);
            //  if (activity != null)
            //  {
            //      activity.LastUseTime = DateTime.Now;
            //      activity.VersionCode = AppVersionCode;
            //      activity.DeviceModel = DeviceModel;
            //      activity.DeviceCode = DeviceCode;
            //      appManagerContext.SubscriptionActivities.Update(activity);
            //  }
            //  else
            //  {
            //      var newActivity = new SubscriptionActivity { SubscriptionId = subscription.Id, DeviceCode = DeviceCode, DeviceModel = DeviceModel, VersionCode = AppVersionCode };
            //      appManagerContext.SubscriptionActivities.Add(newActivity);
            //  }
            //  appManagerContext.SaveChanges();
            //---------------------------------------------
            TimeSpan difference = subscription.EndTime.Subtract(DateTime.Now);

            return Ok(new LicenceCheckResultDTO
            {
                Message = ".اشتراک فعال دارید",
                DateRemainig = difference.Days
            });

        }

        [HttpGet("{customerId}/subscription")]
        public IActionResult GetCustomerSubscription(Guid customerId)
        {
            var app = appManagerContext.Customers.Include(a => a.Subscriptions)
                .ThenInclude(a => a.applicationType)
                                .Include(a => a.Subscriptions)
                .ThenInclude(a => a.SubscriptionPlan)

                                  .SingleOrDefault(a => a.Id == customerId);

            if (app == null)
            {
                return NotFound(); // مشتری مورد نظر یافت نشد
            }
            var subList = app.Subscriptions.Select(a => new SubscriptionDTO
            {
                Id = a.Id,
                CustomerId = a.CustomerId,
                AppEName = a.AppEName,
                AppName=a.applicationType.Name,
                PlanName=a.SubscriptionPlan.Name,  
                StartTime = ((DateTimeOffset)a.StartTime).ToUnixTimeSeconds(),
                EndTime = ((DateTimeOffset)a.EndTime).ToUnixTimeSeconds(),
                DeviceId = a.DeviceId,
                IsActive = a.IsActive,
                PlanId = a.PlanId 
            });

            return Ok(subList); // بازگشت لیست اشتراک ها
        }
        [HttpPut("Subscription/{subscriptionId}")]
        public IActionResult UpdateSubscription(long subscriptionId, Guid userId, Subscription updatedSubsciption)
        {
            var existingSubscription = appManagerContext.Subscriptions.Find(subscriptionId);

            if (existingSubscription == null)
            {
                return NotFound(); // برنامه مورد نظر یافت نشد
            }

            existingSubscription.AppEName = updatedSubsciption.AppEName;
            existingSubscription.PlanId = updatedSubsciption.PlanId;
            existingSubscription.StartTime = updatedSubsciption.StartTime;
            existingSubscription.EndTime = updatedSubsciption.EndTime;
            existingSubscription.IsActive = updatedSubsciption.IsActive;

            // آپدیت سایر خصوصیات برنامه

            appManagerContext.SaveChanges();

            return Ok(existingSubscription); // بازگشت نتیجه موفقیت‌آمیز به همراه اطلاعات برنامه آپدیت شده
        }
        [HttpGet("GetSubscription")]
        public IActionResult GetSubscription(long subscriptionId)
        {
            Subscription subscription1 = appManagerContext.Subscriptions.FirstOrDefault((e => e.Id == subscriptionId));


            if (subscription1 == null)
            {
                return NotFound(); // اشتراک مورد نظر یافت نشد
            }

            return Ok(subscription1); // بازگشت  اشتراک 
        }

    }
}
