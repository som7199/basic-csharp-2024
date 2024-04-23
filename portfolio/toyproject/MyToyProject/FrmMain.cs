using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyToyProject
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }

        // DB 연결
        DataTable todoList = new DataTable();
        bool isEditing = false;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            timer.Start();

            // Create Columns
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            // Point our datagridview(저 외국인은 todoListView, 나는 DgvToDoList) to our datasource
            DgvToDoList.DataSource = todoList;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtTitle.Text = "";
            TxtDescription.Text = "";
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // Fill text fields with data from table
            TxtTitle.Text = todoList.Rows[DgvToDoList.CurrentCell.RowIndex].ItemArray[0].ToString();
            TxtDescription.Text = todoList.Rows[DgvToDoList.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[DgvToDoList.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                if (TxtTitle.Text == string.Empty || TxtDescription.Text == string.Empty)
                {
                    MessageBox.Show("입력!");
                    return;
                }
                todoList.Rows[DgvToDoList.CurrentCell.RowIndex]["title"] = TxtTitle.Text;
                todoList.Rows[DgvToDoList.CurrentCell.RowIndex]["Description"] = TxtDescription.Text;
            }
            else
            {
                todoList.Rows.Add(TxtTitle.Text, TxtDescription.Text);
            }
            // clear fields
            TxtTitle.Text = "";
            TxtDescription.Text = "";
            isEditing = false;
        }
    }
}
