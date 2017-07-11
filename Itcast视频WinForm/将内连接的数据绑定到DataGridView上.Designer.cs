namespace Itcast视频WinForm
{
    partial class 将内连接的数据绑定到DataGridView上
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCellPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColName,
            this.ColCellPhone,
            this.ColGroup});
            this.dataGridView1.Location = new System.Drawing.Point(93, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(1113, 574);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 706);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "PID";
            this.ColID.HeaderText = "联系人ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "PName";
            this.ColName.HeaderText = "姓名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColCellPhone
            // 
            this.ColCellPhone.DataPropertyName = "PCellPhone";
            this.ColCellPhone.HeaderText = "手机号";
            this.ColCellPhone.Name = "ColCellPhone";
            this.ColCellPhone.ReadOnly = true;
            // 
            // ColGroup
            // 
            this.ColGroup.DataPropertyName = "Group";
            this.ColGroup.HeaderText = "分组";
            this.ColGroup.Name = "ColGroup";
            this.ColGroup.ReadOnly = true;
            // 
            // 将内连接的数据绑定到DataGridView上
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 792);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "将内连接的数据绑定到DataGridView上";
            this.Text = "将内连接的数据绑定到DataGridView上";
            this.Load += new System.EventHandler(this.将内连接的数据绑定到DataGridView上_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCellPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGroup;
    }
}