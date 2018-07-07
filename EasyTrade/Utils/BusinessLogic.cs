using EasyTrade.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EasyTrade.Utils
{
    public class BusinessLogic
    {
        public List<LeftMenuItem> GetLeftMenuItems()
        {
            using (NTContext _nt = new NTContext())
            {
                List<LeftMenuItem> rootLeftMenuItem = _nt.GetList<LeftMenuItem>("SELECT id, name, url, parent_id AS parentId, level_class AS levelClass, icon_class AS iconClass FROM cfg.LeftMenuItems WHERE parent_id IS NULL ORDER BY index_number");
                if (rootLeftMenuItem != null)
                {
                    rootLeftMenuItem.ForEach(rlmi =>
                    {
                        rlmi.Children = FillLeftMenuItemChildren(rlmi.Id);
                    });
                }

                return rootLeftMenuItem;
            }
        }

        List<LeftMenuItem> FillLeftMenuItemChildren(int id)
        {
            using (NTContext _nt = new NTContext())
            {
                List<LeftMenuItem> leftMenuItems = _nt.GetList<LeftMenuItem>("SELECT id, name, url, parent_id AS parentId, level_class AS levelClass, icon_class AS iconClass FROM cfg.LeftMenuItems WHERE parent_id = @parentId ORDER BY index_number", new SqlParameter() { ParameterName = "@parentId", Value = id });

                if (leftMenuItems != null)
                {
                    leftMenuItems.ForEach(lmi =>
                    {
                        lmi.Children = FillLeftMenuItemChildren(lmi.Id);
                    });
                }

                return leftMenuItems;
            }
        }

        public string GetCurrentLanguage()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];
            return cookie != null && !string.IsNullOrEmpty(cookie.Value) ? cookie.Value : "ge";
        }
    }
}