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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            TimeLabel = new Label();
            label1 = new Label();
            TxtTitle = new TextBox();
            TxtDescription = new TextBox();
            label4 = new Label();
            label2 = new Label();
            BtnNew = new Button();
            BtnEdit = new Button();
            BtnDelete = new Button();
            BtnSave = new Button();
            timer = new System.Windows.Forms.Timer(components);
            DgvToDoList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgvToDoList).BeginInit();
            SuspendLayout();
            // 
            // TimeLabel
            // 
            TimeLabel.Anchor = AnchorStyles.Right;
            TimeLabel.BackColor = Color.WhiteSmoke;
            TimeLabel.BorderStyle = BorderStyle.Fixed3D;
            TimeLabel.Font = new Font("나눔스퀘어라운드 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            TimeLabel.ImageAlign = ContentAlignment.MiddleRight;
            TimeLabel.Location = new Point(513, 62);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(183, 18);
            TimeLabel.TabIndex = 0;
            TimeLabel.Text = " - -  : :";
            TimeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.BackColor = Color.AliceBlue;
            label1.Font = new Font("맑은 고딕", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(36, 9);
            label1.Name = "label1";
            label1.Size = new Size(660, 43);
            label1.TabIndex = 3;
            label1.Text = "To Do List";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // TxtTitle
            // 
            TxtTitle.BackColor = SystemColors.ControlLightLight;
            TxtTitle.Location = new Point(36, 85);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.Size = new Size(660, 23);
            TxtTitle.TabIndex = 4;
            // 
            // TxtDescription
            // 
            TxtDescription.BackColor = SystemColors.ControlLightLight;
            TxtDescription.Location = new Point(36, 139);
            TxtDescription.Name = "TxtDescription";
            TxtDescription.Size = new Size(660, 23);
            TxtDescription.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label4.Location = new Point(36, 62);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 8;
            label4.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(36, 116);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 9;
            label2.Text = "Description";
            // 
            // BtnNew
            // 
            BtnNew.BackColor = Color.WhiteSmoke;
            BtnNew.ForeColor = SystemColors.ControlDarkDark;
            BtnNew.Location = new Point(99, 174);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(130, 33);
            BtnNew.TabIndex = 10;
            BtnNew.Text = "New";
            BtnNew.UseVisualStyleBackColor = false;
            BtnNew.Click += BtnNew_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.BackColor = Color.WhiteSmoke;
            BtnEdit.ForeColor = SystemColors.ControlDarkDark;
            BtnEdit.Location = new Point(235, 174);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(130, 33);
            BtnEdit.TabIndex = 11;
            BtnEdit.Text = "Edit";
            BtnEdit.UseVisualStyleBackColor = false;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.BackColor = Color.WhiteSmoke;
            BtnDelete.ForeColor = SystemColors.ControlDarkDark;
            BtnDelete.Location = new Point(371, 174);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(130, 33);
            BtnDelete.TabIndex = 12;
            BtnDelete.Text = "Delete";
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.WhiteSmoke;
            BtnSave.ForeColor = SystemColors.ControlDarkDark;
            BtnSave.Location = new Point(507, 174);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(130, 33);
            BtnSave.TabIndex = 13;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // DgvToDoList
            // 
            DgvToDoList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvToDoList.BackgroundColor = Color.AliceBlue;
            DgvToDoList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvToDoList.Dock = DockStyle.Bottom;
            DgvToDoList.GridColor = SystemColors.ScrollBar;
            DgvToDoList.Location = new Point(0, 225);
            DgvToDoList.Name = "DgvToDoList";
            DgvToDoList.Size = new Size(732, 356);
            DgvToDoList.TabIndex = 14;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(732, 581);
            Controls.Add(DgvToDoList);
            Controls.Add(TimeLabel);
            Controls.Add(BtnSave);
            Controls.Add(BtnDelete);
            Controls.Add(BtnEdit);
            Controls.Add(BtnNew);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(TxtDescription);
            Controls.Add(TxtTitle);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlDarkDark;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "To Do List";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)DgvToDoList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label TimeLabel;
        private Label label1;
        private TextBox TxtTitle;
        private TextBox TxtDescription;
        private Label label4;
        private Label label2;
        private Button BtnNew;
        private Button BtnEdit;
        private Button BtnDelete;
        private Button BtnSave;
        private System.Windows.Forms.Timer timer;
        private DataGridView DgvToDoList;
    }
}