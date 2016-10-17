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
namespace Maticsoft.Web.tblMessage
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
		Maticsoft.BLL.tblMessage bll=new Maticsoft.BLL.tblMessage();
		Maticsoft.Model.tblMessage model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txttitle.Text=model.title;
		this.txtcontent.Text=model.content;
		this.txtmobile.Text=model.mobile;
		this.txtemail.Text=model.email;
		this.txtpubdate.Text=model.pubdate.ToString();
		this.txtschool.Text=model.school;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="title不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="content不能为空！\\n";	
			}
			if(this.txtmobile.Text.Trim().Length==0)
			{
				strErr+="mobile不能为空！\\n";	
			}
			if(this.txtemail.Text.Trim().Length==0)
			{
				strErr+="email不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtpubdate.Text))
			{
				strErr+="pubdate格式错误！\\n";	
			}
			if(this.txtschool.Text.Trim().Length==0)
			{
				strErr+="school不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string title=this.txttitle.Text;
			string content=this.txtcontent.Text;
			string mobile=this.txtmobile.Text;
			string email=this.txtemail.Text;
			DateTime pubdate=DateTime.Parse(this.txtpubdate.Text);
			string school=this.txtschool.Text;


			Maticsoft.Model.tblMessage model=new Maticsoft.Model.tblMessage();
			model.id=id;
			model.title=title;
			model.content=content;
			model.mobile=mobile;
			model.email=email;
			model.pubdate=pubdate;
			model.school=school;

			Maticsoft.BLL.tblMessage bll=new Maticsoft.BLL.tblMessage();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
