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
namespace Maticsoft.Web.tblWebinfo
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
		Maticsoft.BLL.tblWebinfo bll=new Maticsoft.BLL.tblWebinfo();
		Maticsoft.Model.tblWebinfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtname.Text=model.name;
		this.txtlogosrc.Text=model.logosrc;
		this.txtfootinfo.Text=model.footinfo;
		this.txtheadseo.Text=model.headseo;
		this.txtkeyseo.Text=model.keyseo;
		this.txtdescribseo.Text=model.describseo;
		this.txtweixin.Text=model.weixin;
		this.txtweibo.Text=model.weibo;
		this.txtgengxin.Text=model.gengxin;
		this.txtzongliang.Text=model.zongliang;
		this.txtschooltestnum.Text=model.schooltestnum;
		this.txtjinpintestnum.Text=model.jinpintestnum;
		this.txtschoolnum.Text=model.schoolnum;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txtlogosrc.Text.Trim().Length==0)
			{
				strErr+="logosrc不能为空！\\n";	
			}
			if(this.txtfootinfo.Text.Trim().Length==0)
			{
				strErr+="footinfo不能为空！\\n";	
			}
			if(this.txtheadseo.Text.Trim().Length==0)
			{
				strErr+="headseo不能为空！\\n";	
			}
			if(this.txtkeyseo.Text.Trim().Length==0)
			{
				strErr+="keyseo不能为空！\\n";	
			}
			if(this.txtdescribseo.Text.Trim().Length==0)
			{
				strErr+="describseo不能为空！\\n";	
			}
			if(this.txtweixin.Text.Trim().Length==0)
			{
				strErr+="weixin不能为空！\\n";	
			}
			if(this.txtweibo.Text.Trim().Length==0)
			{
				strErr+="weibo不能为空！\\n";	
			}
			if(this.txtgengxin.Text.Trim().Length==0)
			{
				strErr+="gengxin不能为空！\\n";	
			}
			if(this.txtzongliang.Text.Trim().Length==0)
			{
				strErr+="zongliang不能为空！\\n";	
			}
			if(this.txtschooltestnum.Text.Trim().Length==0)
			{
				strErr+="schooltestnum不能为空！\\n";	
			}
			if(this.txtjinpintestnum.Text.Trim().Length==0)
			{
				strErr+="jinpintestnum不能为空！\\n";	
			}
			if(this.txtschoolnum.Text.Trim().Length==0)
			{
				strErr+="schoolnum不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string name=this.txtname.Text;
			string logosrc=this.txtlogosrc.Text;
			string footinfo=this.txtfootinfo.Text;
			string headseo=this.txtheadseo.Text;
			string keyseo=this.txtkeyseo.Text;
			string describseo=this.txtdescribseo.Text;
			string weixin=this.txtweixin.Text;
			string weibo=this.txtweibo.Text;
			string gengxin=this.txtgengxin.Text;
			string zongliang=this.txtzongliang.Text;
			string schooltestnum=this.txtschooltestnum.Text;
			string jinpintestnum=this.txtjinpintestnum.Text;
			string schoolnum=this.txtschoolnum.Text;


			Maticsoft.Model.tblWebinfo model=new Maticsoft.Model.tblWebinfo();
			model.id=id;
			model.name=name;
			model.logosrc=logosrc;
			model.footinfo=footinfo;
			model.headseo=headseo;
			model.keyseo=keyseo;
			model.describseo=describseo;
			model.weixin=weixin;
			model.weibo=weibo;
			model.gengxin=gengxin;
			model.zongliang=zongliang;
			model.schooltestnum=schooltestnum;
			model.jinpintestnum=jinpintestnum;
			model.schoolnum=schoolnum;

			Maticsoft.BLL.tblWebinfo bll=new Maticsoft.BLL.tblWebinfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
