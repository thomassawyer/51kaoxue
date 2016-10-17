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
namespace Maticsoft.Web.tblbookversion
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
		Maticsoft.BLL.tblbookversion bll=new Maticsoft.BLL.tblbookversion();
		Maticsoft.Model.tblbookversion model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtname.Text=model.name;
		this.txtsubjectid.Text=model.subjectid.ToString();
		this.txtpid.Text=model.pid.ToString();
		this.txtlayer.Text=model.layer.ToString();
		this.txtmemo.Text=model.memo;
		this.txtorderid.Text=model.orderid.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtsubjectid.Text))
			{
				strErr+="subjectid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtpid.Text))
			{
				strErr+="pid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtlayer.Text))
			{
				strErr+="layer格式错误！\\n";	
			}
			if(this.txtmemo.Text.Trim().Length==0)
			{
				strErr+="memo不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtorderid.Text))
			{
				strErr+="orderid格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string name=this.txtname.Text;
			int subjectid=int.Parse(this.txtsubjectid.Text);
			int pid=int.Parse(this.txtpid.Text);
			int layer=int.Parse(this.txtlayer.Text);
			string memo=this.txtmemo.Text;
			int orderid=int.Parse(this.txtorderid.Text);


			Maticsoft.Model.tblbookversion model=new Maticsoft.Model.tblbookversion();
			model.id=id;
			model.name=name;
			model.subjectid=subjectid;
			model.pid=pid;
			model.layer=layer;
			model.memo=memo;
			model.orderid=orderid;

			Maticsoft.BLL.tblbookversion bll=new Maticsoft.BLL.tblbookversion();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
