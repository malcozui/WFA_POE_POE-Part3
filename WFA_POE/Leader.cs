using System;

namespace WFA_POE
{
	public class Leader : Enemy
	{
		private Tile? target;

        /// <summary>
        /// The constructor for the Leader Enemy object.
        /// </summary>
        /// <param name="x">The X position of the leader.</param>
        /// <param name="y">The Y position of the leader.</param>
        /// <param name="hp">An optional HP param for loading from data.</param>
        public Leader(int x, int y, int hp = 20) : base(x, y, hp, 20, 2)
        {
            weapon = new MeleeWeapon(MeleeWeapon.Type.Longsword);
            goldAmount = 2;
        }

        public Tile? Target { get => target; set => target = value; }

        public override Movement ReturnMove(Movement move = Movement.Up)
        {
            return Movement.NoMovement;
        }
    }
}
