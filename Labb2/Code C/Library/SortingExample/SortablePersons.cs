using System.Collections.Generic;
using Library.SortingExample.Libs.Common;

namespace Library.SortingExample
{
    public class SortablePersons
    {
        private readonly List<Person> _persons;

        public SortablePersons(ISort sort)
        {
            Sort = sort;
            _persons = new List<Person>();
        }

        public ISort Sort { get; set; }

        public void Add(Person person)
        {
            _persons.Add(person);
        }

        public void Clear()
        {
            _persons.Clear();
        }

        public List<Person> Sort()
        {
            List<Person> sortedPersons = Sort.Sort(_persons);
            return sortedPersons;
        }
    }
}
