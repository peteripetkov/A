using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPApp
{
    public partial class _Default : Page
    {
        IPService.IPServiceClient ipServiceClient = new IPService.IPServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewIPs.DataSource = ipServiceClient.GetAllIPs();
                GridViewIPs.DataBind();
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            ipServiceClient.InsertIP(new IPService.IP() {
                Address = TextBoxAddress.Text,
                Name = TextBoxName.Text
            });

            GridViewIPs.DataSource = ipServiceClient.GetAllIPs();
            GridViewIPs.DataBind();
        }

        protected void GridViewIPs_Delete(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewIPs.DataKeys[e.RowIndex].Values["ID"].ToString());
            ipServiceClient.DeleteIP(id);

            GridViewIPs.DataSource = ipServiceClient.GetAllIPs();
            GridViewIPs.DataBind();
        }

    }
}