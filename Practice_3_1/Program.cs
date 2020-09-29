using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3_1
{
    class Program
    {
        static int[,] dir = new int[8,2] { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, 1 }, };
        static void FindRiver(ref int[,] map, ref bool[,] map_explored, int current_row, int current_col)
        {
            map_explored[current_row, current_col] = true;
            for(int i=0; i<8; i++)
            {
                int next_row = current_row + dir[i, 0];
                int next_col = current_col + dir[i, 1];
                if(next_row >=0 && next_col >=0 && next_row <map.GetLength(0) && next_col < map.GetLength(1)){ //if in bound

                    //if is water and not explored
                    if (map[next_row, next_col] == 1 && !map_explored[next_row, next_col])
                    {
                        //explore it
                        FindRiver(ref map, ref map_explored, next_row, next_col);
                    }
                }
                else
                {
                    continue;
                }
            }
            return;
            
        }
        static void Main(string[] args)
        {
            int row, col = 0;
            row = int.Parse(Console.ReadLine());
            col = int.Parse(Console.ReadLine());

            int[,] map = new int[row, col];
            bool[,] map_explored = new bool[row, col];
            for (int i=0; i<row; i++)
            {
                string str = Console.ReadLine();
                for(int j=0; j<col; j++) {
                    char x = str[j];
                    if (x == '#')
                    {
                        map[i, j] = 1;
                    }
                    else if(x == '*')
                    {
                        map[i, j] = 0;
                    }
                    map_explored[i, j] = false;
                }
                
            }
            

            int num_of_rivers = 0;
            for(int i=0; i<row; i++)
            {
                for(int j=0; j<col; j++)
                {
                    if(map[i,j] == 1 && !map_explored[i,j])
                    {
                        num_of_rivers++;
                        FindRiver(ref map, ref map_explored, i, j);
                    }
                }
            }
            

            Console.WriteLine(num_of_rivers);
           
            Console.ReadKey();
        }
    }
}
