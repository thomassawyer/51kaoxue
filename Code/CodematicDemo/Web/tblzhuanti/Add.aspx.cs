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
namespace Maticsoft.Web.tblzhuanti
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
			if(this.txtpicsrc.Text.Trim().Length==0)
			{
				strErr+="picsrc不能为空！\\n";	
			}
			if(this.txtftitle.Text.Trim().Length==0)
			{
				strErr+="ftitle不能为空！\\n";	
			}
			if(this.txtstitle.Text.Trim().Length==0)
			{
				strErr+="stitle不能为空！\\n";	
			}
			if(this.txtdaodu.Text.Trim().Length==0)
			{
				strErr+="daodu不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtmodel.Text))
			{
				strErr+="model格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtviewstate.Text))
			{
				strErr+="viewstate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtlevel.Text))
			{
				strErr+="level格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtsubject.Text))
			{
				strErr+="subject格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtcategory.Text))
			{
				strErr+="category格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtistop.Text))
			{
				strErr+="istop格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtposition.Text))
			{
				strErr+="position格式错误！\\n";	
			}
			if(this.txtbigpic.Text.Trim().Length==0)
			{
				strErr+="bigpic不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtupdatetime.Text))
			{
				strErr+="updatetime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string name=this.txtname.Text;
			string picsrc=this.txtpicsrc.Text;
			string ftitle=this.txtftitle.Text;
			string stitle=this.txtstitle.Text;
			string daodu=this.txtdaodu.Text;
			int model=int.Parse(this.txtmodel.Text);
			int viewstate=int.Parse(this.txtviewstate.Text);
			int level=int.Parse(this.txtlevel.Text);
			int subject=int.Parse(this.txtsubject.Text);
			int category=int.Parse(this.txtcategory.Text);
			int istop=int.Parse(this.txtistop.Text);
			int position=int.Parse(this.txtposition.Text);
			string bigpic=this.txtbigpic.Text;
			DateTime updatetime=DateTime.Parse(this.txtupdatetime.Text);

			Maticsoft.Model.tblzhuanti model=new Maticsoft.Model.tblzhuanti();
			model.name=name;
			model.picsrc=picsrc;
			model.ftitle=ftitle;
			model.stitle=stitle;
			model.daodu=daodu;
			model.model=model;
			model.viewstate=viewstate;
			model.level=level;
			model.subject=subject;
			model.category=category;
			model.istop=istop;
			model.position=position;
			model.bigpic=bigpic;
			model.updatetime=updatetime;

			Maticsoft.BLL.tblzhuanti bll=new Maticsoft.BLL.tblzhuanti();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
