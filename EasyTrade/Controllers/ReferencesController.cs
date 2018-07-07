using EasyTrade.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyTrade.Controllers
{
    [ValidateUserFilter]
    public class ReferencesController : BaseController
    {
        public ActionResult Goods()
        {
            ViewBag.title = Resources.Translator.Goods;

            return View();
        }

        public ActionResult Suppliers()
        {
            ViewBag.title = Resources.Translator.Suppliers;

            return View();
        }

        public ActionResult Buyers()
        {
            ViewBag.title = Resources.Translator.Buyers;

            return View();
        }

        public ActionResult Staff()
        {
            ViewBag.title = Resources.Translator.Staff;

            return View();
        }

        public ActionResult Warehouses_and_Shops()
        {
            ViewBag.title = Resources.Translator.WarehousesAndShops;

            return View();
        }
    }
}