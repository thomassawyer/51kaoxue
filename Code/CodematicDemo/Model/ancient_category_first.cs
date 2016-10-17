using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ancient_category_first:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ancient_category_first
	{
		public ancient_category_first()
		{}
		#region Model
		private int _id;
		private string _title;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 一级古文分类名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		#endregion Model

	}
}

