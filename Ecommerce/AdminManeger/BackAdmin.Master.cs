using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.AdminManeger
{
    public partial class BackAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null) // בדיקה האם המשתמש מזוהה ומוכר במערכת
            {
                Response.Redirect("/Login.aspx");
            }
        }
    }
}