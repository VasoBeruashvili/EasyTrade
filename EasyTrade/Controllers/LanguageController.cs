using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using EasyTrade.Utils;

namespace EasyTrade.Controllers
{
    public class LanguageController : BaseController
    {      
        public ActionResult Change(string lang)
        {                       
            if (!string.IsNullOrEmpty(lang))
            {
                HttpCookie currentLanguage = Request.Cookies["Language"];

                if(currentLanguage != null && !string.IsNullOrEmpty(currentLanguage.Value))
                {
                    if (lang != currentLanguage.Value)
                    {
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

                        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(lang);                                            
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ka-GE");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ka-GE");

                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("ka-GE");
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("ka-GE");                    
                }

                HttpCookie cookie = new HttpCookie("Language");
                cookie.Value = lang;
                cookie.Expires.AddYears(100);
                Response.Cookies.Add(cookie);
            }           

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}