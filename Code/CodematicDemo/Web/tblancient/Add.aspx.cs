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
namespace Maticsoft.Web.tblancient
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
				strErr+="文章标题不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="文章内容不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtpubdate.Text))
			{
				strErr+="日期格式错误！\\n";	
			}
			if(this.txtkeyword.Text.Trim().Length==0)
			{
				strErr+="关键字（用于相关推荐）不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtviewcounts.Text))
			{
				strErr+="点击数量格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtfirst_id.Text))
			{
				strErr+="一级分类编号格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtsecond_id.Text))
			{
				strErr+="二级分类编号格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtthird_id.Text))
			{
				strErr+="三级分类编号格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
			string content=this.txtcontent.Text;
			DateTime pubdate=DateTime.Parse(this.txtpubdate.Text);
			string keyword=this.txtkeyword.Text;
			int viewcounts=int.Parse(this.txtviewcounts.Text);
			int first_id=int.Parse(this.txtfirst_id.Text);
			int second_id=int.Parse(this.txtsecond_id.Text);
			int third_id=int.Parse(this.txtthird_id.Text);

			Maticsoft.Model.tblancient model=new Maticsoft.Model.tblancient();
			model.title=title;
			model.content=content;
			model.pubdate=pubdate;
			model.keyword=keyword;
			model.viewcounts=viewcounts;
			model.first_id=first_id;
			model.second_id=second_id;
			model.third_id=third_id;

			Maticsoft.BLL.tblancient bll=new Maticsoft.BLL.tblancient();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
