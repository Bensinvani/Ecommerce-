using Ecommerce.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            List<Client> LstClient = (List<Client>)Application["Clients"];//הגדרת רשימה עבור לקוחות

            string Email = TxtEmail.Text;
            string Pass = TxtPass.Text;
            for (int i = 0; i < LstClient.Count; i++)//מעבר על כל רשימת הלקוחות
            {
                //אם נמצא לקוח עם המייל והסיסמה , אז צור משתנה מסוג סשן ושמור בתוכו את האובייקט של הלקוח
                if (LstClient[i].ClientEmail == Email && LstClient[i].ClientPassword == Pass)
                {
                    //ניצור משתנה מסוג סשן ונשמור בתוכו את האובייקט של המשתמש
                    Session["Login"] = LstClient[i];
                    //נעביר את הגולש לעמוד רשימת מוצרים
                    Response.Redirect("/AdminManeger");
                }

            }
            LtlMsg.Text = "שם וסיסמה אינם תקינים";
        }
    }
}