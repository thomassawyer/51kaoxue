﻿using System;
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
namespace Maticsoft.Web.tblcollect
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.tblcollect bll=new Maticsoft.BLL.tblcollect();
		Maticsoft.Model.tblcollect model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbluserid.Text=model.userid.ToString();
		this.lblcategory.Text=model.category.ToString();
		this.lblfileid.Text=model.fileid.ToString();
		this.lblcollectTime.Text=model.collectTime.ToString();
		this.lblfilename.Text=model.filename;

	}


    }
}
