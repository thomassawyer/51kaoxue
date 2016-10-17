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
namespace Maticsoft.Web.tblcollect
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserid.Text))
			{
				strErr+="userid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtcategory.Text))
			{
				strErr+="category格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtfileid.Text))
			{
				strErr+="fileid格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtcollectTime.Text))
			{
				strErr+="collectTime格式错误！\\n";	
			}
			if(this.txtfilename.Text.Trim().Length==0)
			{
				strErr+="filename不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int userid=int.Parse(this.txtuserid.Text);
			int category=int.Parse(this.txtcategory.Text);
			int fileid=int.Parse(this.txtfileid.Text);
			DateTime collectTime=DateTime.Parse(this.txtcollectTime.Text);
			string filename=this.txtfilename.Text;

			Maticsoft.Model.tblcollect model=new Maticsoft.Model.tblcollect();
			model.userid=userid;
			model.category=category;
			model.fileid=fileid;
			model.collectTime=collectTime;
			model.filename=filename;

			Maticsoft.BLL.tblcollect bll=new Maticsoft.BLL.tblcollect();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
