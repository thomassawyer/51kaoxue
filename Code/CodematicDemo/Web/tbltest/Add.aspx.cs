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
namespace Maticsoft.Web.tbltest
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtlevel.Text))
			{
				strErr+="level格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtareaid.Text))
			{
				strErr+="areaid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtsubjectid.Text))
			{
				strErr+="subjectid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttestcategory.Text))
			{
				strErr+="testcategory格式错误！\\n";	
			}
			if(this.txttestname.Text.Trim().Length==0)
			{
				strErr+="testname不能为空！\\n";	
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
			if(!PageValidate.IsNumber(txtgroupid.Text))
			{
				strErr+="groupid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtschoolid.Text))
			{
				strErr+="schoolid格式错误！\\n";	
			}
			if(this.txtismingxiao.Text.Trim().Length==0)
			{
				strErr+="ismingxiao不能为空！\\n";	
			}
			if(this.txtisjingpin.Text.Trim().Length==0)
			{
				strErr+="isjingpin不能为空！\\n";	
			}
			if(this.txtistuijian.Text.Trim().Length==0)
			{
				strErr+="istuijian不能为空！\\n";	
			}
			if(this.txtisgaokao.Text.Trim().Length==0)
			{
				strErr+="isgaokao不能为空！\\n";	
			}
			if(this.txtisdujia.Text.Trim().Length==0)
			{
				strErr+="isdujia不能为空！\\n";	
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
			int level=int.Parse(this.txtlevel.Text);
			int areaid=int.Parse(this.txtareaid.Text);
			int subjectid=int.Parse(this.txtsubjectid.Text);
			int testcategory=int.Parse(this.txttestcategory.Text);
			string testname=this.txttestname.Text;
			DateTime uploadtime=DateTime.Parse(this.txtuploadtime.Text);
			string filesrc=this.txtfilesrc.Text;
			int downloadnum=int.Parse(this.txtdownloadnum.Text);
			int neednum=int.Parse(this.txtneednum.Text);
			string extension=this.txtextension.Text;
			string year=this.txtyear.Text;
			string uploader=this.txtuploader.Text;
			string content=this.txtcontent.Text;
			int groupid=int.Parse(this.txtgroupid.Text);
			int schoolid=int.Parse(this.txtschoolid.Text);
			string ismingxiao=this.txtismingxiao.Text;
			string isjingpin=this.txtisjingpin.Text;
			string istuijian=this.txtistuijian.Text;
			string isgaokao=this.txtisgaokao.Text;
			string isdujia=this.txtisdujia.Text;
			string beikao=this.txtbeikao.Text;

			Maticsoft.Model.tbltest model=new Maticsoft.Model.tbltest();
			model.level=level;
			model.areaid=areaid;
			model.subjectid=subjectid;
			model.testcategory=testcategory;
			model.testname=testname;
			model.uploadtime=uploadtime;
			model.filesrc=filesrc;
			model.downloadnum=downloadnum;
			model.neednum=neednum;
			model.extension=extension;
			model.year=year;
			model.uploader=uploader;
			model.content=content;
			model.groupid=groupid;
			model.schoolid=schoolid;
			model.ismingxiao=ismingxiao;
			model.isjingpin=isjingpin;
			model.istuijian=istuijian;
			model.isgaokao=isgaokao;
			model.isdujia=isdujia;
			model.beikao=beikao;

			Maticsoft.BLL.tbltest bll=new Maticsoft.BLL.tbltest();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
