using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_03
{
    internal class Seminar_solution
    {
        static void Point()
        {
            int[,] labirynth1 = new int[,]
                 {
                 {1, 1, 1, 0, 1, 0, 0 },
                 {1, 0, 0, 0, 0, 0, 1 },
                 {1, 0, 1, 1, 1, 0, 1 },
                 {0, 0, 0, 0, 1, 0, 0 },
                 {1, 1, 0, 0, 1, 1, 1 },
                 {1, 1, 1, 0, 1, 1, 1 },
                 {1, 1, 1, 0, 1, 1, 1 }
                 };

            Console.Write(Find(3, 3, labirynth1));
        }

        static int Find(int x, int y, int[,] array)
        {
            if (!IsEmpty(x, y, array))
                return 0;

            int count = 0;
            array[x, y] = 2;

            if (x == 0 && y == 0
                || x == 0 && y == array.GetLength(1) - 1
                || x == array.GetLength(0) - 1 && y == 0
                || x == array.GetLength(0) - 1 && y == array.GetLength(1) - 1)
                count += 2;
            else if (x == 0 || y == 0 || y == array.GetLength(1) - 1 || x == array.GetLength(0) - 1)
                count++;

            count += Find(x, y + 1, array);
            count += Find(x + 1, y, array);
            count += Find(x - 1, y, array);
            count += Find(x, y - 1, array);

            return count;
        }

        static bool IsEmpty(int x, int y, int[,] array)
        {
            if (x < 0 || x >= array.GetLength(0))
                return false;
            if (y < 0 || y >= array.GetLength(1))
                return false;
            return array[x, y] == 0;
        }

    }
}
