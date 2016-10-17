using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbltest
	/// </summary>
	public partial class tbltest
	{
		public tbltest()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tbltest"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime uploadtime,int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbltest");
			strSql.Append(" where uploadtime=@uploadtime and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@uploadtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = uploadtime;
			parameters[1].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tbltest model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbltest(");
			strSql.Append("level,areaid,subjectid,testcategory,testname,uploadtime,filesrc,downloadnum,neednum,extension,year,uploader,content,groupid,schoolid,ismingxiao,isjingpin,istuijian,isgaokao,isdujia,beikao)");
			strSql.Append(" values (");
			strSql.Append("@level,@areaid,@subjectid,@testcategory,@testname,@uploadtime,@filesrc,@downloadnum,@neednum,@extension,@year,@uploader,@content,@groupid,@schoolid,@ismingxiao,@isjingpin,@istuijian,@isgaokao,@isdujia,@beikao)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@subjectid", SqlDbType.Int,4),
					new SqlParameter("@testcategory", SqlDbType.Int,4),
					new SqlParameter("@testname", SqlDbType.NVarChar,100),
					new SqlParameter("@uploadtime", SqlDbType.DateTime),
					new SqlParameter("@filesrc", SqlDbType.NVarChar,100),
					new SqlParameter("@downloadnum", SqlDbType.Int,4),
					new SqlParameter("@neednum", SqlDbType.Int,4),
					new SqlParameter("@extension", SqlDbType.NVarChar,5),
					new SqlParameter("@year", SqlDbType.NVarChar,5),
					new SqlParameter("@uploader", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NVarChar,-1),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@schoolid", SqlDbType.Int,4),
					new SqlParameter("@ismingxiao", SqlDbType.NVarChar,10),
					new SqlParameter("@isjingpin", SqlDbType.NVarChar,10),
					new SqlParameter("@istuijian", SqlDbType.NVarChar,10),
					new SqlParameter("@isgaokao", SqlDbType.NVarChar,10),
					new SqlParameter("@isdujia", SqlDbType.NVarChar,10),
					new SqlParameter("@beikao", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.level;
			parameters[1].Value = model.areaid;
			parameters[2].Value = model.subjectid;
			parameters[3].Value = model.testcategory;
			parameters[4].Value = model.testname;
			parameters[5].Value = model.uploadtime;
			parameters[6].Value = model.filesrc;
			parameters[7].Value = model.downloadnum;
			parameters[8].Value = model.neednum;
			parameters[9].Value = model.extension;
			parameters[10].Value = model.year;
			parameters[11].Value = model.uploader;
			parameters[12].Value = model.content;
			parameters[13].Value = model.groupid;
			parameters[14].Value = model.schoolid;
			parameters[15].Value = model.ismingxiao;
			parameters[16].Value = model.isjingpin;
			parameters[17].Value = model.istuijian;
			parameters[18].Value = model.isgaokao;
			parameters[19].Value = model.isdujia;
			parameters[20].Value = model.beikao;

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
		public bool Update(Maticsoft.Model.tbltest model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbltest set ");
			strSql.Append("level=@level,");
			strSql.Append("areaid=@areaid,");
			strSql.Append("subjectid=@subjectid,");
			strSql.Append("testcategory=@testcategory,");
			strSql.Append("testname=@testname,");
			strSql.Append("filesrc=@filesrc,");
			strSql.Append("downloadnum=@downloadnum,");
			strSql.Append("neednum=@neednum,");
			strSql.Append("extension=@extension,");
			strSql.Append("year=@year,");
			strSql.Append("uploader=@uploader,");
			strSql.Append("content=@content,");
			strSql.Append("groupid=@groupid,");
			strSql.Append("schoolid=@schoolid,");
			strSql.Append("ismingxiao=@ismingxiao,");
			strSql.Append("isjingpin=@isjingpin,");
			strSql.Append("istuijian=@istuijian,");
			strSql.Append("isgaokao=@isgaokao,");
			strSql.Append("isdujia=@isdujia,");
			strSql.Append("beikao=@beikao");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@subjectid", SqlDbType.Int,4),
					new SqlParameter("@testcategory", SqlDbType.Int,4),
					new SqlParameter("@testname", SqlDbType.NVarChar,100),
					new SqlParameter("@filesrc", SqlDbType.NVarChar,100),
					new SqlParameter("@downloadnum", SqlDbType.Int,4),
					new SqlParameter("@neednum", SqlDbType.Int,4),
					new SqlParameter("@extension", SqlDbType.NVarChar,5),
					new SqlParameter("@year", SqlDbType.NVarChar,5),
					new SqlParameter("@uploader", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NVarChar,-1),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@schoolid", SqlDbType.Int,4),
					new SqlParameter("@ismingxiao", SqlDbType.NVarChar,10),
					new SqlParameter("@isjingpin", SqlDbType.NVarChar,10),
					new SqlParameter("@istuijian", SqlDbType.NVarChar,10),
					new SqlParameter("@isgaokao", SqlDbType.NVarChar,10),
					new SqlParameter("@isdujia", SqlDbType.NVarChar,10),
					new SqlParameter("@beikao", SqlDbType.NVarChar,10),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@uploadtime", SqlDbType.DateTime)};
			parameters[0].Value = model.level;
			parameters[1].Value = model.areaid;
			parameters[2].Value = model.subjectid;
			parameters[3].Value = model.testcategory;
			parameters[4].Value = model.testname;
			parameters[5].Value = model.filesrc;
			parameters[6].Value = model.downloadnum;
			parameters[7].Value = model.neednum;
			parameters[8].Value = model.extension;
			parameters[9].Value = model.year;
			parameters[10].Value = model.uploader;
			parameters[11].Value = model.content;
			parameters[12].Value = model.groupid;
			parameters[13].Value = model.schoolid;
			parameters[14].Value = model.ismingxiao;
			parameters[15].Value = model.isjingpin;
			parameters[16].Value = model.istuijian;
			parameters[17].Value = model.isgaokao;
			parameters[18].Value = model.isdujia;
			parameters[19].Value = model.beikao;
			parameters[20].Value = model.id;
			parameters[21].Value = model.uploadtime;

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
			strSql.Append("delete from tbltest ");
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
		public bool Delete(DateTime uploadtime,int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbltest ");
			strSql.Append(" where uploadtime=@uploadtime and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@uploadtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = uploadtime;
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
			strSql.Append("delete from tbltest ");
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
		public Maticsoft.Model.tbltest GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,level,areaid,subjectid,testcategory,testname,uploadtime,filesrc,downloadnum,neednum,extension,year,uploader,content,groupid,schoolid,ismingxiao,isjingpin,istuijian,isgaokao,isdujia,beikao from tbltest ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tbltest model=new Maticsoft.Model.tbltest();
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
		public Maticsoft.Model.tbltest DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbltest model=new Maticsoft.Model.tbltest();
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
				if(row["testcategory"]!=null && row["testcategory"].ToString()!="")
				{
					model.testcategory=int.Parse(row["testcategory"].ToString());
				}
				if(row["testname"]!=null)
				{
					model.testname=row["testname"].ToString();
				}
				if(row["uploadtime"]!=null && row["uploadtime"].ToString()!="")
				{
					model.uploadtime=DateTime.Parse(row["uploadtime"].ToString());
				}
				if(row["filesrc"]!=null)
				{
					model.filesrc=row["filesrc"].ToString();
				}
				if(row["downloadnum"]!=null && row["downloadnum"].ToString()!="")
				{
					model.downloadnum=int.Parse(row["downloadnum"].ToString());
				}
				if(row["neednum"]!=null && row["neednum"].ToString()!="")
				{
					model.neednum=int.Parse(row["neednum"].ToString());
				}
				if(row["extension"]!=null)
				{
					model.extension=row["extension"].ToString();
				}
				if(row["year"]!=null)
				{
					model.year=row["year"].ToString();
				}
				if(row["uploader"]!=null)
				{
					model.uploader=row["uploader"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["groupid"]!=null && row["groupid"].ToString()!="")
				{
					model.groupid=int.Parse(row["groupid"].ToString());
				}
				if(row["schoolid"]!=null && row["schoolid"].ToString()!="")
				{
					model.schoolid=int.Parse(row["schoolid"].ToString());
				}
				if(row["ismingxiao"]!=null)
				{
					model.ismingxiao=row["ismingxiao"].ToString();
				}
				if(row["isjingpin"]!=null)
				{
					model.isjingpin=row["isjingpin"].ToString();
				}
				if(row["istuijian"]!=null)
				{
					model.istuijian=row["istuijian"].ToString();
				}
				if(row["isgaokao"]!=null)
				{
					model.isgaokao=row["isgaokao"].ToString();
				}
				if(row["isdujia"]!=null)
				{
					model.isdujia=row["isdujia"].ToString();
				}
				if(row["beikao"]!=null)
				{
					model.beikao=row["beikao"].ToString();
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
			strSql.Append("select id,level,areaid,subjectid,testcategory,testname,uploadtime,filesrc,downloadnum,neednum,extension,year,uploader,content,groupid,schoolid,ismingxiao,isjingpin,istuijian,isgaokao,isdujia,beikao ");
			strSql.Append(" FROM tbltest ");
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
			strSql.Append(" id,level,areaid,subjectid,testcategory,testname,uploadtime,filesrc,downloadnum,neednum,extension,year,uploader,content,groupid,schoolid,ismingxiao,isjingpin,istuijian,isgaokao,isdujia,beikao ");
			strSql.Append(" FROM tbltest ");
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
			strSql.Append("select count(1) FROM tbltest ");
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
			strSql.Append(")AS Row, T.*  from tbltest T ");
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
			parameters[0].Value = "tbltest";
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

