using System;

namespace WFA_POE
{
    public class MeleeWeapon : Weapon
    {

        public enum Type
        {
            Longsword,
            Dagger
        }


        public MeleeWeapon(Type weaponType, int x = -1, int y = -1) : base(x, y)
        {
            switch (weaponType)
            {
                case Type.Longsword:
                    this.weaponType = "Longsword";
                    durability = 6;
                    dmg = 4;
                    cost = 3;
                    break;
                case Type.Dagger:
                    this.weaponType = "Dagger";
                    durability = 10;
                    dmg = 3;
                    cost = 3;
                    break;
            }
        }
        public MeleeWeapon(Type weaponType, int durability) : base(-1, -1)
        {
            switch (weaponType)
            {
                case Type.Longsword:
                    this.weaponType = "Longsword";
                    this.durability = durability;
                    dmg = 4;
                    cost = 3;
                    break;
                case Type.Dagger:
                    this.weaponType = "Dagger";
                    this.durability = durability;
                    dmg = 3;
                    cost = 3;
                    break;
            }
        }
        public override int Range { get => 1; }
        public override string ToString()
        {
            return weaponType;
        }
    }
}