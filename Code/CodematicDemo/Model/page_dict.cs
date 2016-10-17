using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// page_dict:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class page_dict
	{
		public page_dict()
		{}
		#region Model
		private string _pageid;
		private string _pagename;
		private string _pageparentid;
		private string _pageurl;
		private string _pagetarget;
		private string _pageimg;
		private string _checkflag;
		private string _pagemoudal;
		private string _isflag;
		private string _seqsort;
		/// <summary>
		/// 
		/// </summary>
		public string PAGEID
		{
			set{ _pageid=value;}
			get{return _pageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAGENAME
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAGEPARENTID
		{
			set{ _pageparentid=value;}
			get{return _pageparentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAGEURL
		{
			set{ _pageurl=value;}
			get{return _pageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAGETARGET
		{
			set{ _pagetarget=value;}
			get{return _pagetarget;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAGEIMG
		{
			set{ _pageimg=value;}
			get{return _pageimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CHECKFLAG
		{
			set{ _checkflag=value;}
			get{return _checkflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAGEMOUDAL
		{
			set{ _pagemoudal=value;}
			get{return _pagemoudal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ISFLAG
		{
			set{ _isflag=value;}
			get{return _isflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SEQSORT
		{
			set{ _seqsort=value;}
			get{return _seqsort;}
		}
		#endregion Model

	}
}

