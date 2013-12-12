using DBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAdmin
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoginDB l = new LoginDB(TextBox1.Text, TextBox2.Text);            
            var result = l.Autenticar();



            Label1.Text = result.ToString();
        }
    }
}