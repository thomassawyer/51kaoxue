using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblzttype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblzttype
	{
		public tblzttype()
		{}
		#region Model
		private int _id;
		private string _typename;
		private int? _ztid;
		private int? _paixu;
		private string _includetest;
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
		public string typename
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ztid
		{
			set{ _ztid=value;}
			get{return _ztid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? paixu
		{
			set{ _paixu=value;}
			get{return _paixu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string includeTest
		{
			set{ _includetest=value;}
			get{return _includetest;}
		}
		#endregion Model

	}
}

