using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    /*abstract*/ class Cell
    {
        List<Agent> listag;
        ////Loại Ô ( Ô đó được thể hiện thuộc loại tác tử nào)
        //public virtual int KindCell { get; set; }

        ////vi tri của ô
        //public int X { get; set; }
        //public int Y { get; set; }

        //public Cell() {  }

        //public Cell(int xPos, int yPos, int k)
        //{
        //    X = xPos;
        //    Y = yPos;
        //    KindCell = k;
        //}

        //public abstract int NumAgofCell();
        //public abstract int KindOfCell();
        //public abstract void AddAgent(Agent a);
        //public abstract void RemoveAgent(Agent a);
        //public abstract List<Agent> ListAg();
        //Loại Ô ( Ô đó được thể hiện thuộc loại tác tử nào)
        public int KindCell { get; set; }

        //vi tri của ô
        public int X { get; set; }
        public int Y { get; set; }

        public Cell() { listag = new List<Agent>(); }

        public Cell(int xPos, int yPos, int k)
        {
            X = xPos;
            Y = yPos;
            KindCell = k;
        }

        public  int NumAgofCell(int kG)
        {
            Random r = new Random();
            if (kG == 1) return 1;
            else 
                return r.Next(10);

        }
        public  int KindOfCell() { return KindCell; }
        public  void AddAgent(Agent a) { listag.Add(a); }
        public  void RemoveAgent(Agent a) { listag.Remove(a); }
        public  List<Agent> ListAg() { return listag; }
    }
}
