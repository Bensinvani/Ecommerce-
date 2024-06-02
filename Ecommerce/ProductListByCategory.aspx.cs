using BLL;
using DAL;
using Ecommerce.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ProductListByCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int cid = int.Parse(Request.QueryString["Cid"]);
                LoadCategoryName(cid);
                LoadProductsByCategory(cid);
            }
        }

        private void LoadCategoryName(int cid)
        {
            Category category = CategoryDAL.GetById(cid);
            if (category != null)
            {
                LitCategoryName.Text = category.Cname;
            }
        }

        private void LoadProductsByCategory(int cid)
        {
            List<Product> products = ProductDAL.GetByCategoryId(cid);
            RepeaterProducts.DataSource = products;
            RepeaterProducts.DataBind();
        }
    }
}