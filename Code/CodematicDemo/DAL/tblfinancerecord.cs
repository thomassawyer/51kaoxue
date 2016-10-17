using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblfinancerecord
	/// </summary>
	public partial class tblfinancerecord
	{
		public tblfinancerecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tblfinancerecord"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime dltime,int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tblfinancerecord");
			strSql.Append(" where dltime=@dltime and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@dltime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = dltime;
			parameters[1].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tblfinancerecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblfinancerecord(");
			strSql.Append("userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID)");
			strSql.Append(" values (");
			strSql.Append("@userid,@category,@fileid,@dltime,@spnum,@level,@filename,@FK_subject_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@category", SqlDbType.Int,4),
					new SqlParameter("@fileid", SqlDbType.Int,4),
					new SqlParameter("@dltime", SqlDbType.DateTime),
					new SqlParameter("@spnum", SqlDbType.Int,4),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@filename", SqlDbType.NVarChar,100),
					new SqlParameter("@FK_subject_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.userid;
			parameters[1].Value = model.category;
			parameters[2].Value = model.fileid;
			parameters[3].Value = model.dltime;
			parameters[4].Value = model.spnum;
			parameters[5].Value = model.level;
			parameters[6].Value = model.filename;
			parameters[7].Value = model.FK_subject_ID;

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
		public bool Update(Maticsoft.Model.tblfinancerecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblfinancerecord set ");
			strSql.Append("userid=@userid,");
			strSql.Append("category=@category,");
			strSql.Append("fileid=@fileid,");
			strSql.Append("spnum=@spnum,");
			strSql.Append("level=@level,");
			strSql.Append("filename=@filename,");
			strSql.Append("FK_subject_ID=@FK_subject_ID");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@category", SqlDbType.Int,4),
					new SqlParameter("@fileid", SqlDbType.Int,4),
					new SqlParameter("@spnum", SqlDbType.Int,4),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@filename", SqlDbType.NVarChar,100),
					new SqlParameter("@FK_subject_ID", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@dltime", SqlDbType.DateTime)};
			parameters[0].Value = model.userid;
			parameters[1].Value = model.category;
			parameters[2].Value = model.fileid;
			parameters[3].Value = model.spnum;
			parameters[4].Value = model.level;
			parameters[5].Value = model.filename;
			parameters[6].Value = model.FK_subject_ID;
			parameters[7].Value = model.id;
			parameters[8].Value = model.dltime;

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
			strSql.Append("delete from tblfinancerecord ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(DateTime dltime,int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tblfinancerecord ");
			strSql.Append(" where dltime=@dltime and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@dltime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = dltime;
			parameters[1].Value = id;

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
			strSql.Append("delete from tblfinancerecord ");
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
		public Maticsoft.Model.tblfinancerecord GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID from tblfinancerecord ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tblfinancerecord model=new Maticsoft.Model.tblfinancerecord();
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
		public Maticsoft.Model.tblfinancerecord DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblfinancerecord model=new Maticsoft.Model.tblfinancerecord();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["userid"]!=null && row["userid"].ToString()!="")
				{
					model.userid=int.Parse(row["userid"].ToString());
				}
				if(row["category"]!=null && row["category"].ToString()!="")
				{
					model.category=int.Parse(row["category"].ToString());
				}
				if(row["fileid"]!=null && row["fileid"].ToString()!="")
				{
					model.fileid=int.Parse(row["fileid"].ToString());
				}
				if(row["dltime"]!=null && row["dltime"].ToString()!="")
				{
					model.dltime=DateTime.Parse(row["dltime"].ToString());
				}
				if(row["spnum"]!=null && row["spnum"].ToString()!="")
				{
					model.spnum=int.Parse(row["spnum"].ToString());
				}
				if(row["level"]!=null && row["level"].ToString()!="")
				{
					model.level=int.Parse(row["level"].ToString());
				}
				if(row["filename"]!=null)
				{
					model.filename=row["filename"].ToString();
				}
				if(row["FK_subject_ID"]!=null && row["FK_subject_ID"].ToString()!="")
				{
					model.FK_subject_ID=int.Parse(row["FK_subject_ID"].ToString());
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
			strSql.Append("select id,userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID ");
			strSql.Append(" FROM tblfinancerecord ");
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
			strSql.Append(" id,userid,category,fileid,dltime,spnum,level,filename,FK_subject_ID ");
			strSql.Append(" FROM tblfinancerecord ");
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
			strSql.Append("select count(1) FROM tblfinancerecord ");
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
			strSql.Append(")AS Row, T.*  from tblfinancerecord T ");
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
			parameters[0].Value = "tblfinancerecord";
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

