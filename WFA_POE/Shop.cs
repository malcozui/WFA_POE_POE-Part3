using System;

namespace WFA_POE
{
	public class Shop
	{
		private Weapon[] weapons;
		private Random random;
		private Character buyer;

		public Shop(Character buyer)
		{
			this.buyer = buyer;

			random = new Random();
		}
		
		
	}
}
