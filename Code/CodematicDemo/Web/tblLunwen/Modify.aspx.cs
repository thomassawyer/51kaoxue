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
		Maticsoft.BLL.tblLunwen bll=new Maticsoft.BLL.tblLunwen();
		Maticsoft.Model.tblLunwen model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtname.Text=model.name;
		this.txtfilesrc.Text=model.filesrc;
		this.txtsubjectid.Text=model.subjectid.ToString();
		this.txtareaid.Text=model.areaid.ToString();
		this.txtdownum.Text=model.downum.ToString();
		this.txtdowneed.Text=model.downeed.ToString();
		this.txtuploaddate.Text=model.uploaddate.ToString();
		this.txtmemoinfo.Text=model.memoinfo;
		this.txtuploader.Text=model.uploader;
		this.txtextension.Text=model.extension;
		this.txtyear.Text=model.year;
		this.txtlevel.Text=model.level;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int id=int.Parse(this.lblid.Text);
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
			model.id=id;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
