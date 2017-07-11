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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //将Tblstudent表中的数据读取到一个List<T>中
            LoadData();
        }
        private void LoadData()
        {
            List<Class1> list = new List<Class1>();
            string constr = "Data Source=localhost;initial catalog=MyfirstDatabase;integrated security=true";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from TblClass";
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //判断是否查询到了数据
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Class1 model = new Class1();
                                model.TClassID = reader.GetInt32(0);
                                model.TClassName = reader.GetString(1);
                                model.TClassDesc = reader.IsDBNull(2)? null:reader.GetString(2);
                                list.Add(model);//把model对象加到list集合中
                            }
                        }
                    }
                }
            }
            //数据绑定需要注意的一点：
            //数据绑定的时候，只认“属性”，不认“字段”！
            //内部通过反射获取属性！
            //数据控件类似于网格，表格数据控件，只要给个数据集合，它自动就会把数据集合给展现出来，这就叫数据绑定。只要把数据集合给它，它自动就会遍历。
            this.dataGridView1.DataSource = list;//数据绑定
        }
        //增加一条数据
        private void button1_Click(object sender, EventArgs e)
        {
            //1.采集用户的输入
            string className = textBox1.Text.Trim();
            string classDesc = textBox2.Text.Trim();
            //2.执行插入操作
            string contr = "data source=localhost;initial catalog=Myfirstdatabase;integrated security=true";
            using (SqlConnection con = new SqlConnection(contr))
            {
                string sql = string.Format("insert into TblClass output inserted.tClassId Values(N'{0}',N'{1}')", className, classDesc);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    object r = cmd.ExecuteScalar();
                    this.Text = "刚刚插入的记录的自动编号是：" + r.ToString();
                    LoadData();
                }
            }
            #region 版本1
            ////1.采集用户的输入
            //string className = textBox1.Text.Trim();
            //string classDesc = textBox2.Text.Trim();
            ////2.执行插入操作
            //string contr = "data source=localhost;initial catalog=Myfirstdatabase;integrated security=true";
            //using (SqlConnection con = new SqlConnection(contr))
            //{
            //    string sql = string.Format("insert into TblClass Values(N'{0}',N'{1}')", className, classDesc);
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        con.Open();
            //        int r = cmd.ExecuteNonQuery();
            //        if (r > 0)
            //        {
            //            //不要用MessageBox，因为MessageBox会阻塞线程，如果不点击确定，那么它的连接是一直打开。
            //            //可以是用标题栏显示:this.Text="成功插入！";
            //            //或是产生个bool类型退出连接数据库后之后再使用
            //            //MessageBox.Show("成功插入！");

            //            this.Text = "插入了" + r + "行!";
            //            //刷新表/更新控件
            //            LoadData();
            //        }
            //        else
            //        {
            //            //MessageBox.Show("插入了" + r + "行!");
            //            this.Text = "插入失败";
            //        }
            //    }
            //}
            #endregion
        }

        //RowEnter，当行获取焦点时候获取整行
        //Multi可否选择多行
        //SelectionMode=FullRowSelection
        //行获取焦点事件
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //sender指GridView控件，不是那一行，因为这是整个控件的事件。
            //this.dataGridView1.SelectedRows(获取指定索引处的行：用于多行选中时的那几行的集合。此时只能为一行，所以直接用Rows)
            DataGridViewRow currentRow=this.dataGridView1.Rows[e.RowIndex];
            //获取当前行中绑定的TblClass数据对象
            Class1 model = currentRow.DataBoundItem as Class1;
            if (model != null)
            {
                label5.Text = model.TClassID.ToString();
                textBox3.Text = model.TClassName;
                textBox4.Text = model.TClassDesc;
            }


        }

        //保存数据 
        private void button2_Click(object sender, EventArgs e)
        {
            //1.采集用户输入
            Class1 model = new Class1();
            model.TClassID = Convert.ToInt32(label5.Text);
            model.TClassName = textBox3.Text.Trim();
            model.TClassDesc = textBox4.Text.Trim();

            //2.连接数据库，执行删除操作！
            string constr = "data source= localhost;initial catalog=Myfirstdatabase;integrated security=true";
            
            using (SqlConnection con = new SqlConnection(constr))
            {
                string str = string.Format("update Tblclass set tClassName='{0}',tClassAs='{1}' where tClassId={2}",model.TClassName,model.TClassDesc,model.TClassID);
                using (SqlCommand cmd = new SqlCommand(str,con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    this.Text = "更新了！";
                    LoadData();
                }
            }
        }
        //删除数据
        private void button3_Click(object sender, EventArgs e)
        {
            //内容，标题，用什么按钮，图标
            DialogResult result = MessageBox.Show("确定要删除吗?","操作提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                int tClassId = Convert.ToInt32(label5.Text);
                string constr = "data source= localhost;initial catalog=Myfirstdatabase;integrated security=true";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string str = string.Format("delete from TblClass where tClassID={0}", tClassId);
                    using (SqlCommand cmd = new SqlCommand(str, con))
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        this.Text = "更新了！";
                        LoadData();
                    }
                }
            }
        }
    }
}
