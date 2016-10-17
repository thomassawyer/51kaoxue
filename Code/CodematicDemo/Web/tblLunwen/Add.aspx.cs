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
namespace Maticsoft.Web.tblLunwen
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
			if(this.txtfilesrc.Text.Trim().Length==0)
			{
				strErr+="filesrc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtsubjectid.Text))
			{
				strErr+="subjectid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtareaid.Text))
			{
				strErr+="areaid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdownum.Text))
			{
				strErr+="downum格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdowneed.Text))
			{
				strErr+="downeed格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtuploaddate.Text))
			{
				strErr+="uploaddate格式错误！\\n";	
			}
			if(this.txtmemoinfo.Text.Trim().Length==0)
			{
				strErr+="memoinfo不能为空！\\n";	
			}
			if(this.txtuploader.Text.Trim().Length==0)
			{
				strErr+="uploader不能为空！\\n";	
			}
			if(this.txtextension.Text.Trim().Length==0)
			{
				strErr+="extension不能为空！\\n";	
			}
			if(this.txtyear.Text.Trim().Length==0)
			{
				strErr+="year不能为空！\\n";	
			}
			if(this.txtlevel.Text.Trim().Length==0)
			{
				strErr+="level不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string name=this.txtname.Text;
			string filesrc=this.txtfilesrc.Text;
			int subjectid=int.Parse(this.txtsubjectid.Text);
			int areaid=int.Parse(this.txtareaid.Text);
			int downum=int.Parse(this.txtdownum.Text);
			int downeed=int.Parse(this.txtdowneed.Text);
			DateTime uploaddate=DateTime.Parse(this.txtuploaddate.Text);
			string memoinfo=this.txtmemoinfo.Text;
			string uploader=this.txtuploader.Text;
			string extension=this.txtextension.Text;
			string year=this.txtyear.Text;
			string level=this.txtlevel.Text;

			Maticsoft.Model.tblLunwen model=new Maticsoft.Model.tblLunwen();
			model.name=name;
			model.filesrc=filesrc;
			model.subjectid=subjectid;
			model.areaid=areaid;
			model.downum=downum;
			model.downeed=downeed;
			model.uploaddate=uploaddate;
			model.memoinfo=memoinfo;
			model.uploader=uploader;
			model.extension=extension;
			model.year=year;
			model.level=level;

			Maticsoft.BLL.tblLunwen bll=new Maticsoft.BLL.tblLunwen();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
