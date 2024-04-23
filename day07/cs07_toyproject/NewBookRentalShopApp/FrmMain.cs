﻿using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmMain : MetroForm
    {
        // 각 화면을 초기화!
        FrmLoginUser frmLoginUser = null;   // 객체를 메서드로 생성
        FrmBookDivision frmBookDivision = null;
        FrmBookInfo frmBookInfo = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        // 폼로드 이벤트 핸들러, 로그인창을 먼저 띄워야함!
        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            //frm.Parent = this;  // FrmMain이 부모창 설정
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.TopMost = true;     // 가장 윈도우화면 상단에
            frm.ShowDialog();
        }

        private void MnuLoginUsers_Click(object sender, EventArgs e)
        {
            // 이미 창이 열려있으면 새로 생성할 필요가 없기 때문에
            // 이런 작업을 안하면 메뉴 클릭 시마다 새 폼이 열림 ㅠ
            frmLoginUser = ShowActiveForm(frmLoginUser, typeof(FrmLoginUser)) as FrmLoginUser;
        }

        // 책 장르 관리 메뉴 클릭 이벤트 핸들러
        private void MnuBookDivision_Click(object sender, EventArgs e)
        {
            frmBookDivision = ShowActiveForm(frmBookDivision, typeof(FrmBookDivision)) as FrmBookDivision;
        }

        // 책 정보 관리 메뉴 클릭 이벤트 핸들러
        private void MnuBookInfo_Click(object sender, EventArgs e)
        {
            // (frmBookInfo) 객체 변수, 객체 변수, (FrmBookInfo) 클래스, 클래스
            frmBookInfo = ShowActiveForm(frmBookInfo, typeof(FrmBookInfo)) as FrmBookInfo;
        }

        Form ShowActiveForm(Form form, Type type)
        {
            if (form == null)   // 화면이 한번도 안열렸으면
            {
                form = Activator.CreateInstance(type) as Form;   // 타입은 클래스 타입
                form.MdiParent = this;  // 자식 창의 부모는 FrmMain
                form.WindowState = FormWindowState.Normal;
                form.Show();
            }
            else
            {
                if (form.IsDisposed)    // 창이 한번 닫혔으면
                {
                    form = Activator.CreateInstance(type) as Form;   // 타입은 클래스 타입
                    form.MdiParent = this;  // 자식 창의 부모는 FrmMain
                    form.WindowState = FormWindowState.Normal;
                    form.Show();
                }
                else                        // 창을 그냥 최소화, 열려있으면
                {
                    form.Activate();        // 화면에 열려있는 창을 활성화
                }
            }
            return form;
        }

    }
}
