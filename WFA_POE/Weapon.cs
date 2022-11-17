using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_POE
{
    public abstract class Weapon : Item
    {
        protected int dmg;
        protected int range;
        protected int durability;
        protected int cost;
        protected string weaponType;

        public Weapon(int x, int y) : base(x, y)
        {
            //string.Empty to prevent weaponType being null when exiting the ctor.
            weaponType = string.Empty;
        }

        #region Properties
        public int Dmg { get => dmg; set => dmg = value; }
        public virtual int Range { get => dmg; set => dmg = value; }
        public int Durability { get => dmg; set => dmg = value; }
        public int Cost { get => dmg; set => dmg = value; }
        public int WeaponType { get => dmg; set => dmg = value; }
        #endregion

        public override abstract string ToString();
    }
}
