using EasyTrade.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyTrade.Controllers
{
    [ValidateUserFilter]
    public class SettingsController : BaseController
    {
        public ActionResult Users()
        {
            ViewBag.title = Resources.Translator.Users;

            return View();
        }

        public ActionResult Company_Requisites()
        {
            ViewBag.title = Resources.Translator.CompanyRequisites;

            return View();
        }
    }
}