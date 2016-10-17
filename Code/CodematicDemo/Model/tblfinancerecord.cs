using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblfinancerecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblfinancerecord
	{
		public tblfinancerecord()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private int? _category;
		private int? _fileid;
		private DateTime _dltime;
		private int? _spnum;
		private int? _level;
		private string _filename;
		private int? _fk_subject_id;
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
		public int? category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? fileid
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dltime
		{
			set{ _dltime=value;}
			get{return _dltime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? spnum
		{
			set{ _spnum=value;}
			get{return _spnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filename
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FK_subject_ID
		{
			set{ _fk_subject_id=value;}
			get{return _fk_subject_id;}
		}
		#endregion Model

	}
}

