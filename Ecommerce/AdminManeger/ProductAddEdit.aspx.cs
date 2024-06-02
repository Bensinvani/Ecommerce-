using BLL;
using DAL;
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
        /*protected void Page_Load(object sender, EventArgs e)
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
                    
                    Product Tmp = Product.GetById(pid);

                    if(Tmp != null)
                    {
                        TxtPname.Text = Tmp.Pname;
                        TxtPrice.Text = Tmp.Price + "";
                        TxtPdesc.Text = Tmp.Pdesc;
                        ImgPicname.ImageUrl = "/images/products/" + Tmp.Picname;
                        HidPid.Value = Pid;
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string Picname = "";
            // נבדוק האם נבחר קובץ תמונה
            if (UploadPic.HasFile)
            {
                // נשמור את קובץ התמונה בתייקת התמונות תחת שם חדש שנייצר בעצמנו
                // נעדכן את השדה שם תמונה שישמר בבסיס הנתונים
                Picname = GlobFunc.GetRandStr(8);
                // "abcdefgh" + ""
                string OriginFileName = UploadPic.FileName;

                string Ext = OriginFileName.Substring(OriginFileName.LastIndexOf('.')); // מציאת המיקום של התו נקודה האחרון עד הסוף

                Picname += Ext; // "abcdefgh.jpg"

                string FullPath = Server.MapPath("/images/products/"); // נתיב מלא של כל התקייה עד לנתיב שרוצים

                UploadPic.SaveAs(FullPath + Picname); // שמירת התמונה שהועלתה בשם שיצרנו עבורה

            }
            else
            {
                Picname = ImgPicname.ImageUrl.Substring(ImgPicname.ImageUrl.LastIndexOf('/') + 1);
            }
            string Sql = "";
            if (HidPid.Value == "-1") // הוספת מוצר חדש
            {
                Sql = "INSERT INTO T_Product (Pname, Price, Pdesc, Picname, AddDate) VALUES ";
                Sql += $"(N'{TxtPname.Text}', {TxtPrice.Text}, N'{TxtPdesc.Text}', N'{Picname}', GETDATE())";
            }
            else
            {
                Sql = "UPDATE T_Product SET ";
                Sql += $"Pname = N'{TxtPname.Text}', ";
                Sql += $"Price = {TxtPrice.Text}, ";
                Sql += $"Pdesc = N'{TxtPdesc.Text}', ";
                Sql += $"Picname = N'{Picname}' ";
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

        }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProduct();
            }
        }

        private void LoadCategories()
        {
            List<Category> categories = Category.GetAll();
            DdlCategory.DataSource = categories;
            DdlCategory.DataTextField = "Cname";
            DdlCategory.DataValueField = "Cid";
            DdlCategory.DataBind();
            DdlCategory.Items.Insert(0, new ListItem("בחר קטגוריה", ""));
        }

        private void LoadProduct()
        {
            string pidStr = Request.QueryString["Pid"];
            if (!string.IsNullOrEmpty(pidStr) && int.TryParse(pidStr, out int pid))
            {
                Product product = Product.GetById(pid);
                if (product != null)
                {
                    TxtPname.Text = product.Pname;
                    TxtPrice.Text = product.Price.ToString();
                    TxtPdesc.Text = product.Pdesc;
                    ImgPicname.ImageUrl = "/images/products/" + product.Picname;
                    HidPid.Value = pid.ToString();
                    DdlCategory.SelectedValue = product.Cid.ToString();
                    BtnDelete.Visible = true;
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string descText = TxtPdesc.Text.Trim();
            if (string.IsNullOrWhiteSpace(descText))
            {
                ReqPdesc.IsValid = false;
                return;
            }

            string picname = UploadPic.HasFile ? SaveImage(UploadPic) : ImgPicname.ImageUrl.Substring(ImgPicname.ImageUrl.LastIndexOf('/') + 1);
            int pid = int.Parse(HidPid.Value);
            int cid = int.Parse(DdlCategory.SelectedValue);

            Product product = new Product
            {
                Pid = pid,
                Pname = TxtPname.Text,
                Price = float.Parse(TxtPrice.Text),
                Pdesc = TxtPdesc.Text,
                Picname = picname,
                Cid = cid,
                Status = "קיים",
                AddDate = DateTime.Now
            };

            if (pid == -1)
            {
                ProductDAL.Insert(product);
            }
            else
            {
                ProductDAL.Update(product);
            }

            Application["Products"] = Product.GetAll();
            Response.Redirect("/ProductList.aspx");
        }

        private string SaveImage(FileUpload fileUpload)
        {
            string fileName = GlobFunc.GetRandStr(8) + System.IO.Path.GetExtension(fileUpload.FileName);
            string fullPath = Server.MapPath("/images/products/") + fileName;
            fileUpload.SaveAs(fullPath);
            return fileName;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int pid = int.Parse(HidPid.Value);
            ProductDAL.Delete(pid);
            Application["Products"] = Product.GetAll();
            Response.Redirect("/ProductList.aspx");
        }

    }
}