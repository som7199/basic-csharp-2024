namespace MyToyProject
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            Timer = new System.Windows.Forms.Timer(components);
            groupBox2 = new GroupBox();
            TimeLabel = new Label();
            dateTimePicker1 = new DateTimePicker();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 435);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "To_Do_List";
            // 
            // Timer
            // 
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TimeLabel);
            groupBox2.Location = new Point(312, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(459, 68);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Time";
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Font = new Font("나눔스퀘어라운드 Bold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            TimeLabel.Location = new Point(23, 19);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(428, 40);
            TimeLabel.TabIndex = 0;
            TimeLabel.Text = "yyyy-MM-dd HH:mm:ss";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(16, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(272, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmMain";
            Text = "MyApp";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private System.Windows.Forms.Timer Timer;
        private GroupBox groupBox2;
        private Label TimeLabel;
        private DateTimePicker dateTimePicker1;
    }
}