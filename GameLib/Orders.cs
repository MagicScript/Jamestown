using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameLib
{
    public class Order
    {
        private ISet<Person> assignedPersons_ = new HashSet<Person>();
        public IEnumerable<Person> AssignedPersons
        {
            get { return assignedPersons_.AsEnumerable(); }
        }

        public Settlement Settlement { get; private set; }

        public string Name { get; set; }

        public Order(Settlement settlement)
        {
            Settlement = settlement;
        }


        protected internal void AddPerson(Person person)
        {
            assignedPersons_.Add(person);
        }

        protected internal void RemovePerson(Person person)
        {
            assignedPersons_.Remove(person);
        }

        protected internal void Clear()
        {
            foreach(var p in assignedPersons_.AsEnumerable().ToArray())
            {
                p.WorkOrder = null;
            }
        }

        internal virtual void ProcessTurn()
        {
            
        }

        public virtual int GetWorkLeft()
        {
            return -1;
        }
    }

    public class OrderType
    {

    }

    public class ZonedOrder : Order
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }

        public ZonedOrder(Settlement settlement, int x, int y, int width, int height) : base(settlement)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    public class ClearTreesOrder : ZonedOrder
    {

        public ClearTreesOrder(Settlement settlement, int x, int y, int width, int height) : base(settlement, x, y, width, height)
        {
            Color = Color.Red;
            Name = "Clear Trees";
        }

        internal override void ProcessTurn()
        {
            int workLeft = AssignedPersons.Count() * 3;
            if (workLeft <= 0)
                return;

            for(int i = X; i < X + Width; ++i)
            {
                for(int j = Y; j < Y + Height; ++j)
                {
                    if(Settlement.Map.GetTree(i, j) != null)
                    {
                        Settlement.Map.RemoveTree(i, j);
                        if (--workLeft == 0)
                            return;
                    }
                }
            }
        }

        public override int GetWorkLeft()
        {
            int assignedPersonCount = AssignedPersons.Count();
            if (assignedPersonCount <= 0)
                return -1;

            int workToDo = 0;

            for (int i = X; i < X + Width; ++i)
            {
                for (int j = Y; j < Y + Height; ++j)
                {
                    if (Settlement.Map.GetTree(i, j) != null)
                    {
                        ++workToDo;
                    }
                }
            }
            return (int)Math.Ceiling((double)workToDo / (3 * assignedPersonCount));
        }
    }

    public class HuntOrder : ZonedOrder
    {

        public HuntOrder(Settlement settlement, int x, int y, int width, int height) : base(settlement, x, y, width, height)
        {
            Color = Color.Purple;
            Name = "Hunt";
        }
    }
}
