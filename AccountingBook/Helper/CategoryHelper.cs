using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingBook.Helper
{
    /// <summary>
    /// Category Helper
    /// </summary>
    public static class CategoryHelper
    {
        public static MvcHtmlString AccountingType(this HtmlHelper helper,string type)
        {
            string typeColor = string.Empty;
            if(type == "支出")
            {
                typeColor = @"<span style='color:red'>"+type+"</span>";
            }
            else
            {
                typeColor = @"<span style='color:blue'>" + type + "</span>";
            }

            return new MvcHtmlString(typeColor);
        }
    }
}