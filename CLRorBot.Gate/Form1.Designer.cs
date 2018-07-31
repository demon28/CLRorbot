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
            this.btn_pipei = new System.Windows.Forms.Button();
            this.btn_timer = new System.Windows.Forms.Button();
            this.tb_coincount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_clock = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1036, 288);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.btn_top15.Location = new System.Drawing.Point(26, 353);
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
            this.btn_user.Location = new System.Drawing.Point(26, 397);
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
            this.btn_sellAll.Location = new System.Drawing.Point(107, 397);
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
            this.btn_buy.Location = new System.Drawing.Point(107, 354);
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
            this.btn_clearorder.Location = new System.Drawing.Point(192, 397);
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
            this.btn_checkcoin.Location = new System.Drawing.Point(323, 354);
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
            this.btn_monitor.Location = new System.Drawing.Point(531, 353);
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
            this.btn_stopmonitor.Location = new System.Drawing.Point(531, 395);
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
            this.btn_queryorder.Location = new System.Drawing.Point(192, 354);
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
            this.tb_kuisun.Location = new System.Drawing.Point(956, 356);
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
            this.tb_yingli.Location = new System.Drawing.Point(1029, 356);
            this.tb_yingli.Name = "tb_yingli";
            this.tb_yingli.Size = new System.Drawing.Size(30, 21);
            this.tb_yingli.TabIndex = 14;
            this.tb_yingli.Text = "5";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(994, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "——";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1030, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "盈";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(964, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "亏";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Location = new System.Drawing.Point(323, 396);
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
            this.btn_delall.Location = new System.Drawing.Point(426, 396);
            this.btn_delall.Name = "btn_delall";
            this.btn_delall.Size = new System.Drawing.Size(75, 23);
            this.btn_delall.TabIndex = 19;
            this.btn_delall.Text = "清空数据库";
            this.btn_delall.UseVisualStyleBackColor = true;
            this.btn_delall.Click += new System.EventHandler(this.btn_delall_Click);
            // 
            // btn_pipei
            // 
            this.btn_pipei.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_pipei.Location = new System.Drawing.Point(426, 353);
            this.btn_pipei.Name = "btn_pipei";
            this.btn_pipei.Size = new System.Drawing.Size(75, 23);
            this.btn_pipei.TabIndex = 20;
            this.btn_pipei.Text = "匹配数据库";
            this.btn_pipei.UseVisualStyleBackColor = true;
            this.btn_pipei.Click += new System.EventHandler(this.btn_pipei_Click);
            // 
            // btn_timer
            // 
            this.btn_timer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_timer.Location = new System.Drawing.Point(956, 397);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(75, 23);
            this.btn_timer.TabIndex = 21;
            this.btn_timer.Text = "定时执行";
            this.btn_timer.UseVisualStyleBackColor = true;
            this.btn_timer.Click += new System.EventHandler(this.btn_timer_Click);
            // 
            // tb_coincount
            // 
            this.tb_coincount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tb_coincount.Location = new System.Drawing.Point(890, 356);
            this.tb_coincount.Name = "tb_coincount";
            this.tb_coincount.Size = new System.Drawing.Size(38, 21);
            this.tb_coincount.TabIndex = 22;
            this.tb_coincount.Text = "5";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(844, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "币数:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(844, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "整点:";
            // 
            // tb_clock
            // 
            this.tb_clock.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tb_clock.Location = new System.Drawing.Point(890, 397);
            this.tb_clock.Name = "tb_clock";
            this.tb_clock.Size = new System.Drawing.Size(38, 21);
            this.tb_clock.TabIndex = 24;
            this.tb_clock.Text = "9";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(626, 356);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 16);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Operate";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 443);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_clock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_coincount);
            this.Controls.Add(this.btn_timer);
            this.Controls.Add(this.btn_pipei);
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
        private System.Windows.Forms.Button btn_pipei;
        private System.Windows.Forms.Button btn_timer;
        private System.Windows.Forms.TextBox tb_coincount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_clock;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

