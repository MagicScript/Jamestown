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
            foreach(var p in assignedPersons_)
            {
                p.WorkOrder = null;
            }
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
