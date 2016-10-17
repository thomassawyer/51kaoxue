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
namespace Maticsoft.Web.page_dict
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
					string PAGEID= strid;
					ShowInfo(PAGEID);
				}
			}
		}
		
	private void ShowInfo(string PAGEID)
	{
		Maticsoft.BLL.page_dict bll=new Maticsoft.BLL.page_dict();
		Maticsoft.Model.page_dict model=bll.GetModel(PAGEID);
		this.lblPAGEID.Text=model.PAGEID;
		this.lblPAGENAME.Text=model.PAGENAME;
		this.lblPAGEPARENTID.Text=model.PAGEPARENTID;
		this.lblPAGEURL.Text=model.PAGEURL;
		this.lblPAGETARGET.Text=model.PAGETARGET;
		this.lblPAGEIMG.Text=model.PAGEIMG;
		this.lblCHECKFLAG.Text=model.CHECKFLAG;
		this.lblPAGEMOUDAL.Text=model.PAGEMOUDAL;
		this.lblISFLAG.Text=model.ISFLAG;
		this.lblSEQSORT.Text=model.SEQSORT;

	}


    }
}
