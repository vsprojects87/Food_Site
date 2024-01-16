using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Site.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Url.AbsoluteUri.ToString().Contains("Default.aspx")) {
                form1.Attributes.Add("class","sub_page");
            }
            else
            {
                form1.Attributes.Remove("class");
                // load the control
                Control SliderUserControl = (Control)Page.LoadControl("SliderUSerControl1.ascx");
                pnlSliderUC.Controls.Add(SliderUserControl);
            }
        }
    }
}