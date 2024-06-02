using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack) // מדובר בטעינה ראשונה של העמוד
            {
                // נשלוף את רשימת המוצרים מתוך האפליקשיין
                // נקשר את רשימת המוצרים לפקד רפיטר
                // נבצע קשירה של הנתונים לפקד הריפטר באמצעות הפעלת הפונקציה
                // Bind()
                List<Product> LstProd;
                LstProd = (List<Product>)Application["Products"];

                // קישור רשימת המוצרים עם הריפטר
                RptProd.DataSource = LstProd;
                // עבור כל פריט במקור הנתונים , יתבצע שכפול של האייטם טמפלייט של הרשיפטר
                RptProd.DataBind(); //  קשירת הנתונים לריפטר 
            }*/
            if (!IsPostBack)
            {
                BindProductList();
            }
        }
        private void BindProductList()
        {
            List<Product> products = Product.GetAll();
            List<Category> categories = Category.GetAll();

            var productList = from p in products
                              join c in categories on p.Cid equals c.Cid
                              select new
                              {
                                  p.Pid,
                                  p.Pname,
                                  p.Price,
                                  p.Pdesc,
                                  p.Picname,
                                  CategoryName = c.Cname
                              };

            RptProd.DataSource = productList;
            RptProd.DataBind();
        }
    }
}