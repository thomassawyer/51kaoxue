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
namespace Maticsoft.Web.tblzhenti
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
		Maticsoft.BLL.tblzhenti bll=new Maticsoft.BLL.tblzhenti();
		Maticsoft.Model.tblzhenti model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblyear.Text=model.year.ToString();
		this.lbldaohang.Text=model.daohang.ToString();
		this.lblsubjectid.Text=model.subjectid.ToString();
		this.lbltype.Text=model.type.ToString();
		this.lbltestid.Text=model.testid.ToString();

	}


    }
}
