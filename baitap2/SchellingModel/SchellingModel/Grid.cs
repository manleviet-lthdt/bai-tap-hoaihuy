using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    class Grid
    {
        public List<Cell> listc;

        public int kindG;
        // Số ô trống
        public int NumEmpty { get; set; }
        // Kích thước của ma trân NxN
        public int N { get; set; }
        //Tỷ lệ 2 tác tử X/O
        public int Qx { get; set; }
        public int Qo { get; set; }

        public Grid()
        {
            listc = new List<Cell>();
        }

        public Grid(int e, int N, int x, int o, int k)
        {
            listc = new List<Cell>();
            NumEmpty = e;
            this.N = N;
            Qx = x;
            Qo = o;
            kindG = k;
        }
        // Số tác tử X và O được tính ra
        //public int NumAgentX()
        //{
        //    return (N * N - NumEmpty) * Qx / (Qx + Qo);
        //}

        //public int NumAgentO()
        //{
        //    return N - NumAgentX() - NumEmpty;
        //}



        // Tạo một list các tác tử nằm ngẫu nhiên
        public List<Cell> MakeList()
        {
            Cell c;
            if (kindG==1)
                c = new SingleCell();
            else
                c = new MultiCell();

            List<Cell> listc = new List<Cell>();

            //Biến đếm để đếm để kiểm tra số lượng tác tử và ô rỗng
            int demAgO = 0;
            int demAgX = 0;
            int demEmpty = 0;

            Random rand = new Random();

            //Số lượng các tác tử
            int NumAgentX = (N * N - NumEmpty) * Qx / (Qx + Qo);
            int NumAgentO = (N * N - NumEmpty) * Qx / (Qx + Qo);

            // Số lượng tác tử trong 1 ( ô đa tác tử )
            int NumAgofCell = rand.Next(100);
            if (c is MultiCell)
            {
                //Số lượng các tác tử được thay đổi
                NumAgentX = (N * N* NumAgofCell - NumEmpty) * Qx / (Qx + Qo);
                NumAgentO = (N * N* NumAgofCell - NumEmpty) * Qx / (Qx + Qo);
            }


            for (int i = 0; i < N; i++)
            {
                // Gán vị trí Y cho tác tử đồng thời chọn ngẫu nhiên loại tác tử 
                for (int j = 0; j < N; j++)
                {
                    if (c is MultiCell)
                    {
                        for (int m = 0; i < NumAgofCell; m++)
                        {
                            Agent b = new Agent();
                            c.AddAgent(b);
                        }
                        c.KindOfCell();
                    }

                    Agent a = new Agent();
                    
                    c.X = i;
                    c.Y = j;

                    // Tạo một dãy các tác tử theo thứ tự rỗng, X, O
                    if (demEmpty != NumEmpty)
                        c.KindCell = -1;
                    else
                    if (demAgX != NumAgentX)
                        c.KindCell = 1;
                    else c.KindCell = 0;

                    if (c.KindCell == -1)
                        demEmpty++;
                    if (c.KindCell == 1)
                        demAgX++;
                    if (c.KindCell == 0)
                        demAgO++;
                    c.AddAgent(a);
                    listc.Add(c);

                }

            }
            // Xáo trộn vị trí các tác tử
            // random numbers without repeating- base on stackoverflow
            List<int> possible = Enumerable.Range(0, N * N).ToList();
            List<int> listNumbers = new List<int>();
            List<Cell> listRand = new List<Cell>();

            for (int i = 0; i < N * N; i++)
            {
                int index = rand.Next(0, possible.Count);
                listRand.Add(listc[possible[index]]);
                possible.RemoveAt(index);
            }
            
            return listRand;
        }

    }
}
