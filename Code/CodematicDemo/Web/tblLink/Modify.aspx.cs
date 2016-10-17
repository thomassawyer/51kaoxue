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
namespace Maticsoft.Web.tblLink
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
		Maticsoft.BLL.tblLink bll=new Maticsoft.BLL.tblLink();
		Maticsoft.Model.tblLink model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txttitle.Text=model.title;
		this.txtlink.Text=model.link;
		this.txtpic.Text=model.pic;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="title不能为空！\\n";	
			}
			if(this.txtlink.Text.Trim().Length==0)
			{
				strErr+="link不能为空！\\n";	
			}
			if(this.txtpic.Text.Trim().Length==0)
			{
				strErr+="pic不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string title=this.txttitle.Text;
			string link=this.txtlink.Text;
			string pic=this.txtpic.Text;


			Maticsoft.Model.tblLink model=new Maticsoft.Model.tblLink();
			model.id=id;
			model.title=title;
			model.link=link;
			model.pic=pic;

			Maticsoft.BLL.tblLink bll=new Maticsoft.BLL.tblLink();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
