using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblLink:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblLink
	{
		public tblLink()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _link;
		private string _pic;
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
		public string link
		{
			set{ _link=value;}
			get{return _link;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic
		{
			set{ _pic=value;}
			get{return _pic;}
		}
		#endregion Model

	}
}

