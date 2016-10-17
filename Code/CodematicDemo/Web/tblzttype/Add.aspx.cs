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
namespace Maticsoft.Web.tblzttype
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttypename.Text.Trim().Length==0)
			{
				strErr+="typename不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtztid.Text))
			{
				strErr+="ztid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtpaixu.Text))
			{
				strErr+="paixu格式错误！\\n";	
			}
			if(this.txtincludeTest.Text.Trim().Length==0)
			{
				strErr+="includeTest不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string typename=this.txttypename.Text;
			int ztid=int.Parse(this.txtztid.Text);
			int paixu=int.Parse(this.txtpaixu.Text);
			string includeTest=this.txtincludeTest.Text;

			Maticsoft.Model.tblzttype model=new Maticsoft.Model.tblzttype();
			model.typename=typename;
			model.ztid=ztid;
			model.paixu=paixu;
			model.includeTest=includeTest;

			Maticsoft.BLL.tblzttype bll=new Maticsoft.BLL.tblzttype();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
