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
namespace Maticsoft.Web.tblzhenti
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtyear.Text))
			{
				strErr+="year格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdaohang.Text))
			{
				strErr+="daohang格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtsubjectid.Text))
			{
				strErr+="subjectid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttype.Text))
			{
				strErr+="type格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttestid.Text))
			{
				strErr+="testid格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int year=int.Parse(this.txtyear.Text);
			int daohang=int.Parse(this.txtdaohang.Text);
			int subjectid=int.Parse(this.txtsubjectid.Text);
			int type=int.Parse(this.txttype.Text);
			int testid=int.Parse(this.txttestid.Text);

			Maticsoft.Model.tblzhenti model=new Maticsoft.Model.tblzhenti();
			model.year=year;
			model.daohang=daohang;
			model.subjectid=subjectid;
			model.type=type;
			model.testid=testid;

			Maticsoft.BLL.tblzhenti bll=new Maticsoft.BLL.tblzhenti();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
