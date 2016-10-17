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
namespace Maticsoft.Web.tblBanner
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
			if(this.txttype.Text.Trim().Length==0)
			{
				strErr+="type不能为空！\\n";	
			}
			if(this.txtpage.Text.Trim().Length==0)
			{
				strErr+="page不能为空！\\n";	
			}
			if(this.txtpic.Text.Trim().Length==0)
			{
				strErr+="pic不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtsort.Text))
			{
				strErr+="sort格式错误！\\n";	
			}
			if(this.txtlink.Text.Trim().Length==0)
			{
				strErr+="link不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
			string type=this.txttype.Text;
			string page=this.txtpage.Text;
			string pic=this.txtpic.Text;
			int sort=int.Parse(this.txtsort.Text);
			string link=this.txtlink.Text;

			Maticsoft.Model.tblBanner model=new Maticsoft.Model.tblBanner();
			model.title=title;
			model.type=type;
			model.page=page;
			model.pic=pic;
			model.sort=sort;
			model.link=link;

			Maticsoft.BLL.tblBanner bll=new Maticsoft.BLL.tblBanner();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
