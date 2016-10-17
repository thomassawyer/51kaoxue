using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblNewstype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblNewstype
	{
		public tblNewstype()
		{}
		#region Model
		private int _id;
		private string _categoryname;
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
		public string categoryname
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
		}
		#endregion Model

	}
}

