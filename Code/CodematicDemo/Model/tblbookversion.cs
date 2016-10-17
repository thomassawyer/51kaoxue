using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblbookversion:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblbookversion
	{
		public tblbookversion()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _subjectid;
		private int? _pid;
		private int? _layer;
		private string _memo;
		private int? _orderid;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? subjectid
		{
			set{ _subjectid=value;}
			get{return _subjectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? layer
		{
			set{ _layer=value;}
			get{return _layer;}
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
		public int? orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

