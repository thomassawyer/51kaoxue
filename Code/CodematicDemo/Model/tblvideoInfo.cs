/**  版本信息模板在安装目录下，可自行修改。
* tblvideoInfo.cs
*
* 功 能： N/A
* 类 名： tblvideoInfo
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
	/// tblvideoInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblvideoInfo
	{
		public tblvideoInfo()
		{}
		#region Model
		private int _id;
		private int? _subjectid;
		private int? _gradeid;
		private int? _videotypeid;
		private string _title;
		private string _videocontent;
		private string _videoimageurl;
		private string _videourl;
		private string _teachername;
		private string _curriculumtime;
		private int? _classcount;
		private int? _chapterid;
		private DateTime? _updatetime;
		private int? _viewingtimes;
		private string _videoforuser;
		private string _videotime;
		private string _videobackimage;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 学科ID
		/// </summary>
		public int? subjectId
		{
			set{ _subjectid=value;}
			get{return _subjectid;}
		}
		/// <summary>
		/// 年级ID
		/// </summary>
		public int? gradeId
		{
			set{ _gradeid=value;}
			get{return _gradeid;}
		}
		/// <summary>
		/// 视频类型ID
		/// </summary>
		public int? videoTypeId
		{
			set{ _videotypeid=value;}
			get{return _videotypeid;}
		}
		/// <summary>
		/// 视频标题名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 视频简介
		/// </summary>
		public string videocontent
		{
			set{ _videocontent=value;}
			get{return _videocontent;}
		}
		/// <summary>
		/// 视频图片地址
		/// </summary>
		public string videoImageUrl
		{
			set{ _videoimageurl=value;}
			get{return _videoimageurl;}
		}
		/// <summary>
		/// 视频地址
		/// </summary>
		public string videoUrl
		{
			set{ _videourl=value;}
			get{return _videourl;}
		}
		/// <summary>
		/// 讲师姓名
		/// </summary>
		public string teacherName
		{
			set{ _teachername=value;}
			get{return _teachername;}
		}
		/// <summary>
		/// 课程主讲时间
		/// </summary>
		public string curriculumTime
		{
			set{ _curriculumtime=value;}
			get{return _curriculumtime;}
		}
		/// <summary>
		/// 课时数
		/// </summary>
		public int? classCount
		{
			set{ _classcount=value;}
			get{return _classcount;}
		}
		/// <summary>
		/// 章节ID
		/// </summary>
		public int? chapterId
		{
			set{ _chapterid=value;}
			get{return _chapterid;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 观看次数
		/// </summary>
		public int? viewingTimes
		{
			set{ _viewingtimes=value;}
			get{return _viewingtimes;}
		}
		/// <summary>
		/// 视频提供者
		/// </summary>
		public string videoForUser
		{
			set{ _videoforuser=value;}
			get{return _videoforuser;}
		}
		/// <summary>
		/// 视频时长
		/// </summary>
		public string videoTime
		{
			set{ _videotime=value;}
			get{return _videotime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string videobackImage
		{
			set{ _videobackimage=value;}
			get{return _videobackimage;}
		}
		#endregion Model

	}
}

