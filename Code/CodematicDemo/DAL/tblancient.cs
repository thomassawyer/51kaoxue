using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblancient
	/// </summary>
	public partial class tblancient
	{
		public tblancient()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tblancient"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tblancient");
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
		public int Add(Maticsoft.Model.tblancient model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblancient(");
			strSql.Append("title,content,pubdate,keyword,viewcounts,first_id,second_id,third_id)");
			strSql.Append(" values (");
			strSql.Append("@title,@content,@pubdate,@keyword,@viewcounts,@first_id,@second_id,@third_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@content", SqlDbType.NVarChar,-1),
					new SqlParameter("@pubdate", SqlDbType.DateTime),
					new SqlParameter("@keyword", SqlDbType.NVarChar,50),
					new SqlParameter("@viewcounts", SqlDbType.Int,4),
					new SqlParameter("@first_id", SqlDbType.Int,4),
					new SqlParameter("@second_id", SqlDbType.Int,4),
					new SqlParameter("@third_id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.content;
			parameters[2].Value = model.pubdate;
			parameters[3].Value = model.keyword;
			parameters[4].Value = model.viewcounts;
			parameters[5].Value = model.first_id;
			parameters[6].Value = model.second_id;
			parameters[7].Value = model.third_id;

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
		public bool Update(Maticsoft.Model.tblancient model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblancient set ");
			strSql.Append("title=@title,");
			strSql.Append("content=@content,");
			strSql.Append("pubdate=@pubdate,");
			strSql.Append("keyword=@keyword,");
			strSql.Append("viewcounts=@viewcounts,");
			strSql.Append("first_id=@first_id,");
			strSql.Append("second_id=@second_id,");
			strSql.Append("third_id=@third_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@content", SqlDbType.NVarChar,-1),
					new SqlParameter("@pubdate", SqlDbType.DateTime),
					new SqlParameter("@keyword", SqlDbType.NVarChar,50),
					new SqlParameter("@viewcounts", SqlDbType.Int,4),
					new SqlParameter("@first_id", SqlDbType.Int,4),
					new SqlParameter("@second_id", SqlDbType.Int,4),
					new SqlParameter("@third_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.content;
			parameters[2].Value = model.pubdate;
			parameters[3].Value = model.keyword;
			parameters[4].Value = model.viewcounts;
			parameters[5].Value = model.first_id;
			parameters[6].Value = model.second_id;
			parameters[7].Value = model.third_id;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from tblancient ");
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
			strSql.Append("delete from tblancient ");
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
		public Maticsoft.Model.tblancient GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,content,pubdate,keyword,viewcounts,first_id,second_id,third_id from tblancient ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tblancient model=new Maticsoft.Model.tblancient();
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
		public Maticsoft.Model.tblancient DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblancient model=new Maticsoft.Model.tblancient();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["pubdate"]!=null && row["pubdate"].ToString()!="")
				{
					model.pubdate=DateTime.Parse(row["pubdate"].ToString());
				}
				if(row["keyword"]!=null)
				{
					model.keyword=row["keyword"].ToString();
				}
				if(row["viewcounts"]!=null && row["viewcounts"].ToString()!="")
				{
					model.viewcounts=int.Parse(row["viewcounts"].ToString());
				}
				if(row["first_id"]!=null && row["first_id"].ToString()!="")
				{
					model.first_id=int.Parse(row["first_id"].ToString());
				}
				if(row["second_id"]!=null && row["second_id"].ToString()!="")
				{
					model.second_id=int.Parse(row["second_id"].ToString());
				}
				if(row["third_id"]!=null && row["third_id"].ToString()!="")
				{
					model.third_id=int.Parse(row["third_id"].ToString());
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
			strSql.Append("select id,title,content,pubdate,keyword,viewcounts,first_id,second_id,third_id ");
			strSql.Append(" FROM tblancient ");
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
			strSql.Append(" id,title,content,pubdate,keyword,viewcounts,first_id,second_id,third_id ");
			strSql.Append(" FROM tblancient ");
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
			strSql.Append("select count(1) FROM tblancient ");
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
			strSql.Append(")AS Row, T.*  from tblancient T ");
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
			parameters[0].Value = "tblancient";
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

