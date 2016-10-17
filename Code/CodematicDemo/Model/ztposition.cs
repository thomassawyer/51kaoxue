using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ztposition:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ztposition
	{
		public ztposition()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _sort;
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
		public string sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

