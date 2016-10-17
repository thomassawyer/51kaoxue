using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblassign:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblassign
	{
		public tblassign()
		{}
		#region Model
		private int _id;
		private int? _testid;
		private int? _zttypeid;
		private int? _category;
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
		public int? testid
		{
			set{ _testid=value;}
			get{return _testid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? zttypeid
		{
			set{ _zttypeid=value;}
			get{return _zttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? category
		{
			set{ _category=value;}
			get{return _category;}
		}
		#endregion Model

	}
}

