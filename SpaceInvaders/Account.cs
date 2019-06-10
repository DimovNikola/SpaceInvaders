using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Account
    {
        private string name { get; set; }
        private int score { get; set; }

        public Account(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public override string ToString()
        {
            return name + " " + score.ToString();
        }
    }
}
