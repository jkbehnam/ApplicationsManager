using Api.Endpoint.Helpers.Authorizations;
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
        [HttpGet("getApplication")]
        public async Task<ActionResult<ApplicationType>> GetApplication(long appId)
        {



            var application = await appManagerContext.ApplicationTypes
            .Where(u => u.Id == appId)
            .Include(u => u.ApplicationVersions)
            .FirstOrDefaultAsync();


            if (application == null)
            {
                // throw new InvalidOperationException("Invalid username or password.");
                return StatusCode(StatusCodes.Status404NotFound, "Invalid application code.");
            }
            return Ok(application);
        }

        [HttpGet("getAllApplications")]
        public async Task<ActionResult> GetAllApplications()
        {

            var appsWithHighestVersion = appManagerContext.ApplicationTypes
            .Include(app => app.ApplicationVersions)  // بارگیری رابطه AppVersions برای هر App
    .Select(app => new
    {
        Id = app.Id,
        AppName = app.Name,
        AppEName = app.AppEName,
        LatestVersionReleaseDate = new DateTimeOffset(app.ApplicationVersions.Any() ? app.ApplicationVersions.OrderByDescending(u => u.ReleaseDate).FirstOrDefault().ReleaseDate : DateTime.UtcNow).ToUnixTimeSeconds(),

        LatestVersionName = app.ApplicationVersions.Any() ? app.ApplicationVersions.OrderByDescending(u => u.ReleaseDate).FirstOrDefault().name : "",

    })
    .ToList();

            //   var application = await appManagerContext.ApplicationTypes.ToListAsync();


            if (appsWithHighestVersion == null)
            {
                // throw new InvalidOperationException("Invalid username or password.");
                return StatusCode(StatusCodes.Status404NotFound, "Invalid application code.");
            }
            return Ok(appsWithHighestVersion);
        }

        //[BasicAuthenticationFilter(UserRole.Admin)]
        [HttpPost]
        public IActionResult CreateApp(ApplicationType app, string userId)
        {


            appManagerContext.ApplicationTypes.Add(app);
            appManagerContext.SaveChanges();

            return Ok(app); // بازگشت نتیجه موفقیت‌آمیز به همراه اطلاعات برنامه ایجاد شده


        }
        [HttpPut("{id}")]
        public IActionResult UpdateApp(int id, ApplicationType updatedApp)
        {
            var existingApp = appManagerContext.ApplicationTypes.Find(id);

            if (existingApp == null)
            {
                return NotFound(); // برنامه مورد نظر یافت نشد
            }

            existingApp.Name = updatedApp.Name;
            existingApp.Description = updatedApp.Description;
            // آپدیت سایر خصوصیات برنامه

            appManagerContext.SaveChanges();

            return Ok(existingApp); // بازگشت نتیجه موفقیت‌آمیز به همراه اطلاعات برنامه آپدیت شده
        }
        [HttpPost("{appId}/versions")]
        public IActionResult CreateAppVersion(string appId, ApplicationVersion newVersion)
        {
            var existingApp = appManagerContext.ApplicationTypes.Find(appId);

            if (existingApp == null)
            {
                return NotFound(); // برنامه مورد نظر یافت نشد
            }

            // تنظیم مقادیر جدید برای نسخه برنامه
            var version = new ApplicationVersion
            {
                ApplicationEName = appId,
                code = newVersion.code,
                name = newVersion.name,
                IsCritical = newVersion.IsCritical,
                ReleaseDate = newVersion.ReleaseDate,
                // تنظیم سایر خصوصیات نسخه برنامه
            };

            appManagerContext.ApplicationVersions.Add(version);
            appManagerContext.SaveChanges();

            return Ok(version); // بازگشت نتیجه موفقیت‌آمیز به همراه اطلاعات نسخه جدید
        }
        [HttpGet("{appId}/versions")]
        public IActionResult GetAppVersions(int appId)
        {
            var app = appManagerContext.ApplicationTypes.Include(a => a.ApplicationVersions)
                                  .SingleOrDefault(a => a.Id == appId);

            if (app == null)
            {
                return NotFound(); // برنامه مورد نظر یافت نشد
            }

            return Ok(app.ApplicationVersions); // بازگشت لیست نسخه‌های برنامه
        }
        [HttpDelete("{appId}/versions/{versionId}")]
        public IActionResult DeleteAppVersion(int appId, int versionId)
        {
            var app = appManagerContext.ApplicationTypes.Include(a => a.ApplicationVersions)
                                  .SingleOrDefault(a => a.Id == appId);

            if (app == null)
            {
                return NotFound(); // برنامه مورد نظر یافت نشد
            }

            var version = app.ApplicationVersions.SingleOrDefault(v => v.Id == versionId);

            if (version == null)
            {
                return NotFound(); // نسخه مورد نظر یافت نشد
            }

            appManagerContext.ApplicationVersions.Remove(version);
            appManagerContext.SaveChanges();

            return NoContent(); // بازگشتی بدون محتوا به عنوان نتیجه موفقیت‌آمیز
        }
        [HttpPut("{appId}/versions/{versionId}")]
        public IActionResult UpdateAppVersion(int appId, int versionId, ApplicationVersion updatedVersion)
        {
            var app = appManagerContext.ApplicationTypes.Include(a => a.ApplicationVersions)
                                  .SingleOrDefault(a => a.Id == appId);

            if (app == null)
            {
                return NotFound(); // برنامه مورد نظر یافت نشد
            }

            var version = app.ApplicationVersions.SingleOrDefault(v => v.Id == versionId);

            if (version == null)
            {
                return NotFound(); // نسخه مورد نظر یافت نشد
            }

            // اعمال تغییرات در نسخه برنامه
            version.code = updatedVersion.code;
            version.ReleaseDate = updatedVersion.ReleaseDate;
            // اعمال سایر تغییرات مورد نیاز

            appManagerContext.SaveChanges();

            return Ok(version); // بازگشت نتیجه موفقیت‌آمیز به همراه نسخه بروزرسانی شده
        }

    }
}
