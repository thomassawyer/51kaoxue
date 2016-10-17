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
namespace Maticsoft.Web.webusers
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
		Maticsoft.BLL.webusers bll=new Maticsoft.BLL.webusers();
		Maticsoft.Model.webusers model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtusername.Text=model.username;
		this.txtpassword.Text=model.password;
		this.txtemail.Text=model.email;
		this.txtschool.Text=model.school;
		this.txtname.Text=model.name;
		this.txtmobile.Text=model.mobile;
		this.txtprovince.Text=model.province;
		this.txtcity.Text=model.city;
		this.txtposition.Text=model.position;
		this.txtsubject.Text=model.subject;
		this.txtaddress.Text=model.address;
		this.txttel.Text=model.tel;
		this.txtlevel.Text=model.level;
		this.txtregdate.Text=model.regdate.ToString();
		this.txtip.Text=model.ip;
		this.txtdaoqidate.Text=model.daoqidate.ToString();
		this.txtopenpwd.Text=model.openpwd;
		this.txtyewu.Text=model.yewu;
		this.txtprovinceid.Text=model.provinceid;
		this.txtcityid.Text=model.cityid;
		this.txtgrade.Text=model.grade;
		this.txtstatus.Text=model.status;
		this.txtyewudiqv.Text=model.yewudiqv;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtusername.Text.Trim().Length==0)
			{
				strErr+="username不能为空！\\n";	
			}
			if(this.txtpassword.Text.Trim().Length==0)
			{
				strErr+="password不能为空！\\n";	
			}
			if(this.txtemail.Text.Trim().Length==0)
			{
				strErr+="email不能为空！\\n";	
			}
			if(this.txtschool.Text.Trim().Length==0)
			{
				strErr+="school不能为空！\\n";	
			}
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txtmobile.Text.Trim().Length==0)
			{
				strErr+="mobile不能为空！\\n";	
			}
			if(this.txtprovince.Text.Trim().Length==0)
			{
				strErr+="province不能为空！\\n";	
			}
			if(this.txtcity.Text.Trim().Length==0)
			{
				strErr+="city不能为空！\\n";	
			}
			if(this.txtposition.Text.Trim().Length==0)
			{
				strErr+="position不能为空！\\n";	
			}
			if(this.txtsubject.Text.Trim().Length==0)
			{
				strErr+="subject不能为空！\\n";	
			}
			if(this.txtaddress.Text.Trim().Length==0)
			{
				strErr+="address不能为空！\\n";	
			}
			if(this.txttel.Text.Trim().Length==0)
			{
				strErr+="tel不能为空！\\n";	
			}
			if(this.txtlevel.Text.Trim().Length==0)
			{
				strErr+="level不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtregdate.Text))
			{
				strErr+="regdate格式错误！\\n";	
			}
			if(this.txtip.Text.Trim().Length==0)
			{
				strErr+="ip不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtdaoqidate.Text))
			{
				strErr+="daoqidate格式错误！\\n";	
			}
			if(this.txtopenpwd.Text.Trim().Length==0)
			{
				strErr+="openpwd不能为空！\\n";	
			}
			if(this.txtyewu.Text.Trim().Length==0)
			{
				strErr+="yewu不能为空！\\n";	
			}
			if(this.txtprovinceid.Text.Trim().Length==0)
			{
				strErr+="provinceid不能为空！\\n";	
			}
			if(this.txtcityid.Text.Trim().Length==0)
			{
				strErr+="cityid不能为空！\\n";	
			}
			if(this.txtgrade.Text.Trim().Length==0)
			{
				strErr+="grade不能为空！\\n";	
			}
			if(this.txtstatus.Text.Trim().Length==0)
			{
				strErr+="status不能为空！\\n";	
			}
			if(this.txtyewudiqv.Text.Trim().Length==0)
			{
				strErr+="yewudiqv不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string username=this.txtusername.Text;
			string password=this.txtpassword.Text;
			string email=this.txtemail.Text;
			string school=this.txtschool.Text;
			string name=this.txtname.Text;
			string mobile=this.txtmobile.Text;
			string province=this.txtprovince.Text;
			string city=this.txtcity.Text;
			string position=this.txtposition.Text;
			string subject=this.txtsubject.Text;
			string address=this.txtaddress.Text;
			string tel=this.txttel.Text;
			string level=this.txtlevel.Text;
			DateTime regdate=DateTime.Parse(this.txtregdate.Text);
			string ip=this.txtip.Text;
			DateTime daoqidate=DateTime.Parse(this.txtdaoqidate.Text);
			string openpwd=this.txtopenpwd.Text;
			string yewu=this.txtyewu.Text;
			string provinceid=this.txtprovinceid.Text;
			string cityid=this.txtcityid.Text;
			string grade=this.txtgrade.Text;
			string status=this.txtstatus.Text;
			string yewudiqv=this.txtyewudiqv.Text;


			Maticsoft.Model.webusers model=new Maticsoft.Model.webusers();
			model.id=id;
			model.username=username;
			model.password=password;
			model.email=email;
			model.school=school;
			model.name=name;
			model.mobile=mobile;
			model.province=province;
			model.city=city;
			model.position=position;
			model.subject=subject;
			model.address=address;
			model.tel=tel;
			model.level=level;
			model.regdate=regdate;
			model.ip=ip;
			model.daoqidate=daoqidate;
			model.openpwd=openpwd;
			model.yewu=yewu;
			model.provinceid=provinceid;
			model.cityid=cityid;
			model.grade=grade;
			model.status=status;
			model.yewudiqv=yewudiqv;

			Maticsoft.BLL.webusers bll=new Maticsoft.BLL.webusers();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
