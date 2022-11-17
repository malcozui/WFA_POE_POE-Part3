using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_POE
{
    public abstract class Character : Tile
    {
        protected int hp;
        protected int maxHp;
        protected int damage;
        protected int goldAmount;
        protected Tile[] charactermovement = new Tile[4];
        protected Weapon? weapon;
        public enum Movement  // Player movement
        {
            Up,
            Down,
            Left,
            Right,
            NoMovement
        }

        public Character(int x, int y, int hp, int maxHp, int damage) : base(x, y)
        {
            this.hp = hp;
            this.maxHp = maxHp;
            this.damage = damage;
        }


        #region Properties

        public int Hp { get { return hp; } set { hp = value; } }
        public int MaxHp { get { return maxHp; } set { maxHp = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public int GoldAmount { get { return goldAmount; } set { goldAmount = value; } }
        public Tile[] Charactermovement { get { return charactermovement; } set { charactermovement = value; } }
        public Weapon WeaponUsed { get { return weapon; } set { weapon = value; } }

        #endregion

        #region Methods

        public virtual void Attack(Character target)
        {
            //returns from the attack if the attacker is too far to attack successfully
            if (!CheckRange(target)) return;
            //damages the target by the attackers damage value.
            if (weapon is null) target.hp -= this.damage;
            else
            {
                target.hp -= weapon.Dmg;
                //using durability of weapons
                weapon.Durability -= 1;
                if (weapon.Durability <= 0)
                {
                    weapon = null;
                }
            }

        }

        public bool IsDead()
        {
            //returns the corresponding bool if player health is below or equal to 0
            return (Hp <= 0);
        }

        public virtual bool CheckRange(Character target)
        {
            if (weapon is null) return (DistanceTo(target) <= 1);
            else return (DistanceTo(target) <= weapon.Range);


        }

        public int DistanceTo(Character target)
        {
            int xDis = Math.Abs(target.X - this.X);  //this.x is who is calling class  target.x is we want the distance from
            int yDis = Math.Abs(target.Y - this.Y);  //this.y is who is calling class  target.y is we want the distance from
            return xDis + yDis;
        }

        public void Move(Movement move)
        {
            switch (move)
            {
                case Movement.Up:
                    this.Y -= 1;
                    break;
                case Movement.Down:
                    this.Y += 1;
                    break;
                case Movement.Left:
                    this.X -= 1;
                    break;
                case Movement.Right:
                    this.X += 1;
                    break;

                case Movement.NoMovement:
                    break;
            }
        }
        

        public void Pickup(Item i)
        {
            switch (i)
            {
                case Gold tmp:
                    goldAmount += tmp.GoldAmount;
                    break;
                default:
                    Equip((Weapon)i);
                    break;
            }
        }

        private void Equip(Weapon w)
        {
            weapon = w;
        }

        public abstract Movement ReturnMove(Movement move = 0);

        public abstract override string ToString();

        #endregion



    }
}
