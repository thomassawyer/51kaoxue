using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:page_dict
	/// </summary>
	public partial class page_dict
	{
		public page_dict()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PAGEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from page_dict");
			strSql.Append(" where PAGEID=@PAGEID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PAGEID", SqlDbType.VarChar,15)			};
			parameters[0].Value = PAGEID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.page_dict model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into page_dict(");
			strSql.Append("PAGEID,PAGENAME,PAGEPARENTID,PAGEURL,PAGETARGET,PAGEIMG,CHECKFLAG,PAGEMOUDAL,ISFLAG,SEQSORT)");
			strSql.Append(" values (");
			strSql.Append("@PAGEID,@PAGENAME,@PAGEPARENTID,@PAGEURL,@PAGETARGET,@PAGEIMG,@CHECKFLAG,@PAGEMOUDAL,@ISFLAG,@SEQSORT)");
			SqlParameter[] parameters = {
					new SqlParameter("@PAGEID", SqlDbType.VarChar,15),
					new SqlParameter("@PAGENAME", SqlDbType.VarChar,50),
					new SqlParameter("@PAGEPARENTID", SqlDbType.VarChar,15),
					new SqlParameter("@PAGEURL", SqlDbType.VarChar,100),
					new SqlParameter("@PAGETARGET", SqlDbType.VarChar,20),
					new SqlParameter("@PAGEIMG", SqlDbType.VarChar,50),
					new SqlParameter("@CHECKFLAG", SqlDbType.VarChar,50),
					new SqlParameter("@PAGEMOUDAL", SqlDbType.VarChar,20),
					new SqlParameter("@ISFLAG", SqlDbType.Char,1),
					new SqlParameter("@SEQSORT", SqlDbType.VarChar,10)};
			parameters[0].Value = model.PAGEID;
			parameters[1].Value = model.PAGENAME;
			parameters[2].Value = model.PAGEPARENTID;
			parameters[3].Value = model.PAGEURL;
			parameters[4].Value = model.PAGETARGET;
			parameters[5].Value = model.PAGEIMG;
			parameters[6].Value = model.CHECKFLAG;
			parameters[7].Value = model.PAGEMOUDAL;
			parameters[8].Value = model.ISFLAG;
			parameters[9].Value = model.SEQSORT;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.page_dict model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update page_dict set ");
			strSql.Append("PAGENAME=@PAGENAME,");
			strSql.Append("PAGEPARENTID=@PAGEPARENTID,");
			strSql.Append("PAGEURL=@PAGEURL,");
			strSql.Append("PAGETARGET=@PAGETARGET,");
			strSql.Append("PAGEIMG=@PAGEIMG,");
			strSql.Append("CHECKFLAG=@CHECKFLAG,");
			strSql.Append("PAGEMOUDAL=@PAGEMOUDAL,");
			strSql.Append("ISFLAG=@ISFLAG,");
			strSql.Append("SEQSORT=@SEQSORT");
			strSql.Append(" where PAGEID=@PAGEID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PAGENAME", SqlDbType.VarChar,50),
					new SqlParameter("@PAGEPARENTID", SqlDbType.VarChar,15),
					new SqlParameter("@PAGEURL", SqlDbType.VarChar,100),
					new SqlParameter("@PAGETARGET", SqlDbType.VarChar,20),
					new SqlParameter("@PAGEIMG", SqlDbType.VarChar,50),
					new SqlParameter("@CHECKFLAG", SqlDbType.VarChar,50),
					new SqlParameter("@PAGEMOUDAL", SqlDbType.VarChar,20),
					new SqlParameter("@ISFLAG", SqlDbType.Char,1),
					new SqlParameter("@SEQSORT", SqlDbType.VarChar,10),
					new SqlParameter("@PAGEID", SqlDbType.VarChar,15)};
			parameters[0].Value = model.PAGENAME;
			parameters[1].Value = model.PAGEPARENTID;
			parameters[2].Value = model.PAGEURL;
			parameters[3].Value = model.PAGETARGET;
			parameters[4].Value = model.PAGEIMG;
			parameters[5].Value = model.CHECKFLAG;
			parameters[6].Value = model.PAGEMOUDAL;
			parameters[7].Value = model.ISFLAG;
			parameters[8].Value = model.SEQSORT;
			parameters[9].Value = model.PAGEID;

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
		public bool Delete(string PAGEID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from page_dict ");
			strSql.Append(" where PAGEID=@PAGEID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PAGEID", SqlDbType.VarChar,15)			};
			parameters[0].Value = PAGEID;

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
		public bool DeleteList(string PAGEIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from page_dict ");
			strSql.Append(" where PAGEID in ("+PAGEIDlist + ")  ");
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
		public Maticsoft.Model.page_dict GetModel(string PAGEID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PAGEID,PAGENAME,PAGEPARENTID,PAGEURL,PAGETARGET,PAGEIMG,CHECKFLAG,PAGEMOUDAL,ISFLAG,SEQSORT from page_dict ");
			strSql.Append(" where PAGEID=@PAGEID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PAGEID", SqlDbType.VarChar,15)			};
			parameters[0].Value = PAGEID;

			Maticsoft.Model.page_dict model=new Maticsoft.Model.page_dict();
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
		public Maticsoft.Model.page_dict DataRowToModel(DataRow row)
		{
			Maticsoft.Model.page_dict model=new Maticsoft.Model.page_dict();
			if (row != null)
			{
				if(row["PAGEID"]!=null)
				{
					model.PAGEID=row["PAGEID"].ToString();
				}
				if(row["PAGENAME"]!=null)
				{
					model.PAGENAME=row["PAGENAME"].ToString();
				}
				if(row["PAGEPARENTID"]!=null)
				{
					model.PAGEPARENTID=row["PAGEPARENTID"].ToString();
				}
				if(row["PAGEURL"]!=null)
				{
					model.PAGEURL=row["PAGEURL"].ToString();
				}
				if(row["PAGETARGET"]!=null)
				{
					model.PAGETARGET=row["PAGETARGET"].ToString();
				}
				if(row["PAGEIMG"]!=null)
				{
					model.PAGEIMG=row["PAGEIMG"].ToString();
				}
				if(row["CHECKFLAG"]!=null)
				{
					model.CHECKFLAG=row["CHECKFLAG"].ToString();
				}
				if(row["PAGEMOUDAL"]!=null)
				{
					model.PAGEMOUDAL=row["PAGEMOUDAL"].ToString();
				}
				if(row["ISFLAG"]!=null)
				{
					model.ISFLAG=row["ISFLAG"].ToString();
				}
				if(row["SEQSORT"]!=null)
				{
					model.SEQSORT=row["SEQSORT"].ToString();
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
			strSql.Append("select PAGEID,PAGENAME,PAGEPARENTID,PAGEURL,PAGETARGET,PAGEIMG,CHECKFLAG,PAGEMOUDAL,ISFLAG,SEQSORT ");
			strSql.Append(" FROM page_dict ");
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
			strSql.Append(" PAGEID,PAGENAME,PAGEPARENTID,PAGEURL,PAGETARGET,PAGEIMG,CHECKFLAG,PAGEMOUDAL,ISFLAG,SEQSORT ");
			strSql.Append(" FROM page_dict ");
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
			strSql.Append("select count(1) FROM page_dict ");
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
				strSql.Append("order by T.PAGEID desc");
			}
			strSql.Append(")AS Row, T.*  from page_dict T ");
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
			parameters[0].Value = "page_dict";
			parameters[1].Value = "PAGEID";
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

