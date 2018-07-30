namespace CLRorBot.Gate
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btn_add = new System.Windows.Forms.Button();
            this.lable1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_cointype = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_price = new System.Windows.Forms.TextBox();
            this.tb_count = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(81, 230);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(136, 33);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "添 加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(29, 61);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(53, 12);
            this.lable1.TabIndex = 1;
            this.lable1.Text = "交易对：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "成交价：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "成交量：";
            // 
            // tb_cointype
            // 
            this.tb_cointype.Location = new System.Drawing.Point(81, 58);
            this.tb_cointype.Name = "tb_cointype";
            this.tb_cointype.Size = new System.Drawing.Size(138, 21);
            this.tb_cointype.TabIndex = 4;
            this.tb_cointype.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "(例如：BTC_USDT)";
            // 
            // tb_price
            // 
            this.tb_price.Location = new System.Drawing.Point(81, 106);
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(138, 21);
            this.tb_price.TabIndex = 6;
            this.tb_price.Text = "0";
            // 
            // tb_count
            // 
            this.tb_count.Location = new System.Drawing.Point(81, 150);
            this.tb_count.Name = "tb_count";
            this.tb_count.Size = new System.Drawing.Size(138, 21);
            this.tb_count.TabIndex = 7;
            this.tb_count.Text = "0";
            this.tb_count.TextChanged += new System.EventHandler(this.tb_count_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "总金额：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "0";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 318);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_count);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_cointype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.btn_add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLRobor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_cointype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_price;
        private System.Windows.Forms.TextBox tb_count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}