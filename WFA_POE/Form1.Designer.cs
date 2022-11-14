namespace WFA_POE
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblMap = new System.Windows.Forms.Label();
            this.playerPanel = new System.Windows.Forms.Panel();
            this.loadBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.Btn_Attack = new System.Windows.Forms.Button();
            this.ComboBox_Enemies = new System.Windows.Forms.ComboBox();
            this.Re_Player_Stats = new System.Windows.Forms.RichTextBox();
            this.enemyPanel = new System.Windows.Forms.Panel();
            this.Re_Enemy_Stats = new System.Windows.Forms.RichTextBox();
            this.gameLogoPanel = new System.Windows.Forms.Panel();
            this.LblStart = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Btn_Stay = new System.Windows.Forms.Button();
            this.Btn_Down = new System.Windows.Forms.Button();
            this.Btn_Left = new System.Windows.Forms.Button();
            this.Btn_Right = new System.Windows.Forms.Button();
            this.Btn_Up = new System.Windows.Forms.Button();
            this.playerPanel.SuspendLayout();
            this.enemyPanel.SuspendLayout();
            this.gameLogoPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblMap
            // 
            this.LblMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.LblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblMap.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblMap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LblMap.Location = new System.Drawing.Point(338, 65);
            this.LblMap.Name = "LblMap";
            this.LblMap.Size = new System.Drawing.Size(400, 400);
            this.LblMap.TabIndex = 0;
            this.LblMap.Text = "XXXXXXXXXXXXXX \r\nX░░░░░░░X \r\nX░░░░░░░X \r\nX░░░░░░░X \r\nX░░░░░░░X \r\nX░░░░░░░X \r\nX░░░" +
    "░░░░X \r\nXXXXXXXXXXXXXXX \r\n\r\n";
            // 
            // playerPanel
            // 
            this.playerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.playerPanel.Controls.Add(this.loadBtn);
            this.playerPanel.Controls.Add(this.saveBtn);
            this.playerPanel.Controls.Add(this.Btn_Attack);
            this.playerPanel.Controls.Add(this.ComboBox_Enemies);
            this.playerPanel.Controls.Add(this.Re_Player_Stats);
            this.playerPanel.Location = new System.Drawing.Point(1, 2);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(328, 613);
            this.playerPanel.TabIndex = 1;
            // 
            // loadBtn
            // 
            this.loadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.loadBtn.FlatAppearance.BorderSize = 0;
            this.loadBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.loadBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.loadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadBtn.ForeColor = System.Drawing.Color.White;
            this.loadBtn.Location = new System.Drawing.Point(13, 519);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(303, 45);
            this.loadBtn.TabIndex = 7;
            this.loadBtn.Text = "Load from save";
            this.loadBtn.UseVisualStyleBackColor = false;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.saveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(13, 468);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(303, 45);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Btn_Attack
            // 
            this.Btn_Attack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Btn_Attack.FlatAppearance.BorderSize = 0;
            this.Btn_Attack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Btn_Attack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Btn_Attack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Attack.ForeColor = System.Drawing.Color.White;
            this.Btn_Attack.Location = new System.Drawing.Point(13, 359);
            this.Btn_Attack.Name = "Btn_Attack";
            this.Btn_Attack.Size = new System.Drawing.Size(303, 45);
            this.Btn_Attack.TabIndex = 5;
            this.Btn_Attack.Text = "Attack Selected";
            this.Btn_Attack.UseVisualStyleBackColor = false;
            this.Btn_Attack.Click += new System.EventHandler(this.Btn_Attack_Click);
            // 
            // ComboBox_Enemies
            // 
            this.ComboBox_Enemies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ComboBox_Enemies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox_Enemies.ForeColor = System.Drawing.Color.White;
            this.ComboBox_Enemies.FormattingEnabled = true;
            this.ComboBox_Enemies.Location = new System.Drawing.Point(13, 330);
            this.ComboBox_Enemies.Name = "ComboBox_Enemies";
            this.ComboBox_Enemies.Size = new System.Drawing.Size(303, 23);
            this.ComboBox_Enemies.TabIndex = 5;
            this.ComboBox_Enemies.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Enemies_SelectedIndexChanged);
            // 
            // Re_Player_Stats
            // 
            this.Re_Player_Stats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Re_Player_Stats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Re_Player_Stats.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Re_Player_Stats.Location = new System.Drawing.Point(13, 10);
            this.Re_Player_Stats.Name = "Re_Player_Stats";
            this.Re_Player_Stats.Size = new System.Drawing.Size(303, 300);
            this.Re_Player_Stats.TabIndex = 1;
            this.Re_Player_Stats.Text = "Player Stats";
            // 
            // enemyPanel
            // 
            this.enemyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.enemyPanel.Controls.Add(this.Re_Enemy_Stats);
            this.enemyPanel.Location = new System.Drawing.Point(744, 2);
            this.enemyPanel.Name = "enemyPanel";
            this.enemyPanel.Size = new System.Drawing.Size(327, 613);
            this.enemyPanel.TabIndex = 2;
            // 
            // Re_Enemy_Stats
            // 
            this.Re_Enemy_Stats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Re_Enemy_Stats.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Re_Enemy_Stats.Location = new System.Drawing.Point(15, 13);
            this.Re_Enemy_Stats.Name = "Re_Enemy_Stats";
            this.Re_Enemy_Stats.Size = new System.Drawing.Size(303, 592);
            this.Re_Enemy_Stats.TabIndex = 1;
            this.Re_Enemy_Stats.Text = "Enemy Stats";
            // 
            // gameLogoPanel
            // 
            this.gameLogoPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gameLogoPanel.Controls.Add(this.LblStart);
            this.gameLogoPanel.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameLogoPanel.Location = new System.Drawing.Point(337, 2);
            this.gameLogoPanel.Name = "gameLogoPanel";
            this.gameLogoPanel.Size = new System.Drawing.Size(401, 60);
            this.gameLogoPanel.TabIndex = 3;
            // 
            // LblStart
            // 
            this.LblStart.AutoSize = true;
            this.LblStart.ForeColor = System.Drawing.Color.White;
            this.LblStart.Location = new System.Drawing.Point(108, 13);
            this.LblStart.Name = "LblStart";
            this.LblStart.Size = new System.Drawing.Size(175, 36);
            this.LblStart.TabIndex = 0;
            this.LblStart.Text = "GAME started";
            this.LblStart.Click += new System.EventHandler(this.LblStart_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel4.Controls.Add(this.Btn_Stay);
            this.panel4.Controls.Add(this.Btn_Down);
            this.panel4.Controls.Add(this.Btn_Left);
            this.panel4.Controls.Add(this.Btn_Right);
            this.panel4.Controls.Add(this.Btn_Up);
            this.panel4.Location = new System.Drawing.Point(338, 468);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 147);
            this.panel4.TabIndex = 4;
            // 
            // Btn_Stay
            // 
            this.Btn_Stay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Btn_Stay.FlatAppearance.BorderSize = 0;
            this.Btn_Stay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Btn_Stay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Btn_Stay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Stay.ForeColor = System.Drawing.Color.White;
            this.Btn_Stay.Location = new System.Drawing.Point(168, 53);
            this.Btn_Stay.Name = "Btn_Stay";
            this.Btn_Stay.Size = new System.Drawing.Size(45, 45);
            this.Btn_Stay.TabIndex = 4;
            this.Btn_Stay.Text = "None";
            this.Btn_Stay.UseVisualStyleBackColor = false;
            this.Btn_Stay.Click += new System.EventHandler(this.Btn_Stay_Click);
            // 
            // Btn_Down
            // 
            this.Btn_Down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Btn_Down.FlatAppearance.BorderSize = 0;
            this.Btn_Down.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Btn_Down.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Btn_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Down.ForeColor = System.Drawing.Color.White;
            this.Btn_Down.Location = new System.Drawing.Point(168, 102);
            this.Btn_Down.Name = "Btn_Down";
            this.Btn_Down.Size = new System.Drawing.Size(45, 45);
            this.Btn_Down.TabIndex = 3;
            this.Btn_Down.Text = "↓";
            this.Btn_Down.UseVisualStyleBackColor = false;
            this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click);
            // 
            // Btn_Left
            // 
            this.Btn_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Btn_Left.FlatAppearance.BorderSize = 0;
            this.Btn_Left.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Btn_Left.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Btn_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Left.ForeColor = System.Drawing.Color.White;
            this.Btn_Left.Location = new System.Drawing.Point(117, 53);
            this.Btn_Left.Name = "Btn_Left";
            this.Btn_Left.Size = new System.Drawing.Size(45, 45);
            this.Btn_Left.TabIndex = 2;
            this.Btn_Left.Text = "←";
            this.Btn_Left.UseVisualStyleBackColor = false;
            this.Btn_Left.Click += new System.EventHandler(this.Btn_Left_Click);
            // 
            // Btn_Right
            // 
            this.Btn_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Btn_Right.FlatAppearance.BorderSize = 0;
            this.Btn_Right.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Btn_Right.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Btn_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Right.ForeColor = System.Drawing.Color.White;
            this.Btn_Right.Location = new System.Drawing.Point(219, 53);
            this.Btn_Right.Name = "Btn_Right";
            this.Btn_Right.Size = new System.Drawing.Size(45, 45);
            this.Btn_Right.TabIndex = 1;
            this.Btn_Right.Text = "→";
            this.Btn_Right.UseVisualStyleBackColor = false;
            this.Btn_Right.Click += new System.EventHandler(this.Btn_Right_Click);
            // 
            // Btn_Up
            // 
            this.Btn_Up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Btn_Up.FlatAppearance.BorderSize = 0;
            this.Btn_Up.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Btn_Up.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Btn_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Up.ForeColor = System.Drawing.Color.White;
            this.Btn_Up.Location = new System.Drawing.Point(168, 2);
            this.Btn_Up.Name = "Btn_Up";
            this.Btn_Up.Size = new System.Drawing.Size(45, 45);
            this.Btn_Up.TabIndex = 0;
            this.Btn_Up.Text = "↑";
            this.Btn_Up.UseVisualStyleBackColor = false;
            this.Btn_Up.Click += new System.EventHandler(this.Btn_Up_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1073, 616);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.gameLogoPanel);
            this.Controls.Add(this.enemyPanel);
            this.Controls.Add(this.playerPanel);
            this.Controls.Add(this.LblMap);
            this.Name = "GameForm";
            this.Text = "Game Window";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.playerPanel.ResumeLayout(false);
            this.enemyPanel.ResumeLayout(false);
            this.gameLogoPanel.ResumeLayout(false);
            this.gameLogoPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label LblMap;
        private Panel playerPanel;
        private Panel enemyPanel;
        private Panel gameLogoPanel;
        private Label LblStart;
        private RichTextBox Re_Player_Stats;
        private RichTextBox Re_Enemy_Stats;
        private Panel panel4;
        private Button Btn_Stay;
        private Button Btn_Down;
        private Button Btn_Left;
        private Button Btn_Right;
        private Button Btn_Up;
        private Button Btn_Attack;
        private ComboBox ComboBox_Enemies;
        private Button loadBtn;
        private Button saveBtn;
    }
}