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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.tblNewstype
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.tblNewstype bll=new Maticsoft.BLL.tblNewstype();
		Maticsoft.Model.tblNewstype model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtcategoryname.Text=model.categoryname;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtcategoryname.Text.Trim().Length==0)
			{
				strErr+="categoryname不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string categoryname=this.txtcategoryname.Text;


			Maticsoft.Model.tblNewstype model=new Maticsoft.Model.tblNewstype();
			model.id=id;
			model.categoryname=categoryname;

			Maticsoft.BLL.tblNewstype bll=new Maticsoft.BLL.tblNewstype();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
