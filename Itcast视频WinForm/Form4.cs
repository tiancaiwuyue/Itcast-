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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.采集用户的输入
            string useroldpwd=textBox1.Text;
            string usernewpwd1 = textBox2.Text;
            string usernewpwd2 = textBox3.Text;
            //2.校验两次输入的新密码是否正确
            if (usernewpwd1==usernewpwd2)
            {
                //3.校验旧密码是否正确
                //使用当前用户输入的旧密码和GlobalHelper._autoId进行匹配
                if (CheckUserOldPassword(useroldpwd,GlobalHelper._autoId))
                {
                    if (UpdatePassword(GlobalHelper._autoId, usernewpwd2))
                    {
                        MessageBox.Show("密码修改成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码修改失败");
                    }
                }
                else
                {
                    MessageBox.Show("用户输入旧密码错误");
                }
            }
            else
            {
                MessageBox.Show("两次输入新密码不一致");
            }
        }

        private bool UpdatePassword(int autoId, string usernewpwd2)
        {
            string constr = "Data source = localhost;initial catalog=myfirstdatabase; integrated security=true";
            string sql = string.Format("update userid set userpassword='{0}' where autoId={1}",usernewpwd2,autoId);
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    return r > 0;
                }
            }
        }

        private bool CheckUserOldPassword(string useroldpwd, int autoId)
        {
            string sql = string.Format("select count(*) from userid where userpassword='{0}' and autoid='{1}'", useroldpwd,autoId);
            string constr = "Data source = localhost;initial catalog=myfirstdatabase; integrated security=true";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    con.Open();
                    int r = (int)cmd.ExecuteScalar();
                    return r > 0;
                }
            }
        }
    }
}
