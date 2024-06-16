using Ecommerce.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.User_Controls
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Client> LstClient = (List<Client>)Application["Clients"]; 

                if (Session["Login"] != null)
                {
                    Client loggedInClient = (Client)Session["Login"];
                    LoginContainer.Visible = false;
                    LtlLoggedUser.Text = $"שלום {loggedInClient.ClientFirstName} {loggedInClient.ClientLastName}";
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            List<Client> LstClient = (List<Client>)Application["Clients"]; 

            string Email = TxtEmail.Text;
            string Pass = TxtPass.Text;
            bool isAuthenticated = false;

            for (int i = 0; i < LstClient.Count; i++) 
            {
                if (LstClient[i].ClientEmail == Email && LstClient[i].ClientPassword == Pass)
                {
                    Session["Login"] = LstClient[i]; 
                    isAuthenticated = true;
                    Response.Redirect("/AdminManeger"); 
                }
            }

            if (!isAuthenticated)
            {
                LtlMsg.Text = "שם וסיסמה אינם תקינים"; 
            }
        }
    }
}
