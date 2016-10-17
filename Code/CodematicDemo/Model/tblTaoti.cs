using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblTaoti:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblTaoti
	{
		public tblTaoti()
		{}
		#region Model
		private int _id;
		private int? _level;
		private int? _areaid;
		private int? _subjectid;
		private string _name;
		private int? _viewcount;
		private DateTime _pubdate;
		private int? _schoolid;
		private string _ismingxiao;
		private string _istuijian;
		private string _isjingpin;
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
		public DateTime pubdate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
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
		public string istuijian
		{
			set{ _istuijian=value;}
			get{return _istuijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isjingpin
		{
			set{ _isjingpin=value;}
			get{return _isjingpin;}
		}
		#endregion Model

	}
}

