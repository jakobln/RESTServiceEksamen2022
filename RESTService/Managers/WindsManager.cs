using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTService.Managers
{
    public class WindsManager
    {
        //A simple int to keep track of ID's
        private static int _nextID = 1;

        private static List<Wind> _data = new List<Wind>()
        {
            new Wind { Id = _nextID++, Direction = "North", Speed = 1},
            new Wind { Id = _nextID++, Direction = "East", Speed = 0},
            new Wind { Id = _nextID++, Direction = "South", Speed = 1},
            new Wind { Id = _nextID++, Direction = "West", Speed = 2},
            new Wind { Id = _nextID++, Direction = "North", Speed = 0}
        };

        //Return a copy of the list
        public List<Wind> GetAll()
        {
            return new List<Wind>(_data);
        }

        //Adds an object to the list, and assign a unique ID
        public int Add(Wind newData)
        {
            newData.Id = _nextID++;
            _data.Add(newData);
            return newData.Id;
        }

    }
}
