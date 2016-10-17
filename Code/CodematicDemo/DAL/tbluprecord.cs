using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbluprecord
	/// </summary>
	public partial class tbluprecord
	{
		public tbluprecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("userid", "tbluprecord"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbluprecord");
			strSql.Append(" where userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4)			};
			parameters[0].Value = userid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.tbluprecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbluprecord(");
			strSql.Append("userid,zong,today,uptime)");
			strSql.Append(" values (");
			strSql.Append("@userid,@zong,@today,@uptime)");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@zong", SqlDbType.Int,4),
					new SqlParameter("@today", SqlDbType.Int,4),
					new SqlParameter("@uptime", SqlDbType.DateTime)};
			parameters[0].Value = model.userid;
			parameters[1].Value = model.zong;
			parameters[2].Value = model.today;
			parameters[3].Value = model.uptime;

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
		public bool Update(Maticsoft.Model.tbluprecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbluprecord set ");
			strSql.Append("zong=@zong,");
			strSql.Append("today=@today,");
			strSql.Append("uptime=@uptime");
			strSql.Append(" where userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@zong", SqlDbType.Int,4),
					new SqlParameter("@today", SqlDbType.Int,4),
					new SqlParameter("@uptime", SqlDbType.DateTime),
					new SqlParameter("@userid", SqlDbType.Int,4)};
			parameters[0].Value = model.zong;
			parameters[1].Value = model.today;
			parameters[2].Value = model.uptime;
			parameters[3].Value = model.userid;

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
		public bool Delete(int userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbluprecord ");
			strSql.Append(" where userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4)			};
			parameters[0].Value = userid;

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
		public bool DeleteList(string useridlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbluprecord ");
			strSql.Append(" where userid in ("+useridlist + ")  ");
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
		public Maticsoft.Model.tbluprecord GetModel(int userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 userid,zong,today,uptime from tbluprecord ");
			strSql.Append(" where userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4)			};
			parameters[0].Value = userid;

			Maticsoft.Model.tbluprecord model=new Maticsoft.Model.tbluprecord();
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
		public Maticsoft.Model.tbluprecord DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbluprecord model=new Maticsoft.Model.tbluprecord();
			if (row != null)
			{
				if(row["userid"]!=null && row["userid"].ToString()!="")
				{
					model.userid=int.Parse(row["userid"].ToString());
				}
				if(row["zong"]!=null && row["zong"].ToString()!="")
				{
					model.zong=int.Parse(row["zong"].ToString());
				}
				if(row["today"]!=null && row["today"].ToString()!="")
				{
					model.today=int.Parse(row["today"].ToString());
				}
				if(row["uptime"]!=null && row["uptime"].ToString()!="")
				{
					model.uptime=DateTime.Parse(row["uptime"].ToString());
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
			strSql.Append("select userid,zong,today,uptime ");
			strSql.Append(" FROM tbluprecord ");
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
			strSql.Append(" userid,zong,today,uptime ");
			strSql.Append(" FROM tbluprecord ");
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
			strSql.Append("select count(1) FROM tbluprecord ");
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
				strSql.Append("order by T.userid desc");
			}
			strSql.Append(")AS Row, T.*  from tbluprecord T ");
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
			parameters[0].Value = "tbluprecord";
			parameters[1].Value = "userid";
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

