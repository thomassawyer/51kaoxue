using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tbluplog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbluplog
	{
		public tbluplog()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private DateTime? _uptime;
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
		public DateTime? uptime
		{
			set{ _uptime=value;}
			get{return _uptime;}
		}
		#endregion Model

	}
}

