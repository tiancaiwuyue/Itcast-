using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itcast视频WinForm
{
    public partial class 资源管理 : Form
    {
        public 资源管理()
        {
            InitializeComponent();
        }

        private void 资源管理_Load(object sender, EventArgs e)
        {
            //1.把数据库中类别名称加到treeview根节点的位置。
            UpdateTreeView();
        }

        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
            LoadTreeViewData(-1, this.treeView1.Nodes);
        }

        private void LoadTreeViewData(int pid, TreeNodeCollection nodes)
        {
            //先根据父ID查询下面的数据
            List<TblFile> list = GetFilesByParentId(pid);
            //遍历list中的数据，把这些数据加载到treeNodeCollection节点集合中
            foreach (TblFile item in list)
            {
                TreeNode node = nodes.Add(item.Name);
                node.Tag = item.Id;
                //递归
                LoadTreeViewData(item.Id, node.Nodes);//节点下的节点
            }
        }

        private List<TblFile> GetFilesByParentId(int pid)
        {
            //集合不要返回null，返回一个长度为0的list，如果返回为对象，可以为null。
            List<TblFile> list = new List<TblFile>();
            string sql = "Select tid,tName,tNote from FileManager01 where tParentid=@pid";
            SqlParameter p1 = new SqlParameter("@pid", SqlDbType.Int) { Value = pid };
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, p1))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblFile model = new TblFile();
                        model.Id = reader.GetInt32(0);
                        model.Name = reader.GetString(1);
                        model.Note = reader.GetString(2);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //listBox1.Items.Clear();
            ////List<TblFile02> list = new List<TblFile02>();
            //TblFile02 model = new TblFile02();
            //string sql = "select did,dName,dContent,dintime,dEdittime,dIsDeleted from FileManager02 where dtid=@pid";
            //SqlParameter p1 = new SqlParameter("@pid", SqlDbType.Int) { Value = e.Node.Tag };
            //using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, p1))
            //{
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            TblFile02 model = new TblFile02();
            //            model.did = reader.GetInt32(0);
            //            model.dName = reader.GetString(1);
            //            model.dContent = reader.GetString(2);
            //            model.dintime = reader.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss");
            //            model.dEdittime = reader.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss");
            //            model.dIsDeleted = (byte)reader.GetInt32(5);
            //            listBox1.Items.Add(model);
            //        }
            //    }
            //}
            //listBox1.Items.AddRange(list.ToArray());
        }

        //选中标题改变事件
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //1.获取当前选中的项Id
            if (this.listBox1.SelectedItem != null)
            {
                //获取当前选中的文章的Id
                int did = (this.listBox1.SelectedItem as TblFile02).did;
                //根据Id查询对应的文章给内容，并显示到下面的文本框中
                this.textBox1.Text = GetContentByDid(did);
            }
        }

        //根据文章ID，获取文章的内容
        private string GetContentByDid(int did)
        {
            string sql = "select dContent from FileManager02 where did=@did";
            SqlParameter p1 = new SqlParameter("@did", SqlDbType.Int) { Value = did };
            object objContent = SQLHelper.ExecuteScalar(sql, p1);
            return objContent == null ? string.Empty : objContent.ToString();
        }

        //节点的鼠标双击事件，sender发生事件的控件，listbox
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //1.获取用户点击的是哪个节点
            int categoryId = (int)e.Node.Tag;
            //2.然后获取节点的id

            //3.查询指定Id下的所有的文章信息
            LoadContentInfoByCategoryId(categoryId);

        }

        //根据文章类别，查询下面的所有的文章信息
        private void LoadContentInfoByCategoryId(int categoryId)
        {
            listBox1.Items.Clear();
            string sql = "select did,dname from filemanager02 where dtid=@pid";
            SqlParameter p1 = new SqlParameter("@pid", SqlDbType.Int) { Value = categoryId };
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, p1))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblFile02 model = new TblFile02();
                        model.did = reader.GetInt32(0);
                        model.dName = reader.GetString(1);
                        listBox1.Items.Add(model);
                    }
                }
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断当前treeview是否又选中类别
            if (treeView1.SelectedNode != null)
            {
                //获取当前选中类别的categoryId
                int areaid = (int)treeView1.SelectedNode.Tag;
                Form5 frm = new Form5(areaid, UpdateTreeView);
                frm.Show();
            }
            else
            {
                MessageBox.Show("请选择类别!");
            }
        }

        //增加一个子类别
        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5(-1, UpdateTreeView);
            frm.Show();
        }

        //导入文章
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //1.判断用户是否选择了类别
            if (this.treeView1.SelectedNode != null)
            {
                //获取类别id
                int categoryId = (int)this.treeView1.SelectedNode.Tag;
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //执行导入文章
                    //获取用户选择的文章给的路径
                    string path = folderBrowserDialog1.SelectedPath;
                    //MessageBox.Show(path);
                    //获取该目录下的所有的文本文件
                    string[] txts = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                    //遍历读取每个记事本文件的名称和内容插入到数据库中
                    for (int i = 0; i < txts.Length; i++)
                    {
                        string txtPath = txts[i];
                        //文件名，文章标题
                        string title = Path.GetFileNameWithoutExtension(txtPath);
                        string content = File.ReadAllText(txtPath, Encoding.Default);
                        //把当前记录插入到数据库中
                        InsertIntoContentInfo(title, content, categoryId);
                        //刷新右边的ListBox
                        LoadContentInfoByCategoryId(categoryId);
                    }
                }
            }
            else
            {
                MessageBox.Show("没有选择类别");
            }
        }

        private void InsertIntoContentInfo(string title, string content, int categoryId)
        {
            string sql = "insert into FileManager02(dtid,dname,dcontent) values (@dtid,@name,@content)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@dtid",SqlDbType.Int){Value=categoryId},
                new SqlParameter("@name",SqlDbType.NVarChar,100){Value=title},
                new SqlParameter("@content",SqlDbType.NVarChar){Value=content}
            };
            SQLHelper.ExecuteNonQuery(sql, pms);
        }
    }
}
