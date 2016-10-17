using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblzhenti:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblzhenti
	{
		public tblzhenti()
		{}
		#region Model
		private int _id;
		private int? _year;
		private int? _daohang;
		private int? _subjectid;
		private int? _type;
		private int? _testid;
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
		public int? year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? daohang
		{
			set{ _daohang=value;}
			get{return _daohang;}
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
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? testid
		{
			set{ _testid=value;}
			get{return _testid;}
		}
		#endregion Model

	}
}

