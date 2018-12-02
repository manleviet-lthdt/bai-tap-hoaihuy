﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Grid g = new Grid();
            int N=0;
            do
            {
                Console.WriteLine("The size of grid N<50");
                Console.Write("Enter the size of grid NxN: ");
                 N = int.Parse(Console.ReadLine());
            }
            while (N > 50);
            g.N = N; 
            //Tỷ lệ tác tử X / 0
            Console.WriteLine("Enter X/O: ");
            Console.Write("Enter X: ");
            g.Qx = int.Parse(Console.ReadLine());
            Console.Write("Enter O: ");
            g.Qo = int.Parse(Console.ReadLine());

            //Số ô trống
            Console.Write("Enter number of Empty cell: ");
             g.NumEmpty = int.Parse(Console.ReadLine());

            ////Nhập chỉ số hạnh phúc
            //Console.Write("Enter index of satisfied: ");
            // = int.Parse(Console.ReadLine());

            //Kiểu ô
            do
            {
                Console.WriteLine("Enter the kind of cell: ");
                Console.WriteLine("  1. Single Cell: ");
                Console.WriteLine("  2. Multi Cell: ");
                Console.Write("Enter 1 or 2: ");
                g.kindG = int.Parse(Console.ReadLine());
            } while (g.kindG != 1 && g.kindG != 2);

            //Xuất ra màn hình
            int[,] grid = new int[g.N, g.N];
            int dem = 0;
            for (int i = 0; i < g.N; i++)
            {

                for (int j = 0; j < g.N; j++)
                {
                    grid[i, j] = g.MakeList()[dem].KindCell;
                    dem++;
                }
            }
            
            GridUtility.DrawGrid(grid);

            Console.ReadKey();
        }
    }
}
