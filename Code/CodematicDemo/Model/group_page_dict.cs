using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// group_page_dict:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class group_page_dict
	{
		public group_page_dict()
		{}
		#region Model
		private string _groupid;
		private string _pageid;
		/// <summary>
		/// 
		/// </summary>
		public string GROUPID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAGEID
		{
			set{ _pageid=value;}
			get{return _pageid;}
		}
		#endregion Model

	}
}

