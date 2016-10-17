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
namespace Maticsoft.Web.tblzhuanti
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
		Maticsoft.BLL.tblzhuanti bll=new Maticsoft.BLL.tblzhuanti();
		Maticsoft.Model.tblzhuanti model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblname.Text=model.name;
		this.lblpicsrc.Text=model.picsrc;
		this.lblftitle.Text=model.ftitle;
		this.lblstitle.Text=model.stitle;
		this.lbldaodu.Text=model.daodu;
		this.lblmodel.Text=model.model.ToString();
		this.lblviewstate.Text=model.viewstate.ToString();
		this.lbllevel.Text=model.level.ToString();
		this.lblsubject.Text=model.subject.ToString();
		this.lblcategory.Text=model.category.ToString();
		this.lblistop.Text=model.istop.ToString();
		this.lblposition.Text=model.position.ToString();
		this.lblbigpic.Text=model.bigpic;
		this.lblupdatetime.Text=model.updatetime.ToString();

	}


    }
}
