// ex16_Winforms/Program.cs를 MainApp.cs로 이름 변경
// <TargetFramework>net8.0-windows</TargetFramework> 수정
// <UseWindowsForms>true</UseWindowsForms> 추가


namespace ex16_winforms
{
    internal class MainApp : Form
    {
        static void Main(string[] args)
        {
            MainApp form = new MainApp(); // 새로 객체 생성

            form.Click += Form_Click;
            form.KeyPress += Form_KeyPress;

            Console.WriteLine("프로그램 시작!");
            Application.Run(form);

            Console.WriteLine("프로그램 종료!");
        }

        // form KeyPress Eventhandler
        private static void Form_KeyPress(object? sender, KeyPressEventArgs e)
        {
            //Console.WriteLine("키보드 클릭!");
            Console.WriteLine($"키보드 클릭 > { e.KeyChar}");
        }

        // 폼 클릭 이벤트핸들러
        private static void Form_Click(object? sender, EventArgs e)
        {
            Console.WriteLine("프로그램 종료 중 ...");
            Application.Exit();
        }
    }
}

