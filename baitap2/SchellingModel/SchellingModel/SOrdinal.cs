using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    class SOrdinal : Search
    {

        public override bool SearchSingle(int i,int j)
        {
            int dem = 0;
            int neibor = 0;
            if (i == (g.N) * j)
            {
                j++;
                neibor = 3;
                if(i<g.N)
                {
                    if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i + g.N].KindOfCell())
                        dem++;
                    neibor = 2;
                }
                   

                if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i + 1].KindOfCell())
                    dem++;

                if (i < (g.MakeListSingle().Count - g.N))
                {
                    if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i - g.N].KindOfCell())
                        dem++;
                    neibor = 2;
                }


            }
            else
            {
                if (i < g.N)
                {
                    if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i + g.N].KindOfCell())
                        dem++;
                    if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i - 1].KindOfCell())
                        dem++;
                    neibor = 2;
                    if(i!=g.N-1)
                    {
                        if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i + 1].KindOfCell())
                            dem++;
                        neibor = 3;
                    }
                }
                else
                {
                    if(i==(g.N)*j-1)
                    {
                        if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i - 1].KindOfCell())
                            dem++;
                        if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i - g.N].KindOfCell())
                            dem++;
                        neibor = 3;
                        if(i< g.MakeListSingle().Count - g.N)
                        {
                            if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i + g.N].KindOfCell())
                                dem++;
                            neibor = 2;
                        }
                            
                    }
                    else
                    {
                        if (i > g.MakeListSingle().Count - g.N)
                        {
                            if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i + 1].KindOfCell())
                                dem++;
                            if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i - g.N].KindOfCell())
                                dem++;
                            neibor = 3;
                        }
                        else
                        {
                            neibor = 4;
                            if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i + 1].KindOfCell())
                                dem++;
                            if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i - g.N].KindOfCell())
                                dem++;
                            if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i - 1].KindOfCell())
                                dem++;
                            if (g.MakeListSingle()[i].KindOfCell() == g.MakeListSingle()[i + g.N].KindOfCell())
                                dem++;

                        }
                    }
                }
                        
            }

            if (dem / neibor == g.Sasti)
                return true;
            else return false;
        }
        public override bool Check()
        {
            int i = 0;
            int j = 0;
            do
            {
                if (SearchSingle(i, j) == false)
                    return false;
                i++;

            }
            while (i > g.N*g.N - 1);
            return true;
        }
        public override List<Agent> SearchMulti()
        {
            throw new NotImplementedException();
        }
    }
}
