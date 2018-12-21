using System;
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
            int N = 0;
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

            //Số vị trí trống ( nhiều tác tử trong một ô)
            do
            {
                Console.Write("Enter the percent Empty of Total agent: ");
                g.Empty = int.Parse(Console.ReadLine());
            }
            while (g.Sasti < 0 || g.Sasti > 100);


            //Nhập chỉ số hạnh phúc
            do
            {
                Console.Write("Enter index of satisfied (0<Index<100): ");
                g.Sasti = double.Parse(Console.ReadLine());
            }
            while (g.Sasti < 0 || g.Sasti > 100);

            //Kiểu ô
            do
            {
                Console.WriteLine("Enter the kind of cell: ");
                Console.WriteLine("  1. Single Cell: ");
                Console.WriteLine("  2. Multi Cell: ");
                Console.Write("Enter 1 or 2: ");
                g.kindG = int.Parse(Console.ReadLine());
            } while (g.kindG != 1 && g.kindG != 2);


            Console.Clear();
            ////Xuất ra màn hình
            int[,] grid = new int[g.N, g.N];

            if (g.kindG == 1)
                Drawgird(grid, g, g.MakeListSingle());
            else
                Drawgird(grid, g, g.MakeListMulti());

            Console.WriteLine("If you want to continute,press Enter ");
            //Console.WriteLine(@"Press 'e' to exit");
            Console.ReadKey();

             Drawgird(grid, g, g.ChangeSingle(4,4));

     
            //int kindS = 1;
            //do
            //{
            //    Console.WriteLine("Enter the key to search: ");
            //    Console.WriteLine("  1.Ordinal: ");
            //    Console.WriteLine("  2.Random: ");
            //    kindS = int.Parse(Console.ReadLine());
            //} while (kindS != 1 && kindS != 2);

            //if (kindS==1)
            //{
            //    do
            //    {
            //        int j = 0;
            //        for (int i = 0; i < g.MakeListSingle().Count; i++)
            //        {
            //            if (g.kindG == 1)
            //                Drawgird(grid, g, g.ChangeSingle(i, j));

            //            //else
            //            //    Drawgird(grid, g, g.MakeListMulti());
            //        }
            //        Console.WriteLine("If you want to continute,press Enter ");
            //        Console.WriteLine(@"Press 'e' to exit");
            //        string t = Console.ReadLine();
            //        if (t.Equals("e"))
            //        {
            //            Environment.Exit(0);
            //        }
            //        Console.ReadKey();
            //        Console.Clear();
            //    }
            //    while (g.search.Check() == true);

            //}



        }

        public static void Drawgird(int [,] grid, Grid g,List<Cell> list)
        {
            int i = 0;
            int j = 0;

            foreach (Cell p in list)
            {
                grid[i, j] = p.KindOfCell();
                j++;
                if (j == g.N)
                { j = 0; i++; }
            }


            GridUtility.DrawGrid(grid);
        }



    }
}
