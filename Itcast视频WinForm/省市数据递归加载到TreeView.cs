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
    public partial class 省市数据递归加载到TreeView : Form
    {
        public 省市数据递归加载到TreeView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAreasToTree(0, this.treeView1.Nodes);
        }

        //将指定的Id下的节点加到Nodes集合中
        private void LoadAreasToTree(int pid, TreeNodeCollection nodes)
        {
            //1.根据pid查询下面的所有子城市
            List<TblArea> list = GetAreaByParentId(pid);
            //2.把这些城市加载到TreeView中
            //遍历list集合，把数据加载到treeNodeCollection中
            foreach (TblArea item in list)
            {
                TreeNode node = nodes.Add(item.AreaName);
                node.Tag = item.AreaID;
                //下面这句话实现了递归
                LoadAreasToTree(item.AreaID, node.Nodes);
            }
        }

        private List<TblArea> GetAreaByParentId(int pid)
        {
            List<TblArea> list = new List<TblArea>();
            string sql = "Select AreaID,AreaName from TblArea where AreaPId=@id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int) { Value = pid };
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
    }
}
