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
namespace Maticsoft.Web.tblzttype
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
		Maticsoft.BLL.tblzttype bll=new Maticsoft.BLL.tblzttype();
		Maticsoft.Model.tblzttype model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbltypename.Text=model.typename;
		this.lblztid.Text=model.ztid.ToString();
		this.lblpaixu.Text=model.paixu.ToString();
		this.lblincludeTest.Text=model.includeTest;

	}


    }
}
