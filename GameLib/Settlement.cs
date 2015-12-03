using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Settlement
    {
        public string Name { get; set; }
        public Map Map { get; private set; }

        private List<Building> buildings_ = new List<Building>();
        public IEnumerable<Building> Buildings
        {
            get { return buildings_.AsEnumerable(); }
        }

        private List<Order> orders_ = new List<Order>();
        public IEnumerable<Order> Orders
        {
            get { return orders_.AsEnumerable(); }
        }

        public List<Person> persons_ = new List<Person>();
        public IEnumerable<Person> Persons
        {
            get { return persons_.AsEnumerable(); }
        }

        public Settlement(string name, Map map)
        {
            Name = name;
            Map = map;
            buildings_.Add(new Building(50, 50, 20, 20, 1));

            persons_.Add(new Person("Henry", "Adling", PersonType.Gentleman));
            persons_.Add(new Person("Jeremy", "Alicock", PersonType.Gentleman));
            persons_.Add(new Person("Grabriel", "Archer", PersonType.Gentleman));
            persons_.Add(new Person("John", "Asbie", PersonType.Colonist));
            persons_.Add(new Person("Benjamin", "Beast", PersonType.Gentleman));
            persons_.Add(new Person("Robert", "Behothland", PersonType.Gentleman));
            persons_.Add(new Person("Edward", "Brinto", PersonType.Colonist, new Skill[] { Skill.Masonry, Skill.Soldier }));
            persons_.Add(new Person("Edward", "Brookes", PersonType.Gentleman));
            persons_.Add(new Person("John", "Brookes", PersonType.Gentleman));
            persons_.Add(new Person("Edward", "Brown", PersonType.Gentleman));
            persons_.Add(new Person("James", "Brunfield", PersonType.Colonist));//boy
            persons_.Add(new Person("William", "Bruster", PersonType.Gentleman));
            persons_.Add(new Person("John", "Capper", PersonType.Colonist));
            persons_.Add(new Person("George", "Cassen", PersonType.Colonist));
            persons_.Add(new Person("Thomas", "Cassen", PersonType.Colonist));
            persons_.Add(new Person("William", "Cassen", PersonType.Colonist));
            persons_.Add(new Person("Ustis", "Clovill", PersonType.Gentleman));
            persons_.Add(new Person("Samuel", "Collier", PersonType.Colonist));//boy
            persons_.Add(new Person("Roger", "Cooke", PersonType.Gentleman));
            persons_.Add(new Person("Thomas", "Cooper", PersonType.Colonist));
            persons_.Add(new Person("Richard", "Crofts", PersonType.Gentleman));
            persons_.Add(new Person("Richard", "Dixon", PersonType.Gentleman));
            persons_.Add(new Person("John", "Dods", PersonType.Colonist, new Skill[] { Skill.Soldier }));
            persons_.Add(new Person("Thomas", "Emry", PersonType.Colonist, new Skill[] { Skill.Carpentry }));
            persons_.Add(new Person("Robert", "Fenton", PersonType.Gentleman));
            persons_.Add(new Person("George", "Flower", PersonType.Gentleman));
            persons_.Add(new Person("Robert", "Ford", PersonType.Gentleman));
            persons_.Add(new Person("Robert", "Frith", PersonType.Gentleman));
            persons_.Add(new Person("Stephen", "Galthrope", PersonType.Gentleman));
            persons_.Add(new Person("William", "Garret", PersonType.Colonist, new Skill[] { Skill.Bricklaying }));
            persons_.Add(new Person("George", "Golding", PersonType.Colonist));
            persons_.Add(new Person("Anthony", "Gosnold", PersonType.Gentleman));//Should there be two of these?
            persons_.Add(new Person("Bartholomew", "Gosnold", PersonType.Gentleman, new Something[] { Something.Captain }));
            persons_.Add(new Person("Thomas", "Gower", PersonType.Gentleman));
            persons_.Add(new Person("Edward", "Harrington", PersonType.Gentleman));
            persons_.Add(new Person("John", "Herd", PersonType.Colonist, new Skill[] { Skill.Bricklaying }));
            persons_.Add(new Person("Nicholas", "Houlgrave", PersonType.Gentleman));
            persons_.Add(new Person("Robert", "Hunt", PersonType.Gentleman, new Something[] { Something.Master, Something.Preacher }));
            persons_.Add(new Person("Thomas", "Jacob", PersonType.Colonist, new Skill[] { Skill.Soldier }));
            persons_.Add(new Person("William", "Johnson", PersonType.Colonist));
            persons_.Add(new Person("George", "Kendall", PersonType.Gentleman, new Something[] { Something.Captain }));//Councilor
            persons_.Add(new Person("Ellis", "Kingston", PersonType.Gentleman));
            persons_.Add(new Person("William", "Laxton", PersonType.Colonist, new Skill[] { Skill.Carpentry }));
            persons_.Add(new Person("John", "Laydon", PersonType.Colonist, new Skill[] { Skill.Carpentry }));
            persons_.Add(new Person("William", "Loue", PersonType.Colonist, new Skill[] { Skill.Soldier, Skill.Tailoring }));
            persons_.Add(new Person("John", "Martin", PersonType.Gentleman, new Something[] { Something.Captain }));//Senior, Councilor
            persons_.Add(new Person("John", "Martin", PersonType.Gentleman));//Junior
            persons_.Add(new Person("George", "Martin", PersonType.Gentleman));
            persons_.Add(new Person("Francis", "Midwinter", PersonType.Gentleman));
            persons_.Add(new Person("Edward", "Morish", PersonType.Gentleman));
            persons_.Add(new Person("Matthew", "Morton", PersonType.Colonist, new Skill[] { Skill.Seamanship }));
            persons_.Add(new Person("Thomas", "Mounslie", PersonType.Colonist));
            persons_.Add(new Person("Thomas", "Mouton", PersonType.Gentleman));
            persons_.Add(new Person("Richard", "Mouton", PersonType.Colonist));//boy
            persons_.Add(new Person("Nathaniel", "Peacock", PersonType.Colonist));//boy
            persons_.Add(new Person("Robert", "Penington", PersonType.Gentleman));
            persons_.Add(new Person("George", "Percy", PersonType.Gentleman, new Something[] { Something.Master }));
            persons_.Add(new Person("Drue", "Pickhouse", PersonType.Gentleman));
            persons_.Add(new Person("Edward", "Posing", PersonType.Colonist, new Skill[] { Skill.Carpentry }));
            persons_.Add(new Person("Nathaniel", "Powell", PersonType.Gentleman));
            persons_.Add(new Person("Jonas", "Profit", PersonType.Colonist, new Skill[] { Skill.Fishing }));
            persons_.Add(new Person("John", "Ratcliffe", PersonType.Gentleman, new Something[] { Something.Captain }));//Councilor
            persons_.Add(new Person("James", "Read", PersonType.Colonist, new Skill[] { Skill.Soldier, Skill.Blacksmithing }));
            persons_.Add(new Person("John", "Robinson", PersonType.Gentleman));
            persons_.Add(new Person("William", "Rods", PersonType.Colonist));
            persons_.Add(new Person("Thomas", "Sands", PersonType.Gentleman));
            persons_.Add(new Person("John", "Short", PersonType.Gentleman));
            persons_.Add(new Person("Eward", "Short", PersonType.Colonist));
            persons_.Add(new Person("Richard", "Simons", PersonType.Gentleman));
            persons_.Add(new Person("Nicholas", "Skot", PersonType.Colonist));
            persons_.Add(new Person("Robert", "Small", PersonType.Colonist, new Skill[] { Skill.Carpentry }));
            persons_.Add(new Person("William", "Smethes", PersonType.Colonist));
            persons_.Add(new Person("John", "Smith", PersonType.Gentleman, new Something[] { Something.Captain }));
            persons_.Add(new Person("Francis", "Snarsborough", PersonType.Gentleman));
            persons_.Add(new Person("John", "Stevenson", PersonType.Gentleman));
            persons_.Add(new Person("Thomas", "Studley", PersonType.Gentleman));
            persons_.Add(new Person("William", "Tankard", PersonType.Gentleman));
            persons_.Add(new Person("Henry", "Tavin", PersonType.Colonist));
            persons_.Add(new Person("Kellam", "Throgmorton", PersonType.Gentleman));
            persons_.Add(new Person("Anas", "Todkill", PersonType.Colonist, new Skill[] { Skill.Soldier }));
            persons_.Add(new Person("William", "Vnger", PersonType.Colonist));
            persons_.Add(new Person("John", "Waller", PersonType.Gentleman));
            persons_.Add(new Person("George", "Walker", PersonType.Gentleman));
            persons_.Add(new Person("Thomas", "Webbe", PersonType.Gentleman));
            persons_.Add(new Person("William", "White", PersonType.Colonist));
            persons_.Add(new Person("William", "Wilkinson", PersonType.Gentleman, new Something[] { Something.Surgeon }));
            persons_.Add(new Person("Edward Maria", "Wingfield", PersonType.Gentleman, new Something[] { Something.Master }));//Councilor
            persons_.Add(new Person("Thomas", "Wotton", PersonType.Gentleman, new Something[] { Something.Surgeon }));
        }

        public Building GetBuildingOn(int x, int y)
        {
            foreach(var b in buildings_)
            {
                if (x >= b.X && x < b.X + b.Width && y >= b.Y && y < b.Y + b.Height)
                    return b;
            }
            return null;
        }

        public ZonedOrder GetZoneOn(int x, int y)
        {
            foreach (var o in orders_)
            {
                ZonedOrder zo = o as ZonedOrder;
                if(zo != null && x >= zo.X && x < zo.X + zo.Width && y >= zo.Y && y < zo.Y + zo.Height)
                    return zo;
            }
            return null;
        }

        public void AddOrder(Order order)
        {
            orders_.Add(order);
        }

        public void CancelOrder(Order order)
        {
            orders_.Remove(order);
            order.Clear();
        }

        internal void ProcessTurn()
        {
            List<Order> remaining = new List<Order>();
            foreach(var order in orders_)
            {
                order.ProcessTurn();
                if (order.GetWorkLeft() > 0)
                { 
                    remaining.Add(order);
                }
                else
                {
                    order.Clear();
                }
            }
            orders_ = remaining;
        }
    }
}
