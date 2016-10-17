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
namespace Maticsoft.Web.tblTaoti
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
		Maticsoft.BLL.tblTaoti bll=new Maticsoft.BLL.tblTaoti();
		Maticsoft.Model.tblTaoti model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtlevel.Text=model.level.ToString();
		this.txtareaid.Text=model.areaid.ToString();
		this.txtsubjectid.Text=model.subjectid.ToString();
		this.txtname.Text=model.name;
		this.txtviewcount.Text=model.viewcount.ToString();
		this.lblpubdate.Text=model.pubdate.ToString();
		this.txtschoolid.Text=model.schoolid.ToString();
		this.txtismingxiao.Text=model.ismingxiao;
		this.txtistuijian.Text=model.istuijian;
		this.txtisjingpin.Text=model.isjingpin;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtviewcount.Text))
			{
				strErr+="viewcount格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtpubdate.Text))
			{
				strErr+="pubdate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtschoolid.Text))
			{
				strErr+="schoolid格式错误！\\n";	
			}
			if(this.txtismingxiao.Text.Trim().Length==0)
			{
				strErr+="ismingxiao不能为空！\\n";	
			}
			if(this.txtistuijian.Text.Trim().Length==0)
			{
				strErr+="istuijian不能为空！\\n";	
			}
			if(this.txtisjingpin.Text.Trim().Length==0)
			{
				strErr+="isjingpin不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int level=int.Parse(this.txtlevel.Text);
			int areaid=int.Parse(this.txtareaid.Text);
			int subjectid=int.Parse(this.txtsubjectid.Text);
			string name=this.txtname.Text;
			int viewcount=int.Parse(this.txtviewcount.Text);
			DateTime pubdate=DateTime.Parse(this.txtpubdate.Text);
			int schoolid=int.Parse(this.txtschoolid.Text);
			string ismingxiao=this.txtismingxiao.Text;
			string istuijian=this.txtistuijian.Text;
			string isjingpin=this.txtisjingpin.Text;


			Maticsoft.Model.tblTaoti model=new Maticsoft.Model.tblTaoti();
			model.id=id;
			model.level=level;
			model.areaid=areaid;
			model.subjectid=subjectid;
			model.name=name;
			model.viewcount=viewcount;
			model.pubdate=pubdate;
			model.schoolid=schoolid;
			model.ismingxiao=ismingxiao;
			model.istuijian=istuijian;
			model.isjingpin=isjingpin;

			Maticsoft.BLL.tblTaoti bll=new Maticsoft.BLL.tblTaoti();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
