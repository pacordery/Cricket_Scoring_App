namespace Cricket_Scoring_App
{
    partial class Player_Addition_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Add_New_Player_Button = new System.Windows.Forms.Button();
            this.Team_Name_Selector = new System.Windows.Forms.ComboBox();
            this.Player_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Add_New_Player_Button
            // 
            this.Add_New_Player_Button.Location = new System.Drawing.Point(362, 171);
            this.Add_New_Player_Button.Name = "Add_New_Player_Button";
            this.Add_New_Player_Button.Size = new System.Drawing.Size(136, 48);
            this.Add_New_Player_Button.TabIndex = 1;
            this.Add_New_Player_Button.Text = "Add Player";
            this.Add_New_Player_Button.UseVisualStyleBackColor = true;
            this.Add_New_Player_Button.Click += new System.EventHandler(this.Add_New_Player_Button_Click);
            // 
            // Team_Name_Selector
            // 
            this.Team_Name_Selector.FormattingEnabled = true;
            this.Team_Name_Selector.Items.AddRange(new object[] {
            "Home",
            "Away"});
            this.Team_Name_Selector.Location = new System.Drawing.Point(241, 44);
            this.Team_Name_Selector.Name = "Team_Name_Selector";
            this.Team_Name_Selector.Size = new System.Drawing.Size(209, 21);
            this.Team_Name_Selector.TabIndex = 2;
            // 
            // Player_Name
            // 
            this.Player_Name.Location = new System.Drawing.Point(241, 105);
            this.Player_Name.Name = "Player_Name";
            this.Player_Name.Size = new System.Drawing.Size(209, 20);
            this.Player_Name.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Team:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Player Name:";
            // 
            // Player_Addition_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(534, 242);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Player_Name);
            this.Controls.Add(this.Team_Name_Selector);
            this.Controls.Add(this.Add_New_Player_Button);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 280);
            this.Name = "Player_Addition_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a New Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add_New_Player_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox Team_Name_Selector;
        public System.Windows.Forms.TextBox Player_Name;
    }
}