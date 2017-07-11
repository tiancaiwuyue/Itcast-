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
using ClassLibrary1;
namespace Itcast视频WinForm
{
    public partial class 练习SQLAdapterTest : Form
    {
        public 练习SQLAdapterTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string constr = "Data Source=localhost;Initial catalog=MyfirstDatabase;integrated security=true";
            string sql = "select * from Filemanager01";
            //DataTable dt = new DataTable();
            //using (SqlDataAdapter adapter = new SqlDataAdapter(sql, constr))
            //{
            //    adapter.Fill(dt);//实现了从数据库中读取数据并加载到DataTable中。
            //}
            //this.dataGridView1.DataSource = dt;//数据绑定
            this.dataGridView1.DataSource = SQLHelper.ExecuteDataTable(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DataSet就是一个集合，内存数据库，临时数据库。
            DataSet ds = new DataSet("School");

            //2.创建一张表
            DataTable dt = new DataTable("Student");

            //2.1向dt表中创建一些列
            DataColumn dcAutoId = new DataColumn("AutoID", typeof(int));
            //设置列为自动编号
            dcAutoId.AutoIncrement = true;
            dcAutoId.AutoIncrementSeed = 1;
            dcAutoId.AutoIncrementStep = 1;
            //把dcAutoId列加到表中
            dt.Columns.Add(dcAutoId);

            //增加一个姓名列
            DataColumn dcUserName = dt.Columns.Add("UserName", typeof(string));
            //设置列不允许为空
            dcUserName.AllowDBNull = false;

            //增加一个年龄列
            dt.Columns.Add("UserAge", typeof(int));

            //----------向dt表中增加一些行数据
            //创建一个行对象
            DataRow dr1 = dt.NewRow();//根据表的结构来创建，它构造函数为internal所以用属性创建
            dr1["UserName"] = "我的朋友";
            dr1["UserAge"] = 21;
            //把该行对象增加到dt中
            dt.Rows.Add(dr1);

            //--再增加一行
            DataRow dr2 = dt.NewRow();
            dr2["UserName"] = "碰碰";
            dr2["UserAge"] = 33;
            dt.Rows.Add(dr2);

            //3.把dt加到ds中。
            ds.Tables.Add(dt);
            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
