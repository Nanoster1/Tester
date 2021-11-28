using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    public class MergeSort
    {
        public static double[] Sort(double[] arr)
        {
            if (arr.Length > 1)
            {
                var left = new double[arr.Length / 2];
                var right = new double[arr.Length - left.Length];
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = arr[i];
                }
                for (int j = 0; j < right.Length; j++)
                {
                    right[j] = arr[left.Length + j];
                }
                if (left.Length > 1)
                    left = Sort(left);
                if (right.Length > 1)
                    right = Sort(right);
                arr = Merge(left, right);
                return arr;
            }
            else
            {
                return arr;
            }
        }
        private static double[] Merge(double[] left, double[] right)
        {
            var result = new double[left.Length + right.Length];
            int i = 0, j = 0;
            for (int k = 0; k < result.Length; k++)
            {
                if (i > left.Length - 1)
                {
                    result[k] = right[j];
                    j++;
                }
                else if (j > right.Length - 1)
                {
                    result[k] = left[i];
                    i++;
                }
                else if (left[i] >= right[j])
                {
                    result[k] = right[j];
                    j++;
                }
                else
                {
                    result[k] = left[i];
                    i++;
                }
            }
            return result;
        }
        public static string[] Sort(string[] arr)
        {
            if (arr.Length > 1)
            {
                var left = new string[arr.Length / 2];
                var right = new string[arr.Length - left.Length];
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = arr[i];
                }
                for (int j = 0; j < right.Length; j++)
                {
                    right[j] = arr[left.Length + j];
                }
                if (left.Length > 1)
                    left = Sort(left);
                if (right.Length > 1)
                    right = Sort(right);
                arr = Merge(left, right);
                return arr;
            }
            else
            {
                return arr;
            }
        }
        private static string[] Merge(string[] left, string[] right)
        {
            var result = new string[left.Length + right.Length];
            int i = 0, j = 0;
            for (int k = 0; k < result.Length; k++)
            {
                if (i > left.Length - 1)
                {
                    result[k] = right[j];
                    j++;
                }
                else if (j > right.Length - 1)
                {
                    result[k] = left[i];
                    i++;
                }
                else if (EqauldString(left[i].ToLower(), right[j].ToLower()))
                {
                    result[k] = right[j];
                    j++;
                }
                else
                {
                    result[k] = left[i];
                    i++;
                }
            }
            return result;

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
        //private static string[] Merge(string[] left, string[] right)
        //{
        //    var result = new string[left.Length + right.Length];
        //    int i = 0, j = 0, m = 0;
        //    for (int k = 0; k < result.Length; k++)
        //    {
        //        char leftLetter = char.Parse(left[i].ToLower().Substring(m, 1));
        //        char rightLetter = char.Parse(right[j].ToLower().Substring(m, 1));
        //        if (i > left.Length - 1)
        //        {
        //            result[k] = right[j];
        //            j++;
        //        }
        //        else if (j > right.Length - 1)
        //        {
        //            result[k] = left[i];
        //            i++;
        //        }
        //        else if (leftLetter > rightLetter)
        //        {
        //            result[k] = right[j];
        //            if (j + 1 < right.Length)
        //            {
        //                j++;
        //            }
        //            else
        //            {
        //                result[k + 1] = left[i];
        //                break;
        //            }
        //        }
        //        else if (leftLetter < rightLetter)
        //        {
        //            result[k] = left[i];
        //            if (i + 1 < left.Length)
        //            {
        //                i++;
        //            }
        //            else
        //            {
        //                result[k + 1] = right[j];
        //                break;
        //            }
        //        }
        //        else if (leftLetter == rightLetter)
        //        {
        //            m++;
        //            while (leftLetter == rightLetter && m < 1)
        //            {
        //                leftLetter = char.Parse(left[i].Substring(m, 1));
        //                rightLetter = char.Parse(right[j].Substring(m, 1));
        //            }
        //            if (leftLetter > rightLetter)
        //            {
        //                result[k] = right[j];
        //                if (j + 1 < right.Length)
        //                {
        //                    j++;
        //                }
        //                else
        //                {
        //                    result[k + 1] = left[i];
        //                    break;
        //                }
        //            }
        //            else if (leftLetter < rightLetter)
        //            {
        //                result[k] = left[i]; if (i + 1 < left.Length)
        //                {
        //                    i++;
        //                }
        //                else
        //                {
        //                    result[k + 1] = right[j];
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
    }
}
