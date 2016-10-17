using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:webusers
	/// </summary>
	public partial class webusers
	{
		public webusers()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "webusers"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from webusers");
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
		public int Add(Maticsoft.Model.webusers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into webusers(");
			strSql.Append("username,password,email,school,name,mobile,province,city,position,subject,address,tel,level,regdate,ip,daoqidate,openpwd,yewu,provinceid,cityid,grade,status,yewudiqv)");
			strSql.Append(" values (");
			strSql.Append("@username,@password,@email,@school,@name,@mobile,@province,@city,@position,@subject,@address,@tel,@level,@regdate,@ip,@daoqidate,@openpwd,@yewu,@provinceid,@cityid,@grade,@status,@yewudiqv)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,40),
					new SqlParameter("@email", SqlDbType.NVarChar,100),
					new SqlParameter("@school", SqlDbType.NVarChar,200),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@province", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,50),
					new SqlParameter("@position", SqlDbType.NVarChar,10),
					new SqlParameter("@subject", SqlDbType.NVarChar,20),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@tel", SqlDbType.NVarChar,20),
					new SqlParameter("@level", SqlDbType.NVarChar,10),
					new SqlParameter("@regdate", SqlDbType.DateTime),
					new SqlParameter("@ip", SqlDbType.NVarChar,50),
					new SqlParameter("@daoqidate", SqlDbType.DateTime),
					new SqlParameter("@openpwd", SqlDbType.NVarChar,50),
					new SqlParameter("@yewu", SqlDbType.NVarChar,50),
					new SqlParameter("@provinceid", SqlDbType.NVarChar,50),
					new SqlParameter("@cityid", SqlDbType.NVarChar,50),
					new SqlParameter("@grade", SqlDbType.NVarChar,2),
					new SqlParameter("@status", SqlDbType.NVarChar,2),
					new SqlParameter("@yewudiqv", SqlDbType.NVarChar,300)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.password;
			parameters[2].Value = model.email;
			parameters[3].Value = model.school;
			parameters[4].Value = model.name;
			parameters[5].Value = model.mobile;
			parameters[6].Value = model.province;
			parameters[7].Value = model.city;
			parameters[8].Value = model.position;
			parameters[9].Value = model.subject;
			parameters[10].Value = model.address;
			parameters[11].Value = model.tel;
			parameters[12].Value = model.level;
			parameters[13].Value = model.regdate;
			parameters[14].Value = model.ip;
			parameters[15].Value = model.daoqidate;
			parameters[16].Value = model.openpwd;
			parameters[17].Value = model.yewu;
			parameters[18].Value = model.provinceid;
			parameters[19].Value = model.cityid;
			parameters[20].Value = model.grade;
			parameters[21].Value = model.status;
			parameters[22].Value = model.yewudiqv;

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
		public bool Update(Maticsoft.Model.webusers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update webusers set ");
			strSql.Append("username=@username,");
			strSql.Append("password=@password,");
			strSql.Append("email=@email,");
			strSql.Append("school=@school,");
			strSql.Append("name=@name,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("province=@province,");
			strSql.Append("city=@city,");
			strSql.Append("position=@position,");
			strSql.Append("subject=@subject,");
			strSql.Append("address=@address,");
			strSql.Append("tel=@tel,");
			strSql.Append("level=@level,");
			strSql.Append("regdate=@regdate,");
			strSql.Append("ip=@ip,");
			strSql.Append("daoqidate=@daoqidate,");
			strSql.Append("openpwd=@openpwd,");
			strSql.Append("yewu=@yewu,");
			strSql.Append("provinceid=@provinceid,");
			strSql.Append("cityid=@cityid,");
			strSql.Append("grade=@grade,");
			strSql.Append("status=@status,");
			strSql.Append("yewudiqv=@yewudiqv");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,40),
					new SqlParameter("@email", SqlDbType.NVarChar,100),
					new SqlParameter("@school", SqlDbType.NVarChar,200),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@province", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,50),
					new SqlParameter("@position", SqlDbType.NVarChar,10),
					new SqlParameter("@subject", SqlDbType.NVarChar,20),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@tel", SqlDbType.NVarChar,20),
					new SqlParameter("@level", SqlDbType.NVarChar,10),
					new SqlParameter("@regdate", SqlDbType.DateTime),
					new SqlParameter("@ip", SqlDbType.NVarChar,50),
					new SqlParameter("@daoqidate", SqlDbType.DateTime),
					new SqlParameter("@openpwd", SqlDbType.NVarChar,50),
					new SqlParameter("@yewu", SqlDbType.NVarChar,50),
					new SqlParameter("@provinceid", SqlDbType.NVarChar,50),
					new SqlParameter("@cityid", SqlDbType.NVarChar,50),
					new SqlParameter("@grade", SqlDbType.NVarChar,2),
					new SqlParameter("@status", SqlDbType.NVarChar,2),
					new SqlParameter("@yewudiqv", SqlDbType.NVarChar,300),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.password;
			parameters[2].Value = model.email;
			parameters[3].Value = model.school;
			parameters[4].Value = model.name;
			parameters[5].Value = model.mobile;
			parameters[6].Value = model.province;
			parameters[7].Value = model.city;
			parameters[8].Value = model.position;
			parameters[9].Value = model.subject;
			parameters[10].Value = model.address;
			parameters[11].Value = model.tel;
			parameters[12].Value = model.level;
			parameters[13].Value = model.regdate;
			parameters[14].Value = model.ip;
			parameters[15].Value = model.daoqidate;
			parameters[16].Value = model.openpwd;
			parameters[17].Value = model.yewu;
			parameters[18].Value = model.provinceid;
			parameters[19].Value = model.cityid;
			parameters[20].Value = model.grade;
			parameters[21].Value = model.status;
			parameters[22].Value = model.yewudiqv;
			parameters[23].Value = model.id;

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
			strSql.Append("delete from webusers ");
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
			strSql.Append("delete from webusers ");
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
		public Maticsoft.Model.webusers GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,username,password,email,school,name,mobile,province,city,position,subject,address,tel,level,regdate,ip,daoqidate,openpwd,yewu,provinceid,cityid,grade,status,yewudiqv from webusers ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.webusers model=new Maticsoft.Model.webusers();
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
		public Maticsoft.Model.webusers DataRowToModel(DataRow row)
		{
			Maticsoft.Model.webusers model=new Maticsoft.Model.webusers();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["school"]!=null)
				{
					model.school=row["school"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["province"]!=null)
				{
					model.province=row["province"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["position"]!=null)
				{
					model.position=row["position"].ToString();
				}
				if(row["subject"]!=null)
				{
					model.subject=row["subject"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["level"]!=null)
				{
					model.level=row["level"].ToString();
				}
				if(row["regdate"]!=null && row["regdate"].ToString()!="")
				{
					model.regdate=DateTime.Parse(row["regdate"].ToString());
				}
				if(row["ip"]!=null)
				{
					model.ip=row["ip"].ToString();
				}
				if(row["daoqidate"]!=null && row["daoqidate"].ToString()!="")
				{
					model.daoqidate=DateTime.Parse(row["daoqidate"].ToString());
				}
				if(row["openpwd"]!=null)
				{
					model.openpwd=row["openpwd"].ToString();
				}
				if(row["yewu"]!=null)
				{
					model.yewu=row["yewu"].ToString();
				}
				if(row["provinceid"]!=null)
				{
					model.provinceid=row["provinceid"].ToString();
				}
				if(row["cityid"]!=null)
				{
					model.cityid=row["cityid"].ToString();
				}
				if(row["grade"]!=null)
				{
					model.grade=row["grade"].ToString();
				}
				if(row["status"]!=null)
				{
					model.status=row["status"].ToString();
				}
				if(row["yewudiqv"]!=null)
				{
					model.yewudiqv=row["yewudiqv"].ToString();
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
			strSql.Append("select id,username,password,email,school,name,mobile,province,city,position,subject,address,tel,level,regdate,ip,daoqidate,openpwd,yewu,provinceid,cityid,grade,status,yewudiqv ");
			strSql.Append(" FROM webusers ");
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
			strSql.Append(" id,username,password,email,school,name,mobile,province,city,position,subject,address,tel,level,regdate,ip,daoqidate,openpwd,yewu,provinceid,cityid,grade,status,yewudiqv ");
			strSql.Append(" FROM webusers ");
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
			strSql.Append("select count(1) FROM webusers ");
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
			strSql.Append(")AS Row, T.*  from webusers T ");
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
			parameters[0].Value = "webusers";
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

