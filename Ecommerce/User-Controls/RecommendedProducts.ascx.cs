using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.User_Controls
{
    public partial class RecommendedProducts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRecommendedProducts();
            }
        }

        private void BindRecommendedProducts()
        {
            List<Product> recommendedProducts = Product.GetRecommended();
            rptRecommendedProducts.DataSource = recommendedProducts;
            rptRecommendedProducts.DataBind();
        }
    }
}