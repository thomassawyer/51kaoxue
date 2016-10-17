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
namespace Maticsoft.Web.tblcollect
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
		Maticsoft.BLL.tblcollect bll=new Maticsoft.BLL.tblcollect();
		Maticsoft.Model.tblcollect model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtuserid.Text=model.userid.ToString();
		this.txtcategory.Text=model.category.ToString();
		this.txtfileid.Text=model.fileid.ToString();
		this.txtcollectTime.Text=model.collectTime.ToString();
		this.txtfilename.Text=model.filename;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserid.Text))
			{
				strErr+="userid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtcategory.Text))
			{
				strErr+="category格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtfileid.Text))
			{
				strErr+="fileid格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtcollectTime.Text))
			{
				strErr+="collectTime格式错误！\\n";	
			}
			if(this.txtfilename.Text.Trim().Length==0)
			{
				strErr+="filename不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int userid=int.Parse(this.txtuserid.Text);
			int category=int.Parse(this.txtcategory.Text);
			int fileid=int.Parse(this.txtfileid.Text);
			DateTime collectTime=DateTime.Parse(this.txtcollectTime.Text);
			string filename=this.txtfilename.Text;


			Maticsoft.Model.tblcollect model=new Maticsoft.Model.tblcollect();
			model.id=id;
			model.userid=userid;
			model.category=category;
			model.fileid=fileid;
			model.collectTime=collectTime;
			model.filename=filename;

			Maticsoft.BLL.tblcollect bll=new Maticsoft.BLL.tblcollect();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
