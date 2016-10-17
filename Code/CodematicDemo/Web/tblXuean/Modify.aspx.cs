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
namespace Maticsoft.Web.tblXuean
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.tblXuean bll=new Maticsoft.BLL.tblXuean();
		Maticsoft.Model.tblXuean model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtlevel.Text=model.level.ToString();
		this.txtsubjectid.Text=model.subjectid.ToString();
		this.txtversionid.Text=model.versionid.ToString();
		this.txtname.Text=model.name;
		this.txtuploadtime.Text=model.uploadtime.ToString();
		this.txtfilesrc.Text=model.filesrc;
		this.txtdownloadnum.Text=model.downloadnum.ToString();
		this.txtneednum.Text=model.neednum.ToString();
		this.txtextension.Text=model.extension;
		this.txtyear.Text=model.year;
		this.txtuploader.Text=model.uploader;
		this.txtcontent.Text=model.content;
		this.txtprepareid.Text=model.prepareid.ToString();
		this.txtisjing.Text=model.isjing.ToString();
		this.txtisgaokao.Text=model.isgaokao.ToString();
		this.txtisdujia.Text=model.isdujia.ToString();
		this.txtbeikao.Text=model.beikao;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtlevel.Text))
			{
				strErr+="level格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtsubjectid.Text))
			{
				strErr+="subjectid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtversionid.Text))
			{
				strErr+="versionid格式错误！\\n";	
			}
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtuploadtime.Text))
			{
				strErr+="uploadtime格式错误！\\n";	
			}
			if(this.txtfilesrc.Text.Trim().Length==0)
			{
				strErr+="filesrc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtdownloadnum.Text))
			{
				strErr+="downloadnum格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtneednum.Text))
			{
				strErr+="neednum格式错误！\\n";	
			}
			if(this.txtextension.Text.Trim().Length==0)
			{
				strErr+="extension不能为空！\\n";	
			}
			if(this.txtyear.Text.Trim().Length==0)
			{
				strErr+="year不能为空！\\n";	
			}
			if(this.txtuploader.Text.Trim().Length==0)
			{
				strErr+="uploader不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="content不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtprepareid.Text))
			{
				strErr+="prepareid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtisjing.Text))
			{
				strErr+="isjing格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtisgaokao.Text))
			{
				strErr+="isgaokao格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtisdujia.Text))
			{
				strErr+="isdujia格式错误！\\n";	
			}
			if(this.txtbeikao.Text.Trim().Length==0)
			{
				strErr+="beikao不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int level=int.Parse(this.txtlevel.Text);
			int subjectid=int.Parse(this.txtsubjectid.Text);
			int versionid=int.Parse(this.txtversionid.Text);
			string name=this.txtname.Text;
			DateTime uploadtime=DateTime.Parse(this.txtuploadtime.Text);
			string filesrc=this.txtfilesrc.Text;
			int downloadnum=int.Parse(this.txtdownloadnum.Text);
			int neednum=int.Parse(this.txtneednum.Text);
			string extension=this.txtextension.Text;
			string year=this.txtyear.Text;
			string uploader=this.txtuploader.Text;
			string content=this.txtcontent.Text;
			int prepareid=int.Parse(this.txtprepareid.Text);
			int isjing=int.Parse(this.txtisjing.Text);
			int isgaokao=int.Parse(this.txtisgaokao.Text);
			int isdujia=int.Parse(this.txtisdujia.Text);
			string beikao=this.txtbeikao.Text;


			Maticsoft.Model.tblXuean model=new Maticsoft.Model.tblXuean();
			model.id=id;
			model.level=level;
			model.subjectid=subjectid;
			model.versionid=versionid;
			model.name=name;
			model.uploadtime=uploadtime;
			model.filesrc=filesrc;
			model.downloadnum=downloadnum;
			model.neednum=neednum;
			model.extension=extension;
			model.year=year;
			model.uploader=uploader;
			model.content=content;
			model.prepareid=prepareid;
			model.isjing=isjing;
			model.isgaokao=isgaokao;
			model.isdujia=isdujia;
			model.beikao=beikao;

			Maticsoft.BLL.tblXuean bll=new Maticsoft.BLL.tblXuean();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
