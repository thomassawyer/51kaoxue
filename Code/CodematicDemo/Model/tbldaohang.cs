using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tbldaohang:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbldaohang
	{
		public tbldaohang()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _year;
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
		public int? year
		{
			set{ _year=value;}
			get{return _year;}
		}
		#endregion Model

	}
}

