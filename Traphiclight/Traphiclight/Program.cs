using System;
using System.Threading;

namespace Traphiclight
{
	class MainClass
	{
		public static int n = 0;
		public  static Square square;
		static void Show()
		{square = new Square();
			while (true)
			{
				square.Draw(n);
				n = n + 1;
				if (n == 3)
					n = 0;
				Thread.Sleep(1000);
			}
		
		
		}
		public static void Main(string[] args)
		{
			Thread thread = new Thread(Show);
			thread.Start();
		}
	}
}
