using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblteacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblteacher
	{
		public tblteacher()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _imgsrc;
		private int? _schoolid;
		private int? _position;
		private string _memo;
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
		public string imgsrc
		{
			set{ _imgsrc=value;}
			get{return _imgsrc;}
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
		public int? position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		#endregion Model

	}
}

