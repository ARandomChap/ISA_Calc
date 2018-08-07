using System;
using System.Threading;

namespace ConsoleApp1
{
	class Program
	{
		static Stuff stuff1 = new Stuff();

		public static void Main(string[] args)
		{
			Console.WriteLine("Please enter a name: ");
			stuff1.Name = Console.ReadLine();
			Console.WriteLine("Please enter the value of it: ");
			stuff1.Value = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter your contribution for each month: ");
			stuff1.MonthlyAdded = int.Parse(Console.ReadLine());

			Console.WriteLine("Would you like to see a monthly of yearly breakdown?");
			Console.WriteLine("1. Monthly");
			Console.WriteLine("2. Yearly");
			Choice(Console.ReadLine());

			//Console.WriteLine(stuff1.Name + " " + stuff1.Value);
			Thread.Sleep(1000);
		}

		static void Choice (string choice)
		{
			if(choice == "1")
			{
				for (int i = 1; i <= 60; i++)
				{
					if (i == 1)
					{
						stuff1.Value = Interest(stuff1.Value);
						Console.WriteLine(stuff1.Name + " has a value of " + Math.Round(stuff1.Value, 2) + " after " + i + " Month.");
						continue;
					}

					Thread.Sleep(200);
					stuff1.Value += stuff1.MonthlyAdded;
					stuff1.Value = Interest(stuff1.Value);
					Console.WriteLine(stuff1.Name + " has a value of " + Math.Round(stuff1.Value, 2) + " after " + i + " Months.");
				}
			}
			else if (choice == "2")
			{
				for (int i = 1; i <=5; i++)
				{
					if (i == 1)
					{
						stuff1.Value = stuff1.Value + (stuff1.MonthlyAdded * 11);
						stuff1.Value = YearlyInterest(stuff1.Value);
						Console.WriteLine(stuff1.Name + " has a value of " + Math.Round(stuff1.Value, 2) + " after " + i + " Year.");
						continue;
					}

					Thread.Sleep(500);
					stuff1.Value = stuff1.Value + (stuff1.MonthlyAdded * 12);
					stuff1.Value = YearlyInterest(stuff1.Value);
					Console.WriteLine(stuff1.Name + " has a value of " + Math.Round(stuff1.Value, 2) + " after " + i + " Years.");
				}
			}
			else
			{
				Console.WriteLine("That was an invalid choice, choose again...");
				Console.WriteLine("1. Monthly");
				Console.WriteLine("2. Yearly");
				Choice(Console.ReadLine());
			}
		}

		static double Interest(double interest)
		{
			var res = (interest * 1.0253) - interest;
			res = (res / 12) + interest;
			return res;
		}

		static double YearlyInterest(double interest)
		{
			var res = (interest * 1.0253) /* - interest*/;
			//res = res + interest;
			return res;
		}
	}
}
