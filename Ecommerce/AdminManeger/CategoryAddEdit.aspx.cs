using BLL;
using Ecommerce.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.AdminManeger
{
    public partial class CategoryAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Cid = Request["Cid"] + "";
                if (string.IsNullOrEmpty(Cid))
                {
                    Cid = "-1";
                }
                else
                {
                    int cid = int.Parse(Cid);
                    Category Tmp = CategoryDAL.GetById(cid);

                    if (Tmp != null)
                    {
                        TxtCname.Text = Tmp.Cname;
                        TxtCdesc.Text = Tmp.Cdesc;
                        HidCid.Value = Cid;
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string picname = UploadPic.HasFile ? SaveImage(UploadPic) : "";

            int cid = int.Parse(HidCid.Value);

            Category category = new Category
            {
                Cid = cid,
                Cname = TxtCname.Text,
                Cdesc = TxtCdesc.Text,
                Picname = picname,
                Status = "Active",
                AddDate = DateTime.Now
            };

            if (cid == -1)
            {
                CategoryDAL.Insert(category);
            }
            else
            {
                CategoryDAL.Update(category);
            }

            Application["Categories"] = Category.GetAll();
            Response.Redirect("/CategoryList.aspx");
        }

        private string SaveImage(FileUpload fileUpload)
        {
            string fileName = GlobFunc.GetRandStr(8) + System.IO.Path.GetExtension(fileUpload.FileName);
            string fullPath = Server.MapPath("/images/categories/") + fileName;
            fileUpload.SaveAs(fullPath);
            return fileName;
        }
    }
}