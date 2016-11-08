using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dbHandin3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.User.Identity.IsAuthenticated)
            {
                user.Visible = false;
                userIcon.Visible = false;

                string getSessionUser = HttpContext.Current.User.Identity.Name;


                if (getSessionUser == "webmaster" || getSessionUser == "Webmaster")
                {
                    pokeball.PostBackUrl = "webmaster.aspx";
                }
                else
                {
                    pokeball.PostBackUrl = "crud.aspx";
                }            
            }
            else
            {
                LoginStatus1.Visible = false;
                logoutIcon.Visible = false;
                pokeball.PostBackUrl = "Index.aspx";

            }
        }
    }
}