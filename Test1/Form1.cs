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

namespace Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql1 = "select count(*) from userid where userid=@uid and userpassword=@pwd";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@uid",SqlDbType.NVarChar,50){Value=textBox1.Text.Trim()},
                new SqlParameter("@pwd",SqlDbType.NVarChar,50){Value=textBox2.Text}
            };
            int r = (int)SQLHelper.ExecuteScalar(sql1, pms);
            if (r > 0)
            {
                MessageBox.Show("登陆成功");
            }
            else
            {
                MessageBox.Show("登陆失败");
            }
        }
    }
}
