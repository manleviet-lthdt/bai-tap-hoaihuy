using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    class Agent
    {
        //Cấu tử
        public Agent() { }
        // Chỉ số hạnh phúc (satisfied)
        public int T 
        {
            set
            {
                if (value<0 ||value > 100)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(value)} must be between 0 -> 100.");
                T = value;
            }
            get
            {
                return T;
            }
        }
        //Loại tác tử
        public int KindAgent { get; set; }

        //Số lượng ô trong ô ( Ô đơn thì NumofCell=1)
        public int NumofCell { get; set; }
        //vi tri của ô
        public int X { get; set; }
        public int Y { get; set; }


        public Agent(int xPos, int yPos, int k,int t)
        {
            X = xPos;
            Y = yPos;
            KindAgent = k;
            T = t;
        }

        public int KindOfAgent()
        {
            return KindAgent;
        }

    }
}
