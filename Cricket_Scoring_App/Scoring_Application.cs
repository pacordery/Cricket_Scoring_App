using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cricket_Scoring_App
{
    public partial class Scoring_Application_Form : Form
    {
        ScorecardHandler scorecardHandler = new ScorecardHandler();
        // Initialise all lists required for the application
        List<string> MatchDetailsList = new List<string>();
        List<string> HomeTeamList = new List<string>();
        List<string> AwayTeamList = new List<string>();
        List<string> NextBatsmanList = new List<string>();
        List<string> NewBowlerList = new List<string>();
        public List<Innings> InningsList = new List<Innings>();
        List<Player> BatList = new List<Player>();
        List<Player> BowlList = new List<Player>();
        List<FallOfWicket> FallOfWicketList = new List<FallOfWicket>();
        List<string> GraphSeriesList = new List<string>();
        List<Over> OverAnalysisList = new List<Over>();

        List<Player> Innings1BatsmanList = new List<Player>();
        List<Player> Innings1BowlerList = new List<Player>();
        List<Over> Innings1OverList = new List<Over>();
        List<FallOfWicket> Innings1fallOfWicketList = new List<FallOfWicket>();

        List<Over> Innings2OverList = new List<Over>();
        List<Player> Innings2BatsmanList = new List<Player>();
        List<Player> Innings2BowlerList = new List<Player>();
        List<FallOfWicket> Innings2fallOfWicketList = new List<FallOfWicket>();

        // Initialises the destination folder for all files. This is created after match details are entered.
        public string folderName { get; set; }

        // Initialising variables required in this class
        string Home_Team;
        string Away_Team;
        int Innings_Id;
        string Innings_Of;
        int Last_Bat_Out;
        string Innings_1_Score;
        string Innings_2_Score;

        public Scoring_Application_Form(string FolderName)
        {
            InitializeComponent();
            this.folderName = FolderName;
        }

        // Load function to read all text files created in the previous form, information is stored into the applications lists
        private void Scoring_Application_Form_Load(object sender, EventArgs e)
        {
            // On load the innings to be scored is the first innings
            Innings_Id = 0;

            Match match = new Match();
            Match awayTeamHandler = new Match();

            // Storing match and team details into lists
            MatchDetailsList = match.GetMatchDetails(this.folderName);
            HomeTeamList = match.GetTeamDetails(MatchDetailsList[1], this.folderName);
            AwayTeamList = awayTeamHandler.GetTeamDetails(MatchDetailsList[2], this.folderName);

            // Insert team names into the Toss Winner combo box on the Opener Selection tab
            Toss_Winner_Combo_Box.Items.Clear();
            Toss_Winner_Combo_Box.Items.Add(MatchDetailsList[1]);
            Toss_Winner_Combo_Box.Items.Add(MatchDetailsList[2]);

            // Insert team names into the Batting Side combo box on the Opener Selection tab
            Open_Select_Bat_Side.Items.Clear();
            Open_Select_Bat_Side.Items.Add(MatchDetailsList[1]);
            Open_Select_Bat_Side.Items.Add(MatchDetailsList[2]);
        }

        // // Populates all dropdowns on the scoring tab, depending on which side is batting
        private void Populate_Scorecard_Player_Combo_Boxes(List<string> battingList, string batting, List<string> bowlingList, string bowling)
        {
            Wicket_Next_Bat_Combo_Box.Items.Clear();
            Wicket_Fielder_Select_Combo_Box.Items.Clear();
            Run_Out_Fielder_Combo.Items.Clear();
            New_Bowler_Combo_Box.Items.Clear();
            NextBatsmanList.Clear();
            for (int i = 0; i < battingList.Count(); i = i + 1)
            {
                NextBatsmanList.Add(battingList[i]);
                Wicket_Next_Bat_Combo_Box.Items.Add(battingList[i]);
            }
            for (int j = 0; j < bowlingList.Count(); j = j + 1)
            {
                Wicket_Fielder_Select_Combo_Box.Items.Add(bowlingList[j]);
                Run_Out_Fielder_Combo.Items.Add(bowlingList[j]);
                New_Bowler_Combo_Box.Items.Add(bowlingList[j]);
            }
        }

        // Populates batsman and bowler dropdowns on both select openers tabs, depending on which side is batting
        private void Populate_Bat_Bowl_Select_Combo_Boxes(List<string> battingList, string batting, List<string> bowlingList, string bowling)
        {
            for (int i = 0; i < battingList.Count(); i = i + 1)
            {
                Open_Select_Bat_1.Items.Add(battingList[i]);
                Open_Select_Bat_2.Items.Add(battingList[i]);
                Open_Select_Bowl_1_Inn_2.Items.Add(battingList[i]);
                Open_Select_Bowl_2_Inn_2.Items.Add(battingList[i]);
            }
            for (int j = 0; j < bowlingList.Count(); j = j + 1)
            {
                Open_Select_Bowl_1.Items.Add(bowlingList[j]);
                Open_Select_Bowl_2.Items.Add(bowlingList[j]);
                Open_Select_Bat_1_Inn_2.Items.Add(bowlingList[j]);
                Open_Select_Bat_2_Inn_2.Items.Add(bowlingList[j]);
            }
        }

        // Updates the combo box in the wickets flow panel to only show the batsmen left to bat
        private void Update_Next_Batsman_List(string batsmanName)
        {
            Wicket_Next_Bat_Combo_Box.Items.Clear();
            NextBatsmanList.Remove(batsmanName);

            for (int i = 0; i < NextBatsmanList.Count; i = i + 1)
            {
                if (NextBatsmanList.Count == 1)
                {
                    Wicket_Next_Bat_Combo_Box.Items.Add("End of Innings");
                }
                Wicket_Next_Bat_Combo_Box.Items.Add(NextBatsmanList[i]);
            }
        }

        /* When the user selects which side is batting in the Batting Side Combo Box,
         * the application will only show the batting side in the batsman select boxes
         * and only the bowling side in the bowler select boxes. */
        private void Open_Select_Bat_Side_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear all current items from batting and bowing selection lists
            Open_Select_Bat_1.Items.Clear();
            Open_Select_Bat_2.Items.Clear();
            Open_Select_Bowl_1.Items.Clear();
            Open_Select_Bowl_2.Items.Clear();
            Open_Select_Bat_1_Inn_2.Items.Clear();
            Open_Select_Bat_2_Inn_2.Items.Clear();
            Open_Select_Bowl_1_Inn_2.Items.Clear();
            Open_Select_Bowl_2_Inn_2.Items.Clear();

            Home_Team = MatchDetailsList[1];
            Away_Team = MatchDetailsList[2];

            if (Open_Select_Bat_Side.SelectedItem.ToString() == Home_Team)
            {
                Populate_Scorecard_Player_Combo_Boxes(HomeTeamList, Home_Team, AwayTeamList, Away_Team);
                Populate_Bat_Bowl_Select_Combo_Boxes(HomeTeamList, Home_Team, AwayTeamList, Away_Team);
                Innings_Of = Home_Team;
            }
            else
            {
                Populate_Scorecard_Player_Combo_Boxes(AwayTeamList, Away_Team, HomeTeamList, Home_Team);
                Populate_Bat_Bowl_Select_Combo_Boxes(AwayTeamList, Away_Team, HomeTeamList, Home_Team);
                Innings_Of = Away_Team;
            }

            First_Inn_Innings_Of.Text = Innings_Of;
        }

        // This function hides all of the flow control panels that are not reqired
        public void HideAllPanels()
        {         
            Flow_Panel_Byes.Hide();
            Flow_Panel_Leg_Byes.Hide();
            Flow_Panel_No_Ball_Bat.Hide();
            Flow_Panel_No_Ball_No_Bat.Hide();
            Flow_Panel_No_Ball_Question.Hide();
            Flow_Panel_Wides.Hide();
            Flow_Panel_Wicket.Hide();
            Flow_Panel_Fielder.Hide();
            Flow_Panel_Run_Out.Hide();
            Flow_Panel_New_Bowler.Hide();
            Flow_Panel_End_Of_Innings.Hide();
        }

        // Inintialises all variables at the start of an innings
        private void Set_Default_Variables()
        {
            HideAllPanels();
            Innings innings = new Innings();
            innings.Create_Innings(MatchDetailsList, Toss_Winner_Combo_Box.SelectedItem.ToString(), Innings_Of);
            InningsList.Add(innings);
            // Gets the team name for the second innings
            GraphSeriesList.Add(InningsList[Innings_Id].Team_Name);
            Over over = new Over();
            over.Create_Over(0,0,0,0);
            OverAnalysisList.Add(over);

            // Sets Extra table details
            Wides_Total_Value.Text = innings.Extras_Wides.ToString();
            No_Balls_Total_Value.Text = innings.Extras_No_Balls.ToString();
            Byes_Total_Value.Text = innings.Extras_Byes.ToString();
            Leg_Byes_Total_Value.Text = innings.Extras_Leg_Byes.ToString();
            Penaltys_Total_Value.Text = innings.Extras_Penaltys.ToString();
            Total_Extras_Value.Text = innings.Extras_Total.ToString();

            // Sets match details
            Scoring_Date_Value.Text = innings.Date;
            Scoring_Innings_Of_Value.Text = InningsList[Innings_Id].Team_Name;
            Scoring_Total_Value.Text = innings.Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = innings.Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = innings.Innings_Overs.ToString();

            // Initialise opening player objects
            Player batTop = new Player();
            Player batBottom = new Player();
            Player bowlTop = new Player();
            Player bowlBottom = new Player();

            if (Innings_Id == 0)
            {
                batTop.Create_Batsman((InningsList[0].topBatId + 1), Open_Select_Bat_1.SelectedItem.ToString(), true);
                batBottom.Create_Batsman((InningsList[0].bottomBatId + 1), Open_Select_Bat_2.SelectedItem.ToString(), false);
                bowlTop.Create_Bowler((InningsList[0].topBowlId + 1), Open_Select_Bowl_1.SelectedItem.ToString(), true);
                bowlBottom.Create_Bowler((InningsList[0].bottomBowlId + 1), Open_Select_Bowl_2.SelectedItem.ToString(), false);
            }
            else
            {
                batTop.Create_Batsman((InningsList[1].topBatId + 1), Open_Select_Bat_1_Inn_2.SelectedItem.ToString(), true);
                batBottom.Create_Batsman((InningsList[1].bottomBatId + 1), Open_Select_Bat_2_Inn_2.SelectedItem.ToString(), false);
                bowlTop.Create_Bowler((InningsList[1].topBowlId + 1), Open_Select_Bowl_1_Inn_2.SelectedItem.ToString(), true);
                bowlBottom.Create_Bowler((InningsList[1].bottomBowlId + 1), Open_Select_Bowl_2_Inn_2.SelectedItem.ToString(), false);
            }          
            BatList.Add(batTop);
            BatList.Add(batBottom);
            BowlList.Add(bowlTop);
            BowlList.Add(bowlBottom);
            Update_Next_Batsman_List(batTop.Bat_Name);
            Update_Next_Batsman_List(batBottom.Bat_Name);
            Create_Graphs();
            Update_Last_Man_Out_Table();
        }

        // Verify all table entrys in the supplied table. If entries missing, the user will not be able to move to next screen.
        // This stops the application from falling over due to a null exception.
        private bool Verify_Table_Entrys(TableLayoutPanel tableName)
        {
            bool verified = true;
            // Check away team table entries
            for (int i = 0; i < tableName.RowCount; i = i + 1)
            {
                Control c = tableName.GetControlFromPosition(1, i);
                Control d = tableName.GetControlFromPosition(2, i);
                if (String.IsNullOrWhiteSpace(c.Text))
                {
                    d.Text = "*";
                    c.BackColor = Color.DarkOrange;
                    verified = false;
                }
                else
                {
                    c.BackColor = Color.White;
                    d.Text = "";
                }
            }
            return verified;
        }

        // Checks that the named combo box has had a value selected before button function is run.
        // This stops the application from falling over due to a null exception.
        private bool Verify_Combo_Selection(ComboBox comboBoxName)
        {
            bool selected = true;
            if ( comboBoxName.SelectedItem.ToString() == "Select Batsman" || comboBoxName.SelectedItem.ToString() == "Select Bowler"
              || comboBoxName.SelectedItem.ToString() == "Select Other Score" || comboBoxName.SelectedItem.ToString() == "Select Fielder"
              || comboBoxName.SelectedItem.ToString() == "Select Reason" )
            {
                comboBoxName.Text = "* Select player";
                comboBoxName.BackColor = Color.DarkOrange;
                comboBoxName.Font = new Font("Serif", 9, FontStyle.Bold);
                selected = false;
            }
            else
            {
                comboBoxName.BackColor = Color.White;
                comboBoxName.Font = new Font("Serif", 8, FontStyle.Regular);
            }
            return selected;
        }
        // When confirm button clicked on select openers 1 tab, this function loads all variables into the lists and tables
        private void First_Inn_Openers_Confirm_Button_Click(object sender, EventArgs e)
        {
            if (Verify_Table_Entrys(tableLayoutPanel_Openers_1))
            {
                Second_Inn_Target_Table.Hide();
                Innings2_Pie.Hide();
                FallOfWicketList = Innings1fallOfWicketList;
                BatList = Innings1BatsmanList;
                BowlList = Innings1BowlerList;
                OverAnalysisList = Innings1OverList;

                First_Innings_Tab.Text = Innings_Of;
                if (Innings_Of == Home_Team)
                {
                    Second_Inn_Tab.Text = Away_Team;
                }
                else
                {
                    Second_Inn_Tab.Text = Home_Team;
                }

                // Sets all variables, creates opening player objects and sets all table information for first innings
                Twenty_Overs_Button.Hide();
                Set_Default_Variables();
                Update_Batsman_Top();
                Update_Batsman_Bottom();
                Update_Bowler_Top();
                Update_Bowler_Bottom();

                Current_Batsman_Number_Top.BackColor = Color.White;
                Current_Batsman_Number_Bottom.BackColor = Color.Transparent;
                Current_Bowler_Number_Top.BackColor = Color.White;
                Current_Bowler_Number_Bottom.BackColor = Color.Transparent;
                Create_Undo_Point();
                Update_Innings_Bat_Rows();
                Update_Innings_Bowl_Rows();

                // Set Innings 1 tab table totals
                First_Inn_Bat_Total_Runs.Text = (InningsList[0].Innings_Total - InningsList[0].Extras_Total).ToString();
                First_Inn_Home_Team.Text = Home_Team;
                First_Inn_Away_Team.Text = Away_Team;
                First_Inn_Venue.Text = InningsList[0].Ground_Name;
                First_Inn_Weather.Text = InningsList[0].Weather;
                First_Inn_Total_Overs.Text = InningsList[0].Innings_Overs.ToString();
                First_Inn_Total_Runs.Text = InningsList[0].Innings_Total.ToString();
                First_Inn_Total_Wickets.Text = InningsList[0].Innings_Wickets.ToString();

                // Switch to the scoring tab
                Scoring_App_Tab_Set.SelectedTab = Scoring_Tab;
            }
        }

        // When confirm button clicked on select openers 2 tab, this function loads all variables into the lists and tables
        private void Second_Inn_Openers_Confirm_Button_Click(object sender, EventArgs e)
        {
            if (Verify_Table_Entrys(tableLayoutPanel_Openers_2))
            {
                Second_Inn_Target_Table.Show();
                Innings2_Pie.Show();
                if (InningsList[0].Match_Type == "Friendly")
                {
                    Twenty_Overs_Button.Show();
                }
                Innings_Id = 1;
                FallOfWicketList = Innings2fallOfWicketList;
                BatList = Innings2BatsmanList;
                BowlList = Innings2BowlerList;
                OverAnalysisList = Innings2OverList;
                if (Innings_Of == Home_Team)
                {
                    Populate_Scorecard_Player_Combo_Boxes(HomeTeamList, Home_Team, AwayTeamList, Away_Team);
                }
                else
                {
                    Populate_Scorecard_Player_Combo_Boxes(AwayTeamList, Away_Team, HomeTeamList, Home_Team);
                }
                // Sets all variables, creates opening player objects for second innings
                Set_Default_Variables();


                // Get the target total, balls remaining and runs remaining for second innings
                InningsList[1].targetTotal = InningsList[0].Innings_Total + 1;
                InningsList[1].runsRemaining = InningsList[1].targetTotal;

                if (InningsList[0].Match_Type == "T20")
                {
                    InningsList[1].ballsRemaining = 120;
                }
                else if (InningsList[0].Match_Type == "40 Over")
                {
                    InningsList[1].ballsRemaining = 240;
                }
                else if (InningsList[0].Match_Type == "Friendly")
                {
                    InningsList[1].ballsRemaining = 0;
                }
                // Sets the target total, balls remaining and runs remaining for second innings
                Second_Inn_Target.Text = InningsList[1].targetTotal.ToString();
                Second_Inn_Runs_Remain.Text = InningsList[1].runsRemaining.ToString();
                Second_Inn_Balls_Remain.Text = InningsList[1].ballsRemaining.ToString();

                // Sets the team name of the second innings
                Second_Inn_Innings_Of.Text = InningsList[1].Team_Name;

                // Sets all table information 
                Update_Batsman_Top();
                Update_Batsman_Bottom();
                Update_Bowler_Top();
                Update_Bowler_Bottom();

                Current_Batsman_Number_Top.BackColor = Color.White;
                Current_Batsman_Number_Bottom.BackColor = Color.Transparent;
                Current_Bowler_Number_Top.BackColor = Color.White;
                Current_Bowler_Number_Bottom.BackColor = Color.Transparent;
                Create_Undo_Point();
                Update_Innings_Bat_Rows();
                Update_Innings_Bowl_Rows();

                // Set Innings 2 tab table totals
                Second_Inn_Bat_Total_Runs.Text = (InningsList[1].Innings_Total - InningsList[1].Extras_Total).ToString();
                Second_Inn_Home_Team.Text = Home_Team;
                Second_Inn_Away_Team.Text = Away_Team;
                Second_Inn_Venue.Text = InningsList[1].Ground_Name;
                Second_Inn_Weather.Text = InningsList[1].Weather;
                Second_Inn_Total_Overs.Text = InningsList[1].Innings_Overs.ToString();
                Second_Inn_Total_Runs.Text = InningsList[1].Innings_Total.ToString(); ;
                Second_Inn_Total_Wickets.Text = InningsList[1].Innings_Wickets.ToString();

                // Switch to the scoring tab
                Scoring_App_Tab_Set.SelectedTab = Scoring_Tab;
            }
        }

        // Triggered when each innings has been completed, either due to declaration, weather or full result
        public void End_Of_Innings()
        { 
            if (Innings_Id == 0)
            {
                InningsList[0].Notes = First_Inn_Notes_Textbox.Text;
                Innings1fallOfWicketList = FallOfWicketList;
                Innings1BatsmanList = BatList;
                Innings1BowlerList = BowlList;
                Innings1OverList = OverAnalysisList;
                Innings_1_Score = InningsList[0].Team_Name + "," + InningsList[0].Innings_Total.ToString() + "-" + InningsList[0].Innings_Wickets.ToString();
                Scoring_App_Tab_Set.SelectedTab = Second_Inn_Select_Tab;
                Innings_Of = Second_Inn_Tab.Text;
            }
            else
            {
                Innings2fallOfWicketList = FallOfWicketList;
                InningsList[1].Notes = Second_Inn_Notes_Textbox.Text;
                Innings2BatsmanList = BatList;
                Innings2BowlerList = BowlList;
                Innings_2_Score = InningsList[1].Team_Name + "," + InningsList[1].Innings_Total.ToString() + "-" + InningsList[1].Innings_Wickets.ToString();

                Match match = new Match();
                match.Save_Match_Result(Innings1BatsmanList, Innings1BowlerList, Innings2BatsmanList, Innings2BowlerList, Home_Team, Away_Team, InningsList[0].Date, Innings_1_Score, Innings_2_Score, match.Get_Match_Result(InningsList), this.folderName);
            }
        }

        // This function creates an undo point to allow the user to undo their last operation.
        private void Create_Undo_Point()
        {
            scorecardHandler.Create_Temp_Variables(MatchDetailsList, HomeTeamList, AwayTeamList, NextBatsmanList, NewBowlerList, InningsList, BatList, BowlList,
                                                   FallOfWicketList, GraphSeriesList, OverAnalysisList, Innings1BatsmanList, Innings1BowlerList, Innings1OverList,
                                                   Innings1fallOfWicketList, Innings_Id, Home_Team, Away_Team, Last_Bat_Out);
        }

        /* Restores the score back to the state before the incorrect operation was carried out.
                * Updates the batsman and bowler objects, extras totals and match totals
                * Updates all tables */
        private void Restore_Last_State()
        {
            // Restore all lists from the temp variables, then update the tables
            
            MatchDetailsList = scorecardHandler.Temp_MatchDetailsList;
            HomeTeamList = scorecardHandler.Temp_HomeTeamList;
            AwayTeamList = scorecardHandler.Temp_AwayTeamList;
            NextBatsmanList = scorecardHandler.Temp_NextBatsmanList;
            NewBowlerList = scorecardHandler.Temp_NewBowlerList;
            InningsList = scorecardHandler.Temp_InningsList;
            BatList = scorecardHandler.Temp_BatList;
            BowlList = scorecardHandler.Temp_BowlList;
            FallOfWicketList = scorecardHandler.Temp_FallOfWicketList;
            GraphSeriesList = scorecardHandler.Temp_GraphSeriesList;
            OverAnalysisList = scorecardHandler.Temp_OverAnalysisList;
            Innings1BatsmanList = scorecardHandler.Temp_Innings1BatsmanList;
            Innings1BowlerList = scorecardHandler.Temp_Innings1BowlerList;
            Innings1OverList = scorecardHandler.Temp_Innings1OverList;
            Innings1fallOfWicketList = scorecardHandler.Temp_Innings1FallOfWicketList;
            Innings_Id = scorecardHandler.Temp_InningsId;
            Home_Team = scorecardHandler.Temp_HomeTeamName;
            Away_Team = scorecardHandler.Temp_AwayTeamName;
            Last_Bat_Out = scorecardHandler.Temp_LastBatOut;

            Update_Score();
            Update_Innings_Fall_Of_Wicket();
            Update_Innings_Over_Analysis();

            // Set the current batsman flag
            if (BatList[InningsList[Innings_Id].topBatId].Bat_Facing)
            {
                Current_Batsman_Number_Top.BackColor = Color.White;
                Current_Batsman_Number_Bottom.BackColor = Color.Transparent;  
            }
            else
            {
                Current_Batsman_Number_Top.BackColor = Color.Transparent;
                Current_Batsman_Number_Bottom.BackColor = Color.White;
            }

            // Set the current bowler flag
            if (BowlList[InningsList[Innings_Id].topBowlId].Bowl_Bowling)
            {
                Current_Bowler_Number_Top.BackColor = Color.White;
                Current_Bowler_Number_Bottom.BackColor = Color.Transparent;
            }
            else
            {
                Current_Bowler_Number_Top.BackColor = Color.Transparent;
                Current_Bowler_Number_Bottom.BackColor = Color.White;
            }
        }

        // Updates the batting table for the respective innings
        private void Update_Innings_Bat_Rows()
        {
            if (Innings_Id == 0)
            {
                First_Inn_Bat_Table.Controls.Clear();
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "#", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "Batsman Name", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 1, 0);
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "How Out", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 2, 0);
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "Bowler", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 3, 0);
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "4's", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 4, 0);
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "6's", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 5, 0);
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "Balls", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 6, 0);
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "Runs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 7, 0);

                for (int i = 0; i < BatList.Count; i = i + 1)
                {
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, BatList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Name, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 1, BatList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_How_Out, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 2, BatList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Out_Bwlr, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 3, BatList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Fours.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 4, BatList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Sixes.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 5, BatList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Balls.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 6, BatList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 7, BatList[i].Bat_Number);
                }
            }
            else
            {
                Second_Inn_Bat_Table.Controls.Clear();
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "#", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "Batsman Name", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 1, 0);
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "How Out", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 2, 0);
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "Bowler", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 3, 0);
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "4's", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 4, 0);
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "6's", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 5, 0);
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "Balls", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 6, 0);
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "Runs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 7, 0);

                for (int i = 0; i < BatList.Count; i = i + 1)
                {
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, BatList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Name, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 1, BatList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_How_Out, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 2, BatList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Out_Bwlr, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 3, BatList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Fours.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 4, BatList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Sixes.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 5, BatList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Balls.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 6, BatList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = BatList[i].Bat_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 7, BatList[i].Bat_Number);
                }
            }
        }

        // Updates the bowling table for the respective innings
        private void Update_Innings_Bowl_Rows()
        {
            if (Innings_Id == 0)
            {
                First_Inn_Bowl_Table.Controls.Clear();
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "#", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Bowler Name", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 1, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "wd", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 2, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "nb", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 3, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Overs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 4, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Mdns", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 5, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Runs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 6, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Wkts", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 7, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Avg", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 8, 0);
                First_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Econ", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 8, 0);

                for (int i = 0; i < BowlList.Count; i = i + 1)
                {
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Name, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 1, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Wides.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 2, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_No_Balls.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 3, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Overs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 4, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Maidens.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 5, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 6, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 7, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Average.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 8, BowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Economy.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 9, BowlList[i].Bowl_Number);
                }
            }
            else
            {
                Second_Inn_Bowl_Table.Controls.Clear();
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "#", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Bowler Name", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 1, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "wd", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 2, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "nb", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 3, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Overs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 4, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Mdns", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 5, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Runs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 6, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Wkts", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 7, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Avg", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 8, 0);
                Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = "Econ", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 8, 0);

                for (int i = 0; i < BowlList.Count; i = i + 1)
                {
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Name, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 1, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Wides.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 2, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_No_Balls.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 3, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Overs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 4, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Maidens.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 5, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 6, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 7, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Average.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 8, BowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = BowlList[i].Bowl_Economy.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 9, BowlList[i].Bowl_Number);
                }
            }
        }

        // Updates the fall of wicket table for the respective innings
        private void Update_Innings_Fall_Of_Wicket()
        {
            if (Innings_Id == 0)
            {
                First_Inn_Fall_Of_Wckt_Table.Controls.Clear();
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Fall of Wicket", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 1);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Out Bat/Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 2);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Not Out Bat/Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 3);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Partnership", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 4);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Over Number", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 5);

                for (int i = 0; i < FallOfWicketList.Count; i = i + 1)
                {
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].wicket_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, FallOfWicketList[i].wicket_Number, 0);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].total_Score.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 1);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].bat_Out_Detail, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 2);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].bat_Not_Out_Detail, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 3);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].partnership.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 4);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 5);
                }
            }
            else
            {
                Second_Inn_Fall_Of_Wckt_Table.Controls.Clear();
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Fall of Wicket", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 1);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Out Bat/Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 2);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Not Out Bat/Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 3);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Partnership", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 4);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Over Number", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 5);

                 for (int i = 0; i < FallOfWicketList.Count; i = i + 1)
                {
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].wicket_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, FallOfWicketList[i].wicket_Number, 1);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].total_Score.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 1);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].bat_Out_Detail, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 2);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].bat_Not_Out_Detail, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 3);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].partnership.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 4);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = FallOfWicketList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, FallOfWicketList[i].wicket_Number, 5);
                }
            }
            InningsList[Innings_Id].Partnership = 0;
        }

        // Updates the over analysis table for the respective innings
        public void Update_Innings_Over_Analysis()
        {
            if (Innings_Id == 0)
            {
                First_Inn_Over_Analysis_Table.Controls.Clear();
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Over #", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, 0);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Bowler", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, 1);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Runs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, 2);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Wickets", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, 3);

                for (int i = 1; i < OverAnalysisList.Count; i = i + 1)
                {
                        First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Bold) }, OverAnalysisList[i].over_Number, 0);
                        First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Bowler_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, OverAnalysisList[i].over_Number, 1);
                        First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, OverAnalysisList[i].over_Number, 2);
                        First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, OverAnalysisList[i].over_Number, 3);
                }
            }
            else
            {
                Second_Inn_Over_Analysis_Table.Controls.Clear();
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Over #", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, 0);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Bowler", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, 1);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Runs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, 2);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Wickets", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, 3);

                for (int i = 1; i < OverAnalysisList.Count; i = i + 1)
                {
                    /* If the over analysis column to be created is greater or equal to the start of the final 20 overs in a friendly match,
                     * shade the bacground of the column white to allow it to be differentiated from the overs before.*/
                    if(OverAnalysisList[i].over_Number >= InningsList[1].startOfTwentyOvers)
                    {
                        Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Bold), BackColor = Color.White }, OverAnalysisList[i].over_Number, 0);
                        Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Bowler_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular), BackColor = Color.White }, OverAnalysisList[i].over_Number, 1);
                        Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular), BackColor = Color.White }, OverAnalysisList[i].over_Number, 2);
                        Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular), BackColor = Color.White }, OverAnalysisList[i].over_Number, 3);
                    }
                    else
                    {
                        Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Bold) }, OverAnalysisList[i].over_Number, 0);
                        Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Bowler_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, OverAnalysisList[i].over_Number, 1);
                        Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, OverAnalysisList[i].over_Number, 2);
                        Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = OverAnalysisList[i].over_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, OverAnalysisList[i].over_Number, 3);
                
                    }
                }
            }
            InningsList[Innings_Id].Over_Analysis_Runs = 0;
            InningsList[Innings_Id].Over_Analysis_Wickets = 0;
        }

        // Updates the scoring tab top batsman row
        private void Update_Batsman_Top()
        {
            Current_Batsman_Number_Top.Text = BatList[InningsList[Innings_Id].topBatId].Bat_Number.ToString();
            Current_Batsman_Name_Top.Text = BatList[InningsList[Innings_Id].topBatId].Bat_Name.ToString();
            Current_Batsman_Number_Of_Fours_Top.Text = BatList[InningsList[Innings_Id].topBatId].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = BatList[InningsList[Innings_Id].topBatId].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Top.Text = BatList[InningsList[Innings_Id].topBatId].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Top.Text = BatList[InningsList[Innings_Id].topBatId].Bat_Runs.ToString();
        }

        // Updates the scoring tab bottom batsman row
        private void Update_Batsman_Bottom()
        {
            Current_Batsman_Number_Bottom.Text = BatList[InningsList[Innings_Id].bottomBatId].Bat_Number.ToString();
            Current_Batsman_Name_Bottom.Text = BatList[InningsList[Innings_Id].bottomBatId].Bat_Name;
            Current_Batsman_Number_Of_Fours_Bottom.Text = BatList[InningsList[Innings_Id].bottomBatId].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = BatList[InningsList[Innings_Id].bottomBatId].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = BatList[InningsList[Innings_Id].bottomBatId].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = BatList[InningsList[Innings_Id].bottomBatId].Bat_Runs.ToString();
        }

        // Updates the scoring tab top bowler row
        private void Update_Bowler_Top()
        {
            Current_Bowler_Number_Top.Text = BowlList[InningsList[Innings_Id].topBowlId].Bowl_Number.ToString();
            Current_Bowler_Name_Top.Text = BowlList[InningsList[Innings_Id].topBowlId].Bowl_Name;
            Current_Bowler_Wides_Conceded_Top.Text = BowlList[InningsList[Innings_Id].topBowlId].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = BowlList[InningsList[Innings_Id].topBowlId].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = BowlList[InningsList[Innings_Id].topBowlId].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = BowlList[InningsList[Innings_Id].topBowlId].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = BowlList[InningsList[Innings_Id].topBowlId].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = BowlList[InningsList[Innings_Id].topBowlId].Bowl_Wickets.ToString();
        }

        // Updates the scoring tab bottom bowler row
        private void Update_Bowler_Bottom()
        {
            Current_Bowler_Number_Bottom.Text = BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Number.ToString();
            Current_Bowler_Name_Bottom.Text = BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Name;
            Current_Bowler_Wides_Conceded_Bottom.Text = BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Wickets.ToString();
        }

        // Function to update the last man out table
        private void Update_Last_Man_Out_Table()
        {
            // Updates Last Man Out table, if no wickets taken then table is blank
            if (InningsList[Innings_Id].Innings_Wickets == 0)
            {
                Out_Batsman_Number_Value.Text = "";
                Out_Batsman_Name.Text = "                    ";
                Out_Batsman_How_Out_Value.Text = "                    ";
                Out_Batsman_Bowler_Value.Text = "                    ";
                Out_Batsman_Total_Runs_Scored_Value.Text = "";
            }
            else
            {
                Player player = new Player();
                Out_Batsman_Number_Value.Text = BatList[Last_Bat_Out].Bat_Number.ToString();
                Out_Batsman_Name.Text = player.Get_Player_Short_Name(BatList[Last_Bat_Out].Bat_Name);
                Out_Batsman_How_Out_Value.Text = BatList[Last_Bat_Out].Bat_How_Out;
                Out_Batsman_Bowler_Value.Text = BatList[Last_Bat_Out].Bat_Out_Bwlr;
                Out_Batsman_Total_Runs_Scored_Value.Text = BatList[Last_Bat_Out].Bat_Runs.ToString();
            }
        }

        /*
         *  This function updates all tables in the application after every button click
         *  The first set of statements update the Scoring Tab
         *  The second set of statements update the Innings 1 tab
         *  The third set of statements update the Innings 2 tab
         */
        public void Update_Score()
        {
            // Update the scoring tab tables
            Update_Batsman_Top();
            Update_Batsman_Bottom();
            Update_Bowler_Top();
            Update_Bowler_Bottom();
            Update_Last_Man_Out_Table();

            // Update the scoring tab Extra table
            Wides_Total_Value.Text = InningsList[Innings_Id].Extras_Wides.ToString();
            No_Balls_Total_Value.Text = InningsList[Innings_Id].Extras_No_Balls.ToString();
            Byes_Total_Value.Text = InningsList[Innings_Id].Extras_Byes.ToString();
            Leg_Byes_Total_Value.Text = InningsList[Innings_Id].Extras_Leg_Byes.ToString();
            Penaltys_Total_Value.Text = InningsList[Innings_Id].Extras_Penaltys.ToString();
            Total_Extras_Value.Text = InningsList[Innings_Id].Extras_Total.ToString();

            // Update the scoring tab match details
            Scoring_Total_Value.Text = InningsList[Innings_Id].Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = InningsList[Innings_Id].Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = InningsList[Innings_Id].Innings_Overs.ToString();

            // Update the innings tab batting and bowling tables
            Update_Innings_Bat_Rows();
            Update_Innings_Bowl_Rows();

            if (Innings_Id == 0)
            {
                // Update the first innings tab Extras table
                First_Inn_Wides_Value.Text = InningsList[0].Extras_Wides.ToString();
                First_Inn_No_Balls_Value.Text = InningsList[0].Extras_No_Balls.ToString();
                First_Inn_Byes_Value.Text = InningsList[0].Extras_Byes.ToString();
                First_Inn_Leg_Byes_Value.Text = InningsList[0].Extras_Leg_Byes.ToString();
                First_Inn_Penaltys_Value.Text = InningsList[0].Extras_Penaltys.ToString();
                First_Inn_Extras_Total_Value.Text = InningsList[0].Extras_Total.ToString();

                // Update the first innings tab table totals
                First_Inn_Bat_Total_Runs.Text = (InningsList[0].Innings_Total - InningsList[0].Extras_Total).ToString();
                First_Inn_Bwl_Ttls_Wds.Text = InningsList[0].Extras_Wides.ToString();
                First_Inn_Bwl_Ttls_Nbs.Text = InningsList[0].Extras_No_Balls.ToString();
                First_Inn_Bwl_Ttls_Ovrs.Text = InningsList[0].Innings_Overs.ToString();
                First_Inn_Bwl_Ttls_Mdns.Text = InningsList[0].Bowl_Total_Maidens.ToString();
                First_Inn_Bwl_Ttls_Runs.Text = InningsList[0].Bowl_Total_Runs.ToString();
                First_Inn_Bwl_Ttls_Wkts.Text = InningsList[0].Bowl_Total_Wickets.ToString();

                // Update the first innings tab match totals
                First_Inn_Total_Runs.Text = InningsList[0].Innings_Total.ToString();
                First_Inn_Total_Wickets.Text = InningsList[0].Innings_Wickets.ToString();
                First_Inn_Total_Overs.Text = InningsList[0].Innings_Overs.ToString();
            }
            else
            {
                // Update the second innings tab Extras table
                Second_Inn_Wides_Value.Text = InningsList[1].Extras_Wides.ToString();
                Second_Inn_No_Balls_Value.Text = InningsList[1].Extras_No_Balls.ToString();
                Second_Inn_Byes_Value.Text = InningsList[1].Extras_Byes.ToString();
                Second_Inn_Leg_Byes_Value.Text = InningsList[1].Extras_Leg_Byes.ToString();
                Second_Inn_Penaltys_Value.Text = InningsList[1].Extras_Penaltys.ToString();
                Second_Inn_Extras_Total_Value.Text = InningsList[1].Extras_Total.ToString();

                // Update the second innings tab table totals
                Second_Inn_Bat_Total_Runs.Text = (InningsList[1].Innings_Total - InningsList[1].Extras_Total).ToString();
                Second_Inn_Bwl_Ttls_Wds.Text = InningsList[1].Extras_Wides.ToString();
                Second_Inn_Bwl_Ttls_Nbs.Text = InningsList[1].Extras_No_Balls.ToString();
                Second_Inn_Bwl_Ttls_Ovrs.Text = InningsList[1].Innings_Overs.ToString();
                Second_Inn_Bwl_Ttls_Mdns.Text = InningsList[1].Bowl_Total_Maidens.ToString();
                Second_Inn_Bwl_Ttls_Runs.Text = InningsList[1].Bowl_Total_Runs.ToString();
                Second_Inn_Bwl_Ttls_Wkts.Text = InningsList[1].Bowl_Total_Wickets.ToString();

                // Update the second innings tab match totals
                Second_Inn_Total_Runs.Text = InningsList[1].Innings_Total.ToString();
                Second_Inn_Total_Wickets.Text = InningsList[1].Innings_Wickets.ToString();
                Second_Inn_Total_Overs.Text = InningsList[1].Innings_Overs.ToString();
                Second_Inn_Balls_Remain.Text = InningsList[1].ballsRemaining.ToString();
                Second_Inn_Runs_Remain.Text = InningsList[1].runsRemaining.ToString();
                Second_Inn_Target.Text = InningsList[1].targetTotal.ToString();
            }
        }

        // Creates points for each pie chart.
        private void Create_Pie_Chart_Points(Series seriesName)
        {
            // Initialis the index variable outside the for loop to allow extras to be added to the end of the chart
            int i;
            for (i = 0; i < BatList.Count; i = i + 1)
            {
                seriesName.Points.Add(BatList[i].Bat_Runs);
                seriesName.Points[i].Label = BatList[i].Bat_Name;
                seriesName.Points[i].LabelForeColor = Color.Transparent;
            }
            // Add the extras total to the pie chart
            seriesName.Points.Add(InningsList[Innings_Id].Extras_Total);
            seriesName.Points[i].Label = "Extras";
            seriesName.Points[i].LabelForeColor = Color.Transparent;
        }

        // Creates points for the manhattan graph.
        private void Create_Manhattan_Chart_Points(Series seriesName, List<Over> overList)
        {
            // Initialised from 1 as the first over is element 2 in the list.
            for (int j = 1; j < OverAnalysisList.Count; j = j + 1)
            {
                seriesName.Points.Add(overList[j].over_Runs);
            }
        }

        // Creates the Manhattan bar graph and the two pie charts on the Graphics tab
        public void Create_Graphs()
        {
            Manhattan_Graph.Palette = ChartColorPalette.Excel;
            Innings1_Pie.Palette = ChartColorPalette.Pastel;
            Innings2_Pie.Palette = ChartColorPalette.Pastel;

            // Creates the Manhattan Graph
            for (int i = 0; i < GraphSeriesList.Count; i = i + 1)
            {
                Manhattan_Graph.Series.Clear();
                Series manhattanSeries = this.Manhattan_Graph.Series.Add(GraphSeriesList[i]);
                manhattanSeries.ChartType = SeriesChartType.Column;
                if (Innings_Id == 1 && i == 0)
                {
                    Create_Manhattan_Chart_Points(manhattanSeries, Innings1OverList);
                }
                else
                {
                    Create_Manhattan_Chart_Points(manhattanSeries, OverAnalysisList);
                }
            }
            // Creates the Pie Charts
            for (int j = 0; j < GraphSeriesList.Count; j = j + 1)
            {
                if (Innings_Id == 0)
                {
                    Innings1_Pie.Series.Clear();
                    Series innings1PieSeries = this.Innings1_Pie.Series.Add(GraphSeriesList[0]);
                    innings1PieSeries.ChartType = SeriesChartType.Pie;
                    Create_Pie_Chart_Points(innings1PieSeries);
                }
                else
                {
                    Innings2_Pie.Series.Clear();
                    Series innings2PieSeries = this.Innings2_Pie.Series.Add(GraphSeriesList[1]);
                    innings2PieSeries.ChartType = SeriesChartType.Pie;
                    Create_Pie_Chart_Points(innings2PieSeries);
                }
            }
        }

        // When called, swap the current batsman facing
        public void Swap_Batsman()
        {
            if (BatList[InningsList[Innings_Id].topBatId].Bat_Facing == true)
            {
                // Set current facing batsman to not facing and change indicator colour
                BatList[InningsList[Innings_Id].topBatId].Bat_Facing = false;
                Current_Batsman_Number_Top.BackColor = Color.Transparent;

                // Set non facing batsman to true and change indicator colour
                BatList[InningsList[Innings_Id].bottomBatId].Bat_Facing = true;
                Current_Batsman_Number_Bottom.BackColor = Color.White;
            }
            else
            {
                // Set current facing batsman to false and change indicator colour
                BatList[InningsList[Innings_Id].bottomBatId].Bat_Facing = false;
                Current_Batsman_Number_Bottom.BackColor = Color.Transparent;

                // Set non facing batsman to true and change indicator colour
                BatList[InningsList[Innings_Id].topBatId].Bat_Facing = true;
                Current_Batsman_Number_Top.BackColor = Color.White;
            }
        }

        // When called, swap the current bowler bowling
        public void Swap_Bowler()
        {
            if (BowlList[InningsList[Innings_Id].topBowlId].Bowl_Bowling == true)
            {
                // Set current bowler to not bowling and change indicator colour
                BowlList[InningsList[Innings_Id].topBowlId].Bowl_Bowling = false;
                Current_Bowler_Number_Top.BackColor = Color.Transparent;

                // Set other bowler to bowling and change indicator colour
                BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Bowling = true;
                Current_Bowler_Number_Bottom.BackColor = Color.White;
            }
            else
            {
                // Set current bowler to not bowling and change indicator colour
                BowlList[InningsList[Innings_Id].bottomBowlId].Bowl_Bowling = false;
                Current_Bowler_Number_Bottom.BackColor = Color.Transparent;

                // Set other bowler to bowling and change indicator colour
                BowlList[InningsList[Innings_Id].topBowlId].Bowl_Bowling = true;
                Current_Bowler_Number_Top.BackColor = Color.White;
            }
        }

        // If outgoing batsman is on top row of batting table, swap bottom batsman to top.
        private void Wicket_Change_Top_Batsman()
        {
            // Move bottom batsman details to the top row.
            InningsList[Innings_Id].topBatId = InningsList[Innings_Id].bottomBatId;
            Update_Batsman_Top();
        }

        // If outgoing bowler is on top row of the bowling table, swap bottom bowler to top.
        private void New_Bowler_Change_Top_Bowler()
        {
            // set current bowler flag of bowler being replaced to false
            BowlList[InningsList[Innings_Id].topBowlId].Bowl_Bowling = false;

            // Move bottom bowler details to the top row.
            InningsList[Innings_Id].topBowlId = InningsList[Innings_Id].bottomBowlId;
            Update_Bowler_Top();
            Current_Bowler_Number_Top.BackColor = Color.Transparent;
        }

        /* When a wicket is taken the application updates the Last Man Out table, Fall Of Wicket table and the batting tables.
         *  1. Adds 1 ball to the batsman, bowler and total overs
         *  2. Adds 1 to bowler and total wickets if batsman is 'caught', 'bowled', 'lbw', 'stumped' or 'caught and bowled'
         *  3. Adds 1 to total wickets if batsman is 'run out' or 'retired' */
        public void WicketTaken(string wicketType, string fielder_Name, bool crossed, int outBatId, int notOutBatId, int bowlId)
        {
            Player player = new Player();
            bool newBatFacing = true;
            // add ball to bowler and out batsman
            player.Bowling_Add_Ball(BowlList, bowlId);
            player.Batting_Add_Ball(BatList, outBatId);
            //add wicket to bowler and total innings wickets
            if (wicketType != "runOut")
            {
            BowlList[bowlId].Bowl_Wickets = BowlList[bowlId].Bowl_Wickets + 1;
            }
            InningsList[Innings_Id].Innings_Wickets = InningsList[Innings_Id].Innings_Wickets + 1;

            // Used to update the last man out table in Update_Score()
            Last_Bat_Out = outBatId;

            // Get the fielder and bowler names associated with the wicket.
            string fielderName = player.Get_Player_Short_Name(fielder_Name);
            string bowlerName = player.Get_Player_Short_Name(BowlList[bowlId].Bowl_Name);

            // Checks if the crossed checkbox has been checked
            if (crossed)
            {
                Swap_Batsman();
                newBatFacing = false;
            }
            else
            {
                BatList[outBatId].Bat_Facing = false;
                Current_Batsman_Number_Top.BackColor = Color.Transparent;
                Current_Batsman_Number_Bottom.BackColor = Color.White;
            }
            switch (wicketType)
            {
                case "caught":
                    BatList[outBatId].Bat_How_Out = "Ct " + fielderName;
                    BatList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Id].Bowl_Total_Wickets = InningsList[Innings_Id].Bowl_Total_Wickets + 1;

                    break;
                case "runOut":
                    BatList[outBatId].Bat_How_Out = "Run Out";
                    BatList[outBatId].Bat_Out_Bwlr = fielderName;
                    break;
                case "bowled":
                    BatList[outBatId].Bat_How_Out = "Bowled";
                    BatList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Id].Bowl_Total_Wickets = InningsList[Innings_Id].Bowl_Total_Wickets + 1;
                    break;
                case "stumped":
                    BatList[outBatId].Bat_How_Out = "Stumped";
                    BatList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Id].Bowl_Total_Wickets = InningsList[Innings_Id].Bowl_Total_Wickets + 1;
                    break;
                case "lbw":
                    BatList[outBatId].Bat_How_Out = "LBW";
                    BatList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Id].Bowl_Total_Wickets = InningsList[Innings_Id].Bowl_Total_Wickets + 1;
                    break;
                case "caughtAndBowled":
                    BatList[outBatId].Bat_How_Out = "Ct && Bwld";
                    BatList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Id].Bowl_Total_Wickets = InningsList[Innings_Id].Bowl_Total_Wickets + 1;
                    break;
                case "retired":
                    BatList[outBatId].Bat_How_Out = "Retired";
                    BatList[outBatId].Bat_Out_Bwlr = "Out";
                    break;
            }
            FallOfWicket fallOfWicket = new FallOfWicket();
            fallOfWicket.Create_Fall_Of_Wicket(InningsList, BatList, Innings_Id, outBatId, notOutBatId);
            FallOfWicketList.Add(fallOfWicket);
            fallOfWicket.Save_Fall_Of_Wicket_List(FallOfWicketList, InningsList[Innings_Id].Team_Name, this.folderName);

            if (InningsList[Innings_Id].Innings_Wickets < 10)
            {
                // Checks if the Current Batsman table rows need to be swapped.
                // Only if the batting side has wickets in hand
                if (outBatId < notOutBatId)
                {
                    Wicket_Change_Top_Batsman();
                }
                // Adds new batsman object into the table and list with Id one greater than the batsman on the bottom row.
                Player newBatsman = new Player();
                newBatsman.Create_Batsman((BatList[InningsList[Innings_Id].bottomBatId].Bat_Number + 1), (Wicket_Next_Bat_Combo_Box.SelectedItem.ToString()), newBatFacing);
                BatList.Add(newBatsman);
                Update_Next_Batsman_List(newBatsman.Bat_Name);
                InningsList[Innings_Id].bottomBatId = InningsList[Innings_Id].bottomBatId + 1;
                Update_Batsman_Bottom();
                InningsList[Innings_Id].Over_Analysis_Wickets = InningsList[Innings_Id].Over_Analysis_Wickets + 1;
            }
            Innings innings = new Innings();
            if (innings.Check_End_Of_Innings(Innings_Id, InningsList))
            {
                End_Of_Innings();
            }
        }

        private void End_OF_Over_Check()
        {
            Over over = new Over();
            if (over.Check_End_Of_Over(BatList, BowlList, InningsList, OverAnalysisList, FallOfWicketList, Innings_Id, folderName))
            {
                Update_Innings_Over_Analysis();
                Create_Graphs();
                // Swap batsmen and bowlers for start of new over
                Swap_Batsman();
                Swap_Bowler();

                // Check if end of innings has been reached
                Innings innings = new Innings();
                if (innings.Check_End_Of_Innings(Innings_Id, InningsList))
                {
                    End_Of_Innings();
                }
            }
        }

        /* When a wicket is taken, this function is called to ensure that the correct batsman is selected as out
         * and that the correct players from the fielding side are referenced for the wicket. */
        private void WicketButtonClick(string howOut, string fielder_Name, bool crossed)
        {
            Player player = new Player();
            Create_Undo_Point();
            // Add one ball to total over amount
            InningsList[Innings_Id].Innings_Overs = InningsList[Innings_Id].Innings_Overs + 0.1;
            if (howOut == "runOut")
            {
                if (Radio_Run_Out_Bat_Top.Checked)
                {
                    WicketTaken(howOut, fielder_Name, crossed, InningsList[Innings_Id].topBatId, InningsList[Innings_Id].bottomBatId, player.Check_Bowler_Bowling(BowlList, InningsList[Innings_Id].topBowlId, InningsList[Innings_Id].bottomBowlId));
                }
                else if (Radio_Run_Out_Bat_Bottom.Checked)
                {
                    WicketTaken(howOut, fielder_Name, crossed, InningsList[Innings_Id].bottomBatId, InningsList[Innings_Id].topBatId, player.Check_Bowler_Bowling(BowlList, InningsList[Innings_Id].topBowlId, InningsList[Innings_Id].bottomBowlId));
                }
            }
            else
            {
                if (BatList[InningsList[Innings_Id].topBatId].Bat_Facing == true)
                {
                    WicketTaken(howOut, fielder_Name, crossed, InningsList[Innings_Id].topBatId, InningsList[Innings_Id].bottomBatId, player.Check_Bowler_Bowling(BowlList, InningsList[Innings_Id].topBowlId, InningsList[Innings_Id].bottomBowlId));
                }
                else
                {
                    WicketTaken(howOut, fielder_Name, crossed, InningsList[Innings_Id].bottomBatId, InningsList[Innings_Id].topBatId, player.Check_Bowler_Bowling(BowlList, InningsList[Innings_Id].topBowlId, InningsList[Innings_Id].bottomBowlId));
                }
            }
            // Check if delivery was last in the over, then update the FOW table and all other tables and hide all flow panels
            End_OF_Over_Check();
            Update_Innings_Fall_Of_Wicket();
            Update_Score();
            HideAllPanels();
        }

        // Gets the button type, number of runs and if runs are off the bat. Calls button handler to update scores.
        private void General_Button_Click(string buttonTypeClicked,bool batUsed, int runs)
        {
            Create_Undo_Point();

            ButtonHandler button = new ButtonHandler();
            button.GeneralButtonClickHandler(BatList, BowlList, InningsList, OverAnalysisList, FallOfWicketList, Innings_Id, folderName, buttonTypeClicked, batUsed, runs);

            if (((buttonTypeClicked == "wide" || buttonTypeClicked == "noBall") && (runs % 2 == 0)) || ((buttonTypeClicked == "legBye" || buttonTypeClicked == "bye" || buttonTypeClicked == "runs") && (runs % 2 == 1)))
            {
                Swap_Batsman();
            }
            // Check if delivery was last in the over
            if (buttonTypeClicked == "runs" || buttonTypeClicked == "bye" || buttonTypeClicked == "legBye" || buttonTypeClicked == "penalty")
            {
                End_OF_Over_Check();
            }
            //Update tables and hide all flow panels
            Update_Score();
            HideAllPanels();
        }

        // Add 0 runs to the score 
        private void Dot_Button_Click(object sender, EventArgs e)
        {
            General_Button_Click("runs", true, 0);
        }
 
         // **** The following functions add runs when the relevant buttons are pressed ****

        // Adds one run to the batsman, bowler and total runs
        private void One_Button_Click(object sender, EventArgs e)
        {
            General_Button_Click("runs", true, 1);
        }

        // Adds two runs to the batsman, bowler and total runs
        private void Two_Button_Click(object sender, EventArgs e)
        {
            General_Button_Click("runs", true, 2);
        }

        // Adds three runs to the batsman, bowler and total runs
        private void Three_Button_Click(object sender, EventArgs e)
        {
            General_Button_Click("runs", true, 3);
        }

        // Adds four runs to the batsman, bowler and total runs
        private void Four_Button_Click(object sender, EventArgs e)
        {
            General_Button_Click("runs", true, 4);
        }

        // Adds six runs to the batsman, bowler and total runs
        private void Six_Button_Click(object sender, EventArgs e)
        {
            General_Button_Click("runs", true, 6);
        }

        // **** The next collection of buttons will allow the user to add byes to the score. ****

        // Shows the byes flow control panel to enter number of runs
        private void Bye_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_Byes.Show();   
        }

        // Adds one bye to the total
        private void Bye_1_Click(object sender, EventArgs e)
        {
            General_Button_Click("bye", false, 1);
        }

        // Adds two byes to the total
        private void Bye_2_Click(object sender, EventArgs e)
        {
            General_Button_Click("bye", false, 2);
        }

        // Adds three byes to the total
        private void Bye_3_Click(object sender, EventArgs e)
        {General_Button_Click("bye", false, 3);
        }

        // Adds four byes to the total
        private void Bye_4_Click(object sender, EventArgs e)
        {
            General_Button_Click("bye", false, 4);
        }

        // Adds number of runs selected from the Byes_Combo_Box
        private void Bye_Ok_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(Bye_Combo_Box))
            {
            int byesToAdd = int.Parse(Bye_Combo_Box.SelectedItem.ToString());
            General_Button_Click("bye", false, byesToAdd);
            Bye_Combo_Box.Text = "Other Score";
            }
        }

        // **** The next collection of buttons will allow the user to add leg byes to the score. ****

        // Shows the leg bye flow control panel
        private void Leg_Bye_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_Leg_Byes.Show();
        }

        // Adds 1 leg bye
        private void Leg_Bye_1_Click(object sender, EventArgs e)
        {
            General_Button_Click("legBye", false, 1);
        }

        // Adds 2 leg byes
        private void Leg_Bye_2_Click(object sender, EventArgs e)
        {
            General_Button_Click("legBye", false, 2);
        }

        // Adds 3 leg byes
        private void Leg_Bye_3_Click(object sender, EventArgs e)
        {
            General_Button_Click("legBye", false, 3);
        }

        // Adds 4 leg byes
        private void Leg_Bye_4_Click(object sender, EventArgs e)
        {
            General_Button_Click("legBye", false, 4);
        }

        // Adds the number of leg byes selected in the leg byes combo box
        private void Leg_Bye_Ok_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(Leg_Byes_Combo_Box))
            {
            int legByesToAdd = int.Parse(Leg_Byes_Combo_Box.SelectedItem.ToString());
            General_Button_Click("legBye", false, legByesToAdd);
            Leg_Byes_Combo_Box.Text = "Other Score";
            }
        }

        // **** The next collection of buttons will allow the user to add wides to the score. ****

        // Allows the user to add wides to the score
        private void Wide_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_Wides.Show();
        }

        // Adds 1 wide
        private void Wides_1_Click(object sender, EventArgs e)
        {
            General_Button_Click("wide", false, 1);
        }

        // Adds 2 wides
        private void Wides_2_Click(object sender, EventArgs e)
        {
            General_Button_Click("wide", false, 2);
        }

        // Adds 3 wides
        private void Wides_3_Click(object sender, EventArgs e)
        {
            General_Button_Click("wide", false, 3);
        }

        // Adds 4 wides
        private void Wides_4_Click(object sender, EventArgs e)
        {
            General_Button_Click("wide", false, 4);
        }

        // Adds 5 wides
        private void Wides_5_Click(object sender, EventArgs e)
        {
            General_Button_Click("wide", false, 5);
        }

        // Adds the number of wides selected in the wides combo box
        private void Wides_Ok_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(Wides_Combo_Box))
            {
            int widesToAdd = int.Parse(Wides_Combo_Box.SelectedItem.ToString());
            General_Button_Click("wide", false, widesToAdd);
            Wides_Combo_Box.Text = "Other Score";
            }
        }

        // **** The next collection of buttons will allow the user to add wides to the score. ****

        // Allows the user to enter runs scored from a no ball
        private void No_Ball_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_No_Ball_Question.Show();
        }

        /* The next two functions allow the user to add no balls
         * The first allows the user to add no ball runs when the batsman has hit the ball
         *The second allows the user to add no ball runs when the batsman has not hit the ball */
        private void No_Ball_Question_Yes_Click(object sender, EventArgs e)
        {
            Flow_Panel_No_Ball_Question.Hide();
            Flow_Panel_No_Ball_Bat.Show();
        }

        private void No_Ball_Question_No_Click(object sender, EventArgs e)
        {
            Flow_Panel_No_Ball_Question.Hide();
            Flow_Panel_No_Ball_No_Bat.Show();
        }

        // **** The next collection of buttons will allow the user to add no balls without batsman runs to the score. ****
        
        // Adds 1 run
        private void No_Ball_No_Bat_1_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", false, 1);
        }

        // Adds 2 runs
        private void No_Ball_No_Bat_2_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", false, 2);
        }

        // Adds 3 runs
        private void No_Ball_No_Bat_3_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", false, 3);
        }

        // Adds 4 runs
        private void No_Ball_No_Bat_4_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", false, 4);
        }

        // Adds 5 runs
        private void No_Ball_No_Bat_5_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", false, 5);
        }

        // Adds the number of no balls selected in the no ball no bat combo box
        private void No_Ball_No_Bat_Ok_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(No_Ball_No_Bat_Combo_Box))
            {
                int NoBallsToAdd = int.Parse(No_Ball_No_Bat_Combo_Box.SelectedItem.ToString());
                General_Button_Click("noBall", false, NoBallsToAdd);
                No_Ball_No_Bat_Combo_Box.Text = "Other Score";
            }
        }

        // **** The next collection of buttons will allow the user to add no balls with batsman runs to the score. ****
        
        // Adds 2 runs (1 for batsman, 1 for no ball)
        private void No_Ball_Bat_2_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", true, 2);
        }

        // Adds 3 runs (2 for batsman, 1 for no ball)
        private void No_Ball_Bat_3_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", true, 3);
        }

        // Adds 4 runs (3 for batsman, 1 for no ball)
        private void No_Ball_Bat_4_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", true, 4);
        }

        // Adds 5 runs (4 for batsman, 1 for no ball)
        private void No_Ball_Bat_5_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", true, 5);
        }

        // Adds 6 runs (5 for batsman, 1 for no ball)
        private void No_Ball_Bat_6_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", true, 6);
        }

        // Adds 7 runs (6 for batsman, 1 for no ball)
        private void No_Ball_Bat_7_Click(object sender, EventArgs e)
        {
            General_Button_Click("noBall", true, 7);
        }

        // Adds the number of no balls selected in the no ball bat combo box (always 1 no ball + x-1 runs for batsman)
        private void No_Ball_Bat_Ok_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(No_Ball_Bat_Combo_Box))
            {
            int NoBallsToAdd = int.Parse(No_Ball_Bat_Combo_Box.SelectedItem.ToString());
            General_Button_Click("noBall", true, NoBallsToAdd);
            No_Ball_Bat_Combo_Box.Text = "Other Score";
            }
        }

        /* Allows the user to select how the wicket was taken, via the wicket flow panel*/
        private void Wicket_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_Wicket.Show();
        }
        // **** The following set of radio buttons allow the user to select how the batsman was out ****

        // If batsman was caught, the user must select the fielder who caught the batsman
        private void Radio_Button_Caught_CheckedChanged(object sender, EventArgs e)
        {
            Flow_Panel_Run_Out.Hide();
            Flow_Panel_Fielder.Show();
        }

        // If batsman was run out, the user must select the fielder who ran out the batsman
        private void Radio_Button_Run_Out_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Run_Out_Bat_Top.Text = BatList[InningsList[Innings_Id].topBatId].Bat_Number.ToString();
            Radio_Run_Out_Bat_Bottom.Text = BatList[InningsList[Innings_Id].bottomBatId].Bat_Number.ToString();
            Flow_Panel_Fielder.Hide();
            Flow_Panel_Run_Out.Show();
        }

        // If batsman was bowled the user does not need to select a fielder
        private void Radio_Button_Bowled_CheckedChanged(object sender, EventArgs e)
        {
            Flow_Panel_Run_Out.Hide();
            Flow_Panel_Fielder.Hide();
        }

        /* If batsman was stumped the user does not need to select a fielder, the wicket keeper should be automaically
        selected by the application*/
        private void Radio_Button_Stumped_CheckedChanged(object sender, EventArgs e)
        {
            Flow_Panel_Run_Out.Hide();
            Flow_Panel_Fielder.Hide();
        }

        // If batsman was caught and bowled the user does not need to select a fielder as the bowler is the fielder
        private void Radio_Button_Caught_And_Bowled_CheckedChanged(object sender, EventArgs e)
        {
            Flow_Panel_Run_Out.Hide();
            Flow_Panel_Fielder.Hide();
        }

        // If batsman was lbw the user does not need to select a fielder
        private void Radio_Button_LBW_CheckedChanged(object sender, EventArgs e)
        {
            Flow_Panel_Run_Out.Hide();
            Flow_Panel_Fielder.Hide();
        }

        // If batsman has retired the user does not need to select a fielder
        private void Radio_Button_Retired_CheckedChanged(object sender, EventArgs e)
        {
            Flow_Panel_Run_Out.Hide();
            Flow_Panel_Fielder.Hide();
        }

        /* Once the relevant radio button has been selected and the new batsman has also been selected
         * the user confirms the details by clicking on the wicket confirm button.
         * Note that fielder name is only needed for run out and caught */
        private void Wicket_Confirm_Button_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(Wicket_Next_Bat_Combo_Box))
            {
                bool crossed = false;

                if (Radio_Button_Run_Out.Checked && Verify_Combo_Selection(Run_Out_Fielder_Combo))
                {
                    string fielderName;
                    fielderName = Run_Out_Fielder_Combo.SelectedItem.ToString();
                    if (Run_Out_Check_Box.Checked)
                    {
                        crossed = true;
                    }
                    WicketButtonClick("runOut", fielderName, crossed);
                    Run_Out_Fielder_Combo.Text = "Select Fielder";
                    Run_Out_Check_Box.Checked = false;
                }
                else if (Radio_Button_Caught.Checked && Verify_Combo_Selection(Wicket_Fielder_Select_Combo_Box))
                {
                    string fielderName;
                    fielderName = Wicket_Fielder_Select_Combo_Box.SelectedItem.ToString();
                    if (Ct_Check_Box.Checked)
                    {
                        crossed = true;
                    }
                    WicketButtonClick("caught", fielderName, crossed);
                    Wicket_Fielder_Select_Combo_Box.Text = "Select Fielder";
                    Ct_Check_Box.Checked = false;
                }
                else if (Radio_Button_Bowled.Checked)
                {
                    WicketButtonClick("bowled", "none", false);
                }
                else if (Radio_Button_Caught_And_Bowled.Checked)
                {
                    WicketButtonClick("caughtAndBowled", "none", false);
                }
                else if (Radio_Button_Stumped.Checked)
                {
                    WicketButtonClick("stumped", "none", false);
                }
                else if (Radio_Button_LBW.Checked)
                {
                    WicketButtonClick("lbw", "none", false);
                }
                else if(Radio_Button_Retired.Checked)
                {
                    WicketButtonClick("retired", "none", crossed);
                }
                Wicket_Next_Bat_Combo_Box.Text = "Next Batsman";
            }
        }

        // If there are penalty runs conceded the application adds these to the score.
        private void Penalty_Button_Click(object sender, EventArgs e)
        {
            General_Button_Click("penalty", false, 5);
        }

        // This fuction allows the user to add runs from the other score combo box.
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(End_Of_Innings_Combo_Box))
            {
                HideAllPanels();
                int runsToAdd = int.Parse(Other_Score_Combo_Box.SelectedItem.ToString());
                General_Button_Click("runs", true, runsToAdd);
                Other_Score_Combo_Box.Text = "Other Score";
            }
        }

        // This function calls the restore last state function to undo the last action taken by the user.
        private void Undo_Last_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Restore_Last_State();
        }

        // When the end of innings button if clicked the end of innings flow panel is shown 
        private void End_Of_Innings_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_End_Of_Innings.Show();
        }
        private void End_Of_Innings_Select_Button_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(End_Of_Innings_Combo_Box))
            {
                InningsList[Innings_Id].reason = End_Of_Innings_Combo_Box.SelectedItem.ToString();
                End_Of_Innings();
                End_Of_Innings_Combo_Box.Text = "Select Reason";
            }
        }

        // When the user needs to enter a new bowler this function shows the combo box to select the next bowler's name.
        private void New_Bowler_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_New_Bowler.Show();
        }

         /* When the user selects the new bowler's name and clicks the select button,
         * this function checks if the bowler being replaced is in the top row of the current bowlers
         * tables, if so the function swaps the bottom bowler details to the top row and inserts
         * the new bowler into the bottom row. */
        private void New_Bowler_Select_Click(object sender, EventArgs e)
        {
            if (Verify_Combo_Selection(New_Bowler_Combo_Box))
            {
                Create_Undo_Point();
                Player player = new Player();
                // Get new bowler name and Id.
                string newBowlerName = New_Bowler_Combo_Box.SelectedItem.ToString();
                int newBowlerId = player.Get_Bowler_Id(BowlList, newBowlerName);
                if (BowlList[InningsList[Innings_Id].topBowlId].Bowl_Bowling)
                {
                    New_Bowler_Change_Top_Bowler();
                }
                if (newBowlerId > -1)
                {
                    InningsList[Innings_Id].bottomBowlId = newBowlerId;
                }
                else
                {
                    player.Create_Bowler((BowlList.Last().Bowl_Number) + 1, newBowlerName, true);
                    InningsList[Innings_Id].bottomBowlId = BowlList.Last().Bowl_Number;
                    BowlList.Add(player);
                }        
                Update_Bowler_Bottom();
                Current_Bowler_Number_Bottom.BackColor = Color.White;
                New_Bowler_Combo_Box.Text = "Select New Bowler";
            }
            HideAllPanels();
        }

        // When clicked by the user, it starts the last 20 overs of a friendly match.
        private void Twenty_Overs_Button_Click(object sender, EventArgs e)
        {
            InningsList[1].twentyOvers = true;
            HideAllPanels();
        }
    }
}