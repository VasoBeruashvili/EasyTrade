using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using EasyTrade.Models;
using EasyTrade.Utils;
using System.Data.SqlClient;

namespace EasyTrade.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.title = Resources.Translator.SignIn;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                int? userId = AuthorizeUser(user.UserName, user.Password);

                if (userId.HasValue)
                {
                    Session.Add("currentUser", new User { Id = userId.Value });
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ViewBag.Error = Resources.Translator.IncorrectUsernameOrPassword;
                    return View("login");
                }
            }
            else
            {
                ViewBag.Error = Resources.Translator.RequiredUsernameAndPassword;
                return View("login");
            }
        }

        int? AuthorizeUser(string userName, string password)
        {
            using (NTContext _nt = new NTContext())
            {
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                    new SqlParameter { ParameterName = "@userName", Value = userName },
                    new SqlParameter { ParameterName = "@password", Value = HashHelper.Calc(password) }
                };

                int? userId = _nt.GetScalar<int>("SELECT u.id FROM acc.Users AS u WHERE @userName = u.username AND @password = u.password", sqlParams);

                return userId;
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("currentUser");
            return RedirectToAction("login", "account");
        }
    }
}