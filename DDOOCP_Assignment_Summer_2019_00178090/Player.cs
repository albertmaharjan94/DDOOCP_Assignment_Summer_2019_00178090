using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDOOCP_Assignment_Summer_2019_00178090
{
    class Player
    {
        string name;
        int score;
        public Player(string p)
        {
            name = p;
        }
        public Player()
        { }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }
    }
}
