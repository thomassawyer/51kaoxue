using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblNews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblNews
	{
		public tblNews()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private DateTime _pubdate;
		private string _keyword;
		private string _isindex;
		private string _isenable;
		private string _type;
		private int? _viewcounts;
		private int? _areaid;
		private string _filesrc;
		private int? _neednum;
		private int? _downloadnum;
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
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime pubdate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isindex
		{
			set{ _isindex=value;}
			get{return _isindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isenable
		{
			set{ _isenable=value;}
			get{return _isenable;}
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
		public int? viewcounts
		{
			set{ _viewcounts=value;}
			get{return _viewcounts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? areaid
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filesrc
		{
			set{ _filesrc=value;}
			get{return _filesrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? neednum
		{
			set{ _neednum=value;}
			get{return _neednum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? downloadnum
		{
			set{ _downloadnum=value;}
			get{return _downloadnum;}
		}
		#endregion Model

	}
}

