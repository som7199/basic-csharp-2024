# basic-csharp-2024
2024년 IoT 개발자 과정 C# 리포지토리

## 1일차
- C# 소개
	- MS에서 개발한 차세대 프로그래밍 언어
	- 2000년 최초 발표. 앤더스 하일버그(파스칼, 델파이 개발자)
	- 1995년 Java 발표되면서 경쟁하기 위해서 개발
	- 객체지향 언어, C/C++ 과 Java를 참조해서 개발
	- OS플랫폼 독립적, 메모리관리 쉬움
	- 다양한 분야에서 사용중
	- 2024년 12버전
	
- .NET Framework (CLR)
	- Windows OS에 종속적
	- OS 독립적인 새로운 틀을 제작하기 시작(2022년 ~ ) -> .NET 5.0
	- 2024년 현재 .NET 8.0
	- C/C++은 gcc 컴파일러, Java는 JDK, C#은 .NET 5.0 이상이 필요
	- 이제는 신규개발 시, .NET Framework는 사용하지 말 것!
	
- Hello, C#!
	- Visual Studio 시작
		- 프로젝트 : 프로그램 개발 최소 단위 그룹
		- 솔루션 : 프로젝트의 묶음

		```cs
		namespace hello_world   // 소스의 가장 큰 단위 namespace == project
		{
			internal class Program  // 접근제한자 class 파일명
			{
				static void Main(string[] args) // 정적 void Main ...
				{
					// System 네임스페이스 > Console 클래스에 있는 정적메서드 WriteLine()
					Console.WriteLine("Hello, World!");
				}
			}
		}
		```
		- 빌드 - 프로그램 만들기
		- 디버그 
			- 디버깅용으로 빌드
			- 빌드 후 생성된 실행파일에 디버깅(Debuging)정보를 포함하여 언제든지 디버깅을 할 수 있도록 하는 모드
			- C:\Sources\basic-csharp-2024\day01\cs01_basic_app\hello_csharp\bin\Debug
		- 릴리즈 
			- 최종 릴리즈 배포용으로 빌드
			- 프로그램을 배포하기 위해 컴파일 하는 모드로 디버깅정보를 삽입하지 않고 코드를 최적화하여 실행 파일의 크기를 최대한 줄여줌
			- C:\Sources\basic-csharp-2024\day01\cs01_basic_app\hello_csharp\bin\Release

- 변수와 상수
	- C++과 동일
	- 모든 C#의 객체는 Object를 조상으로!
	- 프로그램 메모리
		- 스택 => 값 형식, 정수, 실수, ...
		- 힙 => 참조 형식, 클래스, 문자열, 리스트, 배열, ...
	- 박싱(Boxing), 언박싱(Unboxing)
	```cs
	int a 20;			// 스택에 할당
	object b = a;		// 박싱(object 박스에 담는다.) -> 힙에 올리는 것

	int c = (int) b;	// 언박싱(object를 각 타입으로 변환)
	```

	- 상수는 const 키워드 사용
	- var는 컴파일러가 자동으로 타입을 지정해주는 변수, 지역변수에만 사용 가능

- 연산자
	- C++과 동일
	- ++, --가 파이썬에 없다는 것
	- and, or가 C++, C#에서는 &&, ||

- 흐름제어
	- C++과 동일
	- if, switch, while, do~while, for, break, continue, goto 모두 동일!
	- C#에는 foreach가 존재 - python의 for item in [] 과 동일

	```cs
	int[] arr = {1, 2, 3, 4, 5};

	foreach (var item in arr)
	{
		Console.WriteLine($"현재 수 : {item}");
	}
	```
- 메서드(method)
	- 함수와 동일, 구조적 프로그래밍에서 함수면, 객체지향에서는 메서드로 부른다(파이썬만 예외)
	- 매개변수 참조형식 : C++에서 Pointer로 값을 사용할 때와 동일한 기능
		```cs
		public static void RefSwap(ref int a, ref int b)
		{
			int temp = b;
			b = a;
			a = temp;
		}

		// 사용 시에도 ref 키워드 사용
		RefSwap(ref x, ref y);
		```
	- 매개변수 출력형식 -> 매개변수를 리턴값으로 사용하도록 대체해주는 방법(과도기적인 방법)
		```cs
		public static void Divide(int a, int b, out int quotient, out int remainder)
		{
			quotient = a / b;
			remainder = a % b;
			// 예전엔 튜플 리턴이 없어서 한번에 하나만 값을 리턴할 수 있었음
		}
		```
	- 메서드 오버로딩 -> 여러 타입으로 같은 처리를 하는 메서드를 여러 개 만들 때
	- 매개변수 가변길이 -> 매개변수 개수를 동적으로 처리할 때
		```cs
		public static int Sum(params int[] argv)
		{
			int sum = 0;
			foreach (var item in argv)
			{
				sum += item;
			}
			return sum;
		}
		```
	- 명명된 매개변수 -> 매개변수 사용 순서를 변경 가능
		```cs
		public static void PrintProfile(string name, string phone)
		{
			Console.WriteLine($"이름 = {name}, 모바일 = {phone}");
		}

		PrintProfile(phone: "010-9999-8888", name: "홍길동");  // 매개변수 순서 지정 가능
		```
	- 기본값 매개변수 -> 매개변수 값 미할당 시 기본값으로 지정
		```cs
		public static void DefaultMethod(int a = 1, int b = 0)
		{
			Console.WriteLine($"Default Value = {a}, {b}");
		}

		DefaultMethod(10, 8);	// a = 10, b = 8
		DefaultMethod(6);		// a= 6, b = 0
		DefaultMethod();		// a = 1, b = 0
		```

- 클래스
	- C++의 클래스, 객체와 유사(문법이 다소 상이)
	- 생성자는 new로 사용해서 객체 생성
	- 종료자(파괴자)는 C#에서 거의 사용 안 함
	- 생성자 오버로딩 -> 파라미터 개수에 따라서 사용 가능, 기본적인 메서드 오버로딩하고 기능 동일
	- this 키워드 -> C++ this라면 C#은 this. 파이썬의 self.와 동일
	- 접근 한정자(Access Modifier)
		- public - 모든 곳에서 접근
		- private - 외부에서 접근 불가(default)
		- protected - 외부에서 접근 불가, 단 파생(상속)클래스에서는 사용 가능
		- internal - 같은 어셈블리(네임스페이스)내에서는 public과 동일
		- protected internal, private protected - 난이도 있는 한정자(고급)
	
	- C#에는 C++과 같은 다중 상속 없음, C++ 다중상속으로 생기는 문제점을 해결하기 위해서 다중상속을 아예 없앰
		- 다중상속이 필요함을 해결 -> 인터페이스
		
		```cs
		class BaseClass {
			// 부모클래스
		}

		class DerivedClass : BaseClass {
			// 파생(자식)클래스
		}
		```

- 구조체
	- 객체지향이 없었을 때 좀 더 객체지향적인 프로그래밍을 위해 만들어진 부분 (C에서)
	- class 이후로 사용 빈도가 완전히 줄어든 구조
	- 구조체 스택(값 형식), 클래스 힙(참조 형식)
	- C#에서는 구조체 안 써도 됨!

- 튜플 (C# 7.0 이후 반영)
	- 한꺼번에 여러 개의 데이터를 리턴하거나 전달할 때 유용
	- 값 할당 후 변경 불가

- 인터페이스
	- 클래스 - 객체의 청사진 / 인터페이스 - 클래스의 청사진
	- 인터페이스는 클래스가 어떠한 메서드를 가져야 하는지를 약속하는 것
	- 다중상속의 문제를 단일상속으로도 해결하게 만든 주체
	- 인터페이스는 명명할 때 제일 앞에 I를 적음
	- 인터페이스의 메서드에는 구현을 작성하지 않음
	- 인터페이스는 약속!
	- 클래스는 상속한다 vs 인터페이스는 구현한다
	- 클래스는 상속 시 별다른 문제 없음 vs 인터페이스는 구현을 하면 약속을 지키지 않으면 오류 표시
	- 인터페이스에서 약속한 메서드를 구현 안 하면 빌드 안 됨!

- 추상클래스(abstract)
	- Virtual 메서드하고도 유사
	- 추상클래스를 단순화 시키면 인터페이스

- 프로퍼티
	- 클래스의 멤버변수 변형, 일반 변수와 유사
	- 멤버변수의 접근제한자를 public으로 했을 때의 객체 지향적 문제점(코드오염 등)을 해결하기 위해서 
	- GET 접근자/SET 접근자
	- SET은 값을 할당 시에 잘못된 데이터가 들어가지 않도록 막아야 함
	- Java에선 Getter메서드/Setter메서드로 사용

## 2일차
- 컬렉션(배열, 리스트, 인덱서)
- 일반화(Generic) 프로그래밍
- 예외처리
- 대리자와 이벤트
- 람다식
- 애트리뷰트
- dynamic 형식
- Winform(파일, 스레드)
- 가비지 컬렉션
- 네트워크 프로그래밍

- WPF
- 예제 프로젝트