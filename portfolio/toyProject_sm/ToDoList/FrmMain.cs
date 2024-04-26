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
            RefreshData();              // todotbl 의 데이터 불러오기
            ChkTodo.Visible = false;    // 처음에는 체크박스 뜨지 않음!
            DgvToDoList.ClearSelection();   // DataGridView 첫 번째 행 자동 선택 해제
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
                DgvToDoList.Columns[1].Width = 694;
                DgvToDoList.Columns[2].Width = 55;
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            settingForNew();
        }

        // DataGridView에 있는 todo 선택 시 todoIdx값을 담아주고
        // description과 state도 텍스트박스에 보여주기
        private void DgvToDoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            todoIdx = (int) DgvToDoList.SelectedRows[0].Cells[0].Value;
            TxtTodo.Text = DgvToDoList.SelectedRows[0].Cells[1].Value.ToString();
            TxtState.Text = DgvToDoList.SelectedRows[0].Cells[2].Value.ToString();

            // Edit 시, 최초로 선택된 행의 state 값을 기준으로 체크박스 표시가 일관되므로
            // => todoIdx = 3 인 행의 state = y 이면,
            // todoIdx = 1이고 state = n 인 행 선택 시 체크 박스가 체크된 상태로 보여짐 ㅠ
            // 이를 위해 여기서 체크박스 설정을 건드려줌
            // 완료되지 않은 일 => 체크 X, 체크박스 활성화
            if (TxtState.Text == "N")
            {
                ChkTodo.Checked = false;
            }
            else
            {
                ChkTodo.Checked = true;     // 완료된 일은 체크박스 체크된 채로 띄우기
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // 완료되지 않은 일 => 체크 X, 체크박스 활성화
            if (TxtState.Text == "N")
            {
                ChkTodo.Checked = false;
            }
            else
            {
                ChkTodo.Checked = true;     // 완료된 일은 체크박스 체크된 채로 띄우기
            }
            TxtTodo.Text = DgvToDoList.SelectedRows[0].Cells[1].Value.ToString();
            TxtState.Text = DgvToDoList.SelectedRows[0].Cells[2].Value.ToString();

            // 체크박스는 Edit 할 때만 보여주기
            ChkTodo.Visible = true;

            // 체크박스는 항상 활성화!
            // 일이 완벽히 안됐다고 생각할 경우 다시 체크를 비활성화해야할 수도 있기 때문에
            ChkTodo.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력검증(Validation check)
            if (string.IsNullOrEmpty(TxtTodo.Text))
            {
                MetroMessageBox.Show(this, "할 일을 작성해주세요!", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrEmpty(TxtState.Text))
            {
                MetroMessageBox.Show(this, "완료 여부를 작성해주세요!", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(TxtState.Text.ToUpper() == "Y" || TxtState.Text.ToUpper() == "N"))
            {
                MetroMessageBox.Show(this, "완료 여부는 (Y|N)으로 작성바랍니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    SqlParameter prmState = new SqlParameter("@state", TxtState.Text.ToUpper());
                    cmd.Parameters.Add(prmState);

                    if (isNew != true)
                    {
                        SqlParameter prmToDoIdx = new SqlParameter("@todoIdx", todoIdx);
                        cmd.Parameters.Add(prmToDoIdx);
                    }

                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MetroMessageBox.Show(this, "저장 성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "저장 실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            makeEmpty();
            RefreshData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtTodo.Text = DgvToDoList.SelectedRows[0].Cells[1].Value.ToString();
            TxtState.Text = DgvToDoList.SelectedRows[0].Cells[2].Value.ToString();

            if (string.IsNullOrEmpty(TxtTodo.Text))
            {
                MetroMessageBox.Show(this, "삭제할 할 일을 선택하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    MetroMessageBox.Show(this, "삭제 성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroMessageBox.Show(this, "삭제 실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            makeEmpty();
            RefreshData();
        }

        // 체크 박스 체크 유무에 따라 TxtState 값 변경해주기
        private void ChkTodo_CheckedChanged(object sender, EventArgs e)
        {
            TxtState.Text = "Y".ToString();

            if (ChkTodo.Checked != true)
            {
                TxtState.Text = "N".ToString();
            }
        }

        // new 기능을 위한 메서드
        private void settingForNew()
        {
            isNew = true;
            ChkTodo.Visible = false;

            TxtTodo.Text = TxtState.Text = string.Empty;
            TxtTodo.Focus();
            DgvToDoList.ClearSelection();   // DataGridView 첫 번째 행 자동 선택 해제
        }

        // save, delete 버튼 클릭 후
        // TxtTodo, TxtState 비워주기
        // 체크박스 안보이게 해주기
        private void makeEmpty()
        {
            isNew = false;
            ChkTodo.Visible = false;

            TxtTodo.Text = TxtState.Text = string.Empty;
            TxtTodo.Focus();
            DgvToDoList.ClearSelection();   // DataGridView 첫 번째 행 자동 선택 해제
        }

        /*
        // NEW를 누르지 않고도 TxtTodo를 클릭했을 때, 작성하고 저장할 수 있도록 해주기 
        private void TxtTodo_Click(object sender, EventArgs e)
        {
            writeTodo();
        }
        

        // TxtTodo, TxtState 작성하는 부분!!
        private void writeTodo()
        {
            // 새로운 값을 입력할 때
            if (string.IsNullOrEmpty(TxtTodo.Text))
            {
                settingForNew();
            }
            // Edit 버튼 눌렀을 때 입력창을 한번 더 클릭하는 경우
            else
            {
                isNew = true;
                ChkTodo.Visible = false;

                todoIdx = (int)DgvToDoList.SelectedRows[0].Cells[0].Value;
                TxtTodo.Text = DgvToDoList.SelectedRows[0].Cells[1].Value.ToString();
                TxtState.Text = DgvToDoList.SelectedRows[0].Cells[2].Value.ToString();
                ChkTodo.Enabled = true;
            }
        }
        */
    }
}
