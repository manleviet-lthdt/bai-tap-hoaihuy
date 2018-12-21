using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    abstract class Search
    {
        public Grid g;
        abstract public bool Check();
        abstract public bool SearchSingle(int i, int j);
        abstract public List<Agent> SearchMulti();

    }
}
