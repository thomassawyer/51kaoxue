using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tbltest:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbltest
	{
		public tbltest()
		{}
		#region Model
		private int _id;
		private int? _level;
		private int? _areaid;
		private int? _subjectid;
		private int? _testcategory;
		private string _testname;
		private DateTime _uploadtime;
		private string _filesrc;
		private int? _downloadnum;
		private int? _neednum;
		private string _extension;
		private string _year;
		private string _uploader;
		private string _content;
		private int? _groupid;
		private int? _schoolid;
		private string _ismingxiao;
		private string _isjingpin;
		private string _istuijian;
		private string _isgaokao;
		private string _isdujia;
		private string _beikao;
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
		public int? level
		{
			set{ _level=value;}
			get{return _level;}
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
		public int? subjectid
		{
			set{ _subjectid=value;}
			get{return _subjectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? testcategory
		{
			set{ _testcategory=value;}
			get{return _testcategory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string testname
		{
			set{ _testname=value;}
			get{return _testname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime uploadtime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
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
		public int? downloadnum
		{
			set{ _downloadnum=value;}
			get{return _downloadnum;}
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
		public string uploader
		{
			set{ _uploader=value;}
			get{return _uploader;}
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
		public int? groupid
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? schoolid
		{
			set{ _schoolid=value;}
			get{return _schoolid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ismingxiao
		{
			set{ _ismingxiao=value;}
			get{return _ismingxiao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isjingpin
		{
			set{ _isjingpin=value;}
			get{return _isjingpin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string istuijian
		{
			set{ _istuijian=value;}
			get{return _istuijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isgaokao
		{
			set{ _isgaokao=value;}
			get{return _isgaokao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isdujia
		{
			set{ _isdujia=value;}
			get{return _isdujia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string beikao
		{
			set{ _beikao=value;}
			get{return _beikao;}
		}
		#endregion Model

	}
}

