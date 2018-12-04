using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    class Grid
    {
        // Chứa các ô
        List<Cell> listc = new List<Cell>();
        public Cell c=new Cell();

        // loại lưới
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
            //listc = new List<Cell>();
        }

        public Grid(int e, int N, int x, int o, int k)
        {
            //listc = new List<Cell>();
            NumEmpty = e;
            this.N = N;
            Qx = x;
            Qo = o;
            kindG = k;
        }
        public int Total()
        {
            return N * N * c.NumAgofCell(kindG);
        }
        //Số tác tử X và O được tính ra
        public int NumAgentX()
        {

            return (Total() - NumEmpty) * Qx / (Qx + Qo);
        }

        public int NumAgentO()
        {

            return Total() - NumAgentX() - NumEmpty;
        }

        // các biến tạm để đếm tác tử
        int demAgX = 0;
        int demAgO = 0;
        int demAgNull = 0;

        //Hàm random
        Random rand = new Random();
        bool tx = false;
        bool to = false;
        bool tnull = false;

        public List<Agent> AddAgent()
        {
            for (int m = 0; m < c.NumAgofCell(kindG); m++)
            {
                c = new Cell();
                Agent a = new Agent();

                //Kiểm tra để tạo các tác tử ngẫu nhiên đúng số lượng
                if (tnull == false && to == false && tx == false)
                {
                    a.KindAgent = rand.Next(-1, 2);
                }

                if (tnull == true && to == false && tx == false)
                {
                    a.KindAgent = rand.Next(0, 2);
                }
                if (tnull == false && to == true && tx == false)
                {
                    do
                    {
                        a.KindAgent = rand.Next(-1, 2);
                    }
                    while (a.KindAgent != 0);

                }
                if (tnull == false && to == false && tx == true)
                {
                    a.KindAgent = rand.Next(-1, 1);
                }


                if (tnull == true && to == true && tx == false)
                {
                    a.KindAgent = 1;
                }

                if (tnull == true && to == false && tx == true)
                {
                    a.KindAgent = 0;
                }
                if (tnull == false && to == true && tx == true)
                {
                    a.KindAgent = -1;
                }
                //Đếm loại tác tử
                if (a.KindAgent == -1)
                    demAgNull++;
                if (a.KindAgent == 1)
                    demAgX++;
                if (a.KindAgent == 0)
                    demAgO++;
                //thay đổi biến để kiểm tra
                tnull = (demAgNull == NumEmpty) ? true : false;
                tx = (demAgX == NumAgentX()) ? true : false;
                to = (demAgO == NumAgentO()) ? true : false;

                c.AddAgent(a);
               
            }
            
            return c.ListAg();
        }
        // Lưu các tác tử
        List<Agent> listAg = new List<Agent>();
        // lưu loại ô
        public List<Agent> MakeListAgent()
        {
            for (int i = 0; i < N; i++)
            {
                for(int j=0;j<N; j++)
                {
                    // Gán vị trí Y cho tác tử đồng thời chọn ngẫu nhiên loại tác tử 
                    listAg.AddRange(AddAgent());
                }
            }
            
            return listAg;
        }
        //Lưu loại tác tử trường hợp đa tác tử trong một ô
        List<int> kind = new List<int>();
        public List<int> Kind()
        {

            for (int i = 0; i < N; i++)
            {
                // Gán vị trí Y cho tác tử đồng thời chọn ngẫu nhiên loại tác tử 
                for (int j = 0; j < N; j++)
                {
                    int demx = 0;
                    int demo = 0;
                    foreach (Agent p in AddAgent())
                    {
                        if (p.KindOfAgent() == 1)
                            demx++;
                        if (p.KindOfAgent() == 0)
                            demo++;
                    }

                    //Console.Write(demx + "," + demo + "  ");
                    if (demx > demo)
                        kind.Add(1);
                    if (demo > demx)
                        kind.Add(0);
                    if ((demx == demo) && (demx != 0 || demo != 0))
                        kind.Add(rand.Next(0, 2));
                    if (demo == demx && demo == 0)
                        kind.Add(-1);
                }

            }

            return kind;
        }

        public List<Cell> MakeListSingle()
        {

            int i = 0;
            int j = 0;
            //listc = new List<Cell>();
            foreach (Agent p in MakeListAgent())
            {
                c= new Cell(i, j, p.KindOfAgent());
                j++;
                if (j == N)
                {
                    i++;
                    j = 0;
                }
                listc.Add(c);
            }

            return listc;
        }
        public List<Cell> MakeListMulti()
        {
            int i = 0;
            int j = 0;
            //listc = new List<Cell>();
            foreach (int p in Kind())
            {
                c = new Cell(i, j, p);

                //Console.Write(i + "," + j + "," + p + "  ");
                j++;
                if (j == N)
                {
                    i++;
                    j = 0;
                }

                listc.Add(c);
            }

            return listc;
        }
       
            
        
    }
}
