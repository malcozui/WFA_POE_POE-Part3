using System;

namespace WFA_POE
{
    internal class RangedWeapon : Weapon
    {
        public RangedWeapon(int x, int y) : base(x, y)
        {

        }

        public override int Range { get => base.Range; }
        public override string ToString()
        {
            return weaponType;
        }
    }
}