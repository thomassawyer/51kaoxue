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
namespace Maticsoft.Web.tblschool
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
		Maticsoft.BLL.tblschool bll=new Maticsoft.BLL.tblschool();
		Maticsoft.Model.tblschool model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblname.Text=model.name;
		this.lblheadname.Text=model.headname;
		this.lblstar.Text=model.star;
		this.lblcontent.Text=model.content;
		this.lbllevel.Text=model.level.ToString();
		this.lblareaid.Text=model.areaid.ToString();
		this.lblintime.Text=model.intime.ToString();
		this.lblimgsrc.Text=model.imgsrc;
		this.lblSchoolPosition.Text=model.SchoolPosition.ToString();

	}


    }
}
