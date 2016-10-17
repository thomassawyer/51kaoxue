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
namespace Maticsoft.Web.tblNews
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
		Maticsoft.BLL.tblNews bll=new Maticsoft.BLL.tblNews();
		Maticsoft.Model.tblNews model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbltitle.Text=model.title;
		this.lblcontent.Text=model.content;
		this.lblpubdate.Text=model.pubdate.ToString();
		this.lblkeyword.Text=model.keyword;
		this.lblisindex.Text=model.isindex;
		this.lblisenable.Text=model.isenable;
		this.lbltype.Text=model.type;
		this.lblviewcounts.Text=model.viewcounts.ToString();
		this.lblareaid.Text=model.areaid.ToString();
		this.lblfilesrc.Text=model.filesrc;
		this.lblneednum.Text=model.neednum.ToString();
		this.lbldownloadnum.Text=model.downloadnum.ToString();

	}


    }
}
