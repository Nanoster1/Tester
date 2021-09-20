using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;

namespace Algorithms.FirstTask
{
	public static class Pow
	{
		public static double Cycle(double num, int rank)
		{
			if (rank == 0) return 1;
			double result = num;
			for(int k = 1; k < rank; k++)
			{
				result *= num;
			}
			return result;
		} 

		public static double Recursion(double num, int rank)
		{
			if (rank == 0) return 1;
			var result = Recursion(num, rank / 2);
			if (rank % 2 == 1)
				result = result * result * num;
			else
				result *= result;
			return result;
		}

		public static double QuickPow(double num, int rank)
		{
			double result;
			if (rank % 2 == 1)
				result = num;
			else
				result = 1;
			while (rank != 0)
			{
				rank /= 2;
				num *= num;
				if (rank % 2 == 1)
					result *= num;
			}
			return result;
		}

		public static double QuickPowAlt(double num, int rank)
		{
			double result = 1;
			while(rank != 0)
			{
				if (rank % 2 == 0)
				{
					num *= num;
					rank /= 2;
				}
				else
				{
					result *= num;
					rank--;
				}
			}
			return result;
		}
	}
}
