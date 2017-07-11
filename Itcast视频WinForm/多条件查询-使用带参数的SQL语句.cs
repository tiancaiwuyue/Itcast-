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
    public partial class 多条件查询_使用带参数的SQL语句 : Form
    {
        public 多条件查询_使用带参数的SQL语句()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //假设表名：Books
            //列名：BookName（书名）、Author（作者）、Publish（出版社）

            //多条件查询，要根据用户输入的内容来动态拼接SQL语句。
            //1.假设如果用户没有输入任何条件，那么就查询出所有的记录
            StringBuilder sbSQL = new StringBuilder("select * from Books");
            //在wheres集合中保存查询的sql条件
            List<string> wheres = new List<string>();
            //把参数也放到一个集合当中
            List<SqlParameter> listParameters = new List<SqlParameter>();
            //2.如果用户输入了条件，则根据用户输入的条件动态拼接SQL语句

            if (textBox1.Text.Trim().Length>0)
            {
                //sbSQL.Append("BookName like @bkName");
                wheres.Add(" BookName like @bkName ");
                listParameters.Add(new SqlParameter("@bkName", SqlDbType.NVarChar, 100) { Value="%"+textBox1.Text.Trim()+"%"});
            }
            if (textBox2.Text.Trim().Length>0)
            {
                //sbSQL.Append("Author like @author");
                wheres.Add(" Author like @author ");
                listParameters.Add(new SqlParameter("@author", SqlDbType.NVarChar, 100) { Value = "%" + textBox2.Text.Trim() + "%" });
            }
            if (textBox3.Text.Trim().Length>0)
            {
                //sbSQL.Append("Publish like @publish");
                wheres.Add(" Publish like @publish ");
                listParameters.Add(new SqlParameter("@publish", SqlDbType.NVarChar, 100) { Value = "%" + textBox3.Text.Trim() + "%" });
                //拼接SQL语句
                //如果wheres集合当中的记录条数大于0，证明用户输入了条件
                if (wheres.Count>0)
                {
                    sbSQL.Append(" where ");//只要有查询条件就拼接一个where
                    //然后把后面的查询条件拼接起来。
                    sbSQL.Append(string.Join(" and ", wheres));
                }
                SqlParameter[] pms = listParameters.ToArray();
                MessageBox.Show(sbSQL.ToString());
                //SqlHelper.ExecuteReader(sbSQL.ToString(),pms);
            }
        }
    }
}
