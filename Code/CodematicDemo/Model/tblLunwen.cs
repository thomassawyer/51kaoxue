using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblLunwen:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblLunwen
	{
		public tblLunwen()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _filesrc;
		private int? _subjectid;
		private int? _areaid;
		private int? _downum;
		private int? _downeed;
		private DateTime? _uploaddate;
		private string _memoinfo;
		private string _uploader;
		private string _extension;
		private string _year;
		private string _level;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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
		public int? subjectid
		{
			set{ _subjectid=value;}
			get{return _subjectid;}
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
		public int? downum
		{
			set{ _downum=value;}
			get{return _downum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? downeed
		{
			set{ _downeed=value;}
			get{return _downeed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? uploaddate
		{
			set{ _uploaddate=value;}
			get{return _uploaddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string memoinfo
		{
			set{ _memoinfo=value;}
			get{return _memoinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uploader
		{
			set{ _uploader=value;}
			get{return _uploader;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string extension
		{
			set{ _extension=value;}
			get{return _extension;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string level
		{
			set{ _level=value;}
			get{return _level;}
		}
		#endregion Model

	}
}

