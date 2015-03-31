namespace Cricket_Scoring_App
{
    partial class Scoring_App_Form
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
            this.Details_Tab_Set = new System.Windows.Forms.TabControl();
            this.Home_Tab = new System.Windows.Forms.TabPage();
            this.Start_New_Match_Button = new System.Windows.Forms.Button();
            this.Previous_Match_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Previous_Match_Table_Row_1 = new System.Windows.Forms.TableLayoutPanel();
            this.Match_Result_1 = new System.Windows.Forms.Label();
            this.Innings_2_Table_2 = new System.Windows.Forms.TableLayoutPanel();
            this.Innings_2_Team_Name_1 = new System.Windows.Forms.Label();
            this.Innings_1_Score_2 = new System.Windows.Forms.Label();
            this.Innings_1_Table_1 = new System.Windows.Forms.TableLayoutPanel();
            this.Innings_1_Team_Name_1 = new System.Windows.Forms.Label();
            this.Innings_1_Score_1 = new System.Windows.Forms.Label();
            this.Match_Date_1 = new System.Windows.Forms.Label();
            this.Season_Results_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Results_Lost_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Lost_Value = new System.Windows.Forms.Label();
            this.Lost_Description = new System.Windows.Forms.Label();
            this.Results_Drawn_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Drawn_Value = new System.Windows.Forms.Label();
            this.Drawn_Description = new System.Windows.Forms.Label();
            this.Results_Win_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Won_Description = new System.Windows.Forms.Label();
            this.Won_Value = new System.Windows.Forms.Label();
            this.This_Season_Heading = new System.Windows.Forms.Label();
            this.Previous_Match_Heading = new System.Windows.Forms.Label();
            this.Match_Details_Tab = new System.Windows.Forms.TabPage();
            this.Next_Tab_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Match_Date_Picker = new System.Windows.Forms.DateTimePicker();
            this.Weather_Label = new System.Windows.Forms.Label();
            this.Venue_Label = new System.Windows.Forms.Label();
            this.Away_Team_Label = new System.Windows.Forms.Label();
            this.Home_Team_Label = new System.Windows.Forms.Label();
            this.Date_Label = new System.Windows.Forms.Label();
            this.Match_Details_Heading = new System.Windows.Forms.Label();
            this.Team_Details_Tab = new System.Windows.Forms.TabPage();
            this.Begin_Match_Button = new System.Windows.Forms.Button();
            this.Add_Player_Home = new System.Windows.Forms.Button();
            this.Add_Player_Away = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Home = new System.Windows.Forms.TableLayoutPanel();
            this.Home_Player_1 = new System.Windows.Forms.TextBox();
            this.Home_Player_Number = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Away = new System.Windows.Forms.TableLayoutPanel();
            this.Away_Player_Name_1 = new System.Windows.Forms.TextBox();
            this.Away_Player_Number = new System.Windows.Forms.Label();
            this.Away_Team_Heading = new System.Windows.Forms.Label();
            this.Home_Team_Heading = new System.Windows.Forms.Label();
            this.Load_Match_Details_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.Weather_Selector = new System.Windows.Forms.ComboBox();
            this.Match_Type_Selector = new System.Windows.Forms.ComboBox();
            this.Venue_Name = new System.Windows.Forms.TextBox();
            this.Away_Team_Name = new System.Windows.Forms.TextBox();
            this.Home_Team_Name = new System.Windows.Forms.TextBox();
            this.Load_Match_Details_Button = new System.Windows.Forms.Button();
            this.Load_Away_Team = new System.Windows.Forms.Button();
            this.Load_Home_Team = new System.Windows.Forms.Button();
            this.Load_Away_Team_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.Load_Home_Team_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Details_Tab_Set.SuspendLayout();
            this.Home_Tab.SuspendLayout();
            this.Previous_Match_Table.SuspendLayout();
            this.Previous_Match_Table_Row_1.SuspendLayout();
            this.Innings_2_Table_2.SuspendLayout();
            this.Innings_1_Table_1.SuspendLayout();
            this.Season_Results_Table.SuspendLayout();
            this.Results_Lost_Table.SuspendLayout();
            this.Results_Drawn_Table.SuspendLayout();
            this.Results_Win_Table.SuspendLayout();
            this.Match_Details_Tab.SuspendLayout();
            this.Team_Details_Tab.SuspendLayout();
            this.tableLayoutPanel_Home.SuspendLayout();
            this.tableLayoutPanel_Away.SuspendLayout();
            this.SuspendLayout();
            // 
            // Details_Tab_Set
            // 
            this.Details_Tab_Set.Controls.Add(this.Home_Tab);
            this.Details_Tab_Set.Controls.Add(this.Match_Details_Tab);
            this.Details_Tab_Set.Controls.Add(this.Team_Details_Tab);
            this.Details_Tab_Set.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Details_Tab_Set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Details_Tab_Set.Location = new System.Drawing.Point(0, 0);
            this.Details_Tab_Set.Name = "Details_Tab_Set";
            this.Details_Tab_Set.SelectedIndex = 0;
            this.Details_Tab_Set.Size = new System.Drawing.Size(964, 562);
            this.Details_Tab_Set.TabIndex = 0;
            // 
            // Home_Tab
            // 
            this.Home_Tab.BackColor = System.Drawing.Color.Green;
            this.Home_Tab.Controls.Add(this.Start_New_Match_Button);
            this.Home_Tab.Controls.Add(this.Previous_Match_Table);
            this.Home_Tab.Controls.Add(this.Season_Results_Table);
            this.Home_Tab.Controls.Add(this.This_Season_Heading);
            this.Home_Tab.Controls.Add(this.Previous_Match_Heading);
            this.Home_Tab.Location = new System.Drawing.Point(4, 22);
            this.Home_Tab.Name = "Home_Tab";
            this.Home_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Home_Tab.Size = new System.Drawing.Size(956, 536);
            this.Home_Tab.TabIndex = 0;
            this.Home_Tab.Text = "Home";
            // 
            // Start_New_Match_Button
            // 
            this.Start_New_Match_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start_New_Match_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Start_New_Match_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_New_Match_Button.Location = new System.Drawing.Point(500, 275);
            this.Start_New_Match_Button.Name = "Start_New_Match_Button";
            this.Start_New_Match_Button.Size = new System.Drawing.Size(181, 62);
            this.Start_New_Match_Button.TabIndex = 7;
            this.Start_New_Match_Button.Text = "Start New Match";
            this.Start_New_Match_Button.UseVisualStyleBackColor = true;
            this.Start_New_Match_Button.Click += new System.EventHandler(this.Start_New_Match_Button_Click);
            // 
            // Previous_Match_Table
            // 
            this.Previous_Match_Table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.Previous_Match_Table.ColumnCount = 1;
            this.Previous_Match_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Previous_Match_Table.Controls.Add(this.Previous_Match_Table_Row_1, 0, 0);
            this.Previous_Match_Table.Location = new System.Drawing.Point(41, 124);
            this.Previous_Match_Table.Name = "Previous_Match_Table";
            this.Previous_Match_Table.RowCount = 1;
            this.Previous_Match_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Previous_Match_Table.Size = new System.Drawing.Size(404, 49);
            this.Previous_Match_Table.TabIndex = 6;
            // 
            // Previous_Match_Table_Row_1
            // 
            this.Previous_Match_Table_Row_1.ColumnCount = 4;
            this.Previous_Match_Table_Row_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.62464F));
            this.Previous_Match_Table_Row_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.6533F));
            this.Previous_Match_Table_Row_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.2011F));
            this.Previous_Match_Table_Row_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.96694F));
            this.Previous_Match_Table_Row_1.Controls.Add(this.Match_Result_1, 3, 0);
            this.Previous_Match_Table_Row_1.Controls.Add(this.Innings_2_Table_2, 2, 0);
            this.Previous_Match_Table_Row_1.Controls.Add(this.Innings_1_Table_1, 1, 0);
            this.Previous_Match_Table_Row_1.Controls.Add(this.Match_Date_1, 0, 0);
            this.Previous_Match_Table_Row_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Previous_Match_Table_Row_1.Location = new System.Drawing.Point(6, 6);
            this.Previous_Match_Table_Row_1.Name = "Previous_Match_Table_Row_1";
            this.Previous_Match_Table_Row_1.RowCount = 1;
            this.Previous_Match_Table_Row_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Previous_Match_Table_Row_1.Size = new System.Drawing.Size(392, 37);
            this.Previous_Match_Table_Row_1.TabIndex = 0;
            // 
            // Match_Result_1
            // 
            this.Match_Result_1.AutoSize = true;
            this.Match_Result_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Match_Result_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Match_Result_1.Location = new System.Drawing.Point(299, 0);
            this.Match_Result_1.Name = "Match_Result_1";
            this.Match_Result_1.Size = new System.Drawing.Size(90, 37);
            this.Match_Result_1.TabIndex = 3;
            this.Match_Result_1.Text = "Won by 70 Runs";
            this.Match_Result_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Innings_2_Table_2
            // 
            this.Innings_2_Table_2.ColumnCount = 1;
            this.Innings_2_Table_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Innings_2_Table_2.Controls.Add(this.Innings_2_Team_Name_1, 0, 0);
            this.Innings_2_Table_2.Controls.Add(this.Innings_1_Score_2, 0, 1);
            this.Innings_2_Table_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Innings_2_Table_2.Location = new System.Drawing.Point(186, 3);
            this.Innings_2_Table_2.Name = "Innings_2_Table_2";
            this.Innings_2_Table_2.RowCount = 2;
            this.Innings_2_Table_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Innings_2_Table_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Innings_2_Table_2.Size = new System.Drawing.Size(107, 31);
            this.Innings_2_Table_2.TabIndex = 1;
            // 
            // Innings_2_Team_Name_1
            // 
            this.Innings_2_Team_Name_1.AutoSize = true;
            this.Innings_2_Team_Name_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Innings_2_Team_Name_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Innings_2_Team_Name_1.Location = new System.Drawing.Point(3, 0);
            this.Innings_2_Team_Name_1.Name = "Innings_2_Team_Name_1";
            this.Innings_2_Team_Name_1.Size = new System.Drawing.Size(101, 15);
            this.Innings_2_Team_Name_1.TabIndex = 0;
            this.Innings_2_Team_Name_1.Text = "Team Name";
            this.Innings_2_Team_Name_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Innings_1_Score_2
            // 
            this.Innings_1_Score_2.AutoSize = true;
            this.Innings_1_Score_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Innings_1_Score_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Innings_1_Score_2.Location = new System.Drawing.Point(3, 15);
            this.Innings_1_Score_2.Name = "Innings_1_Score_2";
            this.Innings_1_Score_2.Size = new System.Drawing.Size(101, 16);
            this.Innings_1_Score_2.TabIndex = 1;
            this.Innings_1_Score_2.Text = "150-8";
            this.Innings_1_Score_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Innings_1_Table_1
            // 
            this.Innings_1_Table_1.ColumnCount = 1;
            this.Innings_1_Table_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Innings_1_Table_1.Controls.Add(this.Innings_1_Team_Name_1, 0, 0);
            this.Innings_1_Table_1.Controls.Add(this.Innings_1_Score_1, 0, 1);
            this.Innings_1_Table_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Innings_1_Table_1.Location = new System.Drawing.Point(75, 3);
            this.Innings_1_Table_1.Name = "Innings_1_Table_1";
            this.Innings_1_Table_1.RowCount = 2;
            this.Innings_1_Table_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Innings_1_Table_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Innings_1_Table_1.Size = new System.Drawing.Size(105, 31);
            this.Innings_1_Table_1.TabIndex = 0;
            // 
            // Innings_1_Team_Name_1
            // 
            this.Innings_1_Team_Name_1.AutoSize = true;
            this.Innings_1_Team_Name_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Innings_1_Team_Name_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Innings_1_Team_Name_1.Location = new System.Drawing.Point(3, 0);
            this.Innings_1_Team_Name_1.Name = "Innings_1_Team_Name_1";
            this.Innings_1_Team_Name_1.Size = new System.Drawing.Size(99, 15);
            this.Innings_1_Team_Name_1.TabIndex = 0;
            this.Innings_1_Team_Name_1.Text = "Team Name";
            this.Innings_1_Team_Name_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Innings_1_Score_1
            // 
            this.Innings_1_Score_1.AutoSize = true;
            this.Innings_1_Score_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Innings_1_Score_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Innings_1_Score_1.Location = new System.Drawing.Point(3, 15);
            this.Innings_1_Score_1.Name = "Innings_1_Score_1";
            this.Innings_1_Score_1.Size = new System.Drawing.Size(99, 16);
            this.Innings_1_Score_1.TabIndex = 1;
            this.Innings_1_Score_1.Text = "147-6";
            this.Innings_1_Score_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Match_Date_1
            // 
            this.Match_Date_1.AutoSize = true;
            this.Match_Date_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Match_Date_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Match_Date_1.Location = new System.Drawing.Point(3, 0);
            this.Match_Date_1.Name = "Match_Date_1";
            this.Match_Date_1.Size = new System.Drawing.Size(66, 37);
            this.Match_Date_1.TabIndex = 2;
            this.Match_Date_1.Text = "Date";
            this.Match_Date_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Season_Results_Table
            // 
            this.Season_Results_Table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.Season_Results_Table.ColumnCount = 3;
            this.Season_Results_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.61F));
            this.Season_Results_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.78F));
            this.Season_Results_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.61F));
            this.Season_Results_Table.Controls.Add(this.Results_Lost_Table, 2, 0);
            this.Season_Results_Table.Controls.Add(this.Results_Drawn_Table, 1, 0);
            this.Season_Results_Table.Controls.Add(this.Results_Win_Table, 0, 0);
            this.Season_Results_Table.Location = new System.Drawing.Point(500, 124);
            this.Season_Results_Table.Name = "Season_Results_Table";
            this.Season_Results_Table.RowCount = 1;
            this.Season_Results_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Season_Results_Table.Size = new System.Drawing.Size(424, 49);
            this.Season_Results_Table.TabIndex = 3;
            // 
            // Results_Lost_Table
            // 
            this.Results_Lost_Table.ColumnCount = 2;
            this.Results_Lost_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Results_Lost_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Results_Lost_Table.Controls.Add(this.Lost_Value, 0, 0);
            this.Results_Lost_Table.Controls.Add(this.Lost_Description, 0, 0);
            this.Results_Lost_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Results_Lost_Table.Location = new System.Drawing.Point(289, 6);
            this.Results_Lost_Table.Name = "Results_Lost_Table";
            this.Results_Lost_Table.RowCount = 1;
            this.Results_Lost_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Results_Lost_Table.Size = new System.Drawing.Size(129, 37);
            this.Results_Lost_Table.TabIndex = 2;
            // 
            // Lost_Value
            // 
            this.Lost_Value.AutoSize = true;
            this.Lost_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lost_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lost_Value.Location = new System.Drawing.Point(67, 0);
            this.Lost_Value.Name = "Lost_Value";
            this.Lost_Value.Size = new System.Drawing.Size(59, 37);
            this.Lost_Value.TabIndex = 2;
            this.Lost_Value.Text = "4";
            this.Lost_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lost_Description
            // 
            this.Lost_Description.AutoSize = true;
            this.Lost_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lost_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lost_Description.ForeColor = System.Drawing.Color.Black;
            this.Lost_Description.Location = new System.Drawing.Point(3, 0);
            this.Lost_Description.Name = "Lost_Description";
            this.Lost_Description.Size = new System.Drawing.Size(58, 37);
            this.Lost_Description.TabIndex = 1;
            this.Lost_Description.Text = "Lost:";
            this.Lost_Description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Results_Drawn_Table
            // 
            this.Results_Drawn_Table.ColumnCount = 2;
            this.Results_Drawn_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.0146F));
            this.Results_Drawn_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.9854F));
            this.Results_Drawn_Table.Controls.Add(this.Drawn_Value, 0, 0);
            this.Results_Drawn_Table.Controls.Add(this.Drawn_Description, 0, 0);
            this.Results_Drawn_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Results_Drawn_Table.Location = new System.Drawing.Point(143, 6);
            this.Results_Drawn_Table.Name = "Results_Drawn_Table";
            this.Results_Drawn_Table.RowCount = 1;
            this.Results_Drawn_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Results_Drawn_Table.Size = new System.Drawing.Size(137, 37);
            this.Results_Drawn_Table.TabIndex = 1;
            // 
            // Drawn_Value
            // 
            this.Drawn_Value.AutoSize = true;
            this.Drawn_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawn_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drawn_Value.Location = new System.Drawing.Point(77, 0);
            this.Drawn_Value.Name = "Drawn_Value";
            this.Drawn_Value.Size = new System.Drawing.Size(57, 37);
            this.Drawn_Value.TabIndex = 2;
            this.Drawn_Value.Text = "2";
            this.Drawn_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Drawn_Description
            // 
            this.Drawn_Description.AutoSize = true;
            this.Drawn_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawn_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drawn_Description.ForeColor = System.Drawing.Color.Black;
            this.Drawn_Description.Location = new System.Drawing.Point(3, 0);
            this.Drawn_Description.Name = "Drawn_Description";
            this.Drawn_Description.Size = new System.Drawing.Size(68, 37);
            this.Drawn_Description.TabIndex = 1;
            this.Drawn_Description.Text = "Drawn:";
            this.Drawn_Description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Results_Win_Table
            // 
            this.Results_Win_Table.ColumnCount = 2;
            this.Results_Win_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Results_Win_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Results_Win_Table.Controls.Add(this.Won_Description, 0, 0);
            this.Results_Win_Table.Controls.Add(this.Won_Value, 1, 0);
            this.Results_Win_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Results_Win_Table.Location = new System.Drawing.Point(6, 6);
            this.Results_Win_Table.Name = "Results_Win_Table";
            this.Results_Win_Table.RowCount = 1;
            this.Results_Win_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Results_Win_Table.Size = new System.Drawing.Size(128, 37);
            this.Results_Win_Table.TabIndex = 0;
            // 
            // Won_Description
            // 
            this.Won_Description.AutoSize = true;
            this.Won_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Won_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Won_Description.ForeColor = System.Drawing.Color.Black;
            this.Won_Description.Location = new System.Drawing.Point(3, 0);
            this.Won_Description.Name = "Won_Description";
            this.Won_Description.Size = new System.Drawing.Size(58, 37);
            this.Won_Description.TabIndex = 0;
            this.Won_Description.Text = "Won:";
            this.Won_Description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Won_Value
            // 
            this.Won_Value.AutoSize = true;
            this.Won_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Won_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Won_Value.Location = new System.Drawing.Point(67, 0);
            this.Won_Value.Name = "Won_Value";
            this.Won_Value.Size = new System.Drawing.Size(58, 37);
            this.Won_Value.TabIndex = 1;
            this.Won_Value.Text = "11";
            this.Won_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // This_Season_Heading
            // 
            this.This_Season_Heading.AutoSize = true;
            this.This_Season_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.This_Season_Heading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.This_Season_Heading.Location = new System.Drawing.Point(495, 69);
            this.This_Season_Heading.Name = "This_Season_Heading";
            this.This_Season_Heading.Size = new System.Drawing.Size(143, 25);
            this.This_Season_Heading.TabIndex = 1;
            this.This_Season_Heading.Text = "This Season";
            // 
            // Previous_Match_Heading
            // 
            this.Previous_Match_Heading.AutoSize = true;
            this.Previous_Match_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Previous_Match_Heading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Previous_Match_Heading.Location = new System.Drawing.Point(36, 69);
            this.Previous_Match_Heading.Name = "Previous_Match_Heading";
            this.Previous_Match_Heading.Size = new System.Drawing.Size(261, 25);
            this.Previous_Match_Heading.TabIndex = 0;
            this.Previous_Match_Heading.Text = "Previous Match Results";
            // 
            // Match_Details_Tab
            // 
            this.Match_Details_Tab.BackColor = System.Drawing.Color.Green;
            this.Match_Details_Tab.Controls.Add(this.Load_Match_Details_Button);
            this.Match_Details_Tab.Controls.Add(this.Weather_Selector);
            this.Match_Details_Tab.Controls.Add(this.Match_Type_Selector);
            this.Match_Details_Tab.Controls.Add(this.Venue_Name);
            this.Match_Details_Tab.Controls.Add(this.Away_Team_Name);
            this.Match_Details_Tab.Controls.Add(this.Home_Team_Name);
            this.Match_Details_Tab.Controls.Add(this.Next_Tab_Button);
            this.Match_Details_Tab.Controls.Add(this.label1);
            this.Match_Details_Tab.Controls.Add(this.Match_Date_Picker);
            this.Match_Details_Tab.Controls.Add(this.Weather_Label);
            this.Match_Details_Tab.Controls.Add(this.Venue_Label);
            this.Match_Details_Tab.Controls.Add(this.Away_Team_Label);
            this.Match_Details_Tab.Controls.Add(this.Home_Team_Label);
            this.Match_Details_Tab.Controls.Add(this.Date_Label);
            this.Match_Details_Tab.Controls.Add(this.Match_Details_Heading);
            this.Match_Details_Tab.Location = new System.Drawing.Point(4, 22);
            this.Match_Details_Tab.Name = "Match_Details_Tab";
            this.Match_Details_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Match_Details_Tab.Size = new System.Drawing.Size(956, 536);
            this.Match_Details_Tab.TabIndex = 1;
            this.Match_Details_Tab.Text = "Match Details";
            // 
            // Next_Tab_Button
            // 
            this.Next_Tab_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Next_Tab_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Next_Tab_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next_Tab_Button.Location = new System.Drawing.Point(781, 465);
            this.Next_Tab_Button.Name = "Next_Tab_Button";
            this.Next_Tab_Button.Size = new System.Drawing.Size(143, 45);
            this.Next_Tab_Button.TabIndex = 16;
            this.Next_Tab_Button.Text = "Next";
            this.Next_Tab_Button.UseVisualStyleBackColor = true;
            this.Next_Tab_Button.Click += new System.EventHandler(this.Next_Tab_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(261, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Match Type:";
            // 
            // Match_Date_Picker
            // 
            this.Match_Date_Picker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Match_Date_Picker.Location = new System.Drawing.Point(436, 133);
            this.Match_Date_Picker.Name = "Match_Date_Picker";
            this.Match_Date_Picker.Size = new System.Drawing.Size(175, 20);
            this.Match_Date_Picker.TabIndex = 7;
            this.Match_Date_Picker.ValueChanged += new System.EventHandler(this.Match_Date_Picker_ValueChanged);
            // 
            // Weather_Label
            // 
            this.Weather_Label.AutoSize = true;
            this.Weather_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Weather_Label.ForeColor = System.Drawing.Color.Black;
            this.Weather_Label.Location = new System.Drawing.Point(261, 407);
            this.Weather_Label.Name = "Weather_Label";
            this.Weather_Label.Size = new System.Drawing.Size(82, 20);
            this.Weather_Label.TabIndex = 5;
            this.Weather_Label.Text = "Weather:";
            // 
            // Venue_Label
            // 
            this.Venue_Label.AutoSize = true;
            this.Venue_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Venue_Label.ForeColor = System.Drawing.Color.Black;
            this.Venue_Label.Location = new System.Drawing.Point(261, 298);
            this.Venue_Label.Name = "Venue_Label";
            this.Venue_Label.Size = new System.Drawing.Size(66, 20);
            this.Venue_Label.TabIndex = 4;
            this.Venue_Label.Text = "Venue:";
            // 
            // Away_Team_Label
            // 
            this.Away_Team_Label.AutoSize = true;
            this.Away_Team_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Away_Team_Label.ForeColor = System.Drawing.Color.Black;
            this.Away_Team_Label.Location = new System.Drawing.Point(261, 243);
            this.Away_Team_Label.Name = "Away_Team_Label";
            this.Away_Team_Label.Size = new System.Drawing.Size(105, 20);
            this.Away_Team_Label.TabIndex = 3;
            this.Away_Team_Label.Text = "Away Team:";
            // 
            // Home_Team_Label
            // 
            this.Home_Team_Label.AutoSize = true;
            this.Home_Team_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home_Team_Label.ForeColor = System.Drawing.Color.Black;
            this.Home_Team_Label.Location = new System.Drawing.Point(261, 188);
            this.Home_Team_Label.Name = "Home_Team_Label";
            this.Home_Team_Label.Size = new System.Drawing.Size(110, 20);
            this.Home_Team_Label.TabIndex = 2;
            this.Home_Team_Label.Text = "Home Team:";
            // 
            // Date_Label
            // 
            this.Date_Label.AutoSize = true;
            this.Date_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_Label.ForeColor = System.Drawing.Color.Black;
            this.Date_Label.Location = new System.Drawing.Point(261, 133);
            this.Date_Label.Name = "Date_Label";
            this.Date_Label.Size = new System.Drawing.Size(53, 20);
            this.Date_Label.TabIndex = 1;
            this.Date_Label.Text = "Date:";
            // 
            // Match_Details_Heading
            // 
            this.Match_Details_Heading.AutoSize = true;
            this.Match_Details_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Match_Details_Heading.Location = new System.Drawing.Point(256, 78);
            this.Match_Details_Heading.Name = "Match_Details_Heading";
            this.Match_Details_Heading.Size = new System.Drawing.Size(241, 39);
            this.Match_Details_Heading.TabIndex = 0;
            this.Match_Details_Heading.Text = "Match Details";
            // 
            // Team_Details_Tab
            // 
            this.Team_Details_Tab.BackColor = System.Drawing.Color.Green;
            this.Team_Details_Tab.Controls.Add(this.Load_Home_Team);
            this.Team_Details_Tab.Controls.Add(this.Load_Away_Team);
            this.Team_Details_Tab.Controls.Add(this.Begin_Match_Button);
            this.Team_Details_Tab.Controls.Add(this.Add_Player_Home);
            this.Team_Details_Tab.Controls.Add(this.Add_Player_Away);
            this.Team_Details_Tab.Controls.Add(this.tableLayoutPanel_Home);
            this.Team_Details_Tab.Controls.Add(this.tableLayoutPanel_Away);
            this.Team_Details_Tab.Controls.Add(this.Away_Team_Heading);
            this.Team_Details_Tab.Controls.Add(this.Home_Team_Heading);
            this.Team_Details_Tab.Location = new System.Drawing.Point(4, 22);
            this.Team_Details_Tab.Name = "Team_Details_Tab";
            this.Team_Details_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Team_Details_Tab.Size = new System.Drawing.Size(956, 536);
            this.Team_Details_Tab.TabIndex = 2;
            this.Team_Details_Tab.Text = "Team Details";
            // 
            // Begin_Match_Button
            // 
            this.Begin_Match_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Begin_Match_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Begin_Match_Button.Location = new System.Drawing.Point(781, 465);
            this.Begin_Match_Button.Name = "Begin_Match_Button";
            this.Begin_Match_Button.Size = new System.Drawing.Size(143, 45);
            this.Begin_Match_Button.TabIndex = 10;
            this.Begin_Match_Button.Text = "Begin Match";
            this.Begin_Match_Button.UseVisualStyleBackColor = true;
            this.Begin_Match_Button.Click += new System.EventHandler(this.Begin_Match_Button_Click);
            // 
            // Add_Player_Home
            // 
            this.Add_Player_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_Player_Home.Location = new System.Drawing.Point(497, 436);
            this.Add_Player_Home.Name = "Add_Player_Home";
            this.Add_Player_Home.Size = new System.Drawing.Size(102, 30);
            this.Add_Player_Home.TabIndex = 9;
            this.Add_Player_Home.Text = "Add Player";
            this.Add_Player_Home.UseVisualStyleBackColor = true;
            this.Add_Player_Home.Click += new System.EventHandler(this.Add_Player_Home_Click);
            // 
            // Add_Player_Away
            // 
            this.Add_Player_Away.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_Player_Away.Location = new System.Drawing.Point(65, 436);
            this.Add_Player_Away.Name = "Add_Player_Away";
            this.Add_Player_Away.Size = new System.Drawing.Size(102, 30);
            this.Add_Player_Away.TabIndex = 8;
            this.Add_Player_Away.Text = "Add Player";
            this.Add_Player_Away.UseVisualStyleBackColor = true;
            this.Add_Player_Away.Click += new System.EventHandler(this.Add_Player_Away_Click);
            // 
            // tableLayoutPanel_Home
            // 
            this.tableLayoutPanel_Home.ColumnCount = 2;
            this.tableLayoutPanel_Home.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Home.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel_Home.Controls.Add(this.Home_Player_1, 1, 0);
            this.tableLayoutPanel_Home.Controls.Add(this.Home_Player_Number, 0, 0);
            this.tableLayoutPanel_Home.Location = new System.Drawing.Point(497, 108);
            this.tableLayoutPanel_Home.Name = "tableLayoutPanel_Home";
            this.tableLayoutPanel_Home.RowCount = 11;
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.701492F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.208955F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Home.Size = new System.Drawing.Size(250, 322);
            this.tableLayoutPanel_Home.TabIndex = 7;
            // 
            // Home_Player_1
            // 
            this.Home_Player_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Home_Player_1.Location = new System.Drawing.Point(57, 5);
            this.Home_Player_1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Home_Player_1.Name = "Home_Player_1";
            this.Home_Player_1.Size = new System.Drawing.Size(190, 20);
            this.Home_Player_1.TabIndex = 0;
            this.Home_Player_1.Text = "Enter Player Name";
            // 
            // Home_Player_Number
            // 
            this.Home_Player_Number.AutoSize = true;
            this.Home_Player_Number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Home_Player_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home_Player_Number.Location = new System.Drawing.Point(3, 0);
            this.Home_Player_Number.Name = "Home_Player_Number";
            this.Home_Player_Number.Size = new System.Drawing.Size(48, 31);
            this.Home_Player_Number.TabIndex = 1;
            this.Home_Player_Number.Text = "1";
            this.Home_Player_Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_Away
            // 
            this.tableLayoutPanel_Away.ColumnCount = 2;
            this.tableLayoutPanel_Away.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Away.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel_Away.Controls.Add(this.Away_Player_Name_1, 1, 0);
            this.tableLayoutPanel_Away.Controls.Add(this.Away_Player_Number, 0, 0);
            this.tableLayoutPanel_Away.Location = new System.Drawing.Point(65, 108);
            this.tableLayoutPanel_Away.Name = "tableLayoutPanel_Away";
            this.tableLayoutPanel_Away.RowCount = 11;
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.701492F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.208955F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel_Away.Size = new System.Drawing.Size(250, 322);
            this.tableLayoutPanel_Away.TabIndex = 3;
            // 
            // Away_Player_Name_1
            // 
            this.Away_Player_Name_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Away_Player_Name_1.Location = new System.Drawing.Point(57, 5);
            this.Away_Player_Name_1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Away_Player_Name_1.Name = "Away_Player_Name_1";
            this.Away_Player_Name_1.Size = new System.Drawing.Size(190, 20);
            this.Away_Player_Name_1.TabIndex = 0;
            this.Away_Player_Name_1.Text = "Enter Player Name";
            // 
            // Away_Player_Number
            // 
            this.Away_Player_Number.AutoSize = true;
            this.Away_Player_Number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Away_Player_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Away_Player_Number.Location = new System.Drawing.Point(3, 0);
            this.Away_Player_Number.Name = "Away_Player_Number";
            this.Away_Player_Number.Size = new System.Drawing.Size(48, 31);
            this.Away_Player_Number.TabIndex = 1;
            this.Away_Player_Number.Text = "1";
            this.Away_Player_Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Away_Team_Heading
            // 
            this.Away_Team_Heading.AutoSize = true;
            this.Away_Team_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Away_Team_Heading.Location = new System.Drawing.Point(60, 58);
            this.Away_Team_Heading.Name = "Away_Team_Heading";
            this.Away_Team_Heading.Size = new System.Drawing.Size(133, 25);
            this.Away_Team_Heading.TabIndex = 1;
            this.Away_Team_Heading.Text = "Away Team";
            // 
            // Home_Team_Heading
            // 
            this.Home_Team_Heading.AutoSize = true;
            this.Home_Team_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home_Team_Heading.Location = new System.Drawing.Point(492, 58);
            this.Home_Team_Heading.Name = "Home_Team_Heading";
            this.Home_Team_Heading.Size = new System.Drawing.Size(137, 25);
            this.Home_Team_Heading.TabIndex = 0;
            this.Home_Team_Heading.Text = "Home Team";
            // 
            // Load_Match_Details_Dialog
            // 
            this.Load_Match_Details_Dialog.FileName = "openFileDialog1";
            // 
            // Weather_Selector
            // 
            this.Weather_Selector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Weather_Selector.FormattingEnabled = true;
            this.Weather_Selector.Items.AddRange(new object[] {
            "Sunny",
            "Overcast",
            "Clear"});
            this.Weather_Selector.Location = new System.Drawing.Point(436, 407);
            this.Weather_Selector.Name = "Weather_Selector";
            this.Weather_Selector.Size = new System.Drawing.Size(175, 21);
            this.Weather_Selector.TabIndex = 21;
            // 
            // Match_Type_Selector
            // 
            this.Match_Type_Selector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Match_Type_Selector.FormattingEnabled = true;
            this.Match_Type_Selector.Items.AddRange(new object[] {
            "T20",
            "40 Over",
            "Friendly"});
            this.Match_Type_Selector.Location = new System.Drawing.Point(436, 353);
            this.Match_Type_Selector.Name = "Match_Type_Selector";
            this.Match_Type_Selector.Size = new System.Drawing.Size(175, 21);
            this.Match_Type_Selector.TabIndex = 20;
            // 
            // Venue_Name
            // 
            this.Venue_Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Venue_Name.Location = new System.Drawing.Point(436, 298);
            this.Venue_Name.Name = "Venue_Name";
            this.Venue_Name.Size = new System.Drawing.Size(175, 20);
            this.Venue_Name.TabIndex = 19;
            // 
            // Away_Team_Name
            // 
            this.Away_Team_Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Away_Team_Name.Location = new System.Drawing.Point(436, 243);
            this.Away_Team_Name.Name = "Away_Team_Name";
            this.Away_Team_Name.Size = new System.Drawing.Size(175, 20);
            this.Away_Team_Name.TabIndex = 18;
            // 
            // Home_Team_Name
            // 
            this.Home_Team_Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Home_Team_Name.Location = new System.Drawing.Point(436, 188);
            this.Home_Team_Name.Name = "Home_Team_Name";
            this.Home_Team_Name.Size = new System.Drawing.Size(175, 20);
            this.Home_Team_Name.TabIndex = 17;
            // 
            // Load_Match_Details_Button
            // 
            this.Load_Match_Details_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Load_Match_Details_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Load_Match_Details_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_Match_Details_Button.Location = new System.Drawing.Point(781, 397);
            this.Load_Match_Details_Button.Name = "Load_Match_Details_Button";
            this.Load_Match_Details_Button.Size = new System.Drawing.Size(143, 45);
            this.Load_Match_Details_Button.TabIndex = 22;
            this.Load_Match_Details_Button.Text = "Load Match";
            this.Load_Match_Details_Button.UseVisualStyleBackColor = true;
            this.Load_Match_Details_Button.Click += new System.EventHandler(this.Load_Match_Details_Button_Click);
            // 
            // Load_Away_Team
            // 
            this.Load_Away_Team.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Load_Away_Team.Location = new System.Drawing.Point(213, 436);
            this.Load_Away_Team.Name = "Load_Away_Team";
            this.Load_Away_Team.Size = new System.Drawing.Size(102, 30);
            this.Load_Away_Team.TabIndex = 11;
            this.Load_Away_Team.Text = "Load Team";
            this.Load_Away_Team.UseVisualStyleBackColor = true;
            this.Load_Away_Team.Click += new System.EventHandler(this.Load_Away_Team_Click);
            // 
            // Load_Home_Team
            // 
            this.Load_Home_Team.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Load_Home_Team.Location = new System.Drawing.Point(645, 436);
            this.Load_Home_Team.Name = "Load_Home_Team";
            this.Load_Home_Team.Size = new System.Drawing.Size(102, 30);
            this.Load_Home_Team.TabIndex = 12;
            this.Load_Home_Team.Text = "Load Team";
            this.Load_Home_Team.UseVisualStyleBackColor = true;
            this.Load_Home_Team.Click += new System.EventHandler(this.Load_Home_Team_Click);
            // 
            // Load_Away_Team_Dialog
            // 
            this.Load_Away_Team_Dialog.FileName = "openFileDialog1";
            // 
            // Load_Home_Team_Dialog
            // 
            this.Load_Home_Team_Dialog.FileName = "openFileDialog2";
            // 
            // Scoring_App_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(964, 562);
            this.Controls.Add(this.Details_Tab_Set);
            this.MaximizeBox = false;
            this.Name = "Scoring_App_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uplands Cricket Club";
            this.Details_Tab_Set.ResumeLayout(false);
            this.Home_Tab.ResumeLayout(false);
            this.Home_Tab.PerformLayout();
            this.Previous_Match_Table.ResumeLayout(false);
            this.Previous_Match_Table_Row_1.ResumeLayout(false);
            this.Previous_Match_Table_Row_1.PerformLayout();
            this.Innings_2_Table_2.ResumeLayout(false);
            this.Innings_2_Table_2.PerformLayout();
            this.Innings_1_Table_1.ResumeLayout(false);
            this.Innings_1_Table_1.PerformLayout();
            this.Season_Results_Table.ResumeLayout(false);
            this.Results_Lost_Table.ResumeLayout(false);
            this.Results_Lost_Table.PerformLayout();
            this.Results_Drawn_Table.ResumeLayout(false);
            this.Results_Drawn_Table.PerformLayout();
            this.Results_Win_Table.ResumeLayout(false);
            this.Results_Win_Table.PerformLayout();
            this.Match_Details_Tab.ResumeLayout(false);
            this.Match_Details_Tab.PerformLayout();
            this.Team_Details_Tab.ResumeLayout(false);
            this.Team_Details_Tab.PerformLayout();
            this.tableLayoutPanel_Home.ResumeLayout(false);
            this.tableLayoutPanel_Home.PerformLayout();
            this.tableLayoutPanel_Away.ResumeLayout(false);
            this.tableLayoutPanel_Away.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Details_Tab_Set;
        private System.Windows.Forms.TabPage Home_Tab;
        private System.Windows.Forms.TabPage Match_Details_Tab;
        private System.Windows.Forms.TabPage Team_Details_Tab;
        private System.Windows.Forms.TableLayoutPanel Season_Results_Table;
        private System.Windows.Forms.TableLayoutPanel Results_Lost_Table;
        private System.Windows.Forms.Label Lost_Description;
        private System.Windows.Forms.TableLayoutPanel Results_Drawn_Table;
        private System.Windows.Forms.Label Drawn_Description;
        private System.Windows.Forms.TableLayoutPanel Results_Win_Table;
        private System.Windows.Forms.Label Won_Description;
        private System.Windows.Forms.Label This_Season_Heading;
        private System.Windows.Forms.Label Previous_Match_Heading;
        private System.Windows.Forms.Label Lost_Value;
        private System.Windows.Forms.Label Drawn_Value;
        private System.Windows.Forms.Label Won_Value;
        private System.Windows.Forms.Label Weather_Label;
        private System.Windows.Forms.Label Venue_Label;
        private System.Windows.Forms.Label Away_Team_Label;
        private System.Windows.Forms.Label Home_Team_Label;
        private System.Windows.Forms.Label Date_Label;
        private System.Windows.Forms.Label Match_Details_Heading;
        private System.Windows.Forms.Label Away_Team_Heading;
        private System.Windows.Forms.Label Home_Team_Heading;
        private System.Windows.Forms.TextBox Away_Player_Name_1;
        private System.Windows.Forms.Label Away_Player_Number;
        private System.Windows.Forms.TextBox Home_Player_1;
        private System.Windows.Forms.Label Home_Player_Number;
        private System.Windows.Forms.TableLayoutPanel Innings_1_Table_1;
        private System.Windows.Forms.Label Innings_1_Team_Name_1;
        private System.Windows.Forms.Label Innings_1_Score_1;
        private System.Windows.Forms.TableLayoutPanel Innings_2_Table_2;
        private System.Windows.Forms.Label Innings_2_Team_Name_1;
        private System.Windows.Forms.Label Innings_1_Score_2;
        private System.Windows.Forms.Label Match_Date_1;
        private System.Windows.Forms.Label Match_Result_1;
        private System.Windows.Forms.TableLayoutPanel Previous_Match_Table;
        private System.Windows.Forms.TableLayoutPanel Previous_Match_Table_Row_1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker Match_Date_Picker;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Away;
        private System.Windows.Forms.Button Start_New_Match_Button;
        private System.Windows.Forms.Button Next_Tab_Button;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Home;
        private System.Windows.Forms.Button Add_Player_Away;
        private System.Windows.Forms.Button Add_Player_Home;
        private System.Windows.Forms.Button Begin_Match_Button;
        private System.Windows.Forms.OpenFileDialog Load_Match_Details_Dialog;
        public System.Windows.Forms.ComboBox Weather_Selector;
        public System.Windows.Forms.ComboBox Match_Type_Selector;
        public System.Windows.Forms.TextBox Venue_Name;
        public System.Windows.Forms.TextBox Away_Team_Name;
        public System.Windows.Forms.TextBox Home_Team_Name;
        private System.Windows.Forms.Button Load_Match_Details_Button;
        private System.Windows.Forms.Button Load_Home_Team;
        private System.Windows.Forms.Button Load_Away_Team;
        private System.Windows.Forms.OpenFileDialog Load_Away_Team_Dialog;
        private System.Windows.Forms.OpenFileDialog Load_Home_Team_Dialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

