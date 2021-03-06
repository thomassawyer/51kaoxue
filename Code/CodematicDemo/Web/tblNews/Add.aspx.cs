﻿using System;
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
namespace Maticsoft.Web.tblNews
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
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="content不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtpubdate.Text))
			{
				strErr+="pubdate格式错误！\\n";	
			}
			if(this.txtkeyword.Text.Trim().Length==0)
			{
				strErr+="keyword不能为空！\\n";	
			}
			if(this.txtisindex.Text.Trim().Length==0)
			{
				strErr+="isindex不能为空！\\n";	
			}
			if(this.txtisenable.Text.Trim().Length==0)
			{
				strErr+="isenable不能为空！\\n";	
			}
			if(this.txttype.Text.Trim().Length==0)
			{
				strErr+="type不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtviewcounts.Text))
			{
				strErr+="viewcounts格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtareaid.Text))
			{
				strErr+="areaid格式错误！\\n";	
			}
			if(this.txtfilesrc.Text.Trim().Length==0)
			{
				strErr+="filesrc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtneednum.Text))
			{
				strErr+="neednum格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdownloadnum.Text))
			{
				strErr+="downloadnum格式错误！\\n";	
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
			string isindex=this.txtisindex.Text;
			string isenable=this.txtisenable.Text;
			string type=this.txttype.Text;
			int viewcounts=int.Parse(this.txtviewcounts.Text);
			int areaid=int.Parse(this.txtareaid.Text);
			string filesrc=this.txtfilesrc.Text;
			int neednum=int.Parse(this.txtneednum.Text);
			int downloadnum=int.Parse(this.txtdownloadnum.Text);

			Maticsoft.Model.tblNews model=new Maticsoft.Model.tblNews();
			model.title=title;
			model.content=content;
			model.pubdate=pubdate;
			model.keyword=keyword;
			model.isindex=isindex;
			model.isenable=isenable;
			model.type=type;
			model.viewcounts=viewcounts;
			model.areaid=areaid;
			model.filesrc=filesrc;
			model.neednum=neednum;
			model.downloadnum=downloadnum;

			Maticsoft.BLL.tblNews bll=new Maticsoft.BLL.tblNews();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
