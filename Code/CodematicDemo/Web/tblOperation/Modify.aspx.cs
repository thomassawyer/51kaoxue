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
namespace Maticsoft.Web.tblOperation
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
		Maticsoft.BLL.tblOperation bll=new Maticsoft.BLL.tblOperation();
		Maticsoft.Model.tblOperation model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtusername.Text=model.username;
		this.txtact.Text=model.act;
		this.txtmemo.Text=model.memo;
		this.txtopdate.Text=model.opdate.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtusername.Text.Trim().Length==0)
			{
				strErr+="username不能为空！\\n";	
			}
			if(this.txtact.Text.Trim().Length==0)
			{
				strErr+="act不能为空！\\n";	
			}
			if(this.txtmemo.Text.Trim().Length==0)
			{
				strErr+="memo不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtopdate.Text))
			{
				strErr+="opdate格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string username=this.txtusername.Text;
			string act=this.txtact.Text;
			string memo=this.txtmemo.Text;
			DateTime opdate=DateTime.Parse(this.txtopdate.Text);


			Maticsoft.Model.tblOperation model=new Maticsoft.Model.tblOperation();
			model.id=id;
			model.username=username;
			model.act=act;
			model.memo=memo;
			model.opdate=opdate;

			Maticsoft.BLL.tblOperation bll=new Maticsoft.BLL.tblOperation();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
