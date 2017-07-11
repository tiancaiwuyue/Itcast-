using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.Data.SqlClient;

namespace Itcast视频WinForm
{
    public partial class 省市联动 : Form
    {
        public 省市联动()
        {
            InitializeComponent();
        }

        private void 省市联动_Load(object sender, EventArgs e)
        {
            //1.把所有的省份加载到combox1上
            LoadProvince();
        }

        private void LoadProvince()
        {
            //1.查询所有父ID为0的那些数据
            string sql = "select areaname,areaid from TblArea where areapid=@pid";
            SqlParameter p1 = new SqlParameter("@pid", SqlDbType.Int) { Value = 0 };
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, p1))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblArea model = new TblArea();
                        model.AreaID = reader.GetInt32(1);
                        model.AreaName = reader.GetString(0);
                        comboBox1.Items.Add(model);

                    }
                }
            }
        }
        //显示当前选中的省份的名称和ID
        private void button1_Click(object sender, EventArgs e)
        {
            //if (comboBox1.Text.Trim().Length > 0)
            //{
            //    comboBox1.SelectedItem
            //}
            if (comboBox1.SelectedItem != null)
            {
                TblArea model = comboBox1.SelectedItem as TblArea;
                MessageBox.Show(model.AreaName + "       " + model.AreaID);
            }
        }
        //选择项改变事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //1.获取当前用户选择的省份ID
            if (comboBox1.SelectedItem!=null)
            {
                TblArea model = comboBox1.SelectedItem as TblArea;
                int areaId = model.AreaID;

                //2.根据areaId从数据库中查询对应的id
                List<TblArea> cities = GetSubCity(areaId);

                //方式一：向下拉菜单中增加数据(需要加comboBox2.Items.Clear();命令)
                //foreach (TblArea item in cities)
                //{
                //    comboBox2.Items.Add(item);
                //}
                //方式二：通过数据绑定的方式向下拉菜单中增加项（不需要情况items）
                //建议绑定数据源的时候，先设置DisplayMember和ValueMember的值。先告诉下拉菜单，这样数据源一绑好就会立刻显示。
                //然后再设置DataSource数据源对象
                comboBox2.DisplayMember = "AreaName";//看见的是哪个
                comboBox2.ValueMember = "AreaID";//对应的Id是多少
                comboBox2.DataSource = cities;
            }
        }

        private List<TblArea> GetSubCity(int areaId)
        {
            List<TblArea> list = new List<TblArea>();
               string sql = "Select AreaID,AreaName from TblArea where AreaPId=@id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int) { Value = areaId };
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, p1))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblArea model = new TblArea();
                        model.AreaID = reader.GetInt32(0);
                        model.AreaName = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox2.Text+"     "+comboBox2.SelectedValue.ToString());
        }
    }
}
