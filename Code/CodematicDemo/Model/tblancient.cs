using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblancient:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblancient
	{
		public tblancient()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private DateTime? _pubdate;
		private string _keyword;
		private int? _viewcounts;
		private int? _first_id;
		private int? _second_id;
		private int? _third_id;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 文章标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 文章内容
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime? pubdate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
		}
		/// <summary>
		/// 关键字（用于相关推荐）
		/// </summary>
		public string keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 点击数量
		/// </summary>
		public int? viewcounts
		{
			set{ _viewcounts=value;}
			get{return _viewcounts;}
		}
		/// <summary>
		/// 一级分类编号
		/// </summary>
		public int? first_id
		{
			set{ _first_id=value;}
			get{return _first_id;}
		}
		/// <summary>
		/// 二级分类编号
		/// </summary>
		public int? second_id
		{
			set{ _second_id=value;}
			get{return _second_id;}
		}
		/// <summary>
		/// 三级分类编号
		/// </summary>
		public int? third_id
		{
			set{ _third_id=value;}
			get{return _third_id;}
		}
		#endregion Model

	}
}

