using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_POE
{
    internal class Gold : Item 
    {
        private int goldAmount;
        private Random rndm = new Random();

        public Gold(int x, int y) : base(x, y)
        {
            goldAmount = rndm.Next(1, 6);
        }

        //gold has a setter so that it can be set back to its prevoius value when it is created in the loading section of the game.
        public int GoldAmount { get => goldAmount; set => goldAmount = value; } 

        public override string ToString()
        {
            return "Gold";
        }
    }

}
