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
namespace Maticsoft.Web.tblschool
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
		Maticsoft.BLL.tblschool bll=new Maticsoft.BLL.tblschool();
		Maticsoft.Model.tblschool model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtname.Text=model.name;
		this.txtheadname.Text=model.headname;
		this.txtstar.Text=model.star;
		this.txtcontent.Text=model.content;
		this.txtlevel.Text=model.level.ToString();
		this.txtareaid.Text=model.areaid.ToString();
		this.lblintime.Text=model.intime.ToString();
		this.txtimgsrc.Text=model.imgsrc;
		this.txtSchoolPosition.Text=model.SchoolPosition.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txtheadname.Text.Trim().Length==0)
			{
				strErr+="headname不能为空！\\n";	
			}
			if(this.txtstar.Text.Trim().Length==0)
			{
				strErr+="star不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="content不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtlevel.Text))
			{
				strErr+="level格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtareaid.Text))
			{
				strErr+="areaid格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtintime.Text))
			{
				strErr+="intime格式错误！\\n";	
			}
			if(this.txtimgsrc.Text.Trim().Length==0)
			{
				strErr+="imgsrc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtSchoolPosition.Text))
			{
				strErr+="SchoolPosition格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string name=this.txtname.Text;
			string headname=this.txtheadname.Text;
			string star=this.txtstar.Text;
			string content=this.txtcontent.Text;
			int level=int.Parse(this.txtlevel.Text);
			int areaid=int.Parse(this.txtareaid.Text);
			DateTime intime=DateTime.Parse(this.txtintime.Text);
			string imgsrc=this.txtimgsrc.Text;
			int SchoolPosition=int.Parse(this.txtSchoolPosition.Text);


			Maticsoft.Model.tblschool model=new Maticsoft.Model.tblschool();
			model.id=id;
			model.name=name;
			model.headname=headname;
			model.star=star;
			model.content=content;
			model.level=level;
			model.areaid=areaid;
			model.intime=intime;
			model.imgsrc=imgsrc;
			model.SchoolPosition=SchoolPosition;

			Maticsoft.BLL.tblschool bll=new Maticsoft.BLL.tblschool();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
