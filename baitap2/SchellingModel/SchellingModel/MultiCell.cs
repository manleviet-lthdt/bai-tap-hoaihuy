using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    class MultiCell:Cell
    {
        public List<Agent> list;

        public MultiCell()
        {
            list = new List<Agent>();
        }

        public MultiCell(int xPos, int yPos, int k,int num)
            : base(xPos, yPos,k)
        {
            this.NumofCell=num;
        }

        public override void AddAgent(Agent a)
        {
            list.Add(a);
        }
        public override void RemoveAgent(Agent a)
        {
            list.Remove(a);
        }

        public override int KindOfCell()
        {
            int demX = 0;
            int demO = 0;
            foreach (Agent p in list)
            {
                if (p.KindAgent == 1)
                    demX++;
                if (p.KindAgent == 0)
                    demO++;
            }
            if (demO > demX)
                return 0;
            else return 1;
        }
        
 
    }
}
