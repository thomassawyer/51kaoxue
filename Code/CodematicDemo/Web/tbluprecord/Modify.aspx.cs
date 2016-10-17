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
namespace Maticsoft.Web.tbluprecord
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int userid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(userid);
				}
			}
		}
			
	private void ShowInfo(int userid)
	{
		Maticsoft.BLL.tbluprecord bll=new Maticsoft.BLL.tbluprecord();
		Maticsoft.Model.tbluprecord model=bll.GetModel(userid);
		this.lbluserid.Text=model.userid.ToString();
		this.txtzong.Text=model.zong.ToString();
		this.txttoday.Text=model.today.ToString();
		this.txtuptime.Text=model.uptime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtzong.Text))
			{
				strErr+="zong格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttoday.Text))
			{
				strErr+="today格式错误！\\n";	
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
			int userid=int.Parse(this.lbluserid.Text);
			int zong=int.Parse(this.txtzong.Text);
			int today=int.Parse(this.txttoday.Text);
			DateTime uptime=DateTime.Parse(this.txtuptime.Text);


			Maticsoft.Model.tbluprecord model=new Maticsoft.Model.tbluprecord();
			model.userid=userid;
			model.zong=zong;
			model.today=today;
			model.uptime=uptime;

			Maticsoft.BLL.tbluprecord bll=new Maticsoft.BLL.tbluprecord();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
