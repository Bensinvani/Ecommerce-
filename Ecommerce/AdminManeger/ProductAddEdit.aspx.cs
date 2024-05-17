using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.AdminManeger
{
    public partial class prodAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Pid = Request["Pid"] + "";
                if(string.IsNullOrEmpty(Pid))
                {
                    Pid = "-1";
                }
                else
                {
                    int pid = int.Parse(Pid); // המרה של המשתנה למספר שלם, לצורך חיפוש במאגר המוצרים

                    List<Product> LstProd = (List<Product>)Application["Products"];

                    for (int i = 0; i < LstProd.Count; i++)
                    {
                        if (LstProd[i].Pid == pid)
                        {
                            TxtPname.Text = LstProd[i].Pname;
                            TxtPrice.Text = LstProd[i].Price + "";
                            TxtPdesc.Text = LstProd[i].Pdesc;
                            TxtPicname.Text = LstProd[i].Picname;
                            HidPid.Value = Pid;
                        }
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string Sql = "";
            if (HidPid.Value == "-1") // הוספת מוצר חדש
            {
                Sql = "INSERT INTO T_Product (Pname, Price, Pdesc, Picname) VALUES ";
                Sql += $"(N'{TxtPname.Text}', {TxtPrice.Text}, N'{TxtPdesc.Text}', N'{TxtPicname.Text}')";
            }
            else
            {
                Sql = "UPDATE T_Product SET ";
                Sql += $"Pname = N'{TxtPname.Text}', ";
                Sql += $"Price = {TxtPrice.Text}, ";
                Sql += $"Pdesc = N'{TxtPdesc.Text}', ";
                Sql += $"Picname = N'{TxtPicname.Text}' ";
                Sql += $"WHERE Pid = {HidPid.Value}";
            }

            string ConnStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString; // שליפת מחרוזת ההתחברות מתוך קובץ הגדרות האפליקציה / שרת web.config

            SqlConnection Conn = new SqlConnection(ConnStr); // יצירת אובייקט מסוג צינור והגדרת מחרוזת ההתחברות של הצינור לבסיס הנתונים 

            Conn.Open(); // פתיחת הצינור לבסיס הנתונים

            SqlCommand Cmd = new SqlCommand(Sql, Conn);

            Cmd.ExecuteNonQuery(); // הפעלת השאילתה שלא מחזירה נתונים כלומר מחזירה אינסרט או אפדייט

            List<Product> LstProd = new List<Product>(); // טעינה מחודשת של רשימת המוצרים אל האפליקשיין

            Sql = "SELECT * FROM T_Product";

            Cmd.CommandText = Sql;

            SqlDataReader Dr = Cmd.ExecuteReader();
            while (Dr.Read())
            {
                Product Tmp = new Product()
                {
                    Pid = int.Parse(Dr["Pid"].ToString()),
                    Pname = Dr["Pname"].ToString(),
                    Price = float.Parse(Dr["Price"].ToString()),
                    Pdesc = Dr["Pdesc"].ToString(),
                    Picname = Dr["Picname"].ToString(),
                };
                LstProd.Add(Tmp); // הוספת המוצר לרשימת המוצרים
            }
            Application["Products"] = LstProd; // שמירת רשימת המוצרים באפליקשיין

            Conn.Close();

            // Feedback to the user
            Response.Write("<script>alert('Product saved successfully');</script>");

            Response.Redirect("/ProductList.aspx");

        }
    }
}