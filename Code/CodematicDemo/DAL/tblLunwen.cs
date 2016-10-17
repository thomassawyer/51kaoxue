using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblLunwen
	/// </summary>
	public partial class tblLunwen
	{
		public tblLunwen()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tblLunwen"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tblLunwen");
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
		public int Add(Maticsoft.Model.tblLunwen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblLunwen(");
			strSql.Append("name,filesrc,subjectid,areaid,downum,downeed,uploaddate,memoinfo,uploader,extension,year,level)");
			strSql.Append(" values (");
			strSql.Append("@name,@filesrc,@subjectid,@areaid,@downum,@downeed,@uploaddate,@memoinfo,@uploader,@extension,@year,@level)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@filesrc", SqlDbType.NVarChar,100),
					new SqlParameter("@subjectid", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@downum", SqlDbType.Int,4),
					new SqlParameter("@downeed", SqlDbType.Int,4),
					new SqlParameter("@uploaddate", SqlDbType.DateTime),
					new SqlParameter("@memoinfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@uploader", SqlDbType.NVarChar,100),
					new SqlParameter("@extension", SqlDbType.NVarChar,10),
					new SqlParameter("@year", SqlDbType.NVarChar,10),
					new SqlParameter("@level", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.filesrc;
			parameters[2].Value = model.subjectid;
			parameters[3].Value = model.areaid;
			parameters[4].Value = model.downum;
			parameters[5].Value = model.downeed;
			parameters[6].Value = model.uploaddate;
			parameters[7].Value = model.memoinfo;
			parameters[8].Value = model.uploader;
			parameters[9].Value = model.extension;
			parameters[10].Value = model.year;
			parameters[11].Value = model.level;

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
		public bool Update(Maticsoft.Model.tblLunwen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblLunwen set ");
			strSql.Append("name=@name,");
			strSql.Append("filesrc=@filesrc,");
			strSql.Append("subjectid=@subjectid,");
			strSql.Append("areaid=@areaid,");
			strSql.Append("downum=@downum,");
			strSql.Append("downeed=@downeed,");
			strSql.Append("uploaddate=@uploaddate,");
			strSql.Append("memoinfo=@memoinfo,");
			strSql.Append("uploader=@uploader,");
			strSql.Append("extension=@extension,");
			strSql.Append("year=@year,");
			strSql.Append("level=@level");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@filesrc", SqlDbType.NVarChar,100),
					new SqlParameter("@subjectid", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@downum", SqlDbType.Int,4),
					new SqlParameter("@downeed", SqlDbType.Int,4),
					new SqlParameter("@uploaddate", SqlDbType.DateTime),
					new SqlParameter("@memoinfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@uploader", SqlDbType.NVarChar,100),
					new SqlParameter("@extension", SqlDbType.NVarChar,10),
					new SqlParameter("@year", SqlDbType.NVarChar,10),
					new SqlParameter("@level", SqlDbType.NVarChar,10),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.filesrc;
			parameters[2].Value = model.subjectid;
			parameters[3].Value = model.areaid;
			parameters[4].Value = model.downum;
			parameters[5].Value = model.downeed;
			parameters[6].Value = model.uploaddate;
			parameters[7].Value = model.memoinfo;
			parameters[8].Value = model.uploader;
			parameters[9].Value = model.extension;
			parameters[10].Value = model.year;
			parameters[11].Value = model.level;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from tblLunwen ");
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
			strSql.Append("delete from tblLunwen ");
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
		public Maticsoft.Model.tblLunwen GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,filesrc,subjectid,areaid,downum,downeed,uploaddate,memoinfo,uploader,extension,year,level from tblLunwen ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tblLunwen model=new Maticsoft.Model.tblLunwen();
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
		public Maticsoft.Model.tblLunwen DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblLunwen model=new Maticsoft.Model.tblLunwen();
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
				if(row["filesrc"]!=null)
				{
					model.filesrc=row["filesrc"].ToString();
				}
				if(row["subjectid"]!=null && row["subjectid"].ToString()!="")
				{
					model.subjectid=int.Parse(row["subjectid"].ToString());
				}
				if(row["areaid"]!=null && row["areaid"].ToString()!="")
				{
					model.areaid=int.Parse(row["areaid"].ToString());
				}
				if(row["downum"]!=null && row["downum"].ToString()!="")
				{
					model.downum=int.Parse(row["downum"].ToString());
				}
				if(row["downeed"]!=null && row["downeed"].ToString()!="")
				{
					model.downeed=int.Parse(row["downeed"].ToString());
				}
				if(row["uploaddate"]!=null && row["uploaddate"].ToString()!="")
				{
					model.uploaddate=DateTime.Parse(row["uploaddate"].ToString());
				}
				if(row["memoinfo"]!=null)
				{
					model.memoinfo=row["memoinfo"].ToString();
				}
				if(row["uploader"]!=null)
				{
					model.uploader=row["uploader"].ToString();
				}
				if(row["extension"]!=null)
				{
					model.extension=row["extension"].ToString();
				}
				if(row["year"]!=null)
				{
					model.year=row["year"].ToString();
				}
				if(row["level"]!=null)
				{
					model.level=row["level"].ToString();
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
			strSql.Append("select id,name,filesrc,subjectid,areaid,downum,downeed,uploaddate,memoinfo,uploader,extension,year,level ");
			strSql.Append(" FROM tblLunwen ");
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
			strSql.Append(" id,name,filesrc,subjectid,areaid,downum,downeed,uploaddate,memoinfo,uploader,extension,year,level ");
			strSql.Append(" FROM tblLunwen ");
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
			strSql.Append("select count(1) FROM tblLunwen ");
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
			strSql.Append(")AS Row, T.*  from tblLunwen T ");
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
			parameters[0].Value = "tblLunwen";
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

