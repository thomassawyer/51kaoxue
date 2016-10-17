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
namespace Maticsoft.Web.tblancient
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
		Maticsoft.BLL.tblancient bll=new Maticsoft.BLL.tblancient();
		Maticsoft.Model.tblancient model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbltitle.Text=model.title;
		this.lblcontent.Text=model.content;
		this.lblpubdate.Text=model.pubdate.ToString();
		this.lblkeyword.Text=model.keyword;
		this.lblviewcounts.Text=model.viewcounts.ToString();
		this.lblfirst_id.Text=model.first_id.ToString();
		this.lblsecond_id.Text=model.second_id.ToString();
		this.lblthird_id.Text=model.third_id.ToString();

	}


    }
}
