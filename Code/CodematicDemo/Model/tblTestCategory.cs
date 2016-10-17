using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblTestCategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblTestCategory
	{
		public tblTestCategory()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _level;
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
		public int? level
		{
			set{ _level=value;}
			get{return _level;}
		}
		#endregion Model

	}
}

