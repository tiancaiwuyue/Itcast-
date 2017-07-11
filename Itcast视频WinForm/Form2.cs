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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            #region 使用带参数的SQL语句
            string constr = "Data Source=localhost;initial catalog=myfirstdatabase;integrated security=true";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select count(*) from userid where userid=@loingid and userpassword=@loingpassword";
                //string sql1 = "exec sp_executesql N'select count(*) from userid where userid = @loingid and userpassword = @loingpassword',N'@loingid nvarchar(4),@loingpassword nvarchar(3)',@loingid = N'1233',@loingpassword = N'321'";
                using (SqlCommand cmd=new SqlCommand(sql,con))
                {
                    //1.当使用带参数的SQL语句的时候，
                    //1>sql语句中会出现参数。
                    //2>如果sql语句中有参数，那么必须在command对象中提供对应的参数和值。

                    ////创建两个参数对象
                    //SqlParameter paramLoginId = new SqlParameter("@loingid", SqlDbType.NVarChar, 50);
                    //paramLoginId.Value = textBox1.Text.Trim();
                    ////使用对象初始化器
                    ////SqlParameter paramLoginId = new SqlParameter("@loingid", SqlDbType.NVarChar, 50) { Value=textBox1.Text.Trim()};
                    //SqlParameter parampassword = new SqlParameter("@loingpassword", SqlDbType.NVarChar, 50) { Value=textBox2.Text};
                    ////向cmd中加参数
                    //cmd.Parameters.Add(paramLoginId);
                    //cmd.Parameters.Add(parampassword);

                    //--简化添加参数
                    //SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@loingid", SqlDbType.NVarChar, 50) { Value=textBox1.Text.Trim()},
                    //    new SqlParameter("@loingpassword", SqlDbType.NVarChar, 50) { Value = textBox2.Text } };
                    ////向command对象中添加参数
                    //cmd.Parameters.AddRange(pms);

                    //--这个AddWithValue内部就是new了一个对象，但是后面采取的是给的值，但是如果后面给的是“0”或特殊值，那么运行的时候就会有问题，不太严谨的时候不太用，一般用数组的方法。
                    cmd.Parameters.AddWithValue("@loingid", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@loingpassword", textBox2.Text);


                    con.Open();
                    int r =(int)cmd.ExecuteScalar();
                    if (r>0)
                    {
                        this.Text="登陆成功";
                    }
                    else
                    {
                        this.Text = "登陆失败";
                    }
                }
            }
            #endregion

            #region 使用不带参数的SQL语句
            ////1.采集数据
            //string loginId = textBox1.Text.Trim();
            //string password = textBox2.Text;
            ////2.连接数据库
            //string constr = "Data source= localhost; initial catalog = Myfirstdatabase;integrated security=true";
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    string sql = string.Format("select count(*) from userid where userid='{0}' and userpassword='{1}'", loginId, password);
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        con.Open();
            //        int count = (int)cmd.ExecuteScalar();
            //        if (count > 0)
            //        {
            //            this.BackColor = Color.Green;
            //        }
            //        else
            //        {
            //            this.BackColor = Color.Red;
            //        }
            //    }
            //} 
            #endregion
        }

        //登陆校验用户名是否存在以及密码是否正确
        private void button2_Click(object sender, EventArgs e)
        {
            //1.采集数据
            string loginId = textBox1.Text.Trim();
            string password = textBox2.Text;

            //2.现根据用户名去数据库中查找，是否有对应的用户
            string constr = "data source=localhost;initial catalog=Myfirstdatabase;integrated security=true";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("select * from userid where userid='{0}'", loginId);
                using (SqlCommand cmd= new SqlCommand(sql,con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())//如果使用ExecuteScalar返回的是null。
                    {
                        if (reader.HasRows)
                        {
                            //存在该用户
                            if (reader.Read())
                            {
                                //3.如果有对应的用户，再比较密码是否正确
                                //获取查询出的密码，和用户输入的密码进行比较
                                string pwd = reader.GetString(2);//不允许空所以不用验证
                                if (pwd==password)
                                {
                                    this.Text="登陆成功!";
                                    //启用button3按钮
                                    button3.Enabled = true;
                                    //获取当前登陆用户的主键Id，设置到GlobalHelper
                                    GlobalHelper._autoId = reader.GetInt32(0);
                                }
                                else
                                {
                                    this.Text="登陆失败!";
                                }
                            }
                        }
                        //4.如果没有该用户，直接提示用户：“用户不存在”
                        else
                        {
                            this.Text = "用户不存在！";
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from userid where userid=@uid and userpassword=@pwd";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@uid",SqlDbType.NVarChar,50){Value=textBox1.Text.Trim()},
                new SqlParameter("@pwd",SqlDbType.NVarChar,50){Value=textBox2.Text}
            };
            int r = (int)SQLHelper.ExecuteScalar(sql, pms);
            if (r > 0)
            {
                MessageBox.Show("登陆成功");
            }
            else
            {
                MessageBox.Show("登陆失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<TblClass> list = new List<TblClass>();
            string sql = "select * from Tblclass";
            //必须要用reader，因为只有reader被释放，方法内部才会释放连接。
            //当外键关闭reader的时候，顺便会把关联的connection关掉。如果reader不关，连接也关不了，所以必须用using
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblClass model = new TblClass();
                        model.TClassID = reader.GetInt32(0);
                        model.TClassName = reader.GetString(1);
                        model.TClassDesc = reader.GetString(2);
                        list.Add(model);
                    }
                }
            }
            MessageBox.Show(list.Count.ToString());
        }
    }
}
