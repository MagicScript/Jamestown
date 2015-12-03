using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public enum PersonType
    {
        Colonist,
        Gentleman,
    }

    public enum Skill
    {
        Soldier,
        Carpentry,
        Masonry,
        Bricklaying,
        Tailoring,
        Seamanship,
        Fishing,
        Hunting,
        Farming,
        Blacksmithing
    }

    public enum Something
    {
        Captain,
        Master,
        Preacher,
        Surgeon
    }


    public class Person
    {
        public PersonType Type { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private Dictionary<Skill, int> skills_ = new Dictionary<Skill, int>();
        private ISet<Something> somethings_ = new HashSet<Something>();

        private Order workOrder_;
        public Order WorkOrder
        {
            get { return workOrder_; }
            set
            {
                if (workOrder_ != null)
                    workOrder_.RemovePerson(this);
                workOrder_ = value;
                if (workOrder_ != null)
                    workOrder_.AddPerson(this);
            }
        }

        public IEnumerable<Skill> Skills
        {
            get { return skills_.Keys; }
        }

        public IEnumerable<Something> Somethings
        {
            get { return somethings_; }
        }

        public Person(string first, string last, PersonType type, Skill[] skills = null, Something[] somethings = null)
        {
            FirstName = first;
            LastName = last;
            Type = type;

            if(skills != null)
            {
                foreach (var skill in skills)
                {
                    skills_.Add(skill, 3);
                }
            }
            if(somethings != null)
            {
                foreach(var s in somethings)
                {
                    somethings_.Add(s);
                }
            }
        }

        public Person(string first, string last, PersonType type, Something[] somethings)
        {
            FirstName = first;
            LastName = last;
            Type = type;
            
            if (somethings != null)
            {
                foreach (var s in somethings)
                {
                    somethings_.Add(s);
                }
            }
        }
    }
}
