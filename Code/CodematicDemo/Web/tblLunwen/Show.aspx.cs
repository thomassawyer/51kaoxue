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
namespace Maticsoft.Web.tblLunwen
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
		Maticsoft.BLL.tblLunwen bll=new Maticsoft.BLL.tblLunwen();
		Maticsoft.Model.tblLunwen model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblname.Text=model.name;
		this.lblfilesrc.Text=model.filesrc;
		this.lblsubjectid.Text=model.subjectid.ToString();
		this.lblareaid.Text=model.areaid.ToString();
		this.lbldownum.Text=model.downum.ToString();
		this.lbldowneed.Text=model.downeed.ToString();
		this.lbluploaddate.Text=model.uploaddate.ToString();
		this.lblmemoinfo.Text=model.memoinfo;
		this.lbluploader.Text=model.uploader;
		this.lblextension.Text=model.extension;
		this.lblyear.Text=model.year;
		this.lbllevel.Text=model.level;

	}


    }
}
