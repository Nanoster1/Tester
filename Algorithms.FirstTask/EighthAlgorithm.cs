using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;

namespace Algorithms.FirstTask
{
	public class EighthAlgorithm : IAlgorithm
	{
		public enum Methods
		{
			Cycle, Rec, Quick, QuickAlt
		}
		public string Name => nameof(EighthAlgorithm)+'1';

		public double Cycle(double num, int rank)
		{
			if (rank == 0) return 1;
			for(int k = 0; k < rank; k++)
			{
				num *= num;
			}
			return num;
		} 

		public double Recursion(double num, int rank)
		{
			if (rank == 0) return 1;
			var result = Recursion(num, rank / 2);
			if (rank % 2 == 1)
				result = result * result * num;
			else
				result *= result;
			return result;
		}

		public double QuickPow(double num, int rank)
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

		public double QuickPowAlt(double num, int rank)
		{
			double result = 1;
			while(rank != 0)
			{
				if (rank % 2 == 0)
				{
					num *= num;
					rank %= 2;
				}
				else
				{
					result *= num;
					rank--;
				}
			}
			return result;
		}

		public void TestRun(object[] @params = null)
		{
			var method = (Methods)@params[2];
			var num = (double)@params[0];
			var rank = (int)@params[1];
			switch (method)
			{
				case (Methods.Cycle):
					Cycle(num, rank);
					break;
				case (Methods.Rec):
					Recursion(num, rank);
					break;
				case (Methods.Quick):
					QuickPow(num, rank);
					break;
				case (Methods.QuickAlt):
					QuickPowAlt(num, rank);
					break;
			}
		}
	}
}
