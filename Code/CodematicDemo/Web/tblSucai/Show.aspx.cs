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
namespace Maticsoft.Web.tblSucai
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
		Maticsoft.BLL.tblSucai bll=new Maticsoft.BLL.tblSucai();
		Maticsoft.Model.tblSucai model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbllevel.Text=model.level.ToString();
		this.lblsubjectid.Text=model.subjectid.ToString();
		this.lblversionid.Text=model.versionid.ToString();
		this.lblname.Text=model.name;
		this.lbluploadtime.Text=model.uploadtime.ToString();
		this.lblfilesrc.Text=model.filesrc;
		this.lbldownloadnum.Text=model.downloadnum.ToString();
		this.lblneednum.Text=model.neednum.ToString();
		this.lblextension.Text=model.extension;
		this.lblyear.Text=model.year;
		this.lbluploader.Text=model.uploader;
		this.lblcontent.Text=model.content;
		this.lblprepareid.Text=model.prepareid.ToString();
		this.lblisjing.Text=model.isjing.ToString();
		this.lblisgaokao.Text=model.isgaokao.ToString();
		this.lblisdujia.Text=model.isdujia.ToString();
		this.lblbeikao.Text=model.beikao;

	}


    }
}
