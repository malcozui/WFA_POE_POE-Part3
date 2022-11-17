using System;
using System.Collections.Generic;
using System.Data;
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
        /// <summary>
        /// Moves the player if they can move that direction, also picks up any items infront of them.
        /// </summary>
        /// <param name="direction">The direction the player is moved in.</param>
        /// <returns>A boolean value representing whether the player sucessfully moved.</returns>
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
                gameMap.GameMap[gameMap.GameHero.Y, gameMap.GameHero.X] = gameMap.GameHero;
                
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

        /// <summary>
        /// Moves all the enemies in the direction they're going to move.
        /// </summary>
        /// <param name="direction">Unused. Here since the POE had it.</param>
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
                                //loot the character they killed if they're in range.
                                if (gameMap.GameEnemies[i].CheckRange(gameMap.GameEnemies[j])) gameMap.GameEnemies[i].Loot(gameMap.GameEnemies[j]);
                                
                                //ensures that the tile of a dead enemy that a player moves into doesn't get overwritten by a blank tile.
                                if (!(gameMap.GameHero.X == gameMap.GameEnemies[j].X || gameMap.GameHero.Y == gameMap.GameEnemies[j].Y)) gameMap.GameMap[gameMap.GameEnemies[j].Y, gameMap.GameEnemies[j].X] = new EmptyTile(gameMap.GameEnemies[j].X, gameMap.GameEnemies[j].Y);
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

        public void Save()
        {
            //saving all the data into XML tables
            DataSet dataSet = new DataSet();
            DataTable mapCreationTable = new DataTable();
            DataTable charactersTable = new DataTable();
            DataTable goldTable = new DataTable();
            DataTable weaponsTable = new DataTable();

            //map creation table
            dataSet.Tables.Add(mapCreationTable);
            mapCreationTable.Columns.Add(new DataColumn("Width", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("Height", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("EnemyCount", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("GoldCount", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("WeaponCount", typeof(int)));

            //characters table
            dataSet.Tables.Add(charactersTable);
            charactersTable.Columns.Add(new DataColumn("CharacterType", typeof(string)));
            charactersTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("HP", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("GoldAmount", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("Weapon", typeof(string)));
            charactersTable.Columns.Add(new DataColumn("WeaponDurability", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("IsDead", typeof(bool)));


            //gold table
            dataSet.Tables.Add(goldTable);
            goldTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            goldTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            goldTable.Columns.Add(new DataColumn("GoldCount", typeof(int)));

            //weapons table for in map weapons
            dataSet.Tables.Add(weaponsTable);
            weaponsTable.Columns.Add(new DataColumn("Type", typeof(string)));
            weaponsTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            weaponsTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            weaponsTable.Columns.Add(new DataColumn("durability", typeof(int)));


            //writing data into tables
            //map creation table
            mapCreationTable.Rows.Add(gameMap.MapWidth, gameMap.MapHeight, gameMap.GameEnemies.Length, 4, 2);

            //characters table
            if (gameMap.GameHero.WeaponUsed is not null) charactersTable.Rows.Add("Hero", gameMap.GameHero.X, gameMap.GameHero.Y, gameMap.GameHero.Hp, gameMap.GameHero.GoldAmount, gameMap.GameHero.WeaponUsed.WeaponType, gameMap.GameHero.WeaponUsed.Durability, gameMap.GameHero.IsDead());
            else charactersTable.Rows.Add("Hero", gameMap.GameHero.X, gameMap.GameHero.Y, gameMap.GameHero.Hp, gameMap.GameHero.GoldAmount, "BareHands", -1, gameMap.GameHero.IsDead());

            for (int i = 0; i < gameMap.GameEnemies.Length; i++)
            {
                switch (gameMap.GameEnemies[i])
                {
                    case SwampCreature:
                        charactersTable.Rows.Add("SwampCreature", gameMap.GameEnemies[i].X, gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].Hp, gameMap.GameEnemies[i].GoldAmount, gameMap.GameEnemies[i].WeaponUsed.WeaponType, gameMap.GameEnemies[i].WeaponUsed.Durability, gameMap.GameEnemies[i].IsDead());
                        break;
                    case Mage:
                        charactersTable.Rows.Add("Mage", gameMap.GameEnemies[i].X, gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].Hp, gameMap.GameEnemies[i].GoldAmount, "BareHands", -1, gameMap.GameEnemies[i].IsDead());
                        break;
                    case Leader:
                        charactersTable.Rows.Add("Leader", gameMap.GameEnemies[i].X, gameMap.GameEnemies[i].Y, gameMap.GameEnemies[i].Hp, gameMap.GameEnemies[i].GoldAmount, gameMap.GameEnemies[i].WeaponUsed.WeaponType, gameMap.GameEnemies[i].WeaponUsed.Durability, gameMap.GameEnemies[i].IsDead());
                        break;
                    default:
                        break;
                }
            }

            //gold and weapons table
            for (int i = 0; i < gameMap.Items.Length; i++)
            {
                switch (gameMap.Items[i])
                {
                    case Gold gold:
                        goldTable.Rows.Add(gold.X, gold.Y, gold.GoldAmount);
                        break;
                    case MeleeWeapon melee:
                        weaponsTable.Rows.Add(melee.WeaponType, melee.X, melee.Y, melee.Durability);
                        break;
                    case RangedWeapon ranged:
                        weaponsTable.Rows.Add(ranged.WeaponType, ranged.X, ranged.Y, ranged.Durability);
                        break;
                }
            }

            dataSet.WriteXml("Tables.xml");
        }

        public void Load()
        {
            DataSet loadingData = new DataSet();
            loadingData.ReadXml("Tables.xml");

            //Map Creation
            int width_MC, height_MC, enemies_MC, gold_MC, weapons_MC;
            width_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["Width"]);
            height_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["Height"]);
            enemies_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["EnemyCount"]);
            gold_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["GoldCount"]);
            weapons_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["WeaponCount"]);

            gameMap = new Map(width_MC, width_MC, height_MC, height_MC, enemies_MC, gold_MC, weapons_MC);

            //emptying the map of its auto-generated content
            for (int i = 1; i < height_MC - 1; i++)
            {
                for (int j = 1; j < width_MC - 1; j++)
                {
                    gameMap.GameMap[i, j] = new EmptyTile(j, i);
                }
            }
            gameMap.GameEnemies = new Enemy[enemies_MC];
            gameMap.Items = new Item[gold_MC + weapons_MC];

            //Characters
            foreach (DataRow row in loadingData.Tables[1].Rows) //Characters Table
            {
                string type_CH;
                int x_CH, y_CH, hp_CH, goldPurse_CH;
                string weapon_CH;
                int weaponDura_CH;
                bool dead_CH;

                type_CH = (string)row["CharacterType"];
                x_CH = Convert.ToInt32(row["Xposition"]);
                y_CH = Convert.ToInt32(row["Yposition"]);
                hp_CH = Convert.ToInt32(row["HP"]);
                goldPurse_CH = Convert.ToInt32(row["GoldAmount"]);
                weapon_CH = (string)row["Weapon"];
                weaponDura_CH = Convert.ToInt32(row["WeaponDurability"]);
                dead_CH = Convert.ToBoolean(row["IsDead"]);
                Weapon? w = weapon_CH switch
                {
                    "Rifle" => new RangedWeapon(RangedWeapon.Type.Rifle, weaponDura_CH),
                    "Longbow" => new RangedWeapon(RangedWeapon.Type.Longbow, weaponDura_CH),
                    "Dagger" => new MeleeWeapon(MeleeWeapon.Type.Dagger, weaponDura_CH),
                    "Longsword" => new MeleeWeapon(MeleeWeapon.Type.Longsword, weaponDura_CH),
                    _ => null
                };

                switch (type_CH)
                {
                    case "Hero":
                        Hero hero = new Hero(x_CH, y_CH, hp_CH, hp_CH) { GoldAmount = goldPurse_CH };
                        if (w is not null) hero.Pickup(w);
                        gameMap.GameHero = hero;
                        gameMap.GameMap[y_CH, x_CH] = hero;
                        break;
                    case "SwampCreature":
                        SwampCreature sc = new SwampCreature(x_CH, y_CH, hp_CH) { GoldAmount = goldPurse_CH };
                        if (w is not null) sc.Pickup(w);
                        for (int i = 0; i < gameMap.GameEnemies.Length; i++)
                        {
                            if (gameMap.GameEnemies[i] is null)
                            {
                                gameMap.GameEnemies[i] = sc;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            gameMap.GameMap[y_CH, x_CH] = sc;
                        }
                        break;
                    case "Mage":
                        Mage mage = new Mage(x_CH, y_CH, hp_CH) { GoldAmount = goldPurse_CH };
                        if (w is not null) mage.Pickup(w);
                        for (int i = 0; i < gameMap.GameEnemies.Length; i++)
                        {
                            if (gameMap.GameEnemies[i] is null)
                            {
                                gameMap.GameEnemies[i] = mage;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            gameMap.GameMap[y_CH, x_CH] = mage;
                        }
                        break;
                    case "Leader":
                        Leader leader = new Leader(x_CH, y_CH, hp_CH) { GoldAmount = goldPurse_CH, Target = gameMap.GameHero };
                        if (w is not null) leader.Pickup(w);
                        for (int i = 0; i < gameMap.GameEnemies.Length; i++)
                        {
                            if (gameMap.GameEnemies[i] is null)
                            {
                                gameMap.GameEnemies[i] = leader;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            gameMap.GameMap[y_CH, x_CH] = leader;
                        }
                        break;

                }
            }

            //gold
            foreach (DataRow row in loadingData.Tables[2].Rows) //gold table
            {
                int x_GO, y_GO, gold_GO;

                x_GO = Convert.ToInt32(row["Xposition"]);
                y_GO = Convert.ToInt32(row["Yposition"]);
                gold_GO = Convert.ToInt32(row["GoldCount"]);


                Gold gold = new Gold(x_GO, y_GO) { GoldAmount = gold_GO };
                for (int i = 0; i < gameMap.Items.Length; i++)
                {
                    if (gameMap.Items[i] is null)
                    {
                        gameMap.Items[i] = gold;
                        break;
                    }
                }
                gameMap.GameMap[y_GO, x_GO] = gold;
            }

            //weapons on gameMap
            foreach (DataRow row in loadingData.Tables[3].Rows) //weapons table
            {
                string type;
                int x_W, y_W, durability_W;

                type = (string)row["Type"];
                x_W = Convert.ToInt32(row["Xposition"]);
                y_W = Convert.ToInt32(row["Yposition"]);
                durability_W = Convert.ToInt32(row["durability"]);

                if (x_W == 0 || y_W == 0)
                {
                    continue;
                }
                switch (type)
                {
                    case "Rifle":
                        RangedWeapon rifle = new RangedWeapon(RangedWeapon.Type.Rifle, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < gameMap.Items.Length; i++)
                        {
                            if (gameMap.Items[i] is null)
                            {
                                gameMap.Items[i] = rifle;
                                break;
                            }
                        }
                        gameMap.GameMap[y_W, x_W] = rifle;
                        break;
                    case "LongBow":
                        RangedWeapon longbow = new RangedWeapon(RangedWeapon.Type.Longbow, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < gameMap.Items.Length; i++)
                        {
                            if (gameMap.Items[i] is null)
                            {
                                gameMap.Items[i] = longbow;
                                break;
                            }
                        }
                        gameMap.GameMap[y_W, x_W] = longbow;
                        break;
                    case "Dagger":
                        MeleeWeapon dagger = new MeleeWeapon(MeleeWeapon.Type.Dagger, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < gameMap.Items.Length; i++)
                        {
                            if (gameMap.Items[i] is null)
                            {
                                gameMap.Items[i] = dagger;
                                break;
                            }
                        }
                        gameMap.GameMap[y_W, x_W] = dagger;
                        break;
                    case "Longsword":
                        MeleeWeapon longsword = new MeleeWeapon(MeleeWeapon.Type.Longsword, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < gameMap.Items.Length; i++)
                        {
                            if (gameMap.Items[i] is null)
                            {
                                gameMap.Items[i] = longsword;
                                break;
                            }
                        }
                        gameMap.GameMap[y_W, x_W] = longsword;
                        break;
                }
            }
            gameMap.UpdateVision();
        }

        #endregion
    }
}
