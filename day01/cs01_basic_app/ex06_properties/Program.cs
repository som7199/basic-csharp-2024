namespace ex06_properties
{
    class Kiturami
    {
        private int temperature;    // 온도
        private int year;           // 제작년도 멤버변수
        public int Year
        {
            get { return year; }
            set { year = value; }
        }   // 일반 프로퍼티
        public string Name { get; set; }    // 자동 프로퍼티 GET/SET에서 특별한 로직이 없으면 생략 가능

        // Rosalyn VS 개발 서포터(alt + Enter)
        public int Temperature
        {
            get
            {   // 값을 리턴할 뿐이니까 특별한 기능이 없음 
                return temperature;
            }
            set
            {
                if (value < 10)
                    temperature = 20;   // 10도 이하는 허용안함
                else if (value > 70)
                    temperature = 50;   // 70도 초과는 허용안함
                else
                    temperature = value;    // value:Temperature에 값을 집어넣으면 알아서 들어가는 것
            }
        }  // 프로퍼티:대문자로 시작함

        //public void SetTemperature(int temp)
        //{
        //    if (temp > 70)
        //    {
        //        Console.WriteLine("온도가 너무 높습니다. 50도로 조정합니다.\n");
        //        this.temperature = 50;
        //    }
        //    else if (temp < 10)
        //    {
        //        Console.WriteLine("온도가 너무 낮습니다. 20도로 조정하빈다.\n");
        //        this.temperature = 20;
        //    }
        //    else
        //    {
        //        this.temperature = temp;
        //    }
        //}
        //public int GetTemperature() 
        //{
        //    return this.temperature;
        //}
        public void On()
        {
            Console.WriteLine("보일러 On");
        }
        public void Off()
        {
            Console.WriteLine("보일러 Off");
        }

        // 생성자
        public Kiturami(int year, string name, int temperature)
        {
            Year = year;
            Name = name;
            Temperature = temperature;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("보일러 시작!");
            //Kiturami boiler = new Kiturami();
            //// boiler.temperature = 40;     // 클래스의 멤버변수를 public으로 사용해선 안됨

            //// boiler.SetTemperature(50);   // Getter/Setter메서드로 구현한 방법
            ////Console.WriteLine($"보일러 온도는 {boiler.GetTemperature}도");

            //boiler.Temperature = 900;       // 프로퍼티로 구현한 방법
            //Console.WriteLine($"보일러 온도는 {boiler.Temperature}도");
            //boiler.On();

            //boiler.Name = "귀뚜라미";
            //Console.WriteLine($"보일러 이름은 {boiler.Name}");

            Kiturami kiturami = new Kiturami(name: "귀뚜라미", temperature: 60, year: 2023);
            Console.WriteLine(kiturami.Name);
            kiturami.Temperature = 150;
            Console.WriteLine($"{kiturami.Name} 현재 온도는 {kiturami.Temperature}");
            Console.WriteLine($"제작년도:{kiturami.Year}");
        }
    }
}
