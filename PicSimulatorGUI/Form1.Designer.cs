
namespace PicSimulatorGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Eprom = new System.Windows.Forms.DataGridView();
            this.loadFile = new System.Windows.Forms.Button();
            this.PA = new System.Windows.Forms.DataGridView();
            this.PB = new System.Windows.Forms.DataGridView();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.codeView = new System.Windows.Forms.DataGridView();
            this.Breakkpoints = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_StepForward = new System.Windows.Forms.Button();
            this.spezialRegister = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridView();
            this.optionReg = new System.Windows.Forms.DataGridView();
            this.label_tmr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.intcon = new System.Windows.Forms.DataGridView();
            this.cb_watchdog = new System.Windows.Forms.CheckBox();
            this.lbl_wdtimer = new System.Windows.Forms.Label();
            this.tb_quartz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Eprom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spezialRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Eprom
            // 
            this.Eprom.AccessibleName = "Eprom";
            this.Eprom.AllowUserToAddRows = false;
            this.Eprom.AllowUserToDeleteRows = false;
            this.Eprom.AllowUserToResizeColumns = false;
            this.Eprom.AllowUserToResizeRows = false;
            this.Eprom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Eprom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Eprom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Eprom.Location = new System.Drawing.Point(998, 30);
            this.Eprom.Name = "Eprom";
            this.Eprom.RowHeadersVisible = false;
            this.Eprom.RowHeadersWidth = 15;
            this.Eprom.RowTemplate.Height = 25;
            this.Eprom.Size = new System.Drawing.Size(252, 600);
            this.Eprom.TabIndex = 0;
            this.Eprom.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Eprom_CellBeginEdit);
            this.Eprom.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Eprom_CellValueChanged);
            // 
            // loadFile
            // 
            this.loadFile.Location = new System.Drawing.Point(223, 487);
            this.loadFile.Name = "loadFile";
            this.loadFile.Size = new System.Drawing.Size(75, 23);
            this.loadFile.TabIndex = 2;
            this.loadFile.Text = "Select File";
            this.loadFile.UseVisualStyleBackColor = true;
            this.loadFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.loadFile_MouseClick);
            // 
            // PA
            // 
            this.PA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PA.Location = new System.Drawing.Point(12, 41);
            this.PA.Name = "PA";
            this.PA.RowTemplate.Height = 25;
            this.PA.Size = new System.Drawing.Size(250, 62);
            this.PA.TabIndex = 4;
            this.PA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PA_CellClick);
            // 
            // PB
            // 
            this.PB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PB.Location = new System.Drawing.Point(12, 127);
            this.PB.Name = "PB";
            this.PB.RowTemplate.Height = 25;
            this.PB.Size = new System.Drawing.Size(250, 62);
            this.PB.TabIndex = 5;
            this.PB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PB_CellClick);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(223, 516);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 6;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(223, 576);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(75, 23);
            this.btn_pause.TabIndex = 7;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // codeView
            // 
            this.codeView.AllowUserToAddRows = false;
            this.codeView.AllowUserToDeleteRows = false;
            this.codeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.codeView.ColumnHeadersVisible = false;
            this.codeView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Breakkpoints,
            this.Lines});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.codeView.DefaultCellStyle = dataGridViewCellStyle4;
            this.codeView.Location = new System.Drawing.Point(304, 233);
            this.codeView.Name = "codeView";
            this.codeView.RowHeadersVisible = false;
            this.codeView.RowTemplate.Height = 15;
            this.codeView.Size = new System.Drawing.Size(677, 397);
            this.codeView.TabIndex = 8;
            // 
            // Breakkpoints
            // 
            this.Breakkpoints.HeaderText = "";
            this.Breakkpoints.Name = "Breakkpoints";
            this.Breakkpoints.Width = 20;
            // 
            // Lines
            // 
            this.Lines.HeaderText = "";
            this.Lines.Name = "Lines";
            this.Lines.Width = 1000;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(223, 605);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 9;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_StepForward
            // 
            this.btn_StepForward.Location = new System.Drawing.Point(223, 545);
            this.btn_StepForward.Name = "btn_StepForward";
            this.btn_StepForward.Size = new System.Drawing.Size(75, 23);
            this.btn_StepForward.TabIndex = 10;
            this.btn_StepForward.Text = "Step";
            this.btn_StepForward.UseVisualStyleBackColor = true;
            this.btn_StepForward.Click += new System.EventHandler(this.btn_StepForward_Click);
            // 
            // spezialRegister
            // 
            this.spezialRegister.AllowUserToAddRows = false;
            this.spezialRegister.AllowUserToDeleteRows = false;
            this.spezialRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spezialRegister.Location = new System.Drawing.Point(21, 89);
            this.spezialRegister.Name = "spezialRegister";
            this.spezialRegister.RowHeadersVisible = false;
            this.spezialRegister.RowHeadersWidth = 10;
            this.spezialRegister.RowTemplate.Height = 15;
            this.spezialRegister.Size = new System.Drawing.Size(220, 38);
            this.spezialRegister.TabIndex = 11;
            // 
            // Status
            // 
            this.Status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Status.Location = new System.Drawing.Point(259, 148);
            this.Status.Name = "Status";
            this.Status.RowTemplate.Height = 25;
            this.Status.Size = new System.Drawing.Size(300, 38);
            this.Status.TabIndex = 12;
            // 
            // optionReg
            // 
            this.optionReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optionReg.Location = new System.Drawing.Point(259, 21);
            this.optionReg.Name = "optionReg";
            this.optionReg.RowTemplate.Height = 25;
            this.optionReg.Size = new System.Drawing.Size(300, 38);
            this.optionReg.TabIndex = 13;
            // 
            // label_tmr
            // 
            this.label_tmr.AutoSize = true;
            this.label_tmr.Location = new System.Drawing.Point(102, 10);
            this.label_tmr.Name = "label_tmr";
            this.label_tmr.Size = new System.Drawing.Size(13, 15);
            this.label_tmr.TabIndex = 14;
            this.label_tmr.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "TMR";
            // 
            // intcon
            // 
            this.intcon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.intcon.Location = new System.Drawing.Point(259, 89);
            this.intcon.Name = "intcon";
            this.intcon.RowTemplate.Height = 25;
            this.intcon.Size = new System.Drawing.Size(300, 38);
            this.intcon.TabIndex = 18;
            // 
            // cb_watchdog
            // 
            this.cb_watchdog.AutoSize = true;
            this.cb_watchdog.Location = new System.Drawing.Point(12, 114);
            this.cb_watchdog.Name = "cb_watchdog";
            this.cb_watchdog.Size = new System.Drawing.Size(81, 19);
            this.cb_watchdog.TabIndex = 20;
            this.cb_watchdog.Text = "Watchdog";
            this.cb_watchdog.UseVisualStyleBackColor = true;
            // 
            // lbl_wdtimer
            // 
            this.lbl_wdtimer.AutoSize = true;
            this.lbl_wdtimer.Location = new System.Drawing.Point(118, 118);
            this.lbl_wdtimer.Name = "lbl_wdtimer";
            this.lbl_wdtimer.Size = new System.Drawing.Size(13, 15);
            this.lbl_wdtimer.TabIndex = 19;
            this.lbl_wdtimer.Text = "0";
            // 
            // tb_quartz
            // 
            this.tb_quartz.Location = new System.Drawing.Point(12, 85);
            this.tb_quartz.Name = "tb_quartz";
            this.tb_quartz.Size = new System.Drawing.Size(100, 23);
            this.tb_quartz.TabIndex = 21;
            this.tb_quartz.Text = "4,000";
            this.tb_quartz.Enter += new System.EventHandler(this.tb_quartz_Enter);
            this.tb_quartz.Validating += new System.ComponentModel.CancelEventHandler(this.tb_quartz_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "MHz";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lbl_timer);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tb_quartz);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_wdtimer);
            this.panel1.Controls.Add(this.cb_watchdog);
            this.panel1.Controls.Add(this.label_tmr);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(120, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 152);
            this.panel1.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 15);
            this.label13.TabIndex = 27;
            this.label13.Text = "Timer";
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Location = new System.Drawing.Point(102, 37);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(13, 15);
            this.lbl_timer.TabIndex = 26;
            this.lbl_timer.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "Quarzfrequenz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "µs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(131, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "µs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(998, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "GPR";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Option";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Intcon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Status";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.spezialRegister);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.optionReg);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Status);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.intcon);
            this.panel2.Location = new System.Drawing.Point(120, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 207);
            this.panel2.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(4, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "Spezialregister";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.PA);
            this.panel3.Controls.Add(this.PB);
            this.panel3.Location = new System.Drawing.Point(706, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 207);
            this.panel3.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 19);
            this.label8.TabIndex = 29;
            this.label8.Text = "Ports";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 642);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_StepForward);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.codeView);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.loadFile);
            this.Controls.Add(this.Eprom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Eprom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spezialRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Eprom;
        private System.Windows.Forms.Button loadFile;
        private System.Windows.Forms.DataGridView PA;
        private System.Windows.Forms.DataGridView PB;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.DataGridView codeView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Breakkpoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_StepForward;
        private System.Windows.Forms.DataGridView spezialRegister;
        private System.Windows.Forms.DataGridView Status;
        private System.Windows.Forms.DataGridView optionReg;
        private System.Windows.Forms.Label label_tmr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView intcon;
        private System.Windows.Forms.CheckBox cb_watchdog;
        private System.Windows.Forms.Label lbl_wdtimer;
        private System.Windows.Forms.TextBox tb_quartz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_timer;
    }
}

