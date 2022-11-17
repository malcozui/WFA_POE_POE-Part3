using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_POE
{
    internal class GameEngine
    {
        private Map gameMap;
        private Shop shop;
        //Map TileType icons
        private static readonly string HERO = "ඞ", EMPTY = "░", SWAMP_CREATURE = "👾", OBSTACLE = "◙", GOLD = "©" , MAGE = "🧙‍", LEADER = "🦹", DAGGER = "🗡", LONGSWORD = "🔪", LONGBOW = "🏹", RIFLE = "🔫"; 

        public GameEngine()
        {
            gameMap = new Map(15, 20, 15, 20, 5, 5, 5);
            shop = new Shop(gameMap.GameHero);
        }

        #region Properties
        
        public Map GameMap { get => gameMap; }
        public Shop GameShop { get => shop; }

        #endregion

        #region Methods 

        public bool MovePlayer(Character.Movement direction)  // Player movement
        {
            //checks if the move is valid
            if (gameMap.GameHero.ReturnMove(direction) == direction)
            {
                switch (direction)
                {
                    case Character.Movement.Up:
                        Item? item = gameMap.GetItemAtPosition(gameMap.GameHero.Y - 1, gameMap.GameHero.X);
                        if (item is not null)
                        {
                            gameMap.GameHero.Pickup(item);
                        }
                        break;
                    case Character.Movement.Down:
                        Item? item2 = gameMap.GetItemAtPosition(gameMap.GameHero.Y + 1, gameMap.GameHero.X);
                        if (item2 is not null)
                        {
                            gameMap.GameHero.Pickup(item2);
                        }
                        break;
                    case Character.Movement.Left:
                        Item? item3 = gameMap.GetItemAtPosition(gameMap.GameHero.Y, gameMap.GameHero.X - 1);
                        if (item3 is not null)
                        {
                            gameMap.GameHero.Pickup(item3);
                        }
                        break;
                    case Character.Movement.Right:
                        Item? item4 = gameMap.GetItemAtPosition(gameMap.GameHero.Y, gameMap.GameHero.X + 1);
                        if (item4 is not null)
                        {
                            gameMap.GameHero.Pickup(item4);
                        }
                        break;
                }
                //Moves the player in the requested direction
                gameMap.GameHero.Move(direction);
                
                gameMap.GameMap[gameMap.GameHero.Y, gameMap.GameHero.X] = new Hero(gameMap.GameHero.X, gameMap.GameHero.Y, gameMap.GameHero.Hp, gameMap.GameHero.MaxHp);
                switch (direction)
                {
                    //makes the tile the player was in empty after they leave.
                    case Character.Movement.Up:
                        gameMap.GameMap[gameMap.GameHero.Y + 1, gameMap.GameHero.X] = new EmptyTile(gameMap.GameHero.X, gameMap.GameHero.Y);
                        break;
                    case Character.Movement.Down:
                        gameMap.GameMap[gameMap.GameHero.Y - 1, gameMap.GameHero.X] = new EmptyTile(gameMap.GameHero.X, gameMap.GameHero.Y);
                        break;
                    case Character.Movement.Left:
                        gameMap.GameMap[gameMap.GameHero.Y, gameMap.GameHero.X + 1] = new EmptyTile(gameMap.GameHero.X, gameMap.GameHero.Y);
                        break;
                    case Character.Movement.Right:
                        gameMap.GameMap[gameMap.GameHero.Y, gameMap.GameHero.X - 1] = new EmptyTile(gameMap.GameHero.X, gameMap.GameHero.Y);
                        break;
                }
                gameMap.UpdateVision();
                return true;
            }
            else
            {
                gameMap.UpdateVision();
                return false;
            }

        }

        public void MoveEnemies(Character.Movement direction = Character.Movement.NoMovement)
        {
            for (int i = 0; i < gameMap.GameEnemies.Length; i++)
            {
                if (gameMap.GameEnemies[i].IsDead()) return;


                direction = gameMap.GameEnemies[i].ReturnMove(direction);

                switch (direction)
                {
                    case Character.Movement.Up:
                        Item? item = gameMap.GetItemAtPosition(gameMap.GameEnemies[i].Y - 1, gameMap.GameEnemies[i].X);
                        if (item is not null)
                        {
                            gameMap.GameEnemies[i].Pickup(item);
                        }
                        break;
                    case Character.Movement.Down:
                        Item? item2 = gameMap.GetItemAtPosition(gameMap.GameEnemies[i].Y + 1, gameMap.GameEnemies[i].X);
                        if (item2 is not null)
                        {
                            gameMap.GameEnemies[i].Pickup(item2);
                        }
                        break;
                    case Character.Movement.Left:
                        Item? item3 = gameMap.GetItemAtPosition(gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].X - 1);
                        if (item3 is not null)
                        {
                            gameMap.GameEnemies[i].Pickup(item3);
                        }
                        break;
                    case Character.Movement.Right:
                        Item? item4 = gameMap.GetItemAtPosition(gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].X + 1);
                        if (item4 is not null)
                        {
                            gameMap.GameEnemies[i].Pickup(item4);
                        }
                        break;
                }
                //Moves the enemies in the requested direction
                gameMap.GameEnemies[i].Move(direction);
                gameMap.GameMap[gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].X] = gameMap.GameEnemies[i];
                
                switch (direction)
                {
                    //makes the tile the enemy was in empty after they leave.
                    case Character.Movement.Up:
                        gameMap.GameMap[gameMap.GameEnemies[i].Y + 1, gameMap.GameEnemies[i].X] = new EmptyTile(gameMap.GameEnemies[i].X, gameMap.GameEnemies[i].Y);
                        break;
                    case Character.Movement.Down:
                        gameMap.GameMap[gameMap.GameEnemies[i].Y - 1, gameMap.GameEnemies[i].X] = new EmptyTile(gameMap.GameEnemies[i].X, gameMap.GameEnemies[i].Y);
                        break;
                    case Character.Movement.Left:
                        gameMap.GameMap[gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].X + 1] = new EmptyTile(gameMap.GameEnemies[i].X, gameMap.GameEnemies[i].Y);
                        break;
                    case Character.Movement.Right:
                        gameMap.GameMap[gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].X - 1] = new EmptyTile(gameMap.GameEnemies[i].X, gameMap.GameEnemies[i].Y);
                        break;
                }
            }
        }

        public void EnemiesAttack()
        {
            for (int i = 0; i < gameMap.GameEnemies.Length; i++)
            {
                if (gameMap.GameEnemies[i].IsDead()) continue;
                switch (gameMap.GameEnemies[i])
                {
                    case Mage:
                        //attacking player
                        gameMap.GameEnemies[i].Attack(gameMap.GameHero);
                        //attacking other enemies
                        for (int j = 0; j < gameMap.GameEnemies.Length; j++)
                        {
                            //prevents mages from killing themselves, but not other mages
                            if (gameMap.GameEnemies[i] == gameMap.GameEnemies[j]) continue;
                            //attacking the enemy 
                            gameMap.GameEnemies[i].Attack(gameMap.GameEnemies[j]);

                            if (gameMap.GameEnemies[j].IsDead())
                            {
                                gameMap.GameMap[gameMap.GameEnemies[j].Y, gameMap.GameEnemies[j].X] = new EmptyTile(gameMap.GameEnemies[j].X, gameMap.GameEnemies[j].Y);
                                
                                //loot the character they killed if they're in range.
                                if (gameMap.GameEnemies[i].CheckRange(gameMap.GameEnemies[j])) gameMap.GameEnemies[i].Loot(gameMap.GameEnemies[j]);
                            }
                        }
                        break;
                    default:
                        gameMap.GameEnemies[i].Attack(gameMap.GameHero);
                        break;
                }
                if (gameMap.GameEnemies[i].IsDead())
                {
                    //deletes the dead enemys by making their Tile blank
                    gameMap.GameMap[gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].X] = new EmptyTile(gameMap.GameEnemies[i].X, gameMap.GameEnemies[i].Y);
                }
            }
        }

        public override string ToString() // Display method
        {
            StringBuilder sb = new();
            for (int i = 0; i < gameMap.GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < gameMap.GameMap.GetLength(1); j++)
                {
                    switch (gameMap.GameMap[i, j])
                    {
                        case Hero:
                            sb.Append(HERO);
                            break;
                        case SwampCreature:
                            sb.Append(SWAMP_CREATURE);
                            break;
                        case Mage:
                            sb.Append(MAGE);
                            break;
                        case Leader:
                            sb.Append(LEADER);
                            break;
                        case RangedWeapon rw:
                            if (rw.WeaponType == "Rifle") sb.Append(RIFLE);
                            else sb.Append(LONGBOW);
                            break;
                        case MeleeWeapon mw:
                            if (mw.WeaponType == "Dagger") sb.Append(DAGGER);
                            else sb.Append(LONGSWORD);
                            break;
                        case Obstacle:
                            sb.Append(OBSTACLE);
                            break;
                        case EmptyTile:
                            sb.Append(EMPTY);
                            break;
                        case Gold:
                            sb.Append(GOLD);
                            break;
                    }
                    sb.Append(' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        #endregion
    }
}
