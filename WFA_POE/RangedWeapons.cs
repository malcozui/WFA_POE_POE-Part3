using System;

namespace WFA_POE
{
    internal class RangedWeapon : Weapon
    {
        public enum Type
        {
            Longbow,
            Rifle
        }

        public RangedWeapon(Type weaponType, int x = -1, int y = -1) : base(x, y)
        {
            switch (weaponType)
            {
                case Type.Longbow:
                    this.weaponType = "Longbow";
                    durability = 4;
                    range = 2;
                    dmg = 4;
                    cost = 6;
                    break;
                case Type.Rifle:
                    this.weaponType = "Rifle";
                    durability = 3;
                    range = 3;
                    dmg = 5;
                    cost = 7;
                    break;
            }
        }
        public RangedWeapon(Type weaponType, int durability) : base(-1, -1)
        {
            switch (weaponType)
            {
                case Type.Longbow:
                    this.weaponType = "Longbow";
                    this.durability = durability;
                    range = 2;
                    dmg = 4;
                    cost = 6;
                    break;
                case Type.Rifle:
                    this.weaponType = "Rifle";
                    this.durability = durability;
                    range = 3;
                    dmg = 5;
                    cost = 7;
                    break;
            }
        }

        public override int Range { get => base.Range; }
        public override string ToString()
        {
            return weaponType;
        }
    }
}