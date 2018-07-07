using EasyTrade.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyTrade.Controllers
{
    [ValidateUserFilter]
    public class OperationsController : BaseController
    {
        public ActionResult Receive_Goods()
        {
            ViewBag.title = Resources.Translator.ReceiveGoods;

            return View();
        }

        public ActionResult Realization_Goods()
        {
            ViewBag.title = Resources.Translator.RealizationGoods;

            return View();
        }
    }
}