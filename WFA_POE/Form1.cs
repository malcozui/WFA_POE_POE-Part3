using System.Data;

namespace WFA_POE
{
    public partial class GameForm : Form
    {
        private GameEngine engine;
        private DataSet dataSet = new DataSet();
        private DataTable characterTable = new DataTable();
        private DataTable itemsTable = new DataTable();


        public GameForm()
        {
            InitializeComponent();
            engine = new GameEngine();
            UpdateMap();
            DispPlayerStats();
            UpdateEnemyComboBox();

            //setting up the table of characters
            dataSet.Tables.Add(characterTable);
            characterTable.Columns.Add(new DataColumn("ObjectType", typeof(string)));
            characterTable.Columns.Add(new DataColumn("Xpos", typeof(int)));
            characterTable.Columns.Add(new DataColumn("YPos", typeof(int)));
            characterTable.Columns.Add(new DataColumn("Hp", typeof(int)));
            characterTable.Columns.Add(new DataColumn("MaxHp", typeof(int)));
            characterTable.Columns.Add(new DataColumn("Gold", typeof(int)));

            //setting up the table f items
            dataSet.Tables.Add(itemsTable);
            itemsTable.Columns.Add(new DataColumn("ObjectType", typeof(string)));
            itemsTable.Columns.Add(new DataColumn("Xpos", typeof(int)));
            itemsTable.Columns.Add(new DataColumn("Ypos", typeof(int)));
            itemsTable.Columns.Add(new DataColumn("Gold", typeof(int)));
        }

        #region Save&&Load
        private void saveBtn_Click(object sender, EventArgs e)
        {
            //hero into table
            characterTable.Rows.Add("Hero", engine.GameMap.GameHero.X, engine.GameMap.GameHero.Y, engine.GameMap.GameHero.Hp, engine.GameMap.GameHero.MaxHp, engine.GameMap.GameHero.GoldAmount);

            //Enemies into table
            for (int i = 0; i < engine.GameMap.GameEnemies.Length; i++)
            {
                switch (engine.GameMap.GameEnemies[i])
                {
                    case SwampCreature:
                        characterTable.Rows.Add("Swamp Creature", engine.GameMap.GameEnemies[i].X, engine.GameMap.GameEnemies[i].Y, engine.GameMap.GameEnemies[i].Hp, engine.GameMap.GameEnemies[i].MaxHp, engine.GameMap.GameEnemies[i].GoldAmount);
                        break;
                    case Mage:
                        characterTable.Rows.Add("Mage", engine.GameMap.GameEnemies[i].X, engine.GameMap.GameEnemies[i].Y, engine.GameMap.GameEnemies[i].Hp, engine.GameMap.GameEnemies[i].MaxHp, engine.GameMap.GameEnemies[i].GoldAmount);
                        break;
                }
            }

            //items into table
            for (int i = 0; i < engine.GameMap.Items.Length; i++)
            {
                switch (engine.GameMap.Items[i])
                {
                    case Gold:
                        itemsTable.Rows.Add("Gold", engine.GameMap.Items[i].X, engine.GameMap.Items[i].Y, ((Gold)engine.GameMap.Items[i]).GoldAmount);
                        break;
                }
            }

            dataSet.WriteXml("XMLData.xml");
        }
        private void loadBtn_Click(object sender, EventArgs e)
        {
            //reseting the gameengine
            engine = new GameEngine();
            //setting the enemies and items arrays to be new arrays with the same length as the current game
            engine.GameMap.Items = new Item[engine.GameMap.Items.Length];
            engine.GameMap.GameEnemies = new Enemy[engine.GameMap.GameEnemies.Length];

            for (int i = 1; i < engine.GameMap.MapWidth - 1; i++)
            {
                for (int j = 1; j < engine.GameMap.MapHeight - 1; j++)
                {
                    //setting all the tiles in the map to be empty tiles
                    engine.GameMap.GameMap[i, j] = new EmptyTile(j, i) { Type = Tile.TileType.EmptyTile };
                }
            }

            DataSet loadSet = new DataSet();
            loadSet.ReadXml("XMLData.xml");

            foreach (DataRow row in loadSet.Tables[0].Rows)//tables[0] is the hero and enemies table
            {
                string objectType = (string)row["ObjectType"];
                int xPos = Convert.ToInt32(row["Xpos"]);
                int yPos = Convert.ToInt32(row["Ypos"]);
                int hp = Convert.ToInt32(row["Hp"]);
                int maxHp = Convert.ToInt32(row["MaxHp"]);
                int gold = Convert.ToInt32(row["Gold"]);

                switch (objectType)
                {
                    case "Hero":
                        engine.GameMap.GameMap[engine.GameMap.GameHero.Y, engine.GameMap.GameHero.X] = new EmptyTile(xPos, yPos) { Type = Tile.TileType.EmptyTile }; 

                        Hero hero = new Hero(xPos, yPos, hp, maxHp) { GoldAmount = gold };
                        engine.GameMap.GameHero = hero;
                        engine.GameMap.GameMap[yPos, xPos] = hero;
                        break;
                    case "Mage":
                        Mage mage = new Mage(xPos, yPos, hp) { Type = Tile.TileType.Enemy, GoldAmount = gold };
                        for (int i = 0; i < engine.GameMap.GameEnemies.Length; i++)
                        {
                            if (engine.GameMap.GameEnemies[i] is null)
                            {
                                engine.GameMap.GameEnemies[i] = mage;
                            }
                        }
                        engine.GameMap.GameMap[yPos, xPos] = mage;
                        break;
                    case "Swamp Creature":
                        SwampCreature swampCreature = new SwampCreature(xPos, yPos, hp) { Type = Tile.TileType.Enemy, GoldAmount = gold };
                        for (int i = 0; i < engine.GameMap.GameEnemies.Length; i++)
                        {
                            if (engine.GameMap.GameEnemies[i] is null)
                            {
                                engine.GameMap.GameEnemies[i] = swampCreature;
                            }
                        }
                        engine.GameMap.GameMap[yPos, xPos] = swampCreature;
                        break;
                    default:
                        break;
                }
            }

            foreach (DataRow row in loadSet.Tables[1].Rows)//Tables[1] is the items table
            {
                string objectType = (string)row["ObjectType"];
                int xPos = Convert.ToInt32(row["Xpos"]);
                int yPos = Convert.ToInt32(row["Ypos"]);
                int gold = Convert.ToInt32(row["Gold"]);

                switch (objectType)
                {

                    case "Gold":
                        Gold _gold = new Gold(xPos, yPos);
                        _gold.GoldAmount = gold;
                        for (int i = 0; i < engine.GameMap.Items.Length; i++)
                        {
                            if (engine.GameMap.Items[i] is null)
                            {
                                engine.GameMap.Items[i] = _gold;
                            }
                        }
                        engine.GameMap.GameMap[yPos, xPos] = _gold;
                        engine.GameMap.GameMap[yPos, xPos].Type = Tile.TileType.Gold;
                        break;
                    default:
                        break;
                }
            }
            
            engine.GameMap.UpdateVision();
        }
        #endregion

        #region Events
        private void Btn_Attack_Click(object sender, EventArgs e)
        {
            if (ComboBox_Enemies.SelectedIndex == -1) return;
            if (CheckDead()) return; ;//Checking if the enemy is dead before attacking
            bool success = engine.GameMap.GameHero.CheckRange(engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex]);
            engine.GameMap.GameHero.Attack(engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex]);
            if (success) UpdateSelectedEnemyStats();
            else Re_Enemy_Stats.Text = "Attack Unsucessful";
            CheckDead(); //checking if the enemy is dead after attacking

            engine.EnemiesAttack();
        }
        
        private void ComboBox_Enemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedEnemyStats();
        }
        
        private void GameForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LblStart_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region DisplayMethods
        private void UpdateEnemyComboBox() //Tells if enemy is dead
        {
            ComboBox_Enemies.Items.Clear();
            for (int i = 0; i < engine.GameMap.GameEnemies.Length; i++)
            {
                if (engine.GameMap.GameEnemies[i].IsDead()) ComboBox_Enemies.Items.Add("Enemy dead.");
                else ComboBox_Enemies.Items.Add(engine.GameMap.GameEnemies[i].ToString());
            }
        }
        private void UpdateSelectedEnemyStats() // if enemy is dead is tells us
        {
            if (engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].IsDead())
            {
                Re_Enemy_Stats.Text = "Enemy is already dead.";
            }
            else Re_Enemy_Stats.Text = engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].ToString();
        }

        private void DispPlayerStats() // Player stats
        {
            Re_Player_Stats.Text = engine.GameMap.GameHero.ToString();
        }

        private void UpdateMap() // Update tile map
        {
            LblMap.Text = engine.ToString();
        }

        private void UpdateVision() // Update hero or enemy vision
        {
            engine.GameMap.UpdateVision();
        }
        #endregion

        #region Directional Buttons
        private void Btn_Up_Click(object sender, EventArgs e) // Up Button
        {
            DirectionHandler(Character.Movement.Up);

        }

        private void Btn_Down_Click(object sender, EventArgs e) // Down Button
        {
            DirectionHandler(Character.Movement.Down);

        }

        private void Btn_Left_Click(object sender, EventArgs e) // Left Button
        {
            DirectionHandler(Character.Movement.Left);

        }

        private void Btn_Right_Click(object sender, EventArgs e) // Right Button
        {
            DirectionHandler(Character.Movement.Right);

        }

        private void Btn_Stay_Click(object sender, EventArgs e) //Stay in place button
        {
            DirectionHandler(Character.Movement.NoMovement);

        }

        private void DirectionHandler(Character.Movement movement)
        {
            engine.MovePlayer(movement);
            engine.MoveEnemies();
            engine.EnemiesAttack();
            DispPlayerStats();

            UpdateEnemyComboBox();
            UpdateVision();

            UpdateMap();
        }
        #endregion

        #region Additional Methods

        private bool CheckDead()
        {
            if (engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].IsDead())
            {
                Re_Enemy_Stats.Text = "Enemy Dead";
                engine.GameMap.GameMap[engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].Y,
                               engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].X]
                    = new EmptyTile(engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].X, engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].Y)
                    {
                        Type = Tile.TileType.EmptyTile
                    };
                UpdateMap();
                DispPlayerStats();
                UpdateEnemyComboBox();
                return true;
            }
            return false;
        }

        #endregion

    }
}