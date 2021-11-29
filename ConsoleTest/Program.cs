using Algorithms.FirstTask.ThirtTask;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Algorithms.FirstTask.FourthTask;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var b =  new ObservableCollection<int>() {2, 5, 6,1,2,0,-4,234};
			b.CollectionChanged += (sender, eventArgs) =>
			{
				Console.WriteLine("Old:" + string.Join(", ", eventArgs.OldItems));
				Console.WriteLine("New" + string.Join(", ", eventArgs.NewItems));
			};
			DirectMergeSort.Sort(b, x=> x);
		}
		
		public static string GetRandomCommnad(int count)
		{
			var rnd = new Random();
			StringBuilder @string = new();
			for (int i = 0; i < count; i++)
			{
				var value = rnd.Next(1, 6);
				if (value == 1)
					@string.Append($"{value},{rnd.Next(1, 100)}");
				else
					@string.Append(value);

			}
			return @string.ToString();
		}
	}
}
