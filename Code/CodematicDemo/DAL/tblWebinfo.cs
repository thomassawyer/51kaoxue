using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblWebinfo
	/// </summary>
	public partial class tblWebinfo
	{
		public tblWebinfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tblWebinfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tblWebinfo");
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
		public int Add(Maticsoft.Model.tblWebinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblWebinfo(");
			strSql.Append("name,logosrc,footinfo,headseo,keyseo,describseo,weixin,weibo,gengxin,zongliang,schooltestnum,jinpintestnum,schoolnum)");
			strSql.Append(" values (");
			strSql.Append("@name,@logosrc,@footinfo,@headseo,@keyseo,@describseo,@weixin,@weibo,@gengxin,@zongliang,@schooltestnum,@jinpintestnum,@schoolnum)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@logosrc", SqlDbType.NVarChar,100),
					new SqlParameter("@footinfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@headseo", SqlDbType.NVarChar,100),
					new SqlParameter("@keyseo", SqlDbType.NVarChar,100),
					new SqlParameter("@describseo", SqlDbType.NVarChar,100),
					new SqlParameter("@weixin", SqlDbType.NVarChar,100),
					new SqlParameter("@weibo", SqlDbType.NVarChar,100),
					new SqlParameter("@gengxin", SqlDbType.NVarChar,50),
					new SqlParameter("@zongliang", SqlDbType.NVarChar,50),
					new SqlParameter("@schooltestnum", SqlDbType.NVarChar,50),
					new SqlParameter("@jinpintestnum", SqlDbType.NVarChar,50),
					new SqlParameter("@schoolnum", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.logosrc;
			parameters[2].Value = model.footinfo;
			parameters[3].Value = model.headseo;
			parameters[4].Value = model.keyseo;
			parameters[5].Value = model.describseo;
			parameters[6].Value = model.weixin;
			parameters[7].Value = model.weibo;
			parameters[8].Value = model.gengxin;
			parameters[9].Value = model.zongliang;
			parameters[10].Value = model.schooltestnum;
			parameters[11].Value = model.jinpintestnum;
			parameters[12].Value = model.schoolnum;

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
		public bool Update(Maticsoft.Model.tblWebinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblWebinfo set ");
			strSql.Append("name=@name,");
			strSql.Append("logosrc=@logosrc,");
			strSql.Append("footinfo=@footinfo,");
			strSql.Append("headseo=@headseo,");
			strSql.Append("keyseo=@keyseo,");
			strSql.Append("describseo=@describseo,");
			strSql.Append("weixin=@weixin,");
			strSql.Append("weibo=@weibo,");
			strSql.Append("gengxin=@gengxin,");
			strSql.Append("zongliang=@zongliang,");
			strSql.Append("schooltestnum=@schooltestnum,");
			strSql.Append("jinpintestnum=@jinpintestnum,");
			strSql.Append("schoolnum=@schoolnum");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@logosrc", SqlDbType.NVarChar,100),
					new SqlParameter("@footinfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@headseo", SqlDbType.NVarChar,100),
					new SqlParameter("@keyseo", SqlDbType.NVarChar,100),
					new SqlParameter("@describseo", SqlDbType.NVarChar,100),
					new SqlParameter("@weixin", SqlDbType.NVarChar,100),
					new SqlParameter("@weibo", SqlDbType.NVarChar,100),
					new SqlParameter("@gengxin", SqlDbType.NVarChar,50),
					new SqlParameter("@zongliang", SqlDbType.NVarChar,50),
					new SqlParameter("@schooltestnum", SqlDbType.NVarChar,50),
					new SqlParameter("@jinpintestnum", SqlDbType.NVarChar,50),
					new SqlParameter("@schoolnum", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.logosrc;
			parameters[2].Value = model.footinfo;
			parameters[3].Value = model.headseo;
			parameters[4].Value = model.keyseo;
			parameters[5].Value = model.describseo;
			parameters[6].Value = model.weixin;
			parameters[7].Value = model.weibo;
			parameters[8].Value = model.gengxin;
			parameters[9].Value = model.zongliang;
			parameters[10].Value = model.schooltestnum;
			parameters[11].Value = model.jinpintestnum;
			parameters[12].Value = model.schoolnum;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from tblWebinfo ");
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
			strSql.Append("delete from tblWebinfo ");
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
		public Maticsoft.Model.tblWebinfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,logosrc,footinfo,headseo,keyseo,describseo,weixin,weibo,gengxin,zongliang,schooltestnum,jinpintestnum,schoolnum from tblWebinfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tblWebinfo model=new Maticsoft.Model.tblWebinfo();
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
		public Maticsoft.Model.tblWebinfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblWebinfo model=new Maticsoft.Model.tblWebinfo();
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
				if(row["logosrc"]!=null)
				{
					model.logosrc=row["logosrc"].ToString();
				}
				if(row["footinfo"]!=null)
				{
					model.footinfo=row["footinfo"].ToString();
				}
				if(row["headseo"]!=null)
				{
					model.headseo=row["headseo"].ToString();
				}
				if(row["keyseo"]!=null)
				{
					model.keyseo=row["keyseo"].ToString();
				}
				if(row["describseo"]!=null)
				{
					model.describseo=row["describseo"].ToString();
				}
				if(row["weixin"]!=null)
				{
					model.weixin=row["weixin"].ToString();
				}
				if(row["weibo"]!=null)
				{
					model.weibo=row["weibo"].ToString();
				}
				if(row["gengxin"]!=null)
				{
					model.gengxin=row["gengxin"].ToString();
				}
				if(row["zongliang"]!=null)
				{
					model.zongliang=row["zongliang"].ToString();
				}
				if(row["schooltestnum"]!=null)
				{
					model.schooltestnum=row["schooltestnum"].ToString();
				}
				if(row["jinpintestnum"]!=null)
				{
					model.jinpintestnum=row["jinpintestnum"].ToString();
				}
				if(row["schoolnum"]!=null)
				{
					model.schoolnum=row["schoolnum"].ToString();
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
			strSql.Append("select id,name,logosrc,footinfo,headseo,keyseo,describseo,weixin,weibo,gengxin,zongliang,schooltestnum,jinpintestnum,schoolnum ");
			strSql.Append(" FROM tblWebinfo ");
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
			strSql.Append(" id,name,logosrc,footinfo,headseo,keyseo,describseo,weixin,weibo,gengxin,zongliang,schooltestnum,jinpintestnum,schoolnum ");
			strSql.Append(" FROM tblWebinfo ");
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
			strSql.Append("select count(1) FROM tblWebinfo ");
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
			strSql.Append(")AS Row, T.*  from tblWebinfo T ");
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
			parameters[0].Value = "tblWebinfo";
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

