using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 15; i++)
            {
                ints.Add(rnd.Next(-15, 15));
            }

            FindThreeNumbers(0, ints.ToArray());
            Console.ReadLine();
        }

        /// <summary>
        /// Поиск трех чисел без дубликатов сумма которых равна искомому числу
        /// </summary>
        /// <param name="requiredNumber">Искомое число</param>
        /// <param name="numbers">Массив чисел</param>
        private static void FindThreeNumbers(int requiredNumber, int[] numbers) 
        {
            int[] nums = numbers.Distinct().OrderBy(n => n).ToArray();
            bool isFind = false;
            Console.WriteLine("Массив:\n" + string.Join(" | ", nums));

            Console.WriteLine($"\nИскомое число: {requiredNumber}");

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                        continue;

                    int temp = requiredNumber - (nums[i] + nums[j]);

                    if (nums.Contains(temp) && temp != nums[i] && temp != nums[j])
                    {
                        Console.WriteLine($"\nНайденные числа: {nums[i]} + {nums[j]} + {requiredNumber - (nums[i] + nums[j])} = {requiredNumber}");
                        isFind = true;
                        return;
                    }
                }
            }
            if(!isFind)
                Console.WriteLine("Числа не найдены");
        }
    }
}
