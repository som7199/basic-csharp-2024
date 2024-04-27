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
            TxtState.Visible = false;   // 상태여부도 뜨지 않음!
            
            TxtTodo.Width = 712;        // 젤 처음 폼 로드 시에는 TxtTodo만 보이게 해주려고 크게 잡음!
            TxtTodo.Text = "New 버튼을 클릭하여 해야할 일을 작성해보세요!";
            TxtTodo.TextAlign = HorizontalAlignment.Center;
            TxtTodo.ReadOnly = true;

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
                adapter.Fill(ds, "todotbl");      // 대표 테이블 이름 사용하면 됨

                DgvToDoList.DataSource = ds.Tables[0];

                //MessageBox.Show(ds.Tables.ToString());        // System.Data.DataTableCollection
                //MessageBox.Show(ds.Tables[0].ToString());   // 테이블명 todotbl
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
            isNew = true;
            // 새로운 할 일을 입력하기 때문에 체크박스와 완료여부는 보이지 않게 해주기
            // 입력란 칸이 짧아보이기 때문에 크기 조절도 잊지말기 ( SAVE 버튼 클릭 시 원래 사이즈로 돌아옴!)
            ChkTodo.Visible = false;
            TxtState.Visible = false;

            TxtTodo.Width = 712;
            TxtTodo.ReadOnly = false;
            TxtTodo.TextAlign = HorizontalAlignment.Left;
            TxtTodo.Text = TxtState.Text = string.Empty;
            TxtTodo.Focus();
            DgvToDoList.ClearSelection();   // DataGridView 첫 번째 행 자동 선택 해제
        }

        // DataGridView에 있는 todo 선택 시 todoIdx값을 담아주고
        // description과 state도 텍스트박스에 보여주기
        private void DgvToDoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 체크박스와 상태여부도 뜨게 해줌!
            ChkTodo.Visible = true;
            TxtState.Visible = true;

            // 초기 화면과 New 버튼 클릭 시에는 TxtTodo 꽉 차게 설정해뒀음
            // 초기 화면에서 버튼 없이 바로 DgvToDoList의 행을 선택할 경우 TxtTodo 랑 TxtState 칸이 겹침 ㅠ 원상복구 해주기
            // 값을 수정할 수 있게 바꿔주고, 왼쪽 정렬해주기
            TxtTodo.Width = 670;
            TxtTodo.ReadOnly = false;
            TxtTodo.TextAlign = HorizontalAlignment.Left;

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

        // 체크 박스 체크 유무에 따라 TxtState 값 변경해주기
        private void ChkTodo_CheckedChanged(object sender, EventArgs e)
        {
            TxtState.Text = "Y".ToString();

            if (ChkTodo.Checked != true)
            {
                TxtState.Text = "N".ToString();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TxtTodo.ReadOnly = false;
            TxtTodo.TextAlign = HorizontalAlignment.Left;

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

            //  Edit 할 땐 체크박스 보여주기
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

            // 어차피 New 버튼을 클릭할 땐 새로운 할 일을 입력하는 것이므로 완료여부 작성X
            // Edit 후 SAVE 할 때에도 체크박스 유무에 따라 Y, N값을 TxtState.Text 담아 저장하므로 없어도 됨!
            // 주석처리 하겠음
            /*
            if (string.IsNullOrEmpty(TxtState.Text))
            {
                MetroMessageBox.Show(this, "완료 여부를 작성해주세요!", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */

            // 대신 Edit 할 때는 입력검증을 받아야함.
            if (!(TxtState.Text.ToUpper() == "Y" || TxtState.Text.ToUpper() == "N" || TxtState.Text.ToUpper() == ""))
            {
                MetroMessageBox.Show(this, "완료 여부는 (Y|N)으로 작성바랍니다.", "경고", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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

                    // New 버튼 클릭 시, TxtState 박스가 뜨지 않기 때문에
                    // Default 값으로 N 값을 넣어주고 그 값을 DB에 저장할 것!
                    if (TxtState.Text.ToUpper() == "")
                    {
                        SqlParameter prmState_forNew = new SqlParameter("@state", "N");
                        cmd.Parameters.Add(prmState_forNew);
                    }
                    else
                    {
                        SqlParameter prmState = new SqlParameter("@state", TxtState.Text.ToUpper());
                        cmd.Parameters.Add(prmState);
                    }
                    
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
            TxtTodo.Width = 670;
            makeEmpty();
            RefreshData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
