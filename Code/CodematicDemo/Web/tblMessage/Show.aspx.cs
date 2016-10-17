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
namespace Maticsoft.Web.tblMessage
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
		Maticsoft.BLL.tblMessage bll=new Maticsoft.BLL.tblMessage();
		Maticsoft.Model.tblMessage model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbltitle.Text=model.title;
		this.lblcontent.Text=model.content;
		this.lblmobile.Text=model.mobile;
		this.lblemail.Text=model.email;
		this.lblpubdate.Text=model.pubdate.ToString();
		this.lblschool.Text=model.school;

	}


    }
}
