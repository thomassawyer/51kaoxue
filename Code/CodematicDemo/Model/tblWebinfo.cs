using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblWebinfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblWebinfo
	{
		public tblWebinfo()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _logosrc;
		private string _footinfo;
		private string _headseo;
		private string _keyseo;
		private string _describseo;
		private string _weixin;
		private string _weibo;
		private string _gengxin;
		private string _zongliang;
		private string _schooltestnum;
		private string _jinpintestnum;
		private string _schoolnum;
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
		public string logosrc
		{
			set{ _logosrc=value;}
			get{return _logosrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string footinfo
		{
			set{ _footinfo=value;}
			get{return _footinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string headseo
		{
			set{ _headseo=value;}
			get{return _headseo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keyseo
		{
			set{ _keyseo=value;}
			get{return _keyseo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string describseo
		{
			set{ _describseo=value;}
			get{return _describseo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weixin
		{
			set{ _weixin=value;}
			get{return _weixin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weibo
		{
			set{ _weibo=value;}
			get{return _weibo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gengxin
		{
			set{ _gengxin=value;}
			get{return _gengxin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zongliang
		{
			set{ _zongliang=value;}
			get{return _zongliang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string schooltestnum
		{
			set{ _schooltestnum=value;}
			get{return _schooltestnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jinpintestnum
		{
			set{ _jinpintestnum=value;}
			get{return _jinpintestnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string schoolnum
		{
			set{ _schoolnum=value;}
			get{return _schoolnum;}
		}
		#endregion Model

	}
}

