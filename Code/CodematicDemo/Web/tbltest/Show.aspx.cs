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
namespace Maticsoft.Web.tbltest
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
		Maticsoft.BLL.tbltest bll=new Maticsoft.BLL.tbltest();
		Maticsoft.Model.tbltest model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbllevel.Text=model.level.ToString();
		this.lblareaid.Text=model.areaid.ToString();
		this.lblsubjectid.Text=model.subjectid.ToString();
		this.lbltestcategory.Text=model.testcategory.ToString();
		this.lbltestname.Text=model.testname;
		this.lbluploadtime.Text=model.uploadtime.ToString();
		this.lblfilesrc.Text=model.filesrc;
		this.lbldownloadnum.Text=model.downloadnum.ToString();
		this.lblneednum.Text=model.neednum.ToString();
		this.lblextension.Text=model.extension;
		this.lblyear.Text=model.year;
		this.lbluploader.Text=model.uploader;
		this.lblcontent.Text=model.content;
		this.lblgroupid.Text=model.groupid.ToString();
		this.lblschoolid.Text=model.schoolid.ToString();
		this.lblismingxiao.Text=model.ismingxiao;
		this.lblisjingpin.Text=model.isjingpin;
		this.lblistuijian.Text=model.istuijian;
		this.lblisgaokao.Text=model.isgaokao;
		this.lblisdujia.Text=model.isdujia;
		this.lblbeikao.Text=model.beikao;

	}


    }
}
