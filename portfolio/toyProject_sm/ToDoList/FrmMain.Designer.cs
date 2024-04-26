namespace ToDoList
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.BtnNew = new MetroFramework.Controls.MetroButton();
            this.TimeLabel = new MetroFramework.Controls.MetroLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.BtnEdit = new MetroFramework.Controls.MetroButton();
            this.BtnDelete = new MetroFramework.Controls.MetroButton();
            this.BtnSave = new MetroFramework.Controls.MetroButton();
            this.TxtTodo = new System.Windows.Forms.TextBox();
            this.DgvToDoList = new System.Windows.Forms.DataGridView();
            this.TxtState = new System.Windows.Forms.TextBox();
            this.ChkTodo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvToDoList)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.BackColor = System.Drawing.Color.AliceBlue;
            this.metroLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel1.Location = new System.Drawing.Point(23, 26);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(749, 40);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "To Do List";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // BtnNew
            // 
            this.BtnNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnNew.Location = new System.Drawing.Point(188, 138);
            this.BtnNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(107, 32);
            this.BtnNew.TabIndex = 3;
            this.BtnNew.Text = "New";
            this.BtnNew.UseSelectable = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.Location = new System.Drawing.Point(640, 74);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(132, 22);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = " - -  : :";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnEdit.Location = new System.Drawing.Point(301, 138);
            this.BtnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(107, 32);
            this.BtnEdit.TabIndex = 4;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseSelectable = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(527, 138);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(107, 32);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseSelectable = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(413, 138);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(107, 32);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseSelectable = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtTodo
            // 
            this.TxtTodo.Font = new System.Drawing.Font("나눔고딕코딩", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtTodo.Location = new System.Drawing.Point(55, 101);
            this.TxtTodo.Name = "TxtTodo";
            this.TxtTodo.Size = new System.Drawing.Size(670, 20);
            this.TxtTodo.TabIndex = 1;
            // 
            // DgvToDoList
            // 
            this.DgvToDoList.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            this.DgvToDoList.AllowUserToAddRows = false;
            this.DgvToDoList.AllowUserToDeleteRows = false;
            this.DgvToDoList.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DgvToDoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvToDoList.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvToDoList.Location = new System.Drawing.Point(23, 187);
            this.DgvToDoList.MultiSelect = false;
            this.DgvToDoList.Name = "DgvToDoList";
            this.DgvToDoList.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvToDoList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvToDoList.RowHeadersVisible = false;
            this.DgvToDoList.RowTemplate.Height = 23;
            this.DgvToDoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvToDoList.Size = new System.Drawing.Size(749, 186);
            this.DgvToDoList.TabIndex = 7;
            this.DgvToDoList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvToDoList_CellClick);
            // 
            // TxtState
            // 
            this.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtState.Location = new System.Drawing.Point(731, 100);
            this.TxtState.MaxLength = 1;
            this.TxtState.Name = "TxtState";
            this.TxtState.Size = new System.Drawing.Size(36, 21);
            this.TxtState.TabIndex = 2;
            // 
            // ChkTodo
            // 
            this.ChkTodo.AutoSize = true;
            this.ChkTodo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkTodo.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ChkTodo.Location = new System.Drawing.Point(38, 106);
            this.ChkTodo.Name = "ChkTodo";
            this.ChkTodo.Size = new System.Drawing.Size(15, 14);
            this.ChkTodo.TabIndex = 8;
            this.ChkTodo.UseVisualStyleBackColor = true;
            this.ChkTodo.CheckedChanged += new System.EventHandler(this.ChkTodo_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 393);
            this.Controls.Add(this.ChkTodo);
            this.Controls.Add(this.TxtState);
            this.Controls.Add(this.DgvToDoList);
            this.Controls.Add(this.TxtTodo);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.metroLabel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmMain";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvToDoList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton BtnNew;
        private MetroFramework.Controls.MetroLabel TimeLabel;
        private System.Windows.Forms.Timer timer;
        private MetroFramework.Controls.MetroButton BtnEdit;
        private MetroFramework.Controls.MetroButton BtnDelete;
        private MetroFramework.Controls.MetroButton BtnSave;
        private System.Windows.Forms.TextBox TxtTodo;
        private System.Windows.Forms.DataGridView DgvToDoList;
        private System.Windows.Forms.TextBox TxtState;
        private System.Windows.Forms.CheckBox ChkTodo;
    }
}

