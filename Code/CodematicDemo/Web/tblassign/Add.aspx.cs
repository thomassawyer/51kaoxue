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
namespace Maticsoft.Web.tblassign
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txttestid.Text))
			{
				strErr+="testid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtzttypeid.Text))
			{
				strErr+="zttypeid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtcategory.Text))
			{
				strErr+="category格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int testid=int.Parse(this.txttestid.Text);
			int zttypeid=int.Parse(this.txtzttypeid.Text);
			int category=int.Parse(this.txtcategory.Text);

			Maticsoft.Model.tblassign model=new Maticsoft.Model.tblassign();
			model.testid=testid;
			model.zttypeid=zttypeid;
			model.category=category;

			Maticsoft.BLL.tblassign bll=new Maticsoft.BLL.tblassign();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
