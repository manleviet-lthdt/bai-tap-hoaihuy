using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    class Grid
    {
        //public List<Cell> listc;
        public Cell c;
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
            return  N* N *c.NumAgofCell();
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

        public List<int> Possitive()
        {
            return Enumerable.Range(0, Total()).ToList();
        }

        //list chính lưu các Agent chưa random
        List<Agent> listag = new List<Agent>();
        //list chính lưu các cell chứa random
        List<Cell> listc = new List<Cell>();
        //list trộn các cell lại
        List<Cell> listRand = new List<Cell>();
        //list trộn các agent lại
        List<Agent> listRandAg = new List<Agent>();
        // list dùng để lưu một dãy số để trộn lại
        //List<int> possible;

        // các biến tạm để đếm tác tử
        int demAgX = 0;
        int demAgO = 0;
        int demAgNull = 0;

        //Hàm random
        Random rand = new Random();
        // Tạo một list các tác tử nằm ngẫu nhiên
        public List<Cell> MakeList()
        {

            for (int i = 0; i < N; i++)
            {
                // Gán vị trí Y cho tác tử đồng thời chọn ngẫu nhiên loại tác tử 
                for (int j = 0; j < N; j++)
                {
                    if (kindG == 1)
                        c = new SingleCell();
                    else
                        c = new MultiCell();

                    c.X = i;
                    c.Y = j;

                        for (int m = 0; m < c.NumAgofCell(); m++)
                        {
                            Agent a = new Agent();
                            if (demAgNull != NumEmpty)
                                a.KindAgent = -1;
                            else
                            if (demAgX != NumAgentX())
                                a.KindAgent = 1;
                            else a.KindAgent = 0;
                            // Tạo một dãy các tác tử theo thứ tự rỗng, X, O
                            if (a.KindAgent == -1)
                                demAgNull++;
                            if (a.KindAgent == 1)
                                demAgX++;
                            if (a.KindAgent == 0)
                                demAgO++;
                            if (c is SingleCell) c.AddAgent(a);
                            else listag.Add(a);
                        }

                    listc.Add(c);

                }

            }

            if(c is MultiCell)
            {
                // Xáo trộn vị trí các tác tử
                //random numbers without repeating-base on stackoverflow
                for (int i = 0; i < Total(); i++)
                {
                    int rd = rand.Next(0, Possitive().Count);
                    listRandAg.Add(listag[Possitive()[rd]]);
                    Possitive().RemoveAt(rd);
                }
 
                int index = 0;
                for (int i = 0; i < listRandAg.Count; i = i + c.NumAgofCell())
                {
                    int demX = 0;
                    int demO = 0;
                    for (int j = i; j < i + c.NumAgofCell(); j++)
                    {
                        if (listRandAg[j].KindAgent == 1)
                            demX++;
                        if (listRandAg[j].KindAgent == 0)
                            demO++;

                    }
                    if (demO > demX)
                        listc[index].KindCell = 0;
                    else if (demO == demX)
                        listc[index].KindCell = -1;
                    else listc[index].KindCell = 1;
                    index++;
                }
                return listc;
            }
            else
            {
                // Xáo trộn vị trí các tác tử
                //random numbers without repeating-base on stackoverflow
                for (int i = 0; i < N * N; i++)
                {
                    int index = rand.Next(0, Possitive().Count);
                    listRand.Add(listc[Possitive()[index]]);
                    Possitive().RemoveAt(index);
                }
                return listRand;
            }

           

            
        }

    }
}
