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
namespace Maticsoft.Web.tbluprecord
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
					int userid=(Convert.ToInt32(strid));
					ShowInfo(userid);
				}
			}
		}
		
	private void ShowInfo(int userid)
	{
		Maticsoft.BLL.tbluprecord bll=new Maticsoft.BLL.tbluprecord();
		Maticsoft.Model.tbluprecord model=bll.GetModel(userid);
		this.lbluserid.Text=model.userid.ToString();
		this.lblzong.Text=model.zong.ToString();
		this.lbltoday.Text=model.today.ToString();
		this.lbluptime.Text=model.uptime.ToString();

	}


    }
}
