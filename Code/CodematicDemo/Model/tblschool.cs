using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblschool:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblschool
	{
		public tblschool()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _headname;
		private string _star;
		private string _content;
		private int? _level;
		private int? _areaid;
		private DateTime _intime;
		private string _imgsrc;
		private int? _schoolposition;
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
		public string headname
		{
			set{ _headname=value;}
			get{return _headname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string star
		{
			set{ _star=value;}
			get{return _star;}
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
		public DateTime intime
		{
			set{ _intime=value;}
			get{return _intime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgsrc
		{
			set{ _imgsrc=value;}
			get{return _imgsrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SchoolPosition
		{
			set{ _schoolposition=value;}
			get{return _schoolposition;}
		}
		#endregion Model

	}
}

