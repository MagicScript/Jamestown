using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Game
    {
        private List<Settlement> settlements_ = new List<Settlement>();
        public IEnumerable<Settlement> Settlements
        {
            get { return settlements_.AsEnumerable(); }
        }

        public Game()
        {
            settlements_.Add(new Settlement("Jamestown", new Map(1000, 1000, 10, 5)));
        }
    }
}
