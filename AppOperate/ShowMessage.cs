using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppOperate
{
    public class ShowMessage
    {
        static string showMethod = "Show"; // 'Message" '"Page"
        public ShowMessage()
        { }
        public static void Exception(Exception ex, Page cPage, string actionType)
        {
            string show = ex.Message.Replace("'", " ");
            switch (showMethod)
            {
                case "Page":
                    WarningMessage(cPage, actionType + " " + show);
                    break;
                case "Message":
                    WarningMessage(cPage, actionType + " has error." + show);
                    break;
                default:
                    WarningMessage(cPage, actionType + " " + show);
                    break;
            }

        }
        static void WarningMessage(Page page, string msg)
        {
            string myUrl = "<script> window.alert('" + msg + "')</script>";
            page.Response.Write(myUrl);  //  Response.Write("<script>window.close()</script>")
        }
        static void CloseMe(Page page)
        {
            string myUrl = "<script>window.close()</script>";
            page.Response.Write(myUrl);//  '   Response.Write("<script>window.close()</script>")
        }
       
    }
}
