using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter6
{
    class Building
    {
        public int Floors;
        public int Area;
        public int Occupants;
        public string type;

        public int AreaPerPerson()
        {
            return Area / Occupants;
        }
        public int MaxOccupant(int minArea)
        {
            return Area / minArea;
        }
    }
}
