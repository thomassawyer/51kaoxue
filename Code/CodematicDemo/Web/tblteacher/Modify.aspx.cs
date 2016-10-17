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
namespace Maticsoft.Web.tblteacher
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
		Maticsoft.BLL.tblteacher bll=new Maticsoft.BLL.tblteacher();
		Maticsoft.Model.tblteacher model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtname.Text=model.name;
		this.txtimgsrc.Text=model.imgsrc;
		this.txtschoolid.Text=model.schoolid.ToString();
		this.txtposition.Text=model.position.ToString();
		this.txtmemo.Text=model.memo;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txtimgsrc.Text.Trim().Length==0)
			{
				strErr+="imgsrc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtschoolid.Text))
			{
				strErr+="schoolid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtposition.Text))
			{
				strErr+="position格式错误！\\n";	
			}
			if(this.txtmemo.Text.Trim().Length==0)
			{
				strErr+="memo不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string name=this.txtname.Text;
			string imgsrc=this.txtimgsrc.Text;
			int schoolid=int.Parse(this.txtschoolid.Text);
			int position=int.Parse(this.txtposition.Text);
			string memo=this.txtmemo.Text;


			Maticsoft.Model.tblteacher model=new Maticsoft.Model.tblteacher();
			model.id=id;
			model.name=name;
			model.imgsrc=imgsrc;
			model.schoolid=schoolid;
			model.position=position;
			model.memo=memo;

			Maticsoft.BLL.tblteacher bll=new Maticsoft.BLL.tblteacher();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
