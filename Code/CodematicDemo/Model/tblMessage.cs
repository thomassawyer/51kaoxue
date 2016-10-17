using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tblMessage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblMessage
	{
		public tblMessage()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private string _mobile;
		private string _email;
		private DateTime? _pubdate;
		private string _school;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? pubdate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string school
		{
			set{ _school=value;}
			get{return _school;}
		}
		#endregion Model

	}
}

