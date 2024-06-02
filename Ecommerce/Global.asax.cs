using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data; // זה בשביל קורא הנתונים
using System.Data.SqlClient;
using Ecommerce.App_Code; // זה בשביל האובייקטים לעבודה מול בסיס הנתונים
using System.Configuration; // שימוש בספריית הקונפגורציה של חיבור המחרוזת
using DATA;
using Ecommerce.App_Code.BLL;
using System.Web.UI;

namespace Ecommerce
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["Products"] = Product.GetAll(); // שמירת רשימת המוצרים באפליקציה
            Application["Clients"] = Client.GetAll(); // שמירת רשימת הלקוחות באפליקציה
            Application["Categories"] = Category.GetAll(); // שמירת רשימת הקטגוריות באפליקציה
            Application["Cities"] = City.GetAll(); // שמירת רשימת הערים באפליקציה

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-3.6.0.min.js",
                DebugPath = "~/scripts/jquery-3.6.0.js",
                CdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js",
                CdnDebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });

            //============= קוד לדוגמה שהתחלנו בכיתה עם נתונים פיקטיביים ===========//
            /*Product p; // יצירת משתנה ייחוס מסוג מוצר
            List<Product> LstProd = new List<Product>(); // יצירת רשימה של המוצרים

            string ConnStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString; // שליפת מחרוזת ההתחברות מתוך קובץ הגדרות האפליקציה / שרת web.config
            SqlConnection Conn = new SqlConnection(ConnStr); // יצירת אובייקט מסוג צינור והגדרת מחרוזת ההתחברות של הצינור לבסיס הנתונים 

            //Conn.ConnectionString = ConnStr; // הגדרת מחרוזת ההתחברות לאחר יצירת האובייקט, זו אופציה נוספת להגדרה

            Conn.Open(); // פתיחת הצינור לבסיס הנתונים

            string Sql = "SELECT * FROM T_Product";

            SqlCommand Cmd = new SqlCommand(Sql, Conn);

            //Cmd.Connection = Conn;
            //Cmd.CommandText = Sql;

            SqlDataReader Dr = null;

            Dr = Cmd.ExecuteReader(); // הפעלת השאילתה וקבלת תוצאות השאילתה לתוך אובייקט קורא נתונים 

            while (Dr.Read())
            {
                p = new Product()
                {
                    Pid = int.Parse(Dr["Pid"] + ""),
                    Pname = Dr["Pname"] + "",
                    Price = float.Parse(Dr["Price"] + ""),
                    Pdesc = Dr["Pdesc"] + "",
                    Picname = Dr["Picname"] + ""
                };
                LstProd.Add(p); // הוספת המוצר לרשימת המוצרים
            }
            Application["Products"] = LstProd; // שמירת רשימת המוצרים באפליקשיין

            // הוספה חדשה של טבלה של יצרתי בשביל היוזרים 
            List<Client> LstClient = new List<Client>();  // רשימה של היוזרים 

            string clientSql = "SELECT * FROM T_Client";  // שאילתת sql לצורך שליפת כל המשתמשים

            SqlCommand clientCmd = new SqlCommand(clientSql, Conn); // משתנה חדש שמקבל את האובייקט של טבלת המשתמשים עם החיבור לצינור

            SqlDataReader clientDr = clientCmd.ExecuteReader();  // // הפעלת השאילתה וקבלת תוצאות השאילתה לתוך אובייקט קורא נתונים 

            while (clientDr.Read())
            {
                var client = new Client()
                {
                    ClientId = int.Parse(clientDr["ClientId"].ToString()),
                    ClientFirstName = clientDr["ClientFirstName"].ToString(),
                    ClientLastName = clientDr["ClientLastName"].ToString(),
                    ClientAddress = clientDr["ClientAddress"].ToString(),
                    ClientCity = clientDr["ClientCity"].ToString(),
                    ClientPhone = clientDr["ClientPhone"].ToString(),
                    ClientEmail = clientDr["ClientEmail"].ToString(),
                    ClientPassword = clientDr["ClientPassword"].ToString(),
                    ClientStatus = clientDr["ClientStatus"].ToString(),
                    ClientPic = clientDr["ClientPic"].ToString(),
                    ClientAddedDate = DateTime.Parse(clientDr["ClientAddedDate"].ToString())
                };
                LstClient.Add(client);  // // הוספת הלקוח לרשימת הלקוחות
            }

            Application["Clients"] = LstClient; // שמירת רשימת הלקוחות באפליקשיין





            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Pid = 1,
                Pname = "Apple Iphone 15",
                Price = 600,
                Pdesc = "Iphone 15 Black",
                Picname = "iphone15_black.jpg",
                Cid = 1,
                Status = "Instock",
                AddDate = DateTime.Now,
            });
            products.Add(new Product()
            {
                Pid = 2,
                Pname = "Apple Iphone 14",
                Price = 300,
                Pdesc = "Iphone 14 White",
                Picname = "iphone14_white.jpg",
                Cid = 2,
                Status = "Instock",
                AddDate = DateTime.Now
            });
            products.Add(new Product()
            {
                Pid = 3,
                Pname = "Apple Iphone 15",
                Price = 700,
                Pdesc = "Iphone 15 Green",
                Picname = "iphone15_green.jpg",
                Cid = 3,
                Status = "Instock",
                AddDate = DateTime.Now
            });

            Application["Products"] = products;

            List<Category> categories = new List<Category>();
            categories.Add(new Category()
            {
                Cid = 1,
                Cname = "Electronics",
                Cdesc = "All electronic products",
                Picname = "electronics.jpg",
                ParentCid = 0, 
                Status = "Active",
                AddDate = "19/04/2024"
            });
            categories.Add(new Category()
            {
                Cid = 2,
                Cname = "Home Appliances",
                Cdesc = "Various home appliances",
                Picname = "home_appliances.jpg",
                ParentCid = 0,
                Status = "Active",
                AddDate = "20/04/2024"
            });

            Application["Categories"] = categories;


            Conn.Close(); // סגירת הצינור לבסיס הנתונים*/
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}