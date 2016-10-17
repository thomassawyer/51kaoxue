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
namespace Maticsoft.Web.ztpage_dict
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtpageid.Text))
			{
				strErr+="pageid格式错误！\\n";	
			}
			if(this.txtpagename.Text.Trim().Length==0)
			{
				strErr+="pagename不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int pageid=int.Parse(this.txtpageid.Text);
			string pagename=this.txtpagename.Text;

			Maticsoft.Model.ztpage_dict model=new Maticsoft.Model.ztpage_dict();
			model.pageid=pageid;
			model.pagename=pagename;

			Maticsoft.BLL.ztpage_dict bll=new Maticsoft.BLL.ztpage_dict();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
