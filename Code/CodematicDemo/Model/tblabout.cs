using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblabout:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblabout
	{
		public tblabout()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model

	}
}

