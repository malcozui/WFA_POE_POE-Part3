using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_POE
{
    public abstract class Enemy : Character
    {
        public Random rndm = new();

        protected Enemy(int x, int y, int hp, int maxHp, int damage) : base(x, y, hp, maxHp, damage)
        {

        }

        #region Methods

        public override string ToString() // Display enemy stats
        {
            if (weapon is null)
            {
                return this switch
                {
                    SwampCreature => $"Bare Handed: Swamp Creature ({hp}/{maxHp}HP) at [{x}, {y}] ({damage})",
                    Mage => $"Bare Handed: Mage ({hp}/{maxHp}HP) at [{x}, {y}] ({damage})",
                    Leader => $"Bare Handed: Leader ({hp}/{maxHp}HP) at [{x}, {y}] ({damage})",
                    _ => $"This is unreachable but the ToString thinks otherwise",
                };
            }
            else
            {
                return this switch
                {
                    SwampCreature => $"Equiped: Swamp Creature ({hp}/{maxHp}HP) at [{x}, {y}] with {weapon.WeaponType} ({weapon.Durability} x {weapon.Dmg})",
                    Mage => $"Equiped: Mage ({hp}/{maxHp}HP) at [{x}, {y}] with {weapon.WeaponType} ({weapon.Durability} x {weapon.Dmg})",
                    Leader => $"Equiped: Leader ({hp}/{maxHp}HP) at [{x}, {y}] with {weapon.WeaponType} ({weapon.Durability} x {weapon.Dmg})",
                    _ => $"This is unreachable but the ToString thinks otherwise",
                };
            }
        }

        #endregion
    }
}
