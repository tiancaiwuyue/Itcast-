using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace Buffet店
{

    public partial class Form1 : Form
    {
        Adult ad;
        Child ch3;
        Child ch6;
        Child ch8;
        ElderPeople ep;
        PublicOfficer po;
        Others ot;
        Drink dr;
        Table ta;
        SpecialDrink Budweiser;
        SpecialDrink BudLight;
        SpecialDrink MillerLite;
        SpecialDrink CoorsLight;
        SpecialDrink Michelob;
        SpecialDrink Tsingtao;
        SpecialDrink Heineken;
        SpecialDrink Sapporo;
        SpecialDrink Corona;
        SpecialDrink TenHigh;
        SpecialDrink Oolong;
        SpecialDrink OrangeJuice;
        SpecialDrink AppleJuice;
        SpecialDrink Milk;
        SpecialDrink Charonna;
        SpecialDrink Zinfandel;
        SpecialDrink Merlot;
        SpecialDrink PlumWine;
        SpecialDrink Sake;

        StringReader lineReader = null;
        PrintDocument printDocument;
        PrintDocument printDocumentTotal;
        int totalNumber = 1;
        // TextBox textFoucs;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 10; i <= 19; i++)
            {
                StaticMethods.SetButton(button13);
                StaticMethods.SetButton(button10);
                StaticMethods.SetButton(button11);
                StaticMethods.SetButton(button12);
                StaticMethods.SetButton(button14);
                StaticMethods.SetButton(button15);
                StaticMethods.SetButton(button16);
                StaticMethods.SetButton(button17);
                StaticMethods.SetButton(button18);
                StaticMethods.SetButton(button19);
                StaticMethods.SetButton(button20);
            }
            DinnerLunchPrice.LoadPrice();
            printDocument = new PrintDocument();
            printDocumentTotal = new PrintDocument();

            printDocument.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocumentTotal.PrintPage += new PrintPageEventHandler(printDocument2_PrintPage);
            ad = new Adult();
            ch3 = new Child(3);
            ch6 = new Child(6);
            ch8 = new Child(8);
            ep = new ElderPeople();
            po = new PublicOfficer();
            ot = new Others();
            dr = new Drink();
            ta = new Table();
            Budweiser = new SpecialDrink("Budweiser");
            BudLight = new SpecialDrink("BudLight");
            MillerLite = new SpecialDrink("MillerLite");
            CoorsLight = new SpecialDrink("CoorsLight");
            Michelob = new SpecialDrink("Michelob");
            Tsingtao = new SpecialDrink("Tsingtao");
            Heineken = new SpecialDrink("Heineken");
            Sapporo = new SpecialDrink("Sapporo");
            Corona = new SpecialDrink("Corona");
            TenHigh = new SpecialDrink("TenHigh");
            Oolong = new SpecialDrink("Oolong");
            OrangeJuice = new SpecialDrink("OrangeJuice");
            AppleJuice = new SpecialDrink("AppleJuice");
            Milk = new SpecialDrink("BMilk");
            Charonna = new SpecialDrink("Charonna");
            Zinfandel = new SpecialDrink("Zinfandel");
            Merlot = new SpecialDrink("Merlot");
            PlumWine = new SpecialDrink("PlumWine");
            Sake = new SpecialDrink("Sake");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSeat.Text.Length >= 5)
            {
                txtSeat.Text = "0";
            }
            else
            {
                txtSeat.Text = (int.Parse(txtSeat.Text) + 1).ToString();
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (txtAdultCount.Text.Length >= 5)
            {
                txtAdultCount.Text = "0";
            }
            else
            {
                txtAdultCount.Text = (int.Parse(txtAdultCount.Text) + 1).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtSeat.Text.Length >= 5 || int.Parse(txtSeat.Text) == 0)
            {
                txtSeat.Text = "0";
            }
            else
            {
                txtSeat.Text = (int.Parse(txtSeat.Text) - 1).ToString();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (txtAdultCount.Text.Length >= 5 || int.Parse(txtAdultCount.Text) == 0)
            {
                txtAdultCount.Text = "0";
            }
            else
            {
                txtAdultCount.Text = (int.Parse(txtAdultCount.Text) - 1).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Dinner")
            {
                tableLayoutPanel1.BackColor = Color.CornflowerBlue;
                button2.Text = "Lunch";
            }
            else
            {
                tableLayoutPanel1.BackColor = Color.Salmon;
                button2.Text = "Dinner";
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (txtDrinkCount.Text.Length >= 5 || int.Parse(txtDrinkCount.Text) == 0)
            {
                txtDrinkCount.Text = "0";
            }
            else
            {
                txtDrinkCount.Text = (int.Parse(txtDrinkCount.Text) - 1).ToString();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (txtDrinkCount.Text.Length >= 5)
            {
                txtDrinkCount.Text = "0";
            }
            else
            {
                txtDrinkCount.Text = (int.Parse(txtDrinkCount.Text) + 1).ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtArea.Text = "A";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtArea.Text = "B";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtArea.Text = "C";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtArea.Text = "D";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SendKeys.Send("1");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SendKeys.Send("2");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SendKeys.Send("3");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SendKeys.Send("4");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SendKeys.Send("5");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SendKeys.Send("6");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SendKeys.Send("7");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SendKeys.Send("8");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SendKeys.Send("9");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SendKeys.Send("0");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SendKeys.Send("\b");
        }

        private void button57_Click(object sender, EventArgs e)
        {
            txtArea.Text = "E";
        }

        private void button58_Click(object sender, EventArgs e)
        {
            txtArea.Text = "F";
        }


        private void 全部清空_Click(object sender, EventArgs e)
        {
            //txtArea.Text = "A";
            //txtSeat.Text = "0";
            //txtAdultCount.Text = "0";
            //txtDrinkCount.Text = "0";
            ad.Count = 0;
            dr.Count = 0;
            ch3.Count = 0;
            ch6.Count = 0;
            ch8.Count = 0;
            po.Count = 0;
            ep.Count = 0;
            ot.Count = 0;
            Budweiser.Count = 0;
            BudLight.Count = 0;
            MillerLite.Count = 0;
            CoorsLight.Count = 0;
            Michelob.Count = 0;
            Tsingtao.Count = 0;
            Heineken.Count = 0;
            Sapporo.Count = 0;
            Corona.Count = 0;
            TenHigh.Count = 0;
            Oolong.Count = 0;
            OrangeJuice.Count = 0;
            AppleJuice.Count = 0;
            Milk.Count = 0;
            Charonna.Count = 0;
            Zinfandel.Count = 0;
            Merlot.Count = 0;
            PlumWine.Count = 0;
            Sake.Count = 0;

            lstSubTotal.Items.Clear();
        }

        #region 单子变化/Purchase changed
        private void txtAdultCount_TextChanged(object sender, EventArgs e)
        {
            if (txtAdultCount.Text == null)
            {
                txtAdultCount.Text = "0";
            }
            int i = ad.Count;
            double j = ad.Count * ad.Price;
            try
            { ad.Count = int.Parse(txtAdultCount.Text); }
            catch
            {
                txtAdultCount.Text = "0";
            }
            StaticMethods.ChangeItem(lstSubTotal, ad);
        }

        private void txtDrinkCount_TextChanged(object sender, EventArgs e)
        {
            int i = dr.Count;
            double j = dr.Count * dr.Price;

            try
            {
                dr.Count = int.Parse(txtDrinkCount.Text);
            }
            catch
            {
                txtDrinkCount.Text = "0";
            }

            StaticMethods.ChangeItem(lstSubTotal, dr);
        }
        #endregion
        #region 座位号/区号变化
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string i = ta.alph + ta.number;
            ta.alph = txtArea.Text;
            ta.number = int.Parse(txtSeat.Text);
            string j = ta.alph + ta.number;
            StaticMethods.ChangeItem(lstSubTotal, "Table", i, j);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string i = ta.alph + ta.number;
            ta.alph = txtArea.Text;
            try
            {
                ta.number = int.Parse(txtSeat.Text);
            }
            catch
            {
                txtSeat.Text = "0";
            }
            string j = ta.alph + ta.number;
            StaticMethods.ChangeItem(lstSubTotal, "Table", i, j);
        }
        #endregion
        #region 打印/Print
        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            //添加文件到打印模板对话框中
            //printDocument.PrinterSettings.PrinterName="";
            //lineReader = new StringReader(txtSeat.Text);
            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            try
            {
                printDocument.Print();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
            }

            lstTotal.Items.Add(string.Concat(new object[] { totalNumber.ToString().PadRight(4), lstSubTotal.Items[0].ToString().Substring(18).PadRight(4),"$", lstSubTotal.Items[lstSubTotal.Items.Count - 1].ToString().Substring(18).PadRight(7), DateTime.Now.ToString("HH:mm:ss") }));
            totalNumber++;
            lstTotal.SelectedIndex = lstTotal.Items.Count - 1;
            lstTotal.Focus();
            //}
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (lstSubTotal.Items.Count != 0)
            {
                Graphics graphics = e.Graphics;
                Font printFont = new Font("Courier New", 12f);
                float height = printFont.GetHeight();
                float heighthalf = height / 2;
                float x = 67, y = 0;
                SolidBrush brush = new SolidBrush(Color.Black);
                string str = "BeyondMenu";
                graphics.DrawString(str, printFont, new SolidBrush(Color.Black), x, y);
                y += heighthalf;
                x = 0;
                graphics.DrawString("------------------------", printFont, brush, x, y);
                y += heighthalf;
                graphics.DrawString(lstSubTotal.Items[0].ToString(), printFont, brush, x, y);
                y += heighthalf;
                graphics.DrawString("------------------------", printFont, brush, x, y);
                y += height;
                for (int i = 1; i < lstSubTotal.Items.Count; i++)
                {
                    graphics.DrawString(lstSubTotal.Items[i].ToString(), printFont, brush, x, y);
                    y += height;
                }
                graphics.DrawString("------------------------", printFont, brush, x, y);
                y += heighthalf;
                graphics.DrawString("Time of order: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), new Font("Courier New", 8f), brush, x, y);
            }
        }
        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (lstTotal.Items.Count != 0)
            {
                Graphics graphics = e.Graphics;
                Font printFont = new Font("Courier New", 12f);
                float height = printFont.GetHeight();
                float heighthalf = height / 2;
                float x = 67, y = 0;
                SolidBrush brush = new SolidBrush(Color.Black);
                string str = "BeyondMenu";
                graphics.DrawString(str, printFont, new SolidBrush(Color.Black), x, y);
                y += heighthalf;
                x = 0;
                graphics.DrawString("------------------------", printFont, brush, x, y);
                y += heighthalf;
                graphics.DrawString(lstTotal.Items[0].ToString(), printFont, brush, x, y);
                //y += heighthalf;
                //graphics.DrawString("------------------------", printFont, brush, x, y);
                y += height;
                for (int i = 1; i < lstTotal.Items.Count; i++)
                {
                    graphics.DrawString(lstTotal.Items[i].ToString(), printFont, brush, x, y);
                    y += height;
                }
                graphics.DrawString("------------------------", printFont, brush, x, y);
                y += heighthalf;
                graphics.DrawString("Time of print: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), new Font("Courier New", 8f), brush, x, y);
            }
        }

        private void 打印设置_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            printDialog.ShowDialog();
        }

        private void 页面设置_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.Document = printDocument;
            pageSetupDialog.ShowDialog();
        }

        private void 打印预览_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            lineReader = new StringReader(txtSeat.Text);
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 取打印图_Click(object sender, EventArgs e)
        {
            PreviewPrintController previewController = new PreviewPrintController();
            // previewController.UseAntiAlias = true;
            printDocument.PrintController = previewController;//赋值后，为打印预览模式，printDocument.Print() 不执行打印操作，执行预览操作
            printDocument.Print();
            PreviewPageInfo[] pageInfo = previewController.GetPreviewPageInfo();
            if (pageInfo != null && pageInfo.Length > 0)
            {
                Image image = pageInfo[0].Image;
                Size s = pageInfo[0].PhysicalSize;
                Bitmap bitmap = new Bitmap(image, 620, s.Height);

                this.pictureBox1.BackColor = Color.White;
                this.pictureBox1.Image = (Image)bitmap;
            }
            StandardPrintController printController = new StandardPrintController();
            printDocument.PrintController = printController;
        }
        #endregion
        #region 特殊价格人群
        private void 小孩3岁_Click(object sender, EventArgs e)
        {
            ch3.Count++;
            StaticMethods.ChangeItem(lstSubTotal, ch3);
        }
        private void 小孩6岁_Click(object sender, EventArgs e)
        {
            ch6.Count++;
            StaticMethods.ChangeItem(lstSubTotal, ch6);
        }

        private void 小孩8岁_Click(object sender, EventArgs e)
        {
            ch8.Count++;
            StaticMethods.ChangeItem(lstSubTotal, ch8);
        }

        private void btnPublicOfficer_Click(object sender, EventArgs e)
        {
            po.Count++;
            StaticMethods.ChangeItem(lstSubTotal, po);
        }
        private void btnElderlyPeople_Click(object sender, EventArgs e)
        {
            ep.Count++;
            StaticMethods.ChangeItem(lstSubTotal, ep);
        }

        private void btnOthers_Click(object sender, EventArgs e)
        {
            ot.Count++;
            StaticMethods.ChangeItem(lstSubTotal, ot);
        }


        private void addItemToSublist(SinglePriceInterface obj)
        {
            obj.Count++;
            StaticMethods.ChangeItem(lstSubTotal, obj);
        }
        #endregion
        #region 翻译/Translation
        private void btnSwitchLanguage_Click(object sender, EventArgs e)
        {
            if (btnSwitchLanguage.Text == "English")
            {
                btnSwitchLanguage.Text = "中文";
                btn3YearOldChild.Text = "3-5 Year Old Child";
                btn6YearOldChild.Text = "6-7 Year Old Child";
                btn8YearOldChild.Text = "8-9 Year Old Child";
                btnPublicOfficer.Text = "Public Officer";
                btnElderlyPeople.Text = "Elderly People";
                btnOthers.Text = "Others";
                lblArea.Text = "Area";
                lblSeat.Text = "Seats";
                lblAdultsCount.Text = "Adults";
                lblNumberOfDrink.Text = "Drink";
                btnDeleteSelected.Text = "Delete Slected";
                btnPrintTotal.Text = "Print Total";
                btnPrintOrder.Text = "Print Order";
                btnReprintOrder.Text = "Reprint Order";
            }
            else
            {
                btnSwitchLanguage.Text = "English";
                btn3YearOldChild.Text = "小孩3-5岁";
                btn6YearOldChild.Text = "小孩6-7岁";
                btn8YearOldChild.Text = "小孩8-9岁";
                btnPublicOfficer.Text = "公职人员";
                btnElderlyPeople.Text = "老年人";
                btnOthers.Text = "其他";
                lblArea.Text = "区域";
                lblSeat.Text = "座位";
                lblAdultsCount.Text = "人数";
                lblNumberOfDrink.Text = "饮料";
            }
        }


        #endregion

        private void btnBudweiser_Click(object sender, EventArgs e)
        {
            addItemToSublist(Budweiser);
        }

        private void btnBudLight_Click(object sender, EventArgs e)
        {
            addItemToSublist(BudLight);
        }

        private void btnMillerLite_Click(object sender, EventArgs e)
        {
            addItemToSublist(MillerLite);
        }

        private void btnCoorsLight_Click(object sender, EventArgs e)
        {
            addItemToSublist(CoorsLight);
        }

        private void btnMichelob_Click(object sender, EventArgs e)
        {
            addItemToSublist(Michelob);
        }

        private void btnTsingtao_Click(object sender, EventArgs e)
        {
            addItemToSublist(Tsingtao);
        }

        private void btnHeineken_Click(object sender, EventArgs e)
        {
            addItemToSublist(Heineken);
        }

        private void btnSapporo_Click(object sender, EventArgs e)
        {
            addItemToSublist(Sapporo);
        }

        private void btnCorona_Click(object sender, EventArgs e)
        {
            addItemToSublist(Corona);
        }

        private void btnTenHigh_Click(object sender, EventArgs e)
        {
            addItemToSublist(TenHigh);
        }

        private void btnOolong_Click(object sender, EventArgs e)
        {
            addItemToSublist(Oolong);
        }

        private void btnOrangeJuice_Click(object sender, EventArgs e)
        {
            addItemToSublist(OrangeJuice);
        }

        private void btnAppleJuice_Click(object sender, EventArgs e)
        {
            addItemToSublist(AppleJuice);
        }

        private void btnMilk_Click(object sender, EventArgs e)
        {
            addItemToSublist(Milk);
        }

        private void btnCharonna_Click(object sender, EventArgs e)
        {
            addItemToSublist(Charonna);
        }

        private void btnZinfandel_Click(object sender, EventArgs e)
        {
            addItemToSublist(Zinfandel);
        }

        private void btnSake_Click(object sender, EventArgs e)
        {
            addItemToSublist(Sake);
        }

        private void btnMerlot_Click(object sender, EventArgs e)
        {
            addItemToSublist(Merlot);
        }

        private void btnPlumWine_Click(object sender, EventArgs e)
        {
            addItemToSublist(PlumWine);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button59_Click(object sender, EventArgs e)
        {
            lstTotal.Items.Remove(lstTotal.SelectedItem);
        }

        private void btnPrintTotal_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocumentTotal;
            //添加文件到打印模板对话框中
            //printDocument.PrinterSettings.PrinterName="";
            //lineReader = new StringReader(txtSeat.Text);
            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            try
            {
                printDocumentTotal.Print();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                printDocumentTotal.PrintController.OnEndPrint(printDocumentTotal, new PrintEventArgs());
            }
        }
    }

}

