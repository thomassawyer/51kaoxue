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
namespace Maticsoft.Web.tblBeike
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
		Maticsoft.BLL.tblBeike bll=new Maticsoft.BLL.tblBeike();
		Maticsoft.Model.tblBeike model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtlevel.Text=model.level.ToString();
		this.txtareaid.Text=model.areaid.ToString();
		this.txtsubjectid.Text=model.subjectid.ToString();
		this.txtname.Text=model.name;
		this.txtviewcount.Text=model.viewcount.ToString();
		this.txtpubdate.Text=model.pubdate.ToString();
		this.txtisjing.Text=model.isjing.ToString();
		this.txtisgaokao.Text=model.isgaokao.ToString();
		this.txtisdujia.Text=model.isdujia.ToString();

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
			int isjing=int.Parse(this.txtisjing.Text);
			int isgaokao=int.Parse(this.txtisgaokao.Text);
			int isdujia=int.Parse(this.txtisdujia.Text);


			Maticsoft.Model.tblBeike model=new Maticsoft.Model.tblBeike();
			model.id=id;
			model.level=level;
			model.areaid=areaid;
			model.subjectid=subjectid;
			model.name=name;
			model.viewcount=viewcount;
			model.pubdate=pubdate;
			model.isjing=isjing;
			model.isgaokao=isgaokao;
			model.isdujia=isdujia;

			Maticsoft.BLL.tblBeike bll=new Maticsoft.BLL.tblBeike();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
