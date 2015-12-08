using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Game
    {
        TreeManager treeManager = new TreeManager();

        private List<Settlement> settlements_ = new List<Settlement>();
        public IEnumerable<Settlement> Settlements
        {
            get { return settlements_.AsEnumerable(); }
        }

        public Game()
        {
            Counter<string> badTags = new Counter<string>();
            treeManager.LoadTreeTypesFromFile("treetypes.xml", badTags);

            settlements_.Add(new Settlement("Jamestown", new Map(5000, 5000, treeManager)));
        }

        public void ProcessTurn()
        {
            foreach(var s in settlements_)
            {
                s.ProcessTurn();
            }
        }
    }
}
