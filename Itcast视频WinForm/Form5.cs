using ClassLibrary1;
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
    public partial class Form5 : Form
    {
        private int v;

        public Form5()
        {
            InitializeComponent();
        }
        private Action _method;
        public Form5(int v,Action method):this()
        {
            this.v = v;
            this._method = method;
        }

        //增加一个类别
        private void button1_Click(object sender, EventArgs e)
        {
            //1.采集数据
            string categoryName = textBox1.Text.Trim();
            string note = textBox2.Text.Trim();
            //2.执行插入操作
            string sql = "insert into FileManager01 values(@name,@pid,@note)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@name",SqlDbType.NVarChar,100){ Value=categoryName},
                new SqlParameter("@pid",SqlDbType.Int){Value=this.v},
                new SqlParameter("@note",SqlDbType.NVarChar,1000){Value=note}
            };

            //3.执行sql
            SQLHelper.ExecuteNonQuery(sql, pms);
            MessageBox.Show("Done");
            if (this._method!=null)
            {
                //刷新父窗口中的TreeView
                this._method();
            }
            //4.关闭当前窗口
            this.Close();
        }
    }
}
