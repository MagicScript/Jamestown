using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLib;

namespace Jamestown
{
    public partial class PersonList : UserControl
    {

        private IEnumerable<Person> persons_;
        public IEnumerable<Person> Persons
        {
            get { return persons_; }
            set
            {
                SetPersons(value);
            }
        }

        public IEnumerable<Person> SelectedPersons
        {
            get
            {
                foreach (DataGridViewRow row in dataView.Rows)
                {
                    if (row.Selected)
                        yield return (Person)row.Tag;
                }
            }
            set
            {
                foreach (DataGridViewRow row in dataView.Rows)
                {
                    row.Selected = value.Contains(row.Tag);
                }
            }
        }

        private void SetPersons(IEnumerable<Person> values)
        {
            if(values == null)
            {
                dataView.RowCount = 0;
                return;
            }

            dataView.RowCount = values.Count();
            IEnumerator<Person> persons = values.GetEnumerator();
            foreach(DataGridViewRow row in dataView.Rows)
            {
                persons.MoveNext();
                Person p = persons.Current;
                row.Tag = p;
                row.Cells[0].Value = string.Format("{0} {1}", p.FirstName, p.LastName);
                row.Cells[1].Value = string.Join(", ", p.Skills);
                row.Cells[2].Value = string.Join(", ", p.Somethings);
                row.Cells[3].Value = p.WorkOrder == null ? "None" : p.WorkOrder.Name;
            }
            persons_ = values;
        }

        public PersonList()
        {
            InitializeComponent();
        }
    }
}
