using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblzhuanti:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblzhuanti
	{
		public tblzhuanti()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _picsrc;
		private string _ftitle;
		private string _stitle;
		private string _daodu;
		private int? _model;
		private int? _viewstate;
		private int? _level;
		private int? _subject;
		private int? _category;
		private int? _istop;
		private int? _position;
		private string _bigpic;
		private DateTime? _updatetime= DateTime.Now;
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
		public string picsrc
		{
			set{ _picsrc=value;}
			get{return _picsrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ftitle
		{
			set{ _ftitle=value;}
			get{return _ftitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stitle
		{
			set{ _stitle=value;}
			get{return _stitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string daodu
		{
			set{ _daodu=value;}
			get{return _daodu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? viewstate
		{
			set{ _viewstate=value;}
			get{return _viewstate;}
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
		public int? subject
		{
			set{ _subject=value;}
			get{return _subject;}
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
		public int? istop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bigpic
		{
			set{ _bigpic=value;}
			get{return _bigpic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

