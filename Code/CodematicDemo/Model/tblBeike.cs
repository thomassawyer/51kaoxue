using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblBeike:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblBeike
	{
		public tblBeike()
		{}
		#region Model
		private int _id;
		private int? _level;
		private int? _areaid;
		private int? _subjectid;
		private string _name;
		private int? _viewcount;
		private DateTime? _pubdate;
		private int? _isjing;
		private int? _isgaokao;
		private int? _isdujia;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? viewcount
		{
			set{ _viewcount=value;}
			get{return _viewcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? pubdate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
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
		#endregion Model

	}
}

