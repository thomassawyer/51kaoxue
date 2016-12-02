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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:videoChaper
	/// </summary>
	public partial class videoChaper
	{
		public videoChaper()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "videoChaper"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from videoChaper");
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
		public int Add(Maticsoft.Model.videoChaper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into videoChaper(");
			strSql.Append("chapterName,subjectId,gradeId,videoId,FId,sortId)");
			strSql.Append(" values (");
			strSql.Append("@chapterName,@subjectId,@gradeId,@videoId,@FId,@sortId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@chapterName", SqlDbType.NVarChar,50),
					new SqlParameter("@subjectId", SqlDbType.Int,4),
					new SqlParameter("@gradeId", SqlDbType.Int,4),
					new SqlParameter("@videoId", SqlDbType.Int,4),
					new SqlParameter("@FId", SqlDbType.Int,4),
					new SqlParameter("@sortId", SqlDbType.Int,4)};
			parameters[0].Value = model.chapterName;
			parameters[1].Value = model.subjectId;
			parameters[2].Value = model.gradeId;
			parameters[3].Value = model.videoId;
			parameters[4].Value = model.FId;
			parameters[5].Value = model.sortId;

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
		public bool Update(Maticsoft.Model.videoChaper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update videoChaper set ");
			strSql.Append("chapterName=@chapterName,");
			strSql.Append("subjectId=@subjectId,");
			strSql.Append("gradeId=@gradeId,");
			strSql.Append("videoId=@videoId,");
			strSql.Append("FId=@FId,");
			strSql.Append("sortId=@sortId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@chapterName", SqlDbType.NVarChar,50),
					new SqlParameter("@subjectId", SqlDbType.Int,4),
					new SqlParameter("@gradeId", SqlDbType.Int,4),
					new SqlParameter("@videoId", SqlDbType.Int,4),
					new SqlParameter("@FId", SqlDbType.Int,4),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.chapterName;
			parameters[1].Value = model.subjectId;
			parameters[2].Value = model.gradeId;
			parameters[3].Value = model.videoId;
			parameters[4].Value = model.FId;
			parameters[5].Value = model.sortId;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from videoChaper ");
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
			strSql.Append("delete from videoChaper ");
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
		public Maticsoft.Model.videoChaper GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,chapterName,subjectId,gradeId,videoId,FId,sortId from videoChaper ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.videoChaper model=new Maticsoft.Model.videoChaper();
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
		public Maticsoft.Model.videoChaper DataRowToModel(DataRow row)
		{
			Maticsoft.Model.videoChaper model=new Maticsoft.Model.videoChaper();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["chapterName"]!=null)
				{
					model.chapterName=row["chapterName"].ToString();
				}
				if(row["subjectId"]!=null && row["subjectId"].ToString()!="")
				{
					model.subjectId=int.Parse(row["subjectId"].ToString());
				}
				if(row["gradeId"]!=null && row["gradeId"].ToString()!="")
				{
					model.gradeId=int.Parse(row["gradeId"].ToString());
				}
				if(row["videoId"]!=null && row["videoId"].ToString()!="")
				{
					model.videoId=int.Parse(row["videoId"].ToString());
				}
				if(row["FId"]!=null && row["FId"].ToString()!="")
				{
					model.FId=int.Parse(row["FId"].ToString());
				}
				if(row["sortId"]!=null && row["sortId"].ToString()!="")
				{
					model.sortId=int.Parse(row["sortId"].ToString());
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
			strSql.Append("select id,chapterName,subjectId,gradeId,videoId,FId,sortId ");
			strSql.Append(" FROM videoChaper ");
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
			strSql.Append(" id,chapterName,subjectId,gradeId,videoId,FId,sortId ");
			strSql.Append(" FROM videoChaper ");
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
			strSql.Append("select count(1) FROM videoChaper ");
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
			strSql.Append(")AS Row, T.*  from videoChaper T ");
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
			parameters[0].Value = "videoChaper";
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

