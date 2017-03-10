using System;
using System.Collections.Generic;
namespace Traphiclight
{
	public class Square   // i=0 0 10 i=1 10 20 
	{
		List<Point> points;
		public void setSquare() {
			points = new List<Point>();
			for (int j = 10; j < 22; j++)
			    for (int i = 10; i < 20; i++)
				
			{
					points.Add(new Point(i, j));
			}
		}
		public Square()
		{
			setSquare();

		}
		public void Draw(int x) {

			Console.Clear();
			for (int i = 0; i < points.Count; i++)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(points[i].x, points[i].y);
				Console.WriteLine('#');
			}
			switch (x)
			{
				case 0:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case 2:
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case 1:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
			}

				for (int i = x*40; i < (x+1)*40; i++)
			{
				
				Console.SetCursorPosition(points[i].x, points[i].y);
				Console.WriteLine('#');
			}
				
		
		}
	}
}
