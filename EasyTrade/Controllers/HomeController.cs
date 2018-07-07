using EasyTrade.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyTrade.Controllers
{
    [ValidateUserFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.title = Resources.Translator.Main;

            return View();
        }        
    }
}