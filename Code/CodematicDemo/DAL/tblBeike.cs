using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblBeike
	/// </summary>
	public partial class tblBeike
	{
		public tblBeike()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tblBeike"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tblBeike");
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
		public int Add(Maticsoft.Model.tblBeike model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblBeike(");
			strSql.Append("level,areaid,subjectid,name,viewcount,pubdate,isjing,isgaokao,isdujia)");
			strSql.Append(" values (");
			strSql.Append("@level,@areaid,@subjectid,@name,@viewcount,@pubdate,@isjing,@isgaokao,@isdujia)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@subjectid", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@viewcount", SqlDbType.Int,4),
					new SqlParameter("@pubdate", SqlDbType.DateTime),
					new SqlParameter("@isjing", SqlDbType.Int,4),
					new SqlParameter("@isgaokao", SqlDbType.Int,4),
					new SqlParameter("@isdujia", SqlDbType.Int,4)};
			parameters[0].Value = model.level;
			parameters[1].Value = model.areaid;
			parameters[2].Value = model.subjectid;
			parameters[3].Value = model.name;
			parameters[4].Value = model.viewcount;
			parameters[5].Value = model.pubdate;
			parameters[6].Value = model.isjing;
			parameters[7].Value = model.isgaokao;
			parameters[8].Value = model.isdujia;

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
		public bool Update(Maticsoft.Model.tblBeike model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblBeike set ");
			strSql.Append("level=@level,");
			strSql.Append("areaid=@areaid,");
			strSql.Append("subjectid=@subjectid,");
			strSql.Append("name=@name,");
			strSql.Append("viewcount=@viewcount,");
			strSql.Append("pubdate=@pubdate,");
			strSql.Append("isjing=@isjing,");
			strSql.Append("isgaokao=@isgaokao,");
			strSql.Append("isdujia=@isdujia");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@subjectid", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@viewcount", SqlDbType.Int,4),
					new SqlParameter("@pubdate", SqlDbType.DateTime),
					new SqlParameter("@isjing", SqlDbType.Int,4),
					new SqlParameter("@isgaokao", SqlDbType.Int,4),
					new SqlParameter("@isdujia", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.level;
			parameters[1].Value = model.areaid;
			parameters[2].Value = model.subjectid;
			parameters[3].Value = model.name;
			parameters[4].Value = model.viewcount;
			parameters[5].Value = model.pubdate;
			parameters[6].Value = model.isjing;
			parameters[7].Value = model.isgaokao;
			parameters[8].Value = model.isdujia;
			parameters[9].Value = model.id;

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
			strSql.Append("delete from tblBeike ");
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
			strSql.Append("delete from tblBeike ");
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
		public Maticsoft.Model.tblBeike GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,level,areaid,subjectid,name,viewcount,pubdate,isjing,isgaokao,isdujia from tblBeike ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tblBeike model=new Maticsoft.Model.tblBeike();
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
		public Maticsoft.Model.tblBeike DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblBeike model=new Maticsoft.Model.tblBeike();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["level"]!=null && row["level"].ToString()!="")
				{
					model.level=int.Parse(row["level"].ToString());
				}
				if(row["areaid"]!=null && row["areaid"].ToString()!="")
				{
					model.areaid=int.Parse(row["areaid"].ToString());
				}
				if(row["subjectid"]!=null && row["subjectid"].ToString()!="")
				{
					model.subjectid=int.Parse(row["subjectid"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["viewcount"]!=null && row["viewcount"].ToString()!="")
				{
					model.viewcount=int.Parse(row["viewcount"].ToString());
				}
				if(row["pubdate"]!=null && row["pubdate"].ToString()!="")
				{
					model.pubdate=DateTime.Parse(row["pubdate"].ToString());
				}
				if(row["isjing"]!=null && row["isjing"].ToString()!="")
				{
					model.isjing=int.Parse(row["isjing"].ToString());
				}
				if(row["isgaokao"]!=null && row["isgaokao"].ToString()!="")
				{
					model.isgaokao=int.Parse(row["isgaokao"].ToString());
				}
				if(row["isdujia"]!=null && row["isdujia"].ToString()!="")
				{
					model.isdujia=int.Parse(row["isdujia"].ToString());
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
			strSql.Append("select id,level,areaid,subjectid,name,viewcount,pubdate,isjing,isgaokao,isdujia ");
			strSql.Append(" FROM tblBeike ");
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
			strSql.Append(" id,level,areaid,subjectid,name,viewcount,pubdate,isjing,isgaokao,isdujia ");
			strSql.Append(" FROM tblBeike ");
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
			strSql.Append("select count(1) FROM tblBeike ");
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
			strSql.Append(")AS Row, T.*  from tblBeike T ");
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
			parameters[0].Value = "tblBeike";
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

