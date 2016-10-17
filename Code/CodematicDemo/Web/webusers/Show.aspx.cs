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
namespace Maticsoft.Web.webusers
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
		Maticsoft.BLL.webusers bll=new Maticsoft.BLL.webusers();
		Maticsoft.Model.webusers model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblusername.Text=model.username;
		this.lblpassword.Text=model.password;
		this.lblemail.Text=model.email;
		this.lblschool.Text=model.school;
		this.lblname.Text=model.name;
		this.lblmobile.Text=model.mobile;
		this.lblprovince.Text=model.province;
		this.lblcity.Text=model.city;
		this.lblposition.Text=model.position;
		this.lblsubject.Text=model.subject;
		this.lbladdress.Text=model.address;
		this.lbltel.Text=model.tel;
		this.lbllevel.Text=model.level;
		this.lblregdate.Text=model.regdate.ToString();
		this.lblip.Text=model.ip;
		this.lbldaoqidate.Text=model.daoqidate.ToString();
		this.lblopenpwd.Text=model.openpwd;
		this.lblyewu.Text=model.yewu;
		this.lblprovinceid.Text=model.provinceid;
		this.lblcityid.Text=model.cityid;
		this.lblgrade.Text=model.grade;
		this.lblstatus.Text=model.status;
		this.lblyewudiqv.Text=model.yewudiqv;

	}


    }
}
