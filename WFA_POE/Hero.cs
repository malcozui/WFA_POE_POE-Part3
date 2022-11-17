using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_POE
{
    internal class Hero : Character
    {
        public Hero(int x, int y, int hp, int maxHp) : base(x, y, hp, maxHp, 2)
        {
            
        }

        public override Movement ReturnMove(Movement move)
        {
            if (move == Movement.NoMovement) return move;
            return (Charactermovement[(int)move] is EmptyTile or Item) ? move : Movement.NoMovement;
        }

        public override string ToString() // Display hero stats
        {
            if (weapon is null)
            {
                return $"Player Stats: {Environment.NewLine}HP:{hp}/{maxHp} {Environment.NewLine}Current weapon: Bare Hands {Environment.NewLine}Weapon range: 1 {Environment.NewLine}Weapon damage: {Damage} {Environment.NewLine}[{x}, {y}]{Environment.NewLine}Gold Amount: {goldAmount}";
            }
            else
            {
                return $"Player Stats: {Environment.NewLine}HP:{hp}/{maxHp} {Environment.NewLine}Current weapon: {weapon.WeaponType} {Environment.NewLine}Weapon range: {weapon.Range} {Environment.NewLine}Weapon damage: {weapon.Dmg} {Environment.NewLine}[{x}, {y}]{Environment.NewLine}Gold Amount: {goldAmount}";

            }
        }
    }
}
