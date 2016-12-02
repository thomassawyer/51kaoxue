/**  版本信息模板在安装目录下，可自行修改。
* tblvideoWatchRecord.cs
*
* 功 能： N/A
* 类 名： tblvideoWatchRecord
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
	/// tblvideoWatchRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tblvideoWatchRecord
	{
		public tblvideoWatchRecord()
		{}
		#region Model
		private int _id;
		private int? _videoid;
		private string _videoname;
		private int? _lookuserid;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 视频ID
		/// </summary>
		public int? videoId
		{
			set{ _videoid=value;}
			get{return _videoid;}
		}
		/// <summary>
		/// 视频名称
		/// </summary>
		public string videoName
		{
			set{ _videoname=value;}
			get{return _videoname;}
		}
		/// <summary>
		/// 观看者ID
		/// </summary>
		public int? lookUserId
		{
			set{ _lookuserid=value;}
			get{return _lookuserid;}
		}
		#endregion Model

	}
}

