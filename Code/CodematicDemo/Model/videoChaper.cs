/**  版本信息模板在安装目录下，可自行修改。
* videoChaper.cs
*
* 功 能： N/A
* 类 名： videoChaper
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/2 9:36:03   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// videoChaper:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class videoChaper
	{
		public videoChaper()
		{}
		#region Model
		private int _id;
		private string _chaptername;
		private int? _subjectid;
		private int? _gradeid;
		private int? _videoid;
		private int? _fid;
		private int? _sortid;
		/// <summary>
		/// 章节主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 章节名称
		/// </summary>
		public string chapterName
		{
			set{ _chaptername=value;}
			get{return _chaptername;}
		}
		/// <summary>
		/// 学科编号
		/// </summary>
		public int? subjectId
		{
			set{ _subjectid=value;}
			get{return _subjectid;}
		}
		/// <summary>
		/// 年级编号
		/// </summary>
		public int? gradeId
		{
			set{ _gradeid=value;}
			get{return _gradeid;}
		}
		/// <summary>
		/// 视频编号
		/// </summary>
		public int? videoId
		{
			set{ _videoid=value;}
			get{return _videoid;}
		}
		/// <summary>
		/// 父级编号
		/// </summary>
		public int? FId
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 排序编号
		/// </summary>
		public int? sortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

