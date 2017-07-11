using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itcast视频WinForm
{
    public partial class 通过ADO : Form
    {
        public 通过ADO()
        {
            InitializeComponent();
        }
        private int pageIndex = 1;
        private int pageSize = 7;
        //private int pageCount;//总页数
        //private int recordCount;//总条数
        //窗体加载的时候显示第一页的数据
        private void 通过ADO_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private void LoadData()
        {
            //根据pageIndex来加载数据
            string constr = "Data Source=.;Initial Catalog=MyfirstDataBase;integrated Security=true";
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter=new SqlDataAdapter("usp_getMystudentsdatabypage",constr))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] pms = new SqlParameter[]
                {
                            new SqlParameter("@pageSize",SqlDbType.Int){Value=pageSize },
                            new SqlParameter("@pageIndex",SqlDbType.Int){Value=pageIndex },
                            new SqlParameter("@recordcount",SqlDbType.Int){ Direction=ParameterDirection.Output},
                            new SqlParameter("@pagecount",SqlDbType.Int){ Direction=ParameterDirection.Output}
                };
                adapter.SelectCommand.Parameters.AddRange(pms);
                adapter.Fill(dt);
                //获取输出参数并且赋值给label
                label1.Text = "总条数"+pms[2].Value.ToString();
                label2.Text = "总页数"+pms[3].Value.ToString();
                label3.Text = "当前页" + pageIndex;
                //数据绑定
                this.dataGridView1.DataSource = dt;
            }



            #region 非adapter
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    //将sql语句变成存储过程名称
            //    string sql = "usp_GetMystudentsdataBypage";
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        //告诉sqlcommand对象，现在执行的存储过程不是SQL语句
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        //增加参数(存储过程中有几个参数，这里就需要增加几个参数)
            //        SqlParameter[] pms = new SqlParameter[]
            //        {
            //            new SqlParameter("@pageSize",SqlDbType.Int){Value=pageSize },
            //            new SqlParameter("@pageIndex",SqlDbType.Int){Value=pageSize },
            //            new SqlParameter("@recordcount",SqlDbType.Int){ Direction=ParameterDirection.Output},
            //            new SqlParameter("@pagecount",SqlDbType.Int){ Direction=ParameterDirection.Output}
            //        };
            //        cmd.Parameters.AddRange(pms);
            //        //打开连接
            //        con.Open();
            //        //执行
            //    }
            //}
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pageIndex--;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pageIndex++;
            LoadData();
        }
    }
}
