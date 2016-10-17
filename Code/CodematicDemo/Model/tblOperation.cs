using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblOperation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblOperation
	{
		public tblOperation()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _act;
		private string _memo;
		private DateTime? _opdate;
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
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string act
		{
			set{ _act=value;}
			get{return _act;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? opdate
		{
			set{ _opdate=value;}
			get{return _opdate;}
		}
		#endregion Model

	}
}

