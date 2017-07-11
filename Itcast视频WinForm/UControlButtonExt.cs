using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itcast视频WinForm
{
    public partial class UControlButtonExt : UserControl
    {
        public UControlButtonExt()
        {
            InitializeComponent();
        }
        int count = 0;
        //声明一个事件
        //声明事件与声明委托变量特变像，就是在声明委托变量的前面加了一个event关键字。
        //当加了event关键字以后，委托变量就变成了一个事件。
        public event Action TripleClick;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            if (count >= 3)
            {
                if (TripleClick != null)
                {
                    //事件在“触发”或“调用”的时候与委托变量的使用时候一摸一样
                    //MessageBox.Show("Clicked 3 times");
                    TripleClick();
                }
                count = 0;
            }
        }
    }
}
