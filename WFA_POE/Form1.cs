using System.Data;

namespace WFA_POE
{
    public partial class GameForm : Form
    {
        private GameEngine engine;
        
        public GameForm()
        {
            InitializeComponent();
            engine = new GameEngine();
            UpdateMap();
            DispPlayerStats();
            UpdateEnemyComboBox();

        }

        #region Save&&Load
        private void saveBtn_Click(object sender, EventArgs e)
        {
            
        }
        private void loadBtn_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Events
        private void Btn_Attack_Click(object sender, EventArgs e)
        {
            if (ComboBox_Enemies.SelectedIndex == -1) return;
            if (engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].IsDead()) return;//Checking if the enemy is dead before attacking

            bool success = engine.GameMap.GameHero.CheckRange(engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex]);
            engine.GameMap.GameHero.Attack(engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex]);

            if (success) UpdateSelectedEnemyStats();
            else Re_Enemy_Stats.Text = "Attack Unsucessful";
            
            //checking if the enemy is dead after attacking
            if (engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].IsDead())
            {
                engine.GameMap.GameHero.Loot(engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex]); //looting
                
                //setting the tile to be Empty
                engine.GameMap.GameMap[engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].Y, engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].X] 
                    = new EmptyTile(engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].X, engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].Y);

                //Updating the Drop down
                ComboBox_Enemies.Items[ComboBox_Enemies.SelectedIndex] = "Enemy Dead";
            }
            else
            {
                //updating the Drop down
                ComboBox_Enemies.Items[ComboBox_Enemies.SelectedIndex] = engine.GameMap.GameEnemies[ComboBox_Enemies.SelectedIndex].ToString();
            }

            DispPlayerStats();
            UpdateMap();
            UpdateVision();
            engine.EnemiesAttack();
        }
        
        private void ComboBox_Enemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedEnemyStats();
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

        

        #endregion

        #region Shop
        private void shopComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buyBtn.Enabled = (engine.GameShop.CanBuy(shopComboBox.SelectedIndex));
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            engine.GameShop.Buy(shopComboBox.SelectedIndex);

            UpdateShop();
            UpdateMap();
            DispPlayerStats();
        }

        private void UpdateShop()
        {
            shopTextBox.Text = "";
            shopComboBox.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                shopTextBox.Text += "♦ " + engine.GameShop.DisplayWeapon(i);
                shopTextBox.Text += Environment.NewLine;

                shopComboBox.Items.Add(engine.GameShop.DisplayWeapon(i));
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            DispPlayerStats();
            UpdateEnemyComboBox();
            UpdateVision();
            UpdateMap();
            UpdateShop();
        }
        #endregion
    }
}