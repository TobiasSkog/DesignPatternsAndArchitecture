using System.Collections.Generic;
using Library.SortingExample.Libs.Common;

namespace Library.SortingExample.Libs
{
    public class SortByFirstName : ISort
    {
        public List<Person> Sort(List<Person> persons)
        {
            var sortedPersons = new List<Person>(persons);
            sortedPersons.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));

            return sortedPersons;
        }
    }
}
