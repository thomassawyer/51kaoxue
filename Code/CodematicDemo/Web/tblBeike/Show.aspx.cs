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
namespace Maticsoft.Web.tblBeike
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
		Maticsoft.BLL.tblBeike bll=new Maticsoft.BLL.tblBeike();
		Maticsoft.Model.tblBeike model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbllevel.Text=model.level.ToString();
		this.lblareaid.Text=model.areaid.ToString();
		this.lblsubjectid.Text=model.subjectid.ToString();
		this.lblname.Text=model.name;
		this.lblviewcount.Text=model.viewcount.ToString();
		this.lblpubdate.Text=model.pubdate.ToString();
		this.lblisjing.Text=model.isjing.ToString();
		this.lblisgaokao.Text=model.isgaokao.ToString();
		this.lblisdujia.Text=model.isdujia.ToString();

	}


    }
}
