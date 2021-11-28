using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask.FirstTask
{
    public class ShakerSort
    {
        //метод обмена элементов
        private static void Swap(ref string e1, ref string e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //сортировка перемешиванием
        public static string[] Sort(string[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (EqauldString(array[j].ToLower(), array[j + 1].ToLower()))
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (EqauldString(array[j - 1].ToLower(), array[j].ToLower()))
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
        private static bool EqauldString(string val1, string val2)
        {
            var min = Math.Min(val2.Length, val1.Length);
            for (int i = 0; i < min; i++)
            {
                if (val1[i] == val2[i]) continue;
                if (val1[i] > val2[i]) return true;
                else return false;
            }
            return false;
        }
    }
}
