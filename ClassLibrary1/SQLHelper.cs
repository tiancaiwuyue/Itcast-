using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class SQLHelper
    {
        //定义一个连接字符串
        //readonly修饰的变量，只能在初始化的时候赋值，以及在构造函数中赋值
        //其他地方只能读取不能设置值
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;

        //1.执行增（insert）、删（delete）、改（update）的方法
        //ExecuteNonQuery()
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }

            }
        }

        //2.执行查询，返回单个值的方法
        //ExecuteScalar()
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }

            }
        }
        //3.执行查询，返回多行，多列的方法
        //ExecuteReader()
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            //reader使用的时候连接是打开的，但是reader使用完毕以后也没法关闭连接了。
            SqlConnection con = new SqlConnection(conStr);
            //如果使用using con的方法的话，是形成try finally的格式，但是reader要一直保持打开，但是使用return的时候它是先关闭连接再执行return，所以reader就无效了。
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
                

                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    //如果return操作发生异常时，则con.Open()不会关闭所以使用try语句修饰
                try
                {
                    con.Open();
                    //return cmd.ExecuteReader();
                    //System.Data.CommandBehavior.CloseConnection这个枚举参数，表示将来使用完毕SqlDataReader后，在关闭reader的同时，在SQLDataReader内部会将关联的Connection对象也关闭掉
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;//只能出现在catch块中。抛出系统异常。
                    //throw new Exception("出错了");//是直接抛出这个内容为“*”的异常，和系统异常无关。
                }
            }
            //}
        }

        //4.查询数据返回DataTable.
        //params即使没有参数传进来，它也不是null，是一个长度为0的数组。
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter=new SqlDataAdapter(sql,conStr))
            {
                if (pms!=null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
