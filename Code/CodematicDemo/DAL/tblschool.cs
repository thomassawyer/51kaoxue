using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblschool
	/// </summary>
	public partial class tblschool
	{
		public tblschool()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tblschool"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime intime,int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tblschool");
			strSql.Append(" where intime=@intime and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@intime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = intime;
			parameters[1].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tblschool model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblschool(");
			strSql.Append("name,headname,star,content,level,areaid,intime,imgsrc,SchoolPosition)");
			strSql.Append(" values (");
			strSql.Append("@name,@headname,@star,@content,@level,@areaid,@intime,@imgsrc,@SchoolPosition)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@headname", SqlDbType.NVarChar,50),
					new SqlParameter("@star", SqlDbType.NVarChar,10),
					new SqlParameter("@content", SqlDbType.NVarChar,-1),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@intime", SqlDbType.DateTime),
					new SqlParameter("@imgsrc", SqlDbType.NVarChar,100),
					new SqlParameter("@SchoolPosition", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.headname;
			parameters[2].Value = model.star;
			parameters[3].Value = model.content;
			parameters[4].Value = model.level;
			parameters[5].Value = model.areaid;
			parameters[6].Value = model.intime;
			parameters[7].Value = model.imgsrc;
			parameters[8].Value = model.SchoolPosition;

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
		public bool Update(Maticsoft.Model.tblschool model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblschool set ");
			strSql.Append("name=@name,");
			strSql.Append("headname=@headname,");
			strSql.Append("star=@star,");
			strSql.Append("content=@content,");
			strSql.Append("level=@level,");
			strSql.Append("areaid=@areaid,");
			strSql.Append("imgsrc=@imgsrc,");
			strSql.Append("SchoolPosition=@SchoolPosition");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@headname", SqlDbType.NVarChar,50),
					new SqlParameter("@star", SqlDbType.NVarChar,10),
					new SqlParameter("@content", SqlDbType.NVarChar,-1),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@imgsrc", SqlDbType.NVarChar,100),
					new SqlParameter("@SchoolPosition", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@intime", SqlDbType.DateTime)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.headname;
			parameters[2].Value = model.star;
			parameters[3].Value = model.content;
			parameters[4].Value = model.level;
			parameters[5].Value = model.areaid;
			parameters[6].Value = model.imgsrc;
			parameters[7].Value = model.SchoolPosition;
			parameters[8].Value = model.id;
			parameters[9].Value = model.intime;

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
			strSql.Append("delete from tblschool ");
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
		public bool Delete(DateTime intime,int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tblschool ");
			strSql.Append(" where intime=@intime and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@intime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = intime;
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
			strSql.Append("delete from tblschool ");
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
		public Maticsoft.Model.tblschool GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,headname,star,content,level,areaid,intime,imgsrc,SchoolPosition from tblschool ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tblschool model=new Maticsoft.Model.tblschool();
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
		public Maticsoft.Model.tblschool DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblschool model=new Maticsoft.Model.tblschool();
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
				if(row["headname"]!=null)
				{
					model.headname=row["headname"].ToString();
				}
				if(row["star"]!=null)
				{
					model.star=row["star"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["level"]!=null && row["level"].ToString()!="")
				{
					model.level=int.Parse(row["level"].ToString());
				}
				if(row["areaid"]!=null && row["areaid"].ToString()!="")
				{
					model.areaid=int.Parse(row["areaid"].ToString());
				}
				if(row["intime"]!=null && row["intime"].ToString()!="")
				{
					model.intime=DateTime.Parse(row["intime"].ToString());
				}
				if(row["imgsrc"]!=null)
				{
					model.imgsrc=row["imgsrc"].ToString();
				}
				if(row["SchoolPosition"]!=null && row["SchoolPosition"].ToString()!="")
				{
					model.SchoolPosition=int.Parse(row["SchoolPosition"].ToString());
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
			strSql.Append("select id,name,headname,star,content,level,areaid,intime,imgsrc,SchoolPosition ");
			strSql.Append(" FROM tblschool ");
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
			strSql.Append(" id,name,headname,star,content,level,areaid,intime,imgsrc,SchoolPosition ");
			strSql.Append(" FROM tblschool ");
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
			strSql.Append("select count(1) FROM tblschool ");
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
			strSql.Append(")AS Row, T.*  from tblschool T ");
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
			parameters[0].Value = "tblschool";
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

