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
namespace Maticsoft.Web.tblzhenti
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
		Maticsoft.BLL.tblzhenti bll=new Maticsoft.BLL.tblzhenti();
		Maticsoft.Model.tblzhenti model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtyear.Text=model.year.ToString();
		this.txtdaohang.Text=model.daohang.ToString();
		this.txtsubjectid.Text=model.subjectid.ToString();
		this.txttype.Text=model.type.ToString();
		this.txttestid.Text=model.testid.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtyear.Text))
			{
				strErr+="year格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdaohang.Text))
			{
				strErr+="daohang格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtsubjectid.Text))
			{
				strErr+="subjectid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttype.Text))
			{
				strErr+="type格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttestid.Text))
			{
				strErr+="testid格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int year=int.Parse(this.txtyear.Text);
			int daohang=int.Parse(this.txtdaohang.Text);
			int subjectid=int.Parse(this.txtsubjectid.Text);
			int type=int.Parse(this.txttype.Text);
			int testid=int.Parse(this.txttestid.Text);


			Maticsoft.Model.tblzhenti model=new Maticsoft.Model.tblzhenti();
			model.id=id;
			model.year=year;
			model.daohang=daohang;
			model.subjectid=subjectid;
			model.type=type;
			model.testid=testid;

			Maticsoft.BLL.tblzhenti bll=new Maticsoft.BLL.tblzhenti();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
