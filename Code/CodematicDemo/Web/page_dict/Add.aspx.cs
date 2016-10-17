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
namespace Maticsoft.Web.page_dict
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPAGEID.Text.Trim().Length==0)
			{
				strErr+="PAGEID不能为空！\\n";	
			}
			if(this.txtPAGENAME.Text.Trim().Length==0)
			{
				strErr+="PAGENAME不能为空！\\n";	
			}
			if(this.txtPAGEPARENTID.Text.Trim().Length==0)
			{
				strErr+="PAGEPARENTID不能为空！\\n";	
			}
			if(this.txtPAGEURL.Text.Trim().Length==0)
			{
				strErr+="PAGEURL不能为空！\\n";	
			}
			if(this.txtPAGETARGET.Text.Trim().Length==0)
			{
				strErr+="PAGETARGET不能为空！\\n";	
			}
			if(this.txtPAGEIMG.Text.Trim().Length==0)
			{
				strErr+="PAGEIMG不能为空！\\n";	
			}
			if(this.txtCHECKFLAG.Text.Trim().Length==0)
			{
				strErr+="CHECKFLAG不能为空！\\n";	
			}
			if(this.txtPAGEMOUDAL.Text.Trim().Length==0)
			{
				strErr+="PAGEMOUDAL不能为空！\\n";	
			}
			if(this.txtISFLAG.Text.Trim().Length==0)
			{
				strErr+="ISFLAG不能为空！\\n";	
			}
			if(this.txtSEQSORT.Text.Trim().Length==0)
			{
				strErr+="SEQSORT不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string PAGEID=this.txtPAGEID.Text;
			string PAGENAME=this.txtPAGENAME.Text;
			string PAGEPARENTID=this.txtPAGEPARENTID.Text;
			string PAGEURL=this.txtPAGEURL.Text;
			string PAGETARGET=this.txtPAGETARGET.Text;
			string PAGEIMG=this.txtPAGEIMG.Text;
			string CHECKFLAG=this.txtCHECKFLAG.Text;
			string PAGEMOUDAL=this.txtPAGEMOUDAL.Text;
			string ISFLAG=this.txtISFLAG.Text;
			string SEQSORT=this.txtSEQSORT.Text;

			Maticsoft.Model.page_dict model=new Maticsoft.Model.page_dict();
			model.PAGEID=PAGEID;
			model.PAGENAME=PAGENAME;
			model.PAGEPARENTID=PAGEPARENTID;
			model.PAGEURL=PAGEURL;
			model.PAGETARGET=PAGETARGET;
			model.PAGEIMG=PAGEIMG;
			model.CHECKFLAG=CHECKFLAG;
			model.PAGEMOUDAL=PAGEMOUDAL;
			model.ISFLAG=ISFLAG;
			model.SEQSORT=SEQSORT;

			Maticsoft.BLL.page_dict bll=new Maticsoft.BLL.page_dict();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
