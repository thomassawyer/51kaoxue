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
namespace Maticsoft.Web.ancient_category_second
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
				strErr+="二级古文分类名称不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtfirst_id.Text))
			{
				strErr+="一级古文分类编号格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
			int first_id=int.Parse(this.txtfirst_id.Text);

			Maticsoft.Model.ancient_category_second model=new Maticsoft.Model.ancient_category_second();
			model.title=title;
			model.first_id=first_id;

			Maticsoft.BLL.ancient_category_second bll=new Maticsoft.BLL.ancient_category_second();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
