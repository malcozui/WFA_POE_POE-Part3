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
        public int Dmg { get => dmg; }
        public virtual int Range { get => range;  }
        public int Durability { get => durability; set => durability = value; }
        public int Cost { get => cost; }
        public string WeaponType { get => weaponType; set => weaponType = value; }
        #endregion

        public override abstract string ToString();
    }
}
