using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace Maticsoft.Web.ztpage_dict
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.ztpage_dict bll=new Maticsoft.BLL.ztpage_dict();
		Maticsoft.Model.ztpage_dict model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblpageid.Text=model.pageid.ToString();
		this.lblpagename.Text=model.pagename;

	}


    }
}
