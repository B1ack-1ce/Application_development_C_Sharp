using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Find find = new Find(5, 5, 5);
            find.PutRandomNumbers(200);
            int res = find.FindQueue(2, 2, 2);
            find.PrintMatrix();

            Console.WriteLine($"Количество выходов в лабиринте: {res}");
            //for (int i = 0; i < 5; i++)
            //    for (int k = 0; k < 5; k++)
            //        for (int j = 0; j < 5; j++)
            //            if (find.map[i, k, j] == 4)
            //                find.map[i, k, j] = 0;

            Console.ReadLine();
        }
    }
}
