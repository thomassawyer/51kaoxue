using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ancient_category_second:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ancient_category_second
	{
		public ancient_category_second()
		{}
		#region Model
		private int _id;
		private string _title;
		private int? _first_id;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 二级古文分类名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 一级古文分类编号
		/// </summary>
		public int? first_id
		{
			set{ _first_id=value;}
			get{return _first_id;}
		}
		#endregion Model

	}
}

