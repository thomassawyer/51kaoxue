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
namespace Maticsoft.Web.tbldlrecord
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			if(!PageValidate.IsDateTime(txtdltime.Text))
			{
				strErr+="dltime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtspnum.Text))
			{
				strErr+="spnum格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtlevel.Text))
			{
				strErr+="level格式错误！\\n";	
			}
			if(this.txtfilename.Text.Trim().Length==0)
			{
				strErr+="filename不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtFK_subject_ID.Text))
			{
				strErr+="FK_subject_ID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int userid=int.Parse(this.txtuserid.Text);
			int category=int.Parse(this.txtcategory.Text);
			int fileid=int.Parse(this.txtfileid.Text);
			DateTime dltime=DateTime.Parse(this.txtdltime.Text);
			int spnum=int.Parse(this.txtspnum.Text);
			int level=int.Parse(this.txtlevel.Text);
			string filename=this.txtfilename.Text;
			int FK_subject_ID=int.Parse(this.txtFK_subject_ID.Text);

			Maticsoft.Model.tbldlrecord model=new Maticsoft.Model.tbldlrecord();
			model.userid=userid;
			model.category=category;
			model.fileid=fileid;
			model.dltime=dltime;
			model.spnum=spnum;
			model.level=level;
			model.filename=filename;
			model.FK_subject_ID=FK_subject_ID;

			Maticsoft.BLL.tbldlrecord bll=new Maticsoft.BLL.tbldlrecord();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
