using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Scores
    {
        public string name;
        public int points;
        public Scores(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }
}
