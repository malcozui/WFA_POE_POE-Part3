using System;

namespace WFA_POE
{
	public class Shop
	{
		private Weapon[] weapons;
		private Random rndm;
		private Character buyer;

		public Shop(Character buyer)
		{
            this.buyer = buyer;

            rndm = new Random();
            weapons = new Weapon[3];
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i] = RandomWeapon();
            }
        }
		
		private Weapon RandomWeapon()
		{
			return (rndm.Next(4)) switch
			{
				0 => new RangedWeapon(RangedWeapon.Type.Longbow),
				1 => new RangedWeapon(RangedWeapon.Type.Rifle),
				2 => new MeleeWeapon(MeleeWeapon.Type.Longsword),
				3 => new MeleeWeapon(MeleeWeapon.Type.Dagger),

                //unreachable but it doesnt think so hence it being here, this will never be called
                _ => new RangedWeapon(RangedWeapon.Type.Rifle) 
            }; 
		}

		public void Buy(int index)
		{
			buyer.GoldAmount -= weapons[index].Cost;
			buyer.Pickup(weapons[index]);
			weapons[index] = RandomWeapon();
		}

		public bool CanBuy(int index)
		{
			return (weapons[index].Cost < buyer.GoldAmount);
		}

		public string DisplayWeapon(int index)
		{
			return $"Buy {weapons[index].WeaponType} ({weapons[index].Cost} Gold)";
		}
		
	}
}
