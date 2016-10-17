using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblarea:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblarea
	{
		public tblarea()
		{}
		#region Model
		private int _id;
		private string _areaname;
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
		public string areaname
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		#endregion Model

	}
}

