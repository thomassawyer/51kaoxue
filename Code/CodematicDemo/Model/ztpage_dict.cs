using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ztpage_dict:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ztpage_dict
	{
		public ztpage_dict()
		{}
		#region Model
		private int _id;
		private int? _pageid;
		private string _pagename;
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
		public int? pageid
		{
			set{ _pageid=value;}
			get{return _pageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pagename
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		#endregion Model

	}
}

