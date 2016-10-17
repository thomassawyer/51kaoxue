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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string PAGEID= Request.Params["id"];
					ShowInfo(PAGEID);
				}
			}
		}
			
	private void ShowInfo(string PAGEID)
	{
		Maticsoft.BLL.page_dict bll=new Maticsoft.BLL.page_dict();
		Maticsoft.Model.page_dict model=bll.GetModel(PAGEID);
		this.lblPAGEID.Text=model.PAGEID;
		this.txtPAGENAME.Text=model.PAGENAME;
		this.txtPAGEPARENTID.Text=model.PAGEPARENTID;
		this.txtPAGEURL.Text=model.PAGEURL;
		this.txtPAGETARGET.Text=model.PAGETARGET;
		this.txtPAGEIMG.Text=model.PAGEIMG;
		this.txtCHECKFLAG.Text=model.CHECKFLAG;
		this.txtPAGEMOUDAL.Text=model.PAGEMOUDAL;
		this.txtISFLAG.Text=model.ISFLAG;
		this.txtSEQSORT.Text=model.SEQSORT;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			string PAGEID=this.lblPAGEID.Text;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
