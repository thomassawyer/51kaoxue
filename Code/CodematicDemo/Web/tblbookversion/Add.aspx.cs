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
namespace Maticsoft.Web.tblbookversion
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtsubjectid.Text))
			{
				strErr+="subjectid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtpid.Text))
			{
				strErr+="pid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtlayer.Text))
			{
				strErr+="layer格式错误！\\n";	
			}
			if(this.txtmemo.Text.Trim().Length==0)
			{
				strErr+="memo不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtorderid.Text))
			{
				strErr+="orderid格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string name=this.txtname.Text;
			int subjectid=int.Parse(this.txtsubjectid.Text);
			int pid=int.Parse(this.txtpid.Text);
			int layer=int.Parse(this.txtlayer.Text);
			string memo=this.txtmemo.Text;
			int orderid=int.Parse(this.txtorderid.Text);

			Maticsoft.Model.tblbookversion model=new Maticsoft.Model.tblbookversion();
			model.name=name;
			model.subjectid=subjectid;
			model.pid=pid;
			model.layer=layer;
			model.memo=memo;
			model.orderid=orderid;

			Maticsoft.BLL.tblbookversion bll=new Maticsoft.BLL.tblbookversion();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
