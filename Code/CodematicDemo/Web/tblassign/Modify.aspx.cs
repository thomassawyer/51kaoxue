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
namespace Maticsoft.Web.tblassign
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
		Maticsoft.BLL.tblassign bll=new Maticsoft.BLL.tblassign();
		Maticsoft.Model.tblassign model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txttestid.Text=model.testid.ToString();
		this.txtzttypeid.Text=model.zttypeid.ToString();
		this.txtcategory.Text=model.category.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txttestid.Text))
			{
				strErr+="testid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtzttypeid.Text))
			{
				strErr+="zttypeid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtcategory.Text))
			{
				strErr+="category格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int testid=int.Parse(this.txttestid.Text);
			int zttypeid=int.Parse(this.txtzttypeid.Text);
			int category=int.Parse(this.txtcategory.Text);


			Maticsoft.Model.tblassign model=new Maticsoft.Model.tblassign();
			model.id=id;
			model.testid=testid;
			model.zttypeid=zttypeid;
			model.category=category;

			Maticsoft.BLL.tblassign bll=new Maticsoft.BLL.tblassign();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
