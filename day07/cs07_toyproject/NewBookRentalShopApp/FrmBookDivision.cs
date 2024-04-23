﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmBookDivision : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookDivision()
        {
            InitializeComponent();
        }

        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;   // 최초 입력 시 PK값을 입력해줘야함!!
            TxtDivision.Focus();            // 순번은 자동증가하기 때문에 입력 불가
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력검증(Validation check), 구분 코드, 구분명을 안넣으면 
            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                MessageBox.Show("구분 코드를 입력하세요.");
                return;
            }
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("구분명을 입력하세요.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();

                    var query = @"";
                    if (isNew)  // INSERT이면
                    {
                        query = @"INSERT INTO divtbl
                                            (Division
                                            ,Names)
                                        VALUES
                                            (@Division
                                            ,@Names)";
                    }
                    else // UPDATE
                    {
                        query = @"UPDATE divtbl
                                 SET Names= @Names
                                WHERE Division = @Division";
                    }
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlParameter prmDivision = new SqlParameter("@Division", TxtDivision.Text);
                    SqlParameter prmNames = new SqlParameter("@Names", TxtNames.Text);
                    // Command에 Parameter를 연결해줘야 함!
                    cmd.Parameters.Add(prmDivision); 
                    cmd.Parameters.Add(prmNames);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this 메시지 박스의 부모창이 누구냐, FrmLoginUser 
                        MetroMessageBox.Show(this, "저장 성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("저장 성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            TxtDivision.Text = TxtNames.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            RefreshData();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDivision.Text))  // 구분코드가 없으면
            {
                MetroMessageBox.Show(this, "삭제할 구분값을 선택하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM divtbl WHERE Division = @Division";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmDivision = new SqlParameter("@Division", TxtDivision.Text);
                cmd.Parameters.Add(prmDivision);

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
            TxtDivision.Text = TxtNames.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            RefreshData();  // 데이터 그리드 재조회
        }

        // 데이터그리드뷰에 데이터를 새로 부르기
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT Division
                                    ,Names
                                FROM divtbl";   // 화면에 필요한 테이블 쿼리 변경
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "divtbl");

                DgvResult.DataSource = ds.Tables[0];

                //MessageBox.Show(ds.Tables.ToString());        // System.Data.DataTableCollection
                //MessageBox.Show(ds.Tables[0].ToString());   // 테이블명 divtbl

                DgvResult.ReadOnly = true;  // 수정 불가
                DgvResult.Columns[0].HeaderText = "구분코드";
                DgvResult.Columns[1].HeaderText = "구분명";
            }
        }

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex];   // 내가 선택한 인덱스값
                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true;    // UPDATE시 PK인 Division을 변경하면 안 됨

                isNew = false;  // UPDATE
            }
        }
    }
}
