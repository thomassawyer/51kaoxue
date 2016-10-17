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
namespace Maticsoft.Web.group_page_dict
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				string GROUPID = "";
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					GROUPID= Request.Params["id0"];
				}
				string PAGEID = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					PAGEID= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(GROUPID,PAGEID);
			}
		}
			
	private void ShowInfo(string GROUPID,string PAGEID)
	{
		Maticsoft.BLL.group_page_dict bll=new Maticsoft.BLL.group_page_dict();
		Maticsoft.Model.group_page_dict model=bll.GetModel(GROUPID,PAGEID);
		this.lblGROUPID.Text=model.GROUPID;
		this.lblPAGEID.Text=model.PAGEID;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string GROUPID=this.lblGROUPID.Text;
			string PAGEID=this.lblPAGEID.Text;


			Maticsoft.Model.group_page_dict model=new Maticsoft.Model.group_page_dict();
			model.GROUPID=GROUPID;
			model.PAGEID=PAGEID;

			Maticsoft.BLL.group_page_dict bll=new Maticsoft.BLL.group_page_dict();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
