using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    abstract class Cell
    {
        public Cell() { }
        //Loại Ô ( Ô đó được thể hiện thuộc loại tác tử nào)
        public int KindCell { get; set; }
        //Số lượng ô trong ô ( Ô đơn thì NumofCell=1)
        public int NumofCell { get; set; }
        //vi tri của ô
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int xPos, int yPos, int k)
        {
            X = xPos;
            Y = yPos;
            KindCell = k;
        }

        public abstract int KindOfCell();


        public virtual void AddAgent(Agent a) { }
        public virtual void RemoveAgent(Agent a) { }

    }
}
