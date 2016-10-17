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
namespace Maticsoft.Web.tblzttype
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
		Maticsoft.BLL.tblzttype bll=new Maticsoft.BLL.tblzttype();
		Maticsoft.Model.tblzttype model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txttypename.Text=model.typename;
		this.txtztid.Text=model.ztid.ToString();
		this.txtpaixu.Text=model.paixu.ToString();
		this.txtincludeTest.Text=model.includeTest;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttypename.Text.Trim().Length==0)
			{
				strErr+="typename不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtztid.Text))
			{
				strErr+="ztid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtpaixu.Text))
			{
				strErr+="paixu格式错误！\\n";	
			}
			if(this.txtincludeTest.Text.Trim().Length==0)
			{
				strErr+="includeTest不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string typename=this.txttypename.Text;
			int ztid=int.Parse(this.txtztid.Text);
			int paixu=int.Parse(this.txtpaixu.Text);
			string includeTest=this.txtincludeTest.Text;


			Maticsoft.Model.tblzttype model=new Maticsoft.Model.tblzttype();
			model.id=id;
			model.typename=typename;
			model.ztid=ztid;
			model.paixu=paixu;
			model.includeTest=includeTest;

			Maticsoft.BLL.tblzttype bll=new Maticsoft.BLL.tblzttype();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
