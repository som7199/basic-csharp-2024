namespace ex19_asyncs
{
    public partial class FrmMain : Form
    {
        #region "생성자, 초기화 영역"

        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region "이벤트 핸들러 영역"

        // 이벤트 핸들러, 복사할 원본 파일 선택
        private void BtnGetSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TxtSource.Text = dlg.FileName;
            }
        }

        // 이벤트 핸들러, 붙여넣기할 타겟 파일 지정
        private void BtnSetTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TxtTarget.Text = dlg.FileName;
            }
        }

        // 이벤트 핸들러, 동기화 복사 진행
        private void BtnSyncCopy_Click(object sender, EventArgs e)
        {
            long result = CopySync(TxtSource.Text, TxtTarget.Text);
        }

        // 이벤트 핸들러, 비동기화 복사 진행
        // void는 리턴값이 없으므로 Task<void> 없음
        private async void BtnAsyncCopy_Click(object sender, EventArgs e)
        {
            long result = await CopyAsync(TxtSource.Text, TxtTarget.Text);
        }

        // 버튼 클릭 이벤트 핸들러, 복사 취소 처리
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UI 반응 테스트 완료!");
        }
        #endregion

        #region "사용자 메서드 영역"

        long CopySync(string srcPath, string destPath)
        {
            // 버튼 사용 비활성화
            BtnAsyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            // File은 Open()하면 반드시 Close() 해야 함, 단 using을 쓰면 Close()를 C#이 알아서 해줌!!!
            // 파일 입출력

            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))  // 원래 존재하는 파일을 여니까 FileMode.Open
            {
                using (FileStream toStream = new FileStream(destPath, FileMode.Create)) // 존재하지 않는 파일을 건드니까 FileMode.Create  
                {
                    // 1MByte 버퍼를 생성
                    byte[] buffer = new byte[1024 * 1024];     // 1024(byte) = 1Kbyte, 1024 * 1024 = 1Mbyte
                    // fromStream에 들어온 파일을 1MB씩 잘라서 버퍼에 담은 다음
                    // toStream에 1MB씩 붙여넣음!
                    int nRead = 0;
                    while ((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        toStream.Write(buffer, 0, nRead);
                        totalCopied += nRead;   // 전체 복사 사이즈를 계속 증가

                        // 프로그레스바에 진행사항을 표시
                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied;     // 복사한 파일 사이즈 리턴
        }

        // 비동기 처리 시 async, await 키워드가 가장 중요
        // async -> 나는 비동기 메서드야 라고 정의
        // await -> 비동기 메서드가 끝날 때까지 기다릴게 라는 정의
        // 비동기를 처리하는 메서드명 ... Async()로 끝남!
        // async는 메서드 리턴값에 작성. 리턴값은 Task<리턴값>

        async Task<long> CopyAsync(string srcPath, string destPath)
        {
            BtnAsyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))  
            {
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024];      // 테스트 시 10으로 변경
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;

                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied;
        }

        #endregion
    }
}