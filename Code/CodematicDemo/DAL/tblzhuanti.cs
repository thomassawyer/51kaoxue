using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblzhuanti
	/// </summary>
	public partial class tblzhuanti
	{
		public tblzhuanti()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tblzhuanti"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tblzhuanti");
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
		public int Add(Maticsoft.Model.tblzhuanti model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblzhuanti(");
			strSql.Append("name,picsrc,ftitle,stitle,daodu,model,viewstate,level,subject,category,istop,position,bigpic,updatetime)");
			strSql.Append(" values (");
			strSql.Append("@name,@picsrc,@ftitle,@stitle,@daodu,@model,@viewstate,@level,@subject,@category,@istop,@position,@bigpic,@updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@picsrc", SqlDbType.NVarChar,100),
					new SqlParameter("@ftitle", SqlDbType.NVarChar,50),
					new SqlParameter("@stitle", SqlDbType.NVarChar,50),
					new SqlParameter("@daodu", SqlDbType.NVarChar,500),
					new SqlParameter("@model", SqlDbType.Int,4),
					new SqlParameter("@viewstate", SqlDbType.Int,4),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@subject", SqlDbType.Int,4),
					new SqlParameter("@category", SqlDbType.Int,4),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@position", SqlDbType.Int,4),
					new SqlParameter("@bigpic", SqlDbType.NVarChar,100),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.picsrc;
			parameters[2].Value = model.ftitle;
			parameters[3].Value = model.stitle;
			parameters[4].Value = model.daodu;
			parameters[5].Value = model.model;
			parameters[6].Value = model.viewstate;
			parameters[7].Value = model.level;
			parameters[8].Value = model.subject;
			parameters[9].Value = model.category;
			parameters[10].Value = model.istop;
			parameters[11].Value = model.position;
			parameters[12].Value = model.bigpic;
			parameters[13].Value = model.updatetime;

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
		public bool Update(Maticsoft.Model.tblzhuanti model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblzhuanti set ");
			strSql.Append("name=@name,");
			strSql.Append("picsrc=@picsrc,");
			strSql.Append("ftitle=@ftitle,");
			strSql.Append("stitle=@stitle,");
			strSql.Append("daodu=@daodu,");
			strSql.Append("model=@model,");
			strSql.Append("viewstate=@viewstate,");
			strSql.Append("level=@level,");
			strSql.Append("subject=@subject,");
			strSql.Append("category=@category,");
			strSql.Append("istop=@istop,");
			strSql.Append("position=@position,");
			strSql.Append("bigpic=@bigpic,");
			strSql.Append("updatetime=@updatetime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@picsrc", SqlDbType.NVarChar,100),
					new SqlParameter("@ftitle", SqlDbType.NVarChar,50),
					new SqlParameter("@stitle", SqlDbType.NVarChar,50),
					new SqlParameter("@daodu", SqlDbType.NVarChar,500),
					new SqlParameter("@model", SqlDbType.Int,4),
					new SqlParameter("@viewstate", SqlDbType.Int,4),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@subject", SqlDbType.Int,4),
					new SqlParameter("@category", SqlDbType.Int,4),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@position", SqlDbType.Int,4),
					new SqlParameter("@bigpic", SqlDbType.NVarChar,100),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.picsrc;
			parameters[2].Value = model.ftitle;
			parameters[3].Value = model.stitle;
			parameters[4].Value = model.daodu;
			parameters[5].Value = model.model;
			parameters[6].Value = model.viewstate;
			parameters[7].Value = model.level;
			parameters[8].Value = model.subject;
			parameters[9].Value = model.category;
			parameters[10].Value = model.istop;
			parameters[11].Value = model.position;
			parameters[12].Value = model.bigpic;
			parameters[13].Value = model.updatetime;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from tblzhuanti ");
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
			strSql.Append("delete from tblzhuanti ");
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
		public Maticsoft.Model.tblzhuanti GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,picsrc,ftitle,stitle,daodu,model,viewstate,level,subject,category,istop,position,bigpic,updatetime from tblzhuanti ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tblzhuanti model=new Maticsoft.Model.tblzhuanti();
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
		public Maticsoft.Model.tblzhuanti DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblzhuanti model=new Maticsoft.Model.tblzhuanti();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["picsrc"]!=null)
				{
					model.picsrc=row["picsrc"].ToString();
				}
				if(row["ftitle"]!=null)
				{
					model.ftitle=row["ftitle"].ToString();
				}
				if(row["stitle"]!=null)
				{
					model.stitle=row["stitle"].ToString();
				}
				if(row["daodu"]!=null)
				{
					model.daodu=row["daodu"].ToString();
				}
				if(row["model"]!=null && row["model"].ToString()!="")
				{
					model.model=int.Parse(row["model"].ToString());
				}
				if(row["viewstate"]!=null && row["viewstate"].ToString()!="")
				{
					model.viewstate=int.Parse(row["viewstate"].ToString());
				}
				if(row["level"]!=null && row["level"].ToString()!="")
				{
					model.level=int.Parse(row["level"].ToString());
				}
				if(row["subject"]!=null && row["subject"].ToString()!="")
				{
					model.subject=int.Parse(row["subject"].ToString());
				}
				if(row["category"]!=null && row["category"].ToString()!="")
				{
					model.category=int.Parse(row["category"].ToString());
				}
				if(row["istop"]!=null && row["istop"].ToString()!="")
				{
					model.istop=int.Parse(row["istop"].ToString());
				}
				if(row["position"]!=null && row["position"].ToString()!="")
				{
					model.position=int.Parse(row["position"].ToString());
				}
				if(row["bigpic"]!=null)
				{
					model.bigpic=row["bigpic"].ToString();
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
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
			strSql.Append("select id,name,picsrc,ftitle,stitle,daodu,model,viewstate,level,subject,category,istop,position,bigpic,updatetime ");
			strSql.Append(" FROM tblzhuanti ");
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
			strSql.Append(" id,name,picsrc,ftitle,stitle,daodu,model,viewstate,level,subject,category,istop,position,bigpic,updatetime ");
			strSql.Append(" FROM tblzhuanti ");
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
			strSql.Append("select count(1) FROM tblzhuanti ");
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
			strSql.Append(")AS Row, T.*  from tblzhuanti T ");
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
			parameters[0].Value = "tblzhuanti";
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

