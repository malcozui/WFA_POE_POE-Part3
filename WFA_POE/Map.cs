using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace WFA_POE
{
    internal class Map
    {
        private Tile[,] map;
        private Hero hero;
        private Enemy[] enemies;
        private int mapWidth, mapHeight;
        private Random rndm = new();
        private Item?[] items;

        /// <summary>
        /// The Constructor for the map object.
        /// </summary>
        /// <param name="minMapWidth">The inclusive minimum width of the map.</param>
        /// <param name="maxMapWidth">The exclusive maximum width of the map.</param>
        /// <param name="minMapHeight">The inclusive minimum height of the map.</param>
        /// <param name="maxMapHeight">The exclusive maximum height of the map.</param>
        /// <param name="enemyCount">The amount of enemies to spawn.</param>
        /// <param name="goldCount">The amount of gold to spawn.</param>
        /// <param name="weaponCount">The amount of weapons to spawn.</param>
        public Map(int minMapWidth, int maxMapWidth, int minMapHeight, int maxMapHeight, int enemyCount, int goldCount, int weaponCount)  
        {
            enemies = new Enemy[enemyCount];
            items = new Item[goldCount + weaponCount];

            mapWidth = rndm.Next(minMapWidth, maxMapWidth);
            mapHeight = rndm.Next(minMapHeight, maxMapHeight);
            
            map = new Tile[mapWidth, mapHeight];

            //Generate map boundry and inside with TileType.Obstacle and TileType.EmptyTile
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {

                    if ((i == 0 || i == mapWidth - 1) || (j == 0 || j == mapHeight - 1))
                    {
                        map[i, j] = new Obstacle(i, j);
                    }
                    else
                    {
                        map[i, j] = new EmptyTile(i, j);
                    }

                }
            }

            hero = (Hero)Create(Tile.TileType.Hero);
            hero.Hp = 99;
            hero.MaxHp = 99;

            CreateLeader();
            for (int i = 0; i < enemies.Length - 1; i++)  
            {
                Create(Tile.TileType.Enemy);
            }

            for (int i = 0; i < goldCount; i++)
            {
                Create(Tile.TileType.Gold);
            }
            for (int i = 0; i < weaponCount; i++)
            {
                Create(Tile.TileType.Weapon);
            }
            UpdateVision();
        }

        #region Properties

        public int MapWidth { get { return mapWidth; } }
        public int MapHeight { get { return mapHeight; } }
        public Tile[,] GameMap { get { return map; } set { map = value; } } 
        public Hero GameHero { get { return hero; } set { hero = value; } }
        public Enemy[] GameEnemies { get { return enemies; } set { enemies = value; } }
        public Item?[] Items { get { return items; } set { items = value; } }

        #endregion

        #region Methods

        /// <summary>
        /// Acts like the Create method but for a leader spesifically
        /// </summary>
        /// <returns>A leader object</returns>
        private Leader CreateLeader()
        {
            int rndmX, rndmY;
            bool loop;
            do
            {
                rndmX = rndm.Next(1, mapWidth - 1);
                rndmY = rndm.Next(1, mapHeight - 1);

                loop = (map[rndmY, rndmX] is not EmptyTile);
            } while (loop);

            Leader leader = new Leader(rndmX, rndmY);
            map[rndmY, rndmX] = leader;
            AddEnemy(leader);
            return leader;
        }

        /// <summary>
        /// Updates the vision of all enemies and the hero.
        /// </summary>
        public void UpdateVision() //Update Vision for each class
        {
            Tile[] tmp = new Tile[4];
            tmp[0] = map[hero.Y - 1, hero.X]; //up
            tmp[1] = map[hero.Y + 1, hero.X]; //down
            tmp[2] = map[hero.Y, hero.X - 1]; //left
            tmp[3] = map[hero.Y, hero.X + 1]; //right
            hero.Charactermovement = tmp;

            foreach (Enemy e in enemies)
            {
                Tile[] enemyTmp = new Tile[4];
                enemyTmp[0] = map[e.Y - 1, e.X]; //up
                enemyTmp[1] = map[e.Y + 1, e.X]; //down
                enemyTmp[2] = map[e.Y, e.X - 1]; //left
                enemyTmp[3] = map[e.Y, e.X + 1]; //right
                e.Charactermovement = enemyTmp;
            }
        }

        /// <summary>
        /// Takes in coordinates and returns an Item if one exists there. Returns null otherwise.
        /// </summary>
        /// <param name="y">The y coordinate.</param>
        /// <param name="x">The x coordinate.</param>
        /// <returns>An Item at the given position if it exists. Null if one does not.</returns>
        public Item? GetItemAtPosition(int y, int x)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] is not null && items[i].X == x && items[i].Y == y)
                {
                    Item? item = items[i];
                    items[i] = null;
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Generates a Tile on the map, in a random spot, by the given type.
        /// </summary>
        /// <param name="type">The Type of Tile to Generate.</param>
        /// <returns>A Tile object of what was placed on the Map.</returns>
        private Tile Create(Tile.TileType type)
        {
            bool loop;
            int rndmX;
            int rndmY;
            do
            {
                rndmY = rndm.Next(1, mapWidth - 1);
                rndmX = rndm.Next(1, mapHeight - 1);

                if (map[rndmY, rndmX] is null)
                {
                    loop = false;
                }
                else
                {
                    loop = (map[rndmY, rndmX] is not EmptyTile);
                }

            } while (loop);

            switch (type)
            {
                case Tile.TileType.Hero:
                    Hero hero = new Hero(rndmX, rndmY, 99, 99);
                    map[rndmY, rndmX] = hero;
                    return hero;
                case Tile.TileType.Enemy:
                    if (rndm.Next(2) == 0)
                    {
                        SwampCreature swampCreature = new SwampCreature(rndmX, rndmY);
                        map[rndmY, rndmX] = swampCreature;
                        AddEnemy(swampCreature);
                        return swampCreature;
                    }
                    else
                    {
                        Mage mage = new Mage(rndmX, rndmY);
                        map[rndmY, rndmX] = mage;
                        AddEnemy(mage);
                        return mage;
                    }
                case Tile.TileType.Gold:
                    Gold gold = new Gold(rndmX, rndmY);
                    map[rndmY, rndmX] = gold;
                    AddItem(gold);
                    return gold;
                case Tile.TileType.Weapon:
                    Weapon weapon = rndm.Next(4) switch
                    {
                        0 => new RangedWeapon(RangedWeapon.Type.Longbow, rndmX, rndmY),
                        1 => new RangedWeapon(RangedWeapon.Type.Rifle, rndmX, rndmY),
                        2 => new MeleeWeapon(MeleeWeapon.Type.Dagger, rndmX, rndmY),
                        3 => new MeleeWeapon(MeleeWeapon.Type.Longsword, rndmX, rndmY),
                        
                        //unreachable but here for error prevention.
                        _ => new MeleeWeapon(MeleeWeapon.Type.Longsword)
                    };
                    map[rndmY, rndmX] = weapon;
                    AddItem(weapon);
                    return weapon;
                default:
                    EmptyTile empty = new EmptyTile(rndmX, rndmY);
                    map[rndmY, rndmX] = empty;
                    return empty;

            }
        }

        /// <summary>
        /// Adds an Enemy to the Enemy array by finding the first available null slot and storing the given Enemy in it.
        /// </summary>
        /// <param name="enemy">The Enemy to add to the Enemy array.</param>
        private void AddEnemy(Enemy enemy)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] == null)
                {
                    enemies[i] = enemy;
                    break;
                }
            }
        }

        /// <summary>
        /// Adds an Item to the Item array by finding the first available null slot and storing the given Item in it.
        /// </summary>
        /// <param name="item">The Item to add to the Item array.</param>
        private void AddItem(Item item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    break;
                }
            }
        }

        #endregion
    
    }
}
