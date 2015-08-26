using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Web.Script.Serialization;

namespace Infrastructure.Utility
{
    public static class JsonHelper
    {
        public static String ToJSON(this object obj)
        {
            JavaScriptSerializer serizlizer = new JavaScriptSerializer();
            return serizlizer.Serialize(obj);
        }

        public static String ToJSON(this object obj, Int32 recursionDepth)
        {
            JavaScriptSerializer serizlizer = new JavaScriptSerializer();
            serizlizer.RecursionLimit = recursionDepth;
            return serizlizer.Serialize(obj);
        }
    }
}
