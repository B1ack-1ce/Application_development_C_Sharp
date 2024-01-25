using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_03
{
    internal class Find
    {
        public int[,,] map;

        private int _width;
        private int _height;
        private int _depth;

        private const int visited = 4;
        private const int seen = 2;

        public Find(int[,,] matrix)
        {
            _width = matrix.GetLength(0);
            _height = matrix.GetLength(1);
            _depth = matrix.GetLength(2);
            map = matrix;
        }

        public Find(int width, int heigth, int depth)
        {
            _depth = depth;
            _width = width;
            _height = heigth;
            map = new int[width, heigth, depth];
        }

        private void SetMap(int x, int y, int z, int number)
        {
            if (x < 0 || x >= _width) return;
            if (y < 0 || y >= _height) return;
            if (z < 0 || z >= _depth) return;
            map[x, y, z] = number;
        }

        private bool IsEmpty(int x, int y, int z)
        {
            if (x < 0 || x >= _width) return false;
            if (y < 0 || y >= _height) return false;
            if (z < 0 || z >= _depth) return false;
            return map[x, y, z] == 0;
        }

        private int Exit(int coord, int border)
        {
            if(coord == 0 || coord == border - 1) return 1;
            return 0;
        }

        public int FindQueue(int pos_x, int pos_y, int pos_z)
        {
            int exits = 0;

            int x, y, z;

            SetMap(pos_x, pos_y, pos_z, seen);

            Queue<Coord> queue = new Queue<Coord>();
            
            queue.Enqueue(new Coord (pos_x, pos_y, pos_z));

            while(queue.Count > 0)
            {
                Coord coord = queue.Dequeue();

                x = coord._x;
                y = coord._y;
                z = coord._z;

                exits += Exit(x, _width) + Exit(y, _height) + Exit(z, _depth);

                SetMap(x, y, z, visited);

                if(IsEmpty(x + 1, y, z)) 
                {
                    queue.Enqueue(new Coord(x + 1, y, z));
                    SetMap(x + 1, y, z, seen);
                }

                if (IsEmpty(x - 1, y, z))
                {
                    queue.Enqueue(new Coord(x - 1, y, z));
                    SetMap(x - 1, y, z, seen);
                }

                if (IsEmpty(x, y + 1, z))
                {
                    queue.Enqueue(new Coord(x, y + 1, z));
                    SetMap(x, y + 1, z, seen);
                }

                if (IsEmpty(x, y - 1, z))
                {
                    queue.Enqueue(new Coord(x, y - 1, z));
                    SetMap(x, y - 1, z, seen);
                }

                if (IsEmpty(x, y, z + 1))
                {
                    queue.Enqueue(new Coord(x, y, z + 1));
                    SetMap(x, y, z + 1, seen);
                }

                if (IsEmpty(x, y, z - 1))
                {
                    queue.Enqueue(new Coord(x, y, z - 1));
                    SetMap(x, y, z - 1, seen);
                }
            }

            return exits;
        }

        public void PutRandomNumbers(int count)
        {
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                SetMap(rnd.Next(_width), rnd.Next(_height), rnd.Next(_depth), 1);
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    for (int k = 0; k < map.GetLength(2); k++)
                        Console.Write(map[i,j,k] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine(string.Join("", Enumerable.Repeat("*", map.GetLength(2) * 2)));
            }

        }
    }
}
