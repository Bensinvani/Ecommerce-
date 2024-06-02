using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int pid;
                if (int.TryParse(Request.QueryString["Pid"], out pid))
                {
                    LoadProductDetails(pid);
                }
            }
        }

        private void LoadProductDetails(int pid)
        {
            Product product = ProductDAL.GetById(pid);
            if (product != null)
            {
                ImgProduct.ImageUrl = "/images/products/" + product.Picname;
                LblPname.InnerText = product.Pname;
                LblPdesc.InnerText = product.Pdesc;
                LblPrice.InnerText = product.Price.ToString("C");
            }
        }
    }
}