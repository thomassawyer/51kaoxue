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
namespace Maticsoft.Web.tblteacher
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
			if(this.txtimgsrc.Text.Trim().Length==0)
			{
				strErr+="imgsrc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtschoolid.Text))
			{
				strErr+="schoolid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtposition.Text))
			{
				strErr+="position格式错误！\\n";	
			}
			if(this.txtmemo.Text.Trim().Length==0)
			{
				strErr+="memo不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string name=this.txtname.Text;
			string imgsrc=this.txtimgsrc.Text;
			int schoolid=int.Parse(this.txtschoolid.Text);
			int position=int.Parse(this.txtposition.Text);
			string memo=this.txtmemo.Text;

			Maticsoft.Model.tblteacher model=new Maticsoft.Model.tblteacher();
			model.name=name;
			model.imgsrc=imgsrc;
			model.schoolid=schoolid;
			model.position=position;
			model.memo=memo;

			Maticsoft.BLL.tblteacher bll=new Maticsoft.BLL.tblteacher();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
