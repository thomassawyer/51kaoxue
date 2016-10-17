using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblBanner:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblBanner
	{
		public tblBanner()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _type;
		private string _page;
		private string _pic;
		private int? _sort;
		private string _link;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string page
		{
			set{ _page=value;}
			get{return _page;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic
		{
			set{ _pic=value;}
			get{return _pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string link
		{
			set{ _link=value;}
			get{return _link;}
		}
		#endregion Model

	}
}

