namespace SRTN
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgv_process = new System.Windows.Forms.DataGridView();
            this.process_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_arrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_burst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_wait = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_wait_ave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_finish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_process)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượng tiến trình";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox1.Location = new System.Drawing.Point(150, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Chọn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(609, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Chạy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // dgv_process
            // 
            this.dgv_process.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_process.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_process.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.process_id,
            this.time_arrival,
            this.time_burst,
            this.time_wait,
            this.time_wait_ave,
            this.time_finish});
            this.dgv_process.Location = new System.Drawing.Point(41, 90);
            this.dgv_process.Name = "dgv_process";
            this.dgv_process.Size = new System.Drawing.Size(643, 348);
            this.dgv_process.TabIndex = 3;
            // 
            // process_id
            // 
            this.process_id.HeaderText = "Mã tiến trình";
            this.process_id.Name = "process_id";
            // 
            // time_arrival
            // 
            this.time_arrival.HeaderText = "Thời gian đến";
            this.time_arrival.Name = "time_arrival";
            // 
            // time_burst
            // 
            this.time_burst.HeaderText = "Thời gian thực thi";
            this.time_burst.Name = "time_burst";
            // 
            // time_wait
            // 
            this.time_wait.HeaderText = "Thời gian chờ";
            this.time_wait.Name = "time_wait";
            // 
            // time_wait_ave
            // 
            this.time_wait_ave.HeaderText = "Thời gian chờ trung bình";
            this.time_wait_ave.Name = "time_wait_ave";
            // 
            // time_finish
            // 
            this.time_finish.HeaderText = "Thời gian hoàn thành";
            this.time_finish.Name = "time_finish";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 450);
            this.Controls.Add(this.dgv_process);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_process)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgv_process;
        private System.Windows.Forms.DataGridViewTextBoxColumn process_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_arrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_burst;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_wait;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_wait_ave;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_finish;
    }
}

