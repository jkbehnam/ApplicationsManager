using ApplicationsManager.Entitiy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReadRasisToken;
using System.Globalization;
using System.Security.Principal;

namespace Api.Endpoint.Helpers.Authorizations
{
    public class BasicAuthenticationFilter : Attribute, IActionFilter
    {
  

        public BasicAuthenticationFilter(UserRole role)
        {
            Role = role;
        }

    
        public UserRole Role { get; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string? authenticationToken = context.HttpContext.Request.Headers["UniqCode"].FirstOrDefault();
                if (authenticationToken == null)
                {
                    context.Result = new NotFoundObjectResult("404 Page Not Found");
                }
                else
                {
                    string ApiKey1 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("XkV0ah8QIKnXZaG9yqtpUYY2JYlbG8X1+lBUvUEZAA3rW/MTnSBGlOxNfUE8Ps8Y");
                    string ApiKey2 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("5GtSf+hyrORIvhDHu7E2kBnV55RX8TKp");
                    string ApiKey3 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("he4aG0Aqs1Bbqojv8W0lTNGvtznle+DawyRlc3DRoo5ZRQg/qzCb1A==");

                    CryptLib cptLib = new CryptLib();
                    RasisKeyRead rasisKS = new RasisKeyRead(ApiKey1, ApiKey2, ApiKey3);
                    string DecToken = rasisKS.DecodeToken(authenticationToken);
                    //DecToken Samiiiiiiiiiiiiiiii log bezen
                    if (DecToken == "-1")
                    {
                        context.Result = new NotFoundObjectResult("404 Page Not Found"); ;
                    }
                    else
                    {
                        string[] tokenParts = DecToken.Split(new string[] { "#00-11#aa-bb" }, StringSplitOptions.None);
                        if (tokenParts.Length == 10)
                        {
                            if (cptLib.GHS("rasis software developers from kerman", 20).Equals(tokenParts[9]))
                            {
                                if (tokenParts[8] != "")
                                {
                                    CultureInfo culture2 = new CultureInfo("en-US");
                                    string tokenDate = tokenParts[8];
                                    string currentDateAndTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss", culture2);
                                    DateTime myDate1 = DateTime.ParseExact(tokenDate, "yyyy.MM.dd HH:mm:ss", culture2);
                                    DateTime myDate2 = DateTime.ParseExact(currentDateAndTime, "yyyy.MM.dd HH:mm:ss", culture2);
                                    TimeSpan ts = myDate2 - myDate1;
                                    if (ts.Minutes >= 0 && ts.Minutes <= 1)
                                    {
                                        if (tokenParts[0] == "version1")//نجمه در کاله استفاده کرده و یوزر و پسورد چک نمی شود
                                            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(authenticationToken), null);
                                        else if (tokenParts[0] == "version2")//برای حالتی که یوزر و پسورد نیاز هست چک شود استفاده شود.
                                        {
                                            string user = tokenParts[3];
                                            string pass = tokenParts[4];
                                            if (UPCheck.Login(user, pass,Role))
                                            {
                                                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(authenticationToken), null);
                                            }
                                            else
                                            {
                                                context.Result = new NotFoundObjectResult("403 Page Not Found"); ;
                                            }
                                        }
                                        else if (tokenParts[0] == "version3")//در سفارش گیر راهکار توسعه استفاده شده است و در این حالت یوزر و پسورد چک نمی شود.
                                        {
                                            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(authenticationToken), null);
                                        }
                                        else
                                        {
                                            context.Result = new NotFoundObjectResult("404 Page Not Found"); ;
                                        }
                                    }
                                    else
                                    {
                                        context.Result = new NotFoundObjectResult("404 Page Not Found"); ;
                                    }
                                }
                                else
                                {
                                    context.Result = new NotFoundObjectResult("404 Page Not Found"); ;
                                }
                            }
                            else
                            {
                                context.Result = new NotFoundObjectResult("404 Page Not Found"); ;
                            }
                        }
                        else
                        {
                            context.Result = new NotFoundObjectResult("404 Page Not Found"); ;
                        }
                    }
                }
            }
            catch (Exception)
            {
                context.Result = new NotFoundObjectResult("404 Page Not Found"); ;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
