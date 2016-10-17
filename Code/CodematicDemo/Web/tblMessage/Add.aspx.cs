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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string title=this.txttitle.Text;
			string content=this.txtcontent.Text;
			string mobile=this.txtmobile.Text;
			string email=this.txtemail.Text;
			DateTime pubdate=DateTime.Parse(this.txtpubdate.Text);
			string school=this.txtschool.Text;

			Maticsoft.Model.tblMessage model=new Maticsoft.Model.tblMessage();
			model.title=title;
			model.content=content;
			model.mobile=mobile;
			model.email=email;
			model.pubdate=pubdate;
			model.school=school;

			Maticsoft.BLL.tblMessage bll=new Maticsoft.BLL.tblMessage();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
