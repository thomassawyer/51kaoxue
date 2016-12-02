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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblvideoInfo
	/// </summary>
	public partial class tblvideoInfo
	{
		public tblvideoInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tblvideoInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tblvideoInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tblvideoInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblvideoInfo(");
			strSql.Append("subjectId,gradeId,videoTypeId,title,videocontent,videoImageUrl,videoUrl,teacherName,curriculumTime,classCount,chapterId,updateTime,viewingTimes,videoForUser,videoTime,videobackImage)");
			strSql.Append(" values (");
			strSql.Append("@subjectId,@gradeId,@videoTypeId,@title,@videocontent,@videoImageUrl,@videoUrl,@teacherName,@curriculumTime,@classCount,@chapterId,@updateTime,@viewingTimes,@videoForUser,@videoTime,@videobackImage)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@subjectId", SqlDbType.Int,4),
					new SqlParameter("@gradeId", SqlDbType.Int,4),
					new SqlParameter("@videoTypeId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,200),
					new SqlParameter("@videocontent", SqlDbType.NVarChar,500),
					new SqlParameter("@videoImageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@videoUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@teacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@curriculumTime", SqlDbType.NVarChar,50),
					new SqlParameter("@classCount", SqlDbType.Int,4),
					new SqlParameter("@chapterId", SqlDbType.Int,4),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@viewingTimes", SqlDbType.Int,4),
					new SqlParameter("@videoForUser", SqlDbType.NVarChar,50),
					new SqlParameter("@videoTime", SqlDbType.NVarChar,50),
					new SqlParameter("@videobackImage", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.subjectId;
			parameters[1].Value = model.gradeId;
			parameters[2].Value = model.videoTypeId;
			parameters[3].Value = model.title;
			parameters[4].Value = model.videocontent;
			parameters[5].Value = model.videoImageUrl;
			parameters[6].Value = model.videoUrl;
			parameters[7].Value = model.teacherName;
			parameters[8].Value = model.curriculumTime;
			parameters[9].Value = model.classCount;
			parameters[10].Value = model.chapterId;
			parameters[11].Value = model.updateTime;
			parameters[12].Value = model.viewingTimes;
			parameters[13].Value = model.videoForUser;
			parameters[14].Value = model.videoTime;
			parameters[15].Value = model.videobackImage;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tblvideoInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblvideoInfo set ");
			strSql.Append("subjectId=@subjectId,");
			strSql.Append("gradeId=@gradeId,");
			strSql.Append("videoTypeId=@videoTypeId,");
			strSql.Append("title=@title,");
			strSql.Append("videocontent=@videocontent,");
			strSql.Append("videoImageUrl=@videoImageUrl,");
			strSql.Append("videoUrl=@videoUrl,");
			strSql.Append("teacherName=@teacherName,");
			strSql.Append("curriculumTime=@curriculumTime,");
			strSql.Append("classCount=@classCount,");
			strSql.Append("chapterId=@chapterId,");
			strSql.Append("updateTime=@updateTime,");
			strSql.Append("viewingTimes=@viewingTimes,");
			strSql.Append("videoForUser=@videoForUser,");
			strSql.Append("videoTime=@videoTime,");
			strSql.Append("videobackImage=@videobackImage");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@subjectId", SqlDbType.Int,4),
					new SqlParameter("@gradeId", SqlDbType.Int,4),
					new SqlParameter("@videoTypeId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,200),
					new SqlParameter("@videocontent", SqlDbType.NVarChar,500),
					new SqlParameter("@videoImageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@videoUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@teacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@curriculumTime", SqlDbType.NVarChar,50),
					new SqlParameter("@classCount", SqlDbType.Int,4),
					new SqlParameter("@chapterId", SqlDbType.Int,4),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@viewingTimes", SqlDbType.Int,4),
					new SqlParameter("@videoForUser", SqlDbType.NVarChar,50),
					new SqlParameter("@videoTime", SqlDbType.NVarChar,50),
					new SqlParameter("@videobackImage", SqlDbType.NVarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.subjectId;
			parameters[1].Value = model.gradeId;
			parameters[2].Value = model.videoTypeId;
			parameters[3].Value = model.title;
			parameters[4].Value = model.videocontent;
			parameters[5].Value = model.videoImageUrl;
			parameters[6].Value = model.videoUrl;
			parameters[7].Value = model.teacherName;
			parameters[8].Value = model.curriculumTime;
			parameters[9].Value = model.classCount;
			parameters[10].Value = model.chapterId;
			parameters[11].Value = model.updateTime;
			parameters[12].Value = model.viewingTimes;
			parameters[13].Value = model.videoForUser;
			parameters[14].Value = model.videoTime;
			parameters[15].Value = model.videobackImage;
			parameters[16].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tblvideoInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tblvideoInfo ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tblvideoInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,subjectId,gradeId,videoTypeId,title,videocontent,videoImageUrl,videoUrl,teacherName,curriculumTime,classCount,chapterId,updateTime,viewingTimes,videoForUser,videoTime,videobackImage from tblvideoInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tblvideoInfo model=new Maticsoft.Model.tblvideoInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tblvideoInfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblvideoInfo model=new Maticsoft.Model.tblvideoInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["subjectId"]!=null && row["subjectId"].ToString()!="")
				{
					model.subjectId=int.Parse(row["subjectId"].ToString());
				}
				if(row["gradeId"]!=null && row["gradeId"].ToString()!="")
				{
					model.gradeId=int.Parse(row["gradeId"].ToString());
				}
				if(row["videoTypeId"]!=null && row["videoTypeId"].ToString()!="")
				{
					model.videoTypeId=int.Parse(row["videoTypeId"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["videocontent"]!=null)
				{
					model.videocontent=row["videocontent"].ToString();
				}
				if(row["videoImageUrl"]!=null)
				{
					model.videoImageUrl=row["videoImageUrl"].ToString();
				}
				if(row["videoUrl"]!=null)
				{
					model.videoUrl=row["videoUrl"].ToString();
				}
				if(row["teacherName"]!=null)
				{
					model.teacherName=row["teacherName"].ToString();
				}
				if(row["curriculumTime"]!=null)
				{
					model.curriculumTime=row["curriculumTime"].ToString();
				}
				if(row["classCount"]!=null && row["classCount"].ToString()!="")
				{
					model.classCount=int.Parse(row["classCount"].ToString());
				}
				if(row["chapterId"]!=null && row["chapterId"].ToString()!="")
				{
					model.chapterId=int.Parse(row["chapterId"].ToString());
				}
				if(row["updateTime"]!=null && row["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(row["updateTime"].ToString());
				}
				if(row["viewingTimes"]!=null && row["viewingTimes"].ToString()!="")
				{
					model.viewingTimes=int.Parse(row["viewingTimes"].ToString());
				}
				if(row["videoForUser"]!=null)
				{
					model.videoForUser=row["videoForUser"].ToString();
				}
				if(row["videoTime"]!=null)
				{
					model.videoTime=row["videoTime"].ToString();
				}
				if(row["videobackImage"]!=null)
				{
					model.videobackImage=row["videobackImage"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,subjectId,gradeId,videoTypeId,title,videocontent,videoImageUrl,videoUrl,teacherName,curriculumTime,classCount,chapterId,updateTime,viewingTimes,videoForUser,videoTime,videobackImage ");
			strSql.Append(" FROM tblvideoInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,subjectId,gradeId,videoTypeId,title,videocontent,videoImageUrl,videoUrl,teacherName,curriculumTime,classCount,chapterId,updateTime,viewingTimes,videoForUser,videoTime,videobackImage ");
			strSql.Append(" FROM tblvideoInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tblvideoInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from tblvideoInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tblvideoInfo";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

