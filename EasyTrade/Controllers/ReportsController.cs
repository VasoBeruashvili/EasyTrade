using EasyTrade.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyTrade.Controllers
{
    [ValidateUserFilter]
    public class ReportsController : BaseController
    {
        public ActionResult Received_Goods()
        {
            ViewBag.title = Resources.Translator.ReceivedGoods;

            return View();
        }

        public ActionResult Realized_Goods()
        {
            ViewBag.title = Resources.Translator.RealizedGoods;

            return View();
        }

        public ActionResult Balance_Of_Goods()
        {
            ViewBag.title = Resources.Translator.BalanceOfGoods;

            return View();
        }
    }
}