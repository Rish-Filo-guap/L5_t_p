using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_t_p
{
    public class Station
    {
        static int idCounter = 0; 
        public int id;
        public string name;
        public int x;
        public int y;
        public Color color;
        private static int GetId() { 
        return idCounter++;
        }
        public Station(string name,int x, int y, Color color)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            id = GetId();
            this.color = color;
        }
    }
    public class Traveltime { 
        public int a;
    }
}
