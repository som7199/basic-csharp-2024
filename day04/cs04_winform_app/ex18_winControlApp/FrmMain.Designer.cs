namespace ex18_winControlApp
{
    partial class FrmMain
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
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            ChkItalic = new CheckBox();
            ChkBold = new CheckBox();
            CboFonts = new ComboBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(ChkItalic);
            groupBox1.Controls.Add(ChkBold);
            groupBox1.Controls.Add(CboFonts);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(429, 128);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "콤보박스, 체크박스, 텍스트박스";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(384, 23);
            textBox1.TabIndex = 5;
            textBox1.Text = "Hello, C#!";
            // 
            // ChkItalic
            // 
            ChkItalic.AutoSize = true;
            ChkItalic.Font = new Font("맑은 고딕", 9F, FontStyle.Italic);
            ChkItalic.Location = new Point(346, 47);
            ChkItalic.Name = "ChkItalic";
            ChkItalic.Size = new Size(62, 19);
            ChkItalic.TabIndex = 4;
            ChkItalic.Text = "이탤릭";
            ChkItalic.UseVisualStyleBackColor = true;
            // 
            // ChkBold
            // 
            ChkBold.AutoSize = true;
            ChkBold.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            ChkBold.Location = new Point(291, 47);
            ChkBold.Name = "ChkBold";
            ChkBold.Size = new Size(50, 19);
            ChkBold.TabIndex = 3;
            ChkBold.Text = "굵게";
            ChkBold.UseVisualStyleBackColor = true;
            // 
            // CboFonts
            // 
            CboFonts.FormattingEnabled = true;
            CboFonts.Location = new Point(62, 45);
            CboFonts.Name = "CboFonts";
            CboFonts.Size = new Size(223, 23);
            CboFonts.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 49);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "폰트 :";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 550);
            Controls.Add(groupBox1);
            Name = "FrmMain";
            Text = "컨트롤 예제";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox ChkBold;
        private ComboBox CboFonts;
        private Label label1;
        private TextBox textBox1;
        private CheckBox ChkItalic;
    }
}
