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
namespace Maticsoft.Web.tblschool
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txtheadname.Text.Trim().Length==0)
			{
				strErr+="headname不能为空！\\n";	
			}
			if(this.txtstar.Text.Trim().Length==0)
			{
				strErr+="star不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="content不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtlevel.Text))
			{
				strErr+="level格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtareaid.Text))
			{
				strErr+="areaid格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtintime.Text))
			{
				strErr+="intime格式错误！\\n";	
			}
			if(this.txtimgsrc.Text.Trim().Length==0)
			{
				strErr+="imgsrc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtSchoolPosition.Text))
			{
				strErr+="SchoolPosition格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string name=this.txtname.Text;
			string headname=this.txtheadname.Text;
			string star=this.txtstar.Text;
			string content=this.txtcontent.Text;
			int level=int.Parse(this.txtlevel.Text);
			int areaid=int.Parse(this.txtareaid.Text);
			DateTime intime=DateTime.Parse(this.txtintime.Text);
			string imgsrc=this.txtimgsrc.Text;
			int SchoolPosition=int.Parse(this.txtSchoolPosition.Text);

			Maticsoft.Model.tblschool model=new Maticsoft.Model.tblschool();
			model.name=name;
			model.headname=headname;
			model.star=star;
			model.content=content;
			model.level=level;
			model.areaid=areaid;
			model.intime=intime;
			model.imgsrc=imgsrc;
			model.SchoolPosition=SchoolPosition;

			Maticsoft.BLL.tblschool bll=new Maticsoft.BLL.tblschool();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
