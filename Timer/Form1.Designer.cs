namespace Timer
{
    partial class CheekyTimer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheekyTimer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Quit = new System.Windows.Forms.Button();
            this.RightInc = new System.Windows.Forms.Button();
            this.RightDec = new System.Windows.Forms.Button();
            this.LeftInc = new System.Windows.Forms.Button();
            this.LeftTime = new System.Windows.Forms.Label();
            this.RightTime = new System.Windows.Forms.Label();
            this.LeftDec = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tickTimer = new System.Windows.Forms.Timer(this.components);
            this.RootPanel = new System.Windows.Forms.Panel();
            this.blinkTimer = new System.Windows.Forms.Timer(this.components);
            this.timerBlinkTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.Quit, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightInc, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightDec, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.LeftInc, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.LeftTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightTime, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.LeftDec, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Timer, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Quit
            // 
            this.Quit.FlatAppearance.BorderSize = 0;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Quit.Location = new System.Drawing.Point(267, 3);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(14, 19);
            this.Quit.TabIndex = 13;
            this.Quit.Text = "X";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // RightInc
            // 
            this.RightInc.FlatAppearance.BorderSize = 0;
            this.RightInc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightInc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RightInc.Location = new System.Drawing.Point(143, 3);
            this.RightInc.Name = "RightInc";
            this.RightInc.Size = new System.Drawing.Size(14, 19);
            this.RightInc.TabIndex = 11;
            this.RightInc.Text = ">";
            this.RightInc.UseVisualStyleBackColor = true;
            this.RightInc.Click += new System.EventHandler(this.RightInc_Click);
            // 
            // RightDec
            // 
            this.RightDec.FlatAppearance.BorderSize = 0;
            this.RightDec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightDec.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RightDec.Location = new System.Drawing.Point(98, 3);
            this.RightDec.Name = "RightDec";
            this.RightDec.Size = new System.Drawing.Size(14, 19);
            this.RightDec.TabIndex = 10;
            this.RightDec.Text = "<";
            this.RightDec.UseVisualStyleBackColor = true;
            this.RightDec.Click += new System.EventHandler(this.RightDec_Click);
            // 
            // LeftInc
            // 
            this.LeftInc.BackColor = System.Drawing.Color.Transparent;
            this.LeftInc.FlatAppearance.BorderSize = 0;
            this.LeftInc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftInc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftInc.Location = new System.Drawing.Point(68, 3);
            this.LeftInc.Name = "LeftInc";
            this.LeftInc.Size = new System.Drawing.Size(14, 19);
            this.LeftInc.TabIndex = 8;
            this.LeftInc.Text = ">";
            this.LeftInc.UseVisualStyleBackColor = false;
            this.LeftInc.Click += new System.EventHandler(this.LeftInc_Click);
            // 
            // LeftTime
            // 
            this.LeftTime.AutoSize = true;
            this.LeftTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftTime.Location = new System.Drawing.Point(43, 0);
            this.LeftTime.Name = "LeftTime";
            this.LeftTime.Size = new System.Drawing.Size(19, 30);
            this.LeftTime.TabIndex = 0;
            this.LeftTime.Text = "20";
            this.LeftTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LeftTime.Click += new System.EventHandler(this.label1_Click);
            // 
            // RightTime
            // 
            this.RightTime.AutoSize = true;
            this.RightTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RightTime.Location = new System.Drawing.Point(118, 0);
            this.RightTime.Name = "RightTime";
            this.RightTime.Size = new System.Drawing.Size(19, 30);
            this.RightTime.TabIndex = 1;
            this.RightTime.Text = "5";
            this.RightTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RightTime.Click += new System.EventHandler(this.label2_Click);
            // 
            // LeftDec
            // 
            this.LeftDec.FlatAppearance.BorderSize = 0;
            this.LeftDec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftDec.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftDec.Location = new System.Drawing.Point(23, 3);
            this.LeftDec.Name = "LeftDec";
            this.LeftDec.Size = new System.Drawing.Size(14, 19);
            this.LeftDec.TabIndex = 7;
            this.LeftDec.Text = "<";
            this.LeftDec.UseVisualStyleBackColor = true;
            this.LeftDec.Click += new System.EventHandler(this.LeftDec_Click);
            // 
            // Timer
            // 
            this.Timer.BackColor = System.Drawing.Color.Transparent;
            this.Timer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Timer.Location = new System.Drawing.Point(165, 0);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(96, 30);
            this.Timer.TabIndex = 1;
            this.Timer.Text = "00:00";
            this.Timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Timer.Click += new System.EventHandler(this.Timer_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(14, 24);
            this.flowLayoutPanel1.TabIndex = 14;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheekyTimer_MouseDown);
            // 
            // tickTimer
            // 
            this.tickTimer.Interval = 1000;
            this.tickTimer.Tick += new System.EventHandler(this.tickTimer_Tick);
            // 
            // RootPanel
            // 
            this.RootPanel.BackColor = System.Drawing.Color.Black;
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Size = new System.Drawing.Size(284, 30);
            this.RootPanel.TabIndex = 2;
            this.RootPanel.Click += new System.EventHandler(this.Timer_Click);
            // 
            // blinkTimer
            // 
            this.blinkTimer.Interval = 250;
            this.blinkTimer.Tick += new System.EventHandler(this.blinkTimer_Tick);
            // 
            // timerBlinkTimer
            // 
            this.timerBlinkTimer.Interval = 500;
            this.timerBlinkTimer.Tick += new System.EventHandler(this.timerBlinkTimer_Tick);
            // 
            // CheekyTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(284, 30);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.RootPanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(284, 30);
            this.Name = "CheekyTimer";
            this.Load += new System.EventHandler(this.CheekyTimer_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheekyTimer_MouseDown);
            this.Move += new System.EventHandler(this.CheekyTimer_Move);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Timer tickTimer;
        private System.Windows.Forms.Label LeftTime;
        private System.Windows.Forms.Label RightTime;
        private System.Windows.Forms.Panel RootPanel;
        private System.Windows.Forms.Button LeftDec;
        private System.Windows.Forms.Button RightInc;
        private System.Windows.Forms.Button RightDec;
        private System.Windows.Forms.Button LeftInc;
        private System.Windows.Forms.Timer blinkTimer;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timerBlinkTimer;
    }
}

