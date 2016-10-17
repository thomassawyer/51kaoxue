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
namespace Maticsoft.Web.tblBanner
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
		Maticsoft.BLL.tblBanner bll=new Maticsoft.BLL.tblBanner();
		Maticsoft.Model.tblBanner model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txttitle.Text=model.title;
		this.txttype.Text=model.type;
		this.txtpage.Text=model.page;
		this.txtpic.Text=model.pic;
		this.txtsort.Text=model.sort.ToString();
		this.txtlink.Text=model.link;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="title不能为空！\\n";	
			}
			if(this.txttype.Text.Trim().Length==0)
			{
				strErr+="type不能为空！\\n";	
			}
			if(this.txtpage.Text.Trim().Length==0)
			{
				strErr+="page不能为空！\\n";	
			}
			if(this.txtpic.Text.Trim().Length==0)
			{
				strErr+="pic不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtsort.Text))
			{
				strErr+="sort格式错误！\\n";	
			}
			if(this.txtlink.Text.Trim().Length==0)
			{
				strErr+="link不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string title=this.txttitle.Text;
			string type=this.txttype.Text;
			string page=this.txtpage.Text;
			string pic=this.txtpic.Text;
			int sort=int.Parse(this.txtsort.Text);
			string link=this.txtlink.Text;


			Maticsoft.Model.tblBanner model=new Maticsoft.Model.tblBanner();
			model.id=id;
			model.title=title;
			model.type=type;
			model.page=page;
			model.pic=pic;
			model.sort=sort;
			model.link=link;

			Maticsoft.BLL.tblBanner bll=new Maticsoft.BLL.tblBanner();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
