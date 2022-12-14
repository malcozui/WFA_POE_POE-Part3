using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_POE
{
    internal class SwampCreature : Enemy
    {
        //hp is optional so that data can be written into it at creation time for saving and loading
        public SwampCreature(int x, int y, int hp = 10) : base(x, y, hp, 10, 1)
        {
            weapon = new MeleeWeapon(MeleeWeapon.Type.Dagger);
            goldAmount = 1;
        }

        public override Movement ReturnMove(Movement move = Movement.NoMovement) // Check movemnet
        {
            int randomDirection = 0;
            bool loop = true;
            int blockedCount = 0;

            //checking if all 4 tiles are full
            for (int i = 0; i < charactermovement.Length; i++)
            {
                if (charactermovement[i] is not EmptyTile or Item) blockedCount++;
            }
            if (blockedCount >= 4) return Movement.NoMovement;

            //picking a tile
            while (loop)
            {
                randomDirection = rndm.Next(4);

                loop = !(charactermovement[randomDirection] is EmptyTile or Item);
            }
            // when loop false the enemy move
            return randomDirection switch
            {
                0 => Movement.Up,
                1 => Movement.Down,
                2 => Movement.Left,
                3 => Movement.Right,
                _ => Movement.NoMovement
            };
        }
    }
}
