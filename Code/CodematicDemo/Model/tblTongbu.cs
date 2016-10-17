using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblTongbu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblTongbu
	{
		public tblTongbu()
		{}
		#region Model
		private int _id;
		private int? _level;
		private int? _subjectid;
		private int? _versionid;
		private string _name;
		private DateTime? _uploadtime;
		private string _filesrc;
		private int? _downloadnum;
		private int? _neednum;
		private string _extension;
		private string _year;
		private string _uploader;
		private string _content;
		private int? _prepareid;
		private int? _isjing;
		private int? _isgaokao;
		private int? _isdujia;
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
		public int? subjectid
		{
			set{ _subjectid=value;}
			get{return _subjectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? versionid
		{
			set{ _versionid=value;}
			get{return _versionid;}
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
		public DateTime? uploadtime
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
		public int? prepareid
		{
			set{ _prepareid=value;}
			get{return _prepareid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isjing
		{
			set{ _isjing=value;}
			get{return _isjing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isgaokao
		{
			set{ _isgaokao=value;}
			get{return _isgaokao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isdujia
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

