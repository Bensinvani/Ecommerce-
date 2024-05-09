using BLL;
using Ecommerce.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.AdminManeger.AdminPages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // מדובר בטעינה ראשונה של העמוד
            {
                // נשלוף את רשימת הלקוחות מתוך האפליקשיין
                // נקשר את רשימת הלקוחות לפקד רפיטר
                // נבצע קשירה של הנתונים לפקד הריפטר באמצעות הפעלת הפונקציה
                // Bind()
                List<Client> LstClient;
                LstClient = (List<Client>)Application["Clients"];

                // קישור רשימת הלקוחות עם הריפטר
                RptClients.DataSource = LstClient;
                // עבור כל פריט במקור הנתונים , יתבצע שכפול של האייטם טמפלייט של הרשיפטר
                RptClients.DataBind(); //  קשירת הנתונים לריפטר 
            }
        }
    }
}