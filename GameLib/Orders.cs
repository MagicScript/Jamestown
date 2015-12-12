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

        internal virtual void ProcessDay()
        {
            
        }

        public virtual float GetWorkLeft()
        {
            return -1.0f;
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

        internal override void ProcessDay()
        {
            float workLeft = AssignedPersons.Count() * 5;
            if (workLeft <= 0)
                return;

            for(int i = X; i < X + Width; ++i)
            {
                for(int j = Y; j < Y + Height; ++j)
                {
                    Tree tree = Settlement.Map.GetTree(i, j);
                    if (tree != null && !tree.IsStump && workLeft >= tree.Diameter)
                    {
                        if(tree.IsLog)
                            Settlement.AddMaterial("Log", tree.GetLogCount());

                        Settlement.AddMaterial("Firewood", tree.CanopySize * tree.CanopySize * 3);
                        tree.Chop();

                        workLeft -= tree.Diameter;
                    }
                }
            }
        }

        public override float GetWorkLeft()
        {
            int assignedPersonCount = AssignedPersons.Count();
            if (assignedPersonCount <= 0)
                return -1;

            float workToDo = 0.0f;

            for (int i = X; i < X + Width; ++i)
            {
                for (int j = Y; j < Y + Height; ++j)
                {
                    Tree tree = Settlement.Map.GetTree(i, j);
                    if (tree != null && !tree.IsStump)
                    {
                        workToDo += tree.Diameter;
                    }
                }
            }
            return workToDo / (5.0f * assignedPersonCount);
        }
    }

    public class CutLogsOrder : ZonedOrder
    {

        public CutLogsOrder(Settlement settlement, int x, int y, int width, int height) : base(settlement, x, y, width, height)
        {
            Color = Color.Red;
            Name = "Cut Logs";
        }

        internal override void ProcessDay()
        {
            float workLeft = AssignedPersons.Count() * 5;
            if (workLeft <= 0)
                return;

            for (int i = X; i < X + Width; ++i)
            {
                for (int j = Y; j < Y + Height; ++j)
                {
                    Tree tree = Settlement.Map.GetTree(i, j);
                    if (tree != null && tree.IsLog && !tree.IsStump && workLeft >= tree.Diameter)
                    {
                        Settlement.AddMaterial("Firewood", tree.CanopySize * tree.CanopySize * 3);
                        Settlement.AddMaterial("Log", tree.GetLogCount());
                        tree.Chop();

                        workLeft -= tree.Diameter;
                    }
                }
            }
        }

        public override float GetWorkLeft()
        {
            int assignedPersonCount = AssignedPersons.Count();
            if (assignedPersonCount <= 0)
                return -1;

            float workToDo = 0.0f;

            for (int i = X; i < X + Width; ++i)
            {
                for (int j = Y; j < Y + Height; ++j)
                {
                    Tree tree = Settlement.Map.GetTree(i, j);
                    if (tree != null && tree.IsLog && !tree.IsStump)
                    {
                        workToDo += tree.Diameter;
                    }
                }
            }
            return workToDo / (5.0f * assignedPersonCount);
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
