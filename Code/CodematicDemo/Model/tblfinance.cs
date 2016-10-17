using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblfinance:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblfinance
	{
		public tblfinance()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private string _username;
		private int? _accountbalance;
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
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? accountbalance
		{
			set{ _accountbalance=value;}
			get{return _accountbalance;}
		}
		#endregion Model

	}
}

