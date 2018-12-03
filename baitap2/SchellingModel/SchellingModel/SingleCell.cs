using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    class SingleCell :Cell
    {
        Agent agent;

        public SingleCell() { }
        public SingleCell(int xPos, int yPos,int k)
            : base(xPos, yPos,k) { }

        public override void AddAgent(Agent a)
        {
            agent = a;
        }
        
        public override int KindOfCell()
        {
            return agent.KindAgent;
        }

        public override int NumAgofCell()
        {
            return 1;
        }

        public override void RemoveAgent(Agent a)
        {
            agent = null;
        }

    }
}
