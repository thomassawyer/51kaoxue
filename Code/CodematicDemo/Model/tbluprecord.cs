using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tbluprecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbluprecord
	{
		public tbluprecord()
		{}
		#region Model
		private int _userid;
		private int? _zong;
		private int? _today;
		private DateTime? _uptime;
		/// <summary>
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? zong
		{
			set{ _zong=value;}
			get{return _zong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? today
		{
			set{ _today=value;}
			get{return _today;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? uptime
		{
			set{ _uptime=value;}
			get{return _uptime;}
		}
		#endregion Model

	}
}

