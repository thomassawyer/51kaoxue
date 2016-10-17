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
namespace Maticsoft.Web.tbluplog
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
		Maticsoft.BLL.tbluplog bll=new Maticsoft.BLL.tbluplog();
		Maticsoft.Model.tbluplog model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtuserid.Text=model.userid.ToString();
		this.txtuptime.Text=model.uptime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserid.Text))
			{
				strErr+="userid格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtuptime.Text))
			{
				strErr+="uptime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int userid=int.Parse(this.txtuserid.Text);
			DateTime uptime=DateTime.Parse(this.txtuptime.Text);


			Maticsoft.Model.tbluplog model=new Maticsoft.Model.tbluplog();
			model.id=id;
			model.userid=userid;
			model.uptime=uptime;

			Maticsoft.BLL.tbluplog bll=new Maticsoft.BLL.tbluplog();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
