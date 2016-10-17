using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ancient_category_third:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ancient_category_third
	{
		public ancient_category_third()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _second_id;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 三级古文分类名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 二级古文分类编号
		/// </summary>
		public string second_id
		{
			set{ _second_id=value;}
			get{return _second_id;}
		}
		#endregion Model

	}
}

