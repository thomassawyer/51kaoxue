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
namespace Maticsoft.Web.tblWebinfo
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
		Maticsoft.BLL.tblWebinfo bll=new Maticsoft.BLL.tblWebinfo();
		Maticsoft.Model.tblWebinfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblname.Text=model.name;
		this.lbllogosrc.Text=model.logosrc;
		this.lblfootinfo.Text=model.footinfo;
		this.lblheadseo.Text=model.headseo;
		this.lblkeyseo.Text=model.keyseo;
		this.lbldescribseo.Text=model.describseo;
		this.lblweixin.Text=model.weixin;
		this.lblweibo.Text=model.weibo;
		this.lblgengxin.Text=model.gengxin;
		this.lblzongliang.Text=model.zongliang;
		this.lblschooltestnum.Text=model.schooltestnum;
		this.lbljinpintestnum.Text=model.jinpintestnum;
		this.lblschoolnum.Text=model.schoolnum;

	}


    }
}
