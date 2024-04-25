using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class FrmMain : MetroForm
    {
        private int todoIdx;
        private bool isNew = false; // UPDATE(false), INSERT(true)
        public string connString = "Data Source=localhost;" +
                                    "Initial Catalog=ToyProjectSom;" +
                                    "Persist Security Info=True;" +
                                    "User ID=sa;Encrypt=False;Password=mssql_p@ss";
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            timer.Start();
            RefreshData();      // todotbl 의 데이터 불러오기
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = @"SELECT [todoIdx]
                                    ,[description]
                                    ,[state]
                                FROM [todotbl]";   // 화면에 필요한 테이블 쿼리 변경

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "rentaltbl");      // 대표 테이블 이름 사용하면 됨

                DgvToDoList.DataSource = ds.Tables[0];

                //MessageBox.Show(ds.Tables.ToString());        // System.Data.DataTableCollection
                //MessageBox.Show(ds.Tables[0].ToString());   // 테이블명 rentaltbl
                DgvToDoList.ReadOnly = true;  // 수정 불가
                
                // DgvToDoList.Columns[0].HeaderText = "Id";
                DgvToDoList.Columns[0].Visible = false;
                DgvToDoList.Columns[1].HeaderText = "To Do";
                DgvToDoList.Columns[2].HeaderText = "state";

                // 컬럼 넓이 지정
                DgvToDoList.Columns[1].Width = 649;
                DgvToDoList.Columns[2].Width = 100;
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtTodo.Text = TxtState.Text = string.Empty;
            TxtTodo.Focus();
            ChkTodo.Enabled = false;    // 새로운 할 일 입력 시에는 체크박스 못 건드리게 해주기!
            ChkTodo.Checked = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TxtTodo.Text = DgvToDoList.SelectedRows[0].Cells[1].Value.ToString();
            TxtState.Text = DgvToDoList.SelectedRows[0].Cells[2].Value.ToString();

            // 완료되지 않은 일 => 체크박스 활성화
            if (TxtState.Text == "N")
            {
                ChkTodo.Checked = false;
                ChkTodo.Enabled = true;
            }
            else
            {
                ChkTodo.Checked = true;
                ChkTodo.Enabled = true;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력검증(Validation check)
            if (string.IsNullOrEmpty(TxtTodo.Text))
            {
                MessageBox.Show("할 일을 작성해주세요!");
                return;
            }

            if (string.IsNullOrEmpty(TxtState.Text))
            {
                MessageBox.Show("완료 여부를 작성해주세요!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    var query = @"";
                    // INSERT
                    if (isNew)   
                    {
                        query = @"INSERT INTO [todotbl]
                                            ([description]
                                            ,[state])
                                        VALUES
                                            (@description
                                            ,@state)";
                    }
                    // UPDATE
                    else
                    {
                        query = @"UPDATE [todotbl]
                                     SET [description] = @description
                                        ,[state] = @state
                                   WHERE todoIdx = @todoIdx";
                    }
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmDescription = new SqlParameter("@description", TxtTodo.Text);
                    cmd.Parameters.Add(prmDescription);

                    SqlParameter prmState = new SqlParameter("@state", TxtState.Text);
                    cmd.Parameters.Add(prmState);

                    if (isNew != true)
                    {
                        SqlParameter prmToDoIdx = new SqlParameter("@todoIdx", todoIdx);
                        cmd.Parameters.Add(prmToDoIdx);
                    }

                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MetroMessageBox.Show(this.Parent, "저장 성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this.Parent, "저장 실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this.Parent, $"오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            makeEmpty();
            RefreshData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtTodo.Text))
            {
                MetroMessageBox.Show(this.Parent, "삭제할 할 일을 선택하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MetroMessageBox.Show(this.Parent, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = @"DELETE FROM todotbl WHERE todoIdx = @todoIdx";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmToDoIdx = new SqlParameter("@todoIdx", todoIdx);
                cmd.Parameters.Add(prmToDoIdx);

                var result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MetroMessageBox.Show(this.Parent, "삭제 성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroMessageBox.Show(this.Parent, "삭제 실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            makeEmpty();
            RefreshData();
        }

        private void ChkTodo_CheckedChanged(object sender, EventArgs e)
        {
            // 체크버튼 눌렀을 때 Y로 바꾸고 DB에도 저장되도록
            TxtState.Text = 'Y'.ToString();

            if (!ChkTodo.Checked)
            {
                TxtState.Text = 'N'.ToString();
            }
        }

        private void DgvToDoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            todoIdx = (int)DgvToDoList.SelectedRows[0].Cells[0].Value;
        }

        private void makeEmpty()
        {
            isNew = false;
            TxtTodo.Text = TxtState.Text = string.Empty;
            TxtTodo.Focus();
            ChkTodo.Checked = false;
        }
    }
}
