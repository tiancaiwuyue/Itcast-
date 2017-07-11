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
    public partial class 将内连接的数据绑定到DataGridView上 : Form
    {
        public 将内连接的数据绑定到DataGridView上()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<PhoneNum> list = new List<PhoneNum>();
            string sql = "select pid,pname,pcellphone,ptname,ptid from PhoneNum pn inner join PhoneType as pt on pn.pTypeId=pt.ptId";
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PhoneNum model = new PhoneNum();
                        model.PID = reader.GetInt32(0);
                        model.PName = reader.GetString(1);
                        model.PCellPhone = reader.GetString(2);
                        model.Group = new PhoneType();
                        model.Group.PTID = reader.GetInt32(4);
                        model.Group.PTName = reader.GetString(3);
                        list.Add(model);
                    }
                }
            }
            this.dataGridView1.DataSource = list;
        }

        private void 将内连接的数据绑定到DataGridView上_Load(object sender, EventArgs e)
        {
            //不要自动生成列
            this.dataGridView1.AutoGenerateColumns = false;
        }
        //设置单元格格式。拿到group对象，改成分组名称。
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            #region 小错误
            //if (e.ColumnIndex==3)   //判断是否为组后一个单元格（“分组”）
            //{
            //    //将“分组”这列显示为分组的名称
            //    DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];//获取最后一个单元格，cell.Value获取最后一个单元格中的值
            //    //判断当前行最后一个单元格中的值是否为null，以及是否是phonetype类型
            //    if (cell.Value !=null&&cell.Value is PhoneType)
            //    {
            //        //重新设置最后一个单元格中的值
            //        string str = (cell.Value as PhoneType).PTName;
            //        cell.ValueType=typeof(string);
            //        cell.Value = str;
            //    }
            //}
            #endregion
            if (e.Value !=null && e.Value is PhoneType && e.ColumnIndex==3)
            {
                e.Value = (e.Value as PhoneType).PTName;
            }
        }
    }
}