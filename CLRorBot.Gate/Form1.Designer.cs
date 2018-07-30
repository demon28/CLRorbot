namespace CLRorBot.Gate
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_top15 = new System.Windows.Forms.Button();
            this.btn_user = new System.Windows.Forms.Button();
            this.btn_sellAll = new System.Windows.Forms.Button();
            this.btn_buy = new System.Windows.Forms.Button();
            this.btn_clearorder = new System.Windows.Forms.Button();
            this.btn_checkcoin = new System.Windows.Forms.Button();
            this.btn_monitor = new System.Windows.Forms.Button();
            this.btn_stopmonitor = new System.Windows.Forms.Button();
            this.btn_queryorder = new System.Windows.Forms.Button();
            this.tb_kuisun = new System.Windows.Forms.TextBox();
            this.tb_yingli = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(898, 256);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据窗口：";
            // 
            // btn_top15
            // 
            this.btn_top15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_top15.Location = new System.Drawing.Point(27, 313);
            this.btn_top15.Name = "btn_top15";
            this.btn_top15.Size = new System.Drawing.Size(75, 23);
            this.btn_top15.TabIndex = 3;
            this.btn_top15.Text = "涨幅查询";
            this.btn_top15.UseVisualStyleBackColor = true;
            this.btn_top15.Click += new System.EventHandler(this.btn_top15_ClickAsync);
            // 
            // btn_user
            // 
            this.btn_user.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_user.Location = new System.Drawing.Point(27, 362);
            this.btn_user.Name = "btn_user";
            this.btn_user.Size = new System.Drawing.Size(75, 23);
            this.btn_user.TabIndex = 4;
            this.btn_user.Text = "账户查询";
            this.btn_user.UseVisualStyleBackColor = true;
            this.btn_user.Click += new System.EventHandler(this.btn_user_Click);
            // 
            // btn_sellAll
            // 
            this.btn_sellAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_sellAll.Location = new System.Drawing.Point(243, 362);
            this.btn_sellAll.Name = "btn_sellAll";
            this.btn_sellAll.Size = new System.Drawing.Size(75, 23);
            this.btn_sellAll.TabIndex = 5;
            this.btn_sellAll.Text = "一键卖币";
            this.btn_sellAll.UseVisualStyleBackColor = true;
            this.btn_sellAll.Click += new System.EventHandler(this.btn_sellAll_Click);
            // 
            // btn_buy
            // 
            this.btn_buy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_buy.Location = new System.Drawing.Point(131, 362);
            this.btn_buy.Name = "btn_buy";
            this.btn_buy.Size = new System.Drawing.Size(75, 23);
            this.btn_buy.TabIndex = 6;
            this.btn_buy.Text = "一键买币";
            this.btn_buy.UseVisualStyleBackColor = true;
            this.btn_buy.Click += new System.EventHandler(this.btn_buyAll_Click);
            // 
            // btn_clearorder
            // 
            this.btn_clearorder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_clearorder.Location = new System.Drawing.Point(243, 314);
            this.btn_clearorder.Name = "btn_clearorder";
            this.btn_clearorder.Size = new System.Drawing.Size(75, 23);
            this.btn_clearorder.TabIndex = 7;
            this.btn_clearorder.Text = "清空挂单";
            this.btn_clearorder.UseVisualStyleBackColor = true;
            this.btn_clearorder.Click += new System.EventHandler(this.btn_clearorder_Click);
            // 
            // btn_checkcoin
            // 
            this.btn_checkcoin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_checkcoin.Location = new System.Drawing.Point(359, 362);
            this.btn_checkcoin.Name = "btn_checkcoin";
            this.btn_checkcoin.Size = new System.Drawing.Size(75, 23);
            this.btn_checkcoin.TabIndex = 8;
            this.btn_checkcoin.Text = "查看持币";
            this.btn_checkcoin.UseVisualStyleBackColor = true;
            this.btn_checkcoin.Click += new System.EventHandler(this.btn_checkcoin_Click);
            // 
            // btn_monitor
            // 
            this.btn_monitor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_monitor.Location = new System.Drawing.Point(471, 362);
            this.btn_monitor.Name = "btn_monitor";
            this.btn_monitor.Size = new System.Drawing.Size(75, 23);
            this.btn_monitor.TabIndex = 10;
            this.btn_monitor.Text = "监控盈亏";
            this.btn_monitor.UseVisualStyleBackColor = true;
            this.btn_monitor.Click += new System.EventHandler(this.btn_monitor_Click);
            // 
            // btn_stopmonitor
            // 
            this.btn_stopmonitor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_stopmonitor.Location = new System.Drawing.Point(581, 362);
            this.btn_stopmonitor.Name = "btn_stopmonitor";
            this.btn_stopmonitor.Size = new System.Drawing.Size(75, 23);
            this.btn_stopmonitor.TabIndex = 11;
            this.btn_stopmonitor.Text = "停止监控";
            this.btn_stopmonitor.UseVisualStyleBackColor = true;
            this.btn_stopmonitor.Click += new System.EventHandler(this.btn_stopmonitor_Click);
            // 
            // btn_queryorder
            // 
            this.btn_queryorder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_queryorder.Location = new System.Drawing.Point(131, 313);
            this.btn_queryorder.Name = "btn_queryorder";
            this.btn_queryorder.Size = new System.Drawing.Size(75, 23);
            this.btn_queryorder.TabIndex = 12;
            this.btn_queryorder.Text = "查看挂单";
            this.btn_queryorder.UseVisualStyleBackColor = true;
            this.btn_queryorder.Click += new System.EventHandler(this.btn_queryorder_Click);
            // 
            // tb_kuisun
            // 
            this.tb_kuisun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tb_kuisun.BackColor = System.Drawing.SystemColors.Control;
            this.tb_kuisun.ForeColor = System.Drawing.Color.Green;
            this.tb_kuisun.Location = new System.Drawing.Point(814, 365);
            this.tb_kuisun.Name = "tb_kuisun";
            this.tb_kuisun.Size = new System.Drawing.Size(32, 21);
            this.tb_kuisun.TabIndex = 13;
            this.tb_kuisun.Text = "-2";
            // 
            // tb_yingli
            // 
            this.tb_yingli.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tb_yingli.BackColor = System.Drawing.SystemColors.Control;
            this.tb_yingli.ForeColor = System.Drawing.Color.Red;
            this.tb_yingli.Location = new System.Drawing.Point(887, 365);
            this.tb_yingli.Name = "tb_yingli";
            this.tb_yingli.Size = new System.Drawing.Size(30, 21);
            this.tb_yingli.TabIndex = 14;
            this.tb_yingli.Text = "5";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(852, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "——";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(888, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "盈";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(822, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "亏";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Location = new System.Drawing.Point(684, 314);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 18;
            this.btn_add.Text = "手工添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delall
            // 
            this.btn_delall.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_delall.Location = new System.Drawing.Point(684, 362);
            this.btn_delall.Name = "btn_delall";
            this.btn_delall.Size = new System.Drawing.Size(75, 23);
            this.btn_delall.TabIndex = 19;
            this.btn_delall.Text = "清空数据库";
            this.btn_delall.UseVisualStyleBackColor = true;
            this.btn_delall.Click += new System.EventHandler(this.btn_delall_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 432);
            this.Controls.Add(this.btn_delall);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_yingli);
            this.Controls.Add(this.tb_kuisun);
            this.Controls.Add(this.btn_queryorder);
            this.Controls.Add(this.btn_stopmonitor);
            this.Controls.Add(this.btn_monitor);
            this.Controls.Add(this.btn_checkcoin);
            this.Controls.Add(this.btn_clearorder);
            this.Controls.Add(this.btn_buy);
            this.Controls.Add(this.btn_sellAll);
            this.Controls.Add(this.btn_user);
            this.Controls.Add(this.btn_top15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RorBot  V1.2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_top15;
        private System.Windows.Forms.Button btn_user;
        private System.Windows.Forms.Button btn_sellAll;
        private System.Windows.Forms.Button btn_buy;
        private System.Windows.Forms.Button btn_clearorder;
        private System.Windows.Forms.Button btn_checkcoin;
        private System.Windows.Forms.Button btn_monitor;
        private System.Windows.Forms.Button btn_stopmonitor;
        private System.Windows.Forms.Button btn_queryorder;
        private System.Windows.Forms.TextBox tb_kuisun;
        private System.Windows.Forms.TextBox tb_yingli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delall;
    }
}

