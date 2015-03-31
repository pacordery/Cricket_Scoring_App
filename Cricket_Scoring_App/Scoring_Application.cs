using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cricket_Scoring_App
{
    public partial class Scoring_Application_Form : Form
    {
        public Scoring_Application_Form()
        {
            InitializeComponent();
        }
        // Initialises the windows directory for read/write access
        string winDir = System.Environment.GetEnvironmentVariable("windir");

        // Initialise all lists required for the application
        List<string> MatchDetailsList = new List<string>();
        List<string> HomeTeamList = new List<string>();
        List<string> AwayTeamList = new List<string>();
        List<Innings> InningsList = new List<Innings>();
        List<Player> Innings1BatsmanList = new List<Player>();
        List<Player> Innings1BowlerList = new List<Player>();
        List<Player> Innings2BatsmanList = new List<Player>();
        List<Player> Innings2BowlerList = new List<Player>();
        List<Player> batList = new List<Player>();
        List<Player> bowlList = new List<Player>();
        List<FallOfWicket> fallOfWicketList = new List<FallOfWicket>();
        List<Over> overAnalsisList = new List<Over>();

        // Initialising all match detail variables
        string Home_Team;
        string Away_Team;
        int Innings_Number;
        string Innings_Of;
        string First_Inn_Team;
        string Second_Inn_Team;
        int Target_Total;
        int Runs_Remaining;
        int Balls_Remain;
        string Innings_Complete_Reason;
        string notes;

        // Initialising all batting variables
        int Bat_Out;
        int Bat_Not_Out;
        int Current_Batsman_Top_Id;
        int Current_Batsman_Bottom_Id;

        // Initialising all bowling variables
        int Current_Bowler_Top_Id;
        int Current_Bowler_Bottom_Id;
        int New_Bowler_Id;

        // Stores match result details
        string Innings_1_Score;
        string Innings_2_Score;
        string Match_Result;

        /* Load function to read all text files created in the previous form,
         * information is stored into the applications lists
         */
        private void Scoring_Application_Form_Load(object sender, EventArgs e)
        {
            // On load the innings to be scored is the first innings
            Innings_Number = 1;

            Match match = new Match();
            Match awayTeamHandler = new Match();

            // Storing match and team details into lists
            MatchDetailsList = match.GetMatchDetails();
            HomeTeamList = match.GetTeamDetails(MatchDetailsList[1]);
            AwayTeamList = awayTeamHandler.GetTeamDetails(MatchDetailsList[2]);

            // Insert team names into the Toss Winner combo box on the Opener Selection tab
            Toss_Winner_Combo_Box.Items.Clear();
            Toss_Winner_Combo_Box.Items.Add(MatchDetailsList[1]);
            Toss_Winner_Combo_Box.Items.Add(MatchDetailsList[2]);

            // Insert team names into the Batting Side combo box on the Opener Selection tab
            Open_Select_Bat_Side.Items.Clear();
            Open_Select_Bat_Side.Items.Add(MatchDetailsList[1]);
            Open_Select_Bat_Side.Items.Add(MatchDetailsList[2]);
        }

        //
        private void Populate_Scorecard_Player_Combo_Boxes(List<string> battingList, string batting, List<string> bowlingList, string bowling)
        {
            Wicket_Next_Bat_Combo_Box.Items.Clear();
            Wicket_Fielder_Select_Combo_Box.Items.Clear();
            Run_Out_Fielder_Combo.Items.Clear();
            New_Bowler_Combo_Box.Items.Clear();

            for (int i = 0; i < battingList.Count(); i = i + 1)
            {
                Wicket_Next_Bat_Combo_Box.Items.Add(battingList[i]);
            }
            for (int j = 0; j < bowlingList.Count(); j = j + 1)
            {
                Wicket_Fielder_Select_Combo_Box.Items.Add(bowlingList[j]);
                Run_Out_Fielder_Combo.Items.Add(bowlingList[j]);
                New_Bowler_Combo_Box.Items.Add(bowlingList[j]);
            }
        }

        //
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

        /*
         *  When the user selects which side is batting in the Batting Side Combo Box,
         *  the application will only show the batting side in the batsman select boxes
         *  and only the bowling side in the bowler select boxes.
         */
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

        /*
         * This function hides all of the flow control panels for extras and wickets
         */
        private void HideAllPanels()
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

        private void Set_Default_Variables()
        {
            HideAllPanels();
            Innings innings = new Innings();
            innings.Create_Innings(MatchDetailsList, Toss_Winner_Combo_Box.SelectedItem.ToString());
            InningsList.Add(innings);

            // Sets Extra table details
            Wides_Total_Value.Text = innings.Extras_Wides.ToString();
            No_Balls_Total_Value.Text = innings.Extras_No_Balls.ToString();
            Byes_Total_Value.Text = innings.Extras_Byes.ToString();
            Leg_Byes_Total_Value.Text = innings.Extras_Leg_Byes.ToString();
            Penaltys_Total_Value.Text = innings.Extras_Penaltys.ToString();
            Total_Extras_Value.Text = innings.Extras_Total.ToString();

            // Sets match details
            Scoring_Date_Value.Text = innings.Date;
            Scoring_Home_Team_Name_Value.Text = Home_Team;
            Scoring_Away_Team_Name_Value.Text = Away_Team;
            Scoring_Innings_Of_Value.Text = Innings_Of;
            Scoring_Total_Value.Text = innings.Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = innings.Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = innings.Innings_Overs.ToString();

            // Initialise opening player objects
            Current_Batsman_Top_Id = 0;
            Current_Batsman_Bottom_Id = 1;
            Current_Bowler_Top_Id = 0;
            Current_Bowler_Bottom_Id = 1;

            Player batTop = new Player();
            Player batBottom = new Player();
            Player bowlTop = new Player();
            Player bowlBottom = new Player();

            if (Innings_Number == 1)
            {
                batTop.Create_Batsman((Current_Batsman_Top_Id + 1), Open_Select_Bat_1.SelectedItem.ToString(), true);
                batBottom.Create_Batsman((Current_Batsman_Bottom_Id + 1), Open_Select_Bat_2.SelectedItem.ToString(), false);
                bowlTop.Create_Bowler((Current_Bowler_Top_Id + 1), Open_Select_Bowl_1.SelectedItem.ToString(), true);
                bowlBottom.Create_Bowler((Current_Bowler_Bottom_Id + 1), Open_Select_Bowl_2.SelectedItem.ToString(), false);
            }
            else
            {
                batTop.Create_Batsman((Current_Batsman_Top_Id + 1), Open_Select_Bat_1_Inn_2.SelectedItem.ToString(), true);
                batBottom.Create_Batsman((Current_Batsman_Bottom_Id + 1), Open_Select_Bat_2_Inn_2.SelectedItem.ToString(), false);
                bowlTop.Create_Bowler((Current_Bowler_Top_Id + 1), Open_Select_Bowl_1_Inn_2.SelectedItem.ToString(), true);
                bowlBottom.Create_Bowler((Current_Bowler_Bottom_Id + 1), Open_Select_Bowl_2_Inn_2.SelectedItem.ToString(), false);
            }          
            batList.Add(batTop);
            batList.Add(batBottom);
            bowlList.Add(bowlTop);
            bowlList.Add(bowlBottom);
        }

        /* 
         * This function handles the assignment of batsman and bowlers into
         * the batting and bowling tables in the first innings tab
         */
        private void First_Inn_Openers_Confirm_Button_Click(object sender, EventArgs e)
        {
            batList = Innings1BatsmanList;
            bowlList = Innings1BowlerList;

            First_Innings_Tab.Text = Open_Select_Bat_Side.SelectedItem.ToString();
            First_Inn_Team = Open_Select_Bat_Side.SelectedItem.ToString();
            if (First_Innings_Tab.Text == Home_Team)
            {
                Second_Inn_Tab.Text = Away_Team;
                Second_Inn_Team = Away_Team;
            }
            else
            {
                Second_Inn_Tab.Text = Home_Team;
                Second_Inn_Team = Home_Team;
            }

            // Sets all variables, creates opening player objects and sets all table information for first innings
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
            First_Inn_Total_Wickets.Text = InningsList[0].Innings_Wickets.ToString(); ;

            // Switch to the scoring tab
            Scoring_App_Tab_Set.SelectedTab = Scoring_Tab;
        }

        private void Second_Inn_Openers_Confirm_Button_Click(object sender, EventArgs e)
        {
            batList = Innings2BatsmanList;
            bowlList = Innings2BowlerList;

            // Sets all variables, creates opening player objects and sets all table information for second innings
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

        /* Triggered when the first innings is completed, either by:
         *      1. declaration
         *      2. no more wickets left
         *      3. no more overs left
         *      4. bad weather
         */
        private void End_Of_Innings()
        {
            if (Innings_Number == 1)
            {
                Innings1BatsmanList = batList;
                Innings1BowlerList = bowlList;
                Innings_Number = 2;
                Target_Total = InningsList[0].Innings_Total + 1;
                Runs_Remaining = Target_Total;
                Innings_1_Score = Innings_Of + "," + InningsList[0].Innings_Total.ToString() + "-" + InningsList[0].Innings_Wickets.ToString();

                if (InningsList[0].Match_Type == "T20")
                {
                    Balls_Remain = 120;
                }
                else if (InningsList[0].Match_Type == "40 Over")
                {
                    Balls_Remain = 240;
                }
                else if (InningsList[0].Match_Type == "Friendly")
                {
                    Balls_Remain = 0;
                }
                Second_Inn_Target.Text = Target_Total.ToString();
                Second_Inn_Runs_Remain.Text = Runs_Remaining.ToString();
                Second_Inn_Balls_Remain.Text = Balls_Remain.ToString();

                if (Innings_Of == Home_Team)
                {
                    Innings_Of = Away_Team;
                }
                else
                {
                    Innings_Of = Home_Team;
                }             
                Second_Inn_Innings_Of.Text = Innings_Of;
                Scoring_App_Tab_Set.SelectedTab = Second_Inn_Select_Tab;
            }
            else
            {
                Innings2BatsmanList = batList;
                Innings2BowlerList = bowlList;
                Innings_2_Score = Innings_Of + "," + InningsList[1].Innings_Total.ToString() + "-" + InningsList[1].Innings_Wickets.ToString();

                // Get Match result based on end of 2nd innings reason
                if (((Target_Total - InningsList[1].Innings_Total) == 1) && ((Innings_Complete_Reason == "All Out") || (Innings_Complete_Reason == "No More Overs")))
                {
                    Match_Result = "Tied";
                }
                else if ((Innings_Complete_Reason == "No More Overs") && (InningsList[0].Match_Type == "Friendly"))
                {
                    Match_Result = "Drawn";
                }
                else if ((Innings_Complete_Reason == "All Out") || ((Innings_Complete_Reason == "No More Overs") && ((InningsList[0].Match_Type == "T20") || (InningsList[0].Match_Type == "40 Over"))))
                {
                    Match_Result = First_Inn_Team + " Won by " + (((Target_Total - 1) - InningsList[1].Innings_Total).ToString()) + " runs";
                }
                else if (Target_Total <= InningsList[1].Innings_Total)
                {
                    Match_Result = Second_Inn_Team + " Won by " + ((10 - InningsList[1].Innings_Wickets).ToString()) + " wickets";
                }
                Match match = new Match();
                match.Create_Match_Result(Innings1BatsmanList,Innings1BowlerList,Innings2BatsmanList,Innings2BowlerList, Home_Team, Away_Team, InningsList[0].Date, Innings_1_Score, Innings_2_Score, Match_Result);
            }
        }

        // This function creates an undo point to allow the user to undo their last operation.
        private void Create_Undo_Point()
        {
            ScorecardHandler scorecardHandler = new ScorecardHandler();
            scorecardHandler.Create_Temp_Bat_Bowl(fallOfWicketList, batList, bowlList, InningsList, overAnalsisList, MatchDetailsList, Bat_Out, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id, Current_Bowler_Bottom_Id);
            scorecardHandler.Create_Temp_Extras(InningsList[Innings_Number - 1].Extras_Wides, InningsList[Innings_Number - 1].Extras_No_Balls, InningsList[Innings_Number - 1].Extras_Byes, InningsList[Innings_Number - 1].Extras_Leg_Byes, InningsList[Innings_Number - 1].Extras_Penaltys, InningsList[Innings_Number - 1].Extras_Total);
            scorecardHandler.Create_Temp_Match_Totals(InningsList[Innings_Number - 1].Innings_Total, InningsList[Innings_Number - 1].Innings_Wickets, InningsList[Innings_Number - 1].Innings_Overs);
        }

        /*
         * Restores the score back to the state before the incorrect operation was carried out.
         * It:
         *      Updates the batsman and bowler objects, extras totals and match totals
         *      Updates all tables
         */
        private void Restore_Last_State()
        {
            ScorecardHandler scorecardHandler = new ScorecardHandler();
            Player player = new Player();
            Current_Batsman_Top_Id = scorecardHandler.Temp_Current_Batsman_Top_Id;
            Current_Batsman_Bottom_Id = scorecardHandler.Temp_Current_Batsman_Bottom_Id;
            Current_Bowler_Top_Id = scorecardHandler.Temp_Current_Bowler_Top_Id;
            Current_Bowler_Bottom_Id = scorecardHandler.Temp_Current_Bowler_Bottom_Id;
            Bat_Out = scorecardHandler.Temp_Bat_Out;
            batList = scorecardHandler.TempBatList;
            bowlList = scorecardHandler.TempBowList;
            fallOfWicketList = scorecardHandler.TempFallOfWicketList;
            InningsList = scorecardHandler.TempInningsList;
            overAnalsisList = scorecardHandler.TempOverAnalysisList;
            Update_Batsman_Top();
            Update_Batsman_Bottom();
            Update_Bowler_Top();
            Update_Bowler_Bottom();
            Update_Last_Man_Out_Table();
            Update_Innings_Fall_Of_Wicket();
            Update_Innings_Over_Analysis();

            // Set the current batsman flag
            if (batList[Current_Batsman_Top_Id].Bat_Facing)
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
            if (bowlList[Current_Bowler_Top_Id].Bowl_Bowling)
            {
                Current_Bowler_Number_Top.BackColor = Color.White;
                Current_Bowler_Number_Bottom.BackColor = Color.Transparent;
            }
            else
            {
                Current_Bowler_Number_Top.BackColor = Color.Transparent;
                Current_Bowler_Number_Bottom.BackColor = Color.White;
            }

            // Restore extra totals
            InningsList[Innings_Number - 1].Extras_Wides = scorecardHandler.Temp_Wides_Total_Value;
            InningsList[Innings_Number - 1].Extras_No_Balls = scorecardHandler.Temp_No_Balls_Total_Value;
            InningsList[Innings_Number - 1].Extras_Byes = scorecardHandler.Temp_Byes_Total_Value;
            InningsList[Innings_Number - 1].Extras_Leg_Byes = scorecardHandler.Temp_Leg_Byes_Total_Value;
            InningsList[Innings_Number - 1].Extras_Penaltys = scorecardHandler.Temp_Penaltys_Total_Value;
            InningsList[Innings_Number - 1].Extras_Total = scorecardHandler.Temp_Total_Extras_Value;

            // Restores Extra table details
            Wides_Total_Value.Text = scorecardHandler.Temp_Wides_Total_Value.ToString();
            No_Balls_Total_Value.Text = scorecardHandler.Temp_No_Balls_Total_Value.ToString();
            Byes_Total_Value.Text = scorecardHandler.Temp_Byes_Total_Value.ToString();
            Leg_Byes_Total_Value.Text = scorecardHandler.Temp_Leg_Byes_Total_Value.ToString();
            Penaltys_Total_Value.Text = scorecardHandler.Temp_Penaltys_Total_Value.ToString();
            Total_Extras_Value.Text = scorecardHandler.Temp_Total_Extras_Value.ToString();

            /* Restores Last Man Out table details,
             * if no wickets have been taken then the table should be blank
             */
            if (InningsList[Innings_Number - 1].Innings_Wickets == 0)
            {
                Out_Batsman_Number_Value.Text = "";
                Out_Batsman_Name.Text = "";
                Out_Batsman_How_Out_Value.Text = "";
                Out_Batsman_Bowler_Value.Text = "";
                Out_Batsman_Total_Runs_Scored_Value.Text = "";
            }
            else
            {
                Out_Batsman_Number_Value.Text = scorecardHandler.Temp_Out_Batsman_Number_Value.ToString();
                Out_Batsman_Name.Text = scorecardHandler.Temp_Out_Batsman_Name;
                Out_Batsman_How_Out_Value.Text = scorecardHandler.Temp_Out_Batsman_How_Out_Value;
                Out_Batsman_Bowler_Value.Text = scorecardHandler.Temp_Out_Batsman_Bowler_Value;
                Out_Batsman_Total_Runs_Scored_Value.Text = scorecardHandler.Temp_Out_Batsman_Total_Runs_Scored_Value.ToString();
            }
            // Restores match details values
            InningsList[Innings_Number - 1].Innings_Overs = scorecardHandler.Temp_Scoring_Total_Overs_Value;
            InningsList[Innings_Number - 1].Innings_Total = scorecardHandler.Temp_Scoring_Total_Value;
            InningsList[Innings_Number - 1].Innings_Wickets = scorecardHandler.Temp_Scoring_Wickets_Down_Value;

            // Restores match details table
            Scoring_Total_Value.Text = scorecardHandler.Temp_Scoring_Total_Value.ToString();
            Scoring_Wickets_Down_Value.Text = scorecardHandler.Temp_Scoring_Wickets_Down_Value.ToString();
            Scoring_Total_Overs_Value.Text = scorecardHandler.Temp_Scoring_Total_Overs_Value.ToString();
        }

        //
        private void Update_Innings_Bat_Rows()
        {
            if (Innings_Number == 1)
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
                First_Inn_Bat_Table.Controls.Add(new Label() { Text = "Minutes", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 8, 0);

                for (int i = 0; i < batList.Count; i = i + 1)
                {
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, batList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Name, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 1, batList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_How_Out, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 2, batList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Out_Bwlr, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 3, batList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Fours.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 4, batList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Sixes.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 5, batList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Balls.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 6, batList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 7, batList[i].Bat_Number);
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Minutes.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 8, batList[i].Bat_Number);
                }
                First_Inn_Bat_Table.ColumnStyles.Clear();
                for (int i = 0; i < First_Inn_Bat_Table.ColumnCount; i = i + 1)
                {
                    if (i == 1)
                    {
                        First_Inn_Bat_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    }
                    else if (i == 2 || i == 3)
                    {
                        First_Inn_Bat_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                    }
                    else
                    {
                        First_Inn_Bat_Table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
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
                Second_Inn_Bat_Table.Controls.Add(new Label() { Text = "Minutes", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 8, 0);

                for (int i = 0; i < batList.Count; i = i + 1)
                {
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, batList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Name, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 1, batList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_How_Out, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 2, batList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Out_Bwlr, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 3, batList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Fours.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 4, batList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Sixes.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 5, batList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Balls.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 6, batList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 7, batList[i].Bat_Number);
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Minutes.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 8, batList[i].Bat_Number);
                }
                Second_Inn_Bat_Table.ColumnStyles.Clear();
                for (int i = 0; i < Second_Inn_Bat_Table.ColumnCount; i = i + 1)
                {
                    if (i == 1)
                    {
                        Second_Inn_Bat_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    }
                    else if (i == 2 || i == 3)
                    {
                        Second_Inn_Bat_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                    }
                    else
                    {
                        Second_Inn_Bat_Table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                }
            }
        }

        //
        private void Update_Innings_Bowl_Rows()
        {
            if (Innings_Number == 1)
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

                for (int i = 0; i < bowlList.Count; i = i + 1)
                {
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Name, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 1, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Wides.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 2, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_No_Balls.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 3, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Overs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 4, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Maidens.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 5, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 6, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 7, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Average.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 8, bowlList[i].Bowl_Number);
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Economy.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 9, bowlList[i].Bowl_Number);
                }

                // Sets column size of the table
                First_Inn_Bowl_Table.ColumnStyles.Clear();
                for (int i = 0; i < First_Inn_Bowl_Table.ColumnCount; i = i + 1)
                {
                    if (i == 1)
                    {
                        First_Inn_Bowl_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    }
                    else
                    {
                        First_Inn_Bowl_Table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
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

                for (int i = 0; i < bowlList.Count; i = i + 1)
                {
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Name, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 1, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Wides.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 2, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_No_Balls.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 3, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Overs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 4, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Maidens.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 5, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 6, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 7, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Average.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 8, bowlList[i].Bowl_Number);
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Economy.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 9, bowlList[i].Bowl_Number);
                }

                // Sets column size of the table
                Second_Inn_Bowl_Table.ColumnStyles.Clear();
                for (int i = 0; i < Second_Inn_Bowl_Table.ColumnCount; i = i + 1)
                {
                    if (i == 1)
                    {
                        Second_Inn_Bowl_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    }
                    else
                    {
                        Second_Inn_Bowl_Table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                }
            }
        }

        //
        private void Update_Innings_Fall_Of_Wicket()
        {
            if (Innings_Number == 1)
            {
                First_Inn_Fall_Of_Wckt_Table.Controls.Clear();
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Fall of Wicket", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 1);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Out Bat/Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 2);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Not Out Bat/Score", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 3);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Partnership", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 4);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = "Over Number", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 5);

                for (int i = 0; i < fallOfWicketList.Count; i = i + 1)
                {
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].wicket_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, fallOfWicketList[i].wicket_Number, 0);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].total_Score.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 1);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].bat_Out_Detail, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 2);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].bat_Not_Out_Detail, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 3);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].partnership.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 4);
                    First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 5);
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

                 for (int i = 0; i < fallOfWicketList.Count; i = i + 1)
                {
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].wicket_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, fallOfWicketList[i].wicket_Number, 1);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].total_Score.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 1);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].bat_Out_Detail, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 2);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].bat_Not_Out_Detail, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 3);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].partnership.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 4);
                    Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = fallOfWicketList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, fallOfWicketList[i].wicket_Number, 5);
                }
            }
            InningsList[Innings_Number - 1].Partnership = 0;
        }

        //
        private void Update_Innings_Over_Analysis()
        {
            if (Innings_Number == 1)
            {
                First_Inn_Over_Analysis_Table.Controls.Clear();
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Over #", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Bowler", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 1);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Runs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 2);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Wickets", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 3);

                for (int i = 0; i < overAnalsisList.Count; i = i + 1)
                {
                    First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = overAnalsisList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, overAnalsisList[i].over_Number, 0);
                    First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = overAnalsisList[i].over_Bowler_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, overAnalsisList[i].over_Number, 1);
                    First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = overAnalsisList[i].over_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, overAnalsisList[i].over_Number, 2);
                    First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = overAnalsisList[i].over_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, overAnalsisList[i].over_Number, 3);
                }
            }
            else
            {
                Second_Inn_Over_Analysis_Table.Controls.Clear();
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Over #", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 0);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Bowler", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 1);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Runs", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 2);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = "Wickets", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 11, FontStyle.Bold) }, 0, 3);

                for (int i = 0; i < overAnalsisList.Count; i = i + 1)
                {
                    Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = overAnalsisList[i].over_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, overAnalsisList[i].over_Number, 0);
                    Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = overAnalsisList[i].over_Bowler_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, overAnalsisList[i].over_Number, 1);
                    Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = overAnalsisList[i].over_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, overAnalsisList[i].over_Number, 2);
                    Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = overAnalsisList[i].over_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, overAnalsisList[i].over_Number, 3);
                }
            }
            InningsList[Innings_Number - 1].Over_Analysis_Runs = 0;
            InningsList[Innings_Number - 1].Over_Analysis_Wickets = 0;
        }

        private void Update_Batsman_Top()
        {
            Current_Batsman_Number_Top.Text = batList[Current_Batsman_Top_Id].Bat_Number.ToString();
            Current_Batsman_Name_Top.Text = batList[Current_Batsman_Top_Id].Bat_Name.ToString();
            Current_Batsman_Number_Of_Fours_Top.Text = batList[Current_Batsman_Top_Id].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = batList[Current_Batsman_Top_Id].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Top.Text = batList[Current_Batsman_Top_Id].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Top.Text = batList[Current_Batsman_Top_Id].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Top.Text = batList[Current_Batsman_Top_Id].Bat_Minutes.ToString();
        }

        private void Update_Batsman_Bottom()
        {
            Current_Batsman_Number_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Number.ToString();
            Current_Batsman_Name_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Name;
            Current_Batsman_Number_Of_Fours_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Minutes.ToString();
        }

        private void Update_Bowler_Top()
        {
            Current_Bowler_Name_Top.Text = bowlList[Current_Bowler_Top_Id].Bowl_Name;
            Current_Bowler_Wides_Conceded_Top.Text = bowlList[Current_Bowler_Top_Id].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = bowlList[Current_Bowler_Top_Id].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = bowlList[Current_Bowler_Top_Id].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = bowlList[Current_Bowler_Top_Id].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = bowlList[Current_Bowler_Top_Id].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = bowlList[Current_Bowler_Top_Id].Bowl_Wickets.ToString();
        }

        private void Update_Bowler_Bottom()
        {
            Current_Bowler_Number_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Number.ToString();
            Current_Bowler_Name_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Name;
            Current_Bowler_Wides_Conceded_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Wickets.ToString();
        }

        private void Update_Last_Man_Out_Table()
        {
            // Updates Last Man Out table, if no wickets taken then table is blank
            if (InningsList[Innings_Number - 1].Innings_Wickets == 0)
            {
                Out_Batsman_Number_Value.Text = "";
                Out_Batsman_Name.Text = "";
                Out_Batsman_How_Out_Value.Text = "";
                Out_Batsman_Bowler_Value.Text = "";
                Out_Batsman_Total_Runs_Scored_Value.Text = "";
            }
            else
            {
                Out_Batsman_Number_Value.Text = batList[Bat_Out].Bat_Number.ToString();
                Out_Batsman_Name.Text = batList[Bat_Out].Bat_Name;
                Out_Batsman_How_Out_Value.Text = batList[Bat_Out].Bat_How_Out;
                Out_Batsman_Bowler_Value.Text = batList[Bat_Out].Bat_Out_Bwlr;
                Out_Batsman_Total_Runs_Scored_Value.Text = batList[Bat_Out].Bat_Runs.ToString();
            }
        }

        /*
         *  This function updates all tables in the application after every button click
         *  The first set of statements update the Scoring Tab
         *  The second set of statements update the Innings 1 tab
         *  The third set of statements update the Innings 2 tab
         */
        private void Update_Score()
        {
            Update_Batsman_Top();
            Update_Batsman_Bottom();
            Update_Bowler_Top();
            Update_Bowler_Bottom();
            Update_Last_Man_Out_Table();

            // Updates Extra table details
            Wides_Total_Value.Text = InningsList[Innings_Number - 1].Extras_Wides.ToString();
            No_Balls_Total_Value.Text = InningsList[Innings_Number - 1].Extras_No_Balls.ToString();
            Byes_Total_Value.Text = InningsList[Innings_Number - 1].Extras_Byes.ToString();
            Leg_Byes_Total_Value.Text = InningsList[Innings_Number - 1].Extras_Leg_Byes.ToString();
            Penaltys_Total_Value.Text = InningsList[Innings_Number - 1].Extras_Penaltys.ToString();
            Total_Extras_Value.Text = InningsList[Innings_Number - 1].Extras_Total.ToString();

            // Updates match details
            Scoring_Total_Value.Text = InningsList[Innings_Number - 1].Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = InningsList[Innings_Number - 1].Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = InningsList[Innings_Number - 1].Innings_Overs.ToString();

            // Updates the batting table
            Update_Innings_Bat_Rows();

            // Updates the bowling table
            Update_Innings_Bowl_Rows();

            if (Innings_Number == 1)
            {
                // Updates Extras table
                First_Inn_Wides_Value.Text = InningsList[0].Extras_Wides.ToString();
                First_Inn_No_Balls_Value.Text = InningsList[0].Extras_No_Balls.ToString();
                First_Inn_Byes_Value.Text = InningsList[0].Extras_Byes.ToString();
                First_Inn_Leg_Byes_Value.Text = InningsList[0].Extras_Leg_Byes.ToString();
                First_Inn_Penaltys_Value.Text = InningsList[0].Extras_Penaltys.ToString();
                First_Inn_Extras_Total_Value.Text = InningsList[0].Extras_Total.ToString();

                // Updates table totals
                First_Inn_Bat_Total_Runs.Text = (InningsList[0].Innings_Total - InningsList[0].Extras_Total).ToString();
                First_Inn_Bwl_Ttls_Wds.Text = InningsList[0].Extras_Wides.ToString();
                First_Inn_Bwl_Ttls_Nbs.Text = InningsList[0].Extras_No_Balls.ToString();
                First_Inn_Bwl_Ttls_Ovrs.Text = InningsList[0].Innings_Overs.ToString();
                First_Inn_Bwl_Ttls_Mdns.Text = InningsList[0].Bowl_Total_Maidens.ToString();
                First_Inn_Bwl_Ttls_Runs.Text = InningsList[0].Bowl_Total_Runs.ToString();
                First_Inn_Bwl_Ttls_Wkts.Text = InningsList[0].Bowl_Total_Wickets.ToString();

                // Updates match totals
                First_Inn_Total_Runs.Text = InningsList[0].Innings_Total.ToString();
                First_Inn_Total_Wickets.Text = InningsList[0].Innings_Wickets.ToString();
                First_Inn_Total_Overs.Text = InningsList[0].Innings_Overs.ToString();
            }
            else
            {
                // Updates Extras table
                Second_Inn_Wides_Value.Text = InningsList[1].Extras_Wides.ToString();
                Second_Inn_No_Balls_Value.Text = InningsList[1].Extras_No_Balls.ToString();
                Second_Inn_Byes_Value.Text = InningsList[1].Extras_Byes.ToString();
                Second_Inn_Leg_Byes_Value.Text = InningsList[1].Extras_Leg_Byes.ToString();
                Second_Inn_Penaltys_Value.Text = InningsList[1].Extras_Penaltys.ToString();
                Second_Inn_Extras_Total_Value.Text = InningsList[1].Extras_Total.ToString();

                // Updates table totals
                Second_Inn_Bat_Total_Runs.Text = (InningsList[1].Innings_Total - InningsList[1].Extras_Total).ToString();
                Second_Inn_Bwl_Ttls_Wds.Text = InningsList[1].Extras_Wides.ToString();
                Second_Inn_Bwl_Ttls_Nbs.Text = InningsList[1].Extras_No_Balls.ToString();
                Second_Inn_Bwl_Ttls_Ovrs.Text = InningsList[1].Innings_Overs.ToString();
                Second_Inn_Bwl_Ttls_Mdns.Text = InningsList[1].Bowl_Total_Maidens.ToString();
                Second_Inn_Bwl_Ttls_Runs.Text = InningsList[1].Bowl_Total_Runs.ToString();
                Second_Inn_Bwl_Ttls_Wkts.Text = InningsList[1].Bowl_Total_Wickets.ToString();

                // Updates match totals
                Second_Inn_Total_Runs.Text = InningsList[1].Innings_Total.ToString();
                Second_Inn_Total_Wickets.Text = InningsList[1].Innings_Wickets.ToString();
                Second_Inn_Total_Overs.Text = InningsList[1].Innings_Overs.ToString();
                Second_Inn_Balls_Remain.Text = Balls_Remain.ToString();
                Second_Inn_Runs_Remain.Text = Runs_Remaining.ToString();
                Second_Inn_Target.Text = Target_Total.ToString();
            }
        }

        /* 
         *  This function swaps the batsman during the match either after runs being scored,
         *  wicket being taken or the end of the over.
        */
        private void Swap_Batsman()
        {
            if (batList[Current_Batsman_Top_Id].Bat_Facing == true)
            {
                // Set current facing batsman to not facing and change indicator colour
                batList[Current_Batsman_Top_Id].Bat_Facing = false;
                Current_Batsman_Number_Top.BackColor = Color.Transparent;

                // Set non facing batsman to true and change indicator colour
                batList[Current_Batsman_Bottom_Id].Bat_Facing = true;
                Current_Batsman_Number_Bottom.BackColor = Color.White;
            }
            else
            {
                // Set current facing batsman to false and change indicator colour
                batList[Current_Batsman_Bottom_Id].Bat_Facing = false;
                Current_Batsman_Number_Bottom.BackColor = Color.Transparent;

                // Set non facing batsman to true and change indicator colour
                batList[Current_Batsman_Top_Id].Bat_Facing = true;
                Current_Batsman_Number_Top.BackColor = Color.White;
            }
        }

        /*
         *  When an over is completed this function swaps to the other bowler in the bowling table
         */
        private void Swap_Bowler()
        {
            if (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true)
            {
                // Set current bowler to not bowling and change indicator colour
                bowlList[Current_Bowler_Top_Id].Bowl_Bowling = false;
                Current_Bowler_Number_Top.BackColor = Color.Transparent;

                // Set other bowler to bowling and change indicator colour
                bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling = true;
                Current_Bowler_Number_Bottom.BackColor = Color.White;
            }
            else
            {
                // Set current bowler to not bowling and change indicator colour
                bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling = false;
                Current_Bowler_Number_Bottom.BackColor = Color.Transparent;

                // Set other bowler to bowling and change indicator colour
                bowlList[Current_Bowler_Top_Id].Bowl_Bowling = true;
                Current_Bowler_Number_Top.BackColor = Color.White;
            }
        }

        /*
         *  Checks if the last deliveery was the last in the over
         *  if so it updates the total overs number to the next highest round number
         */
        private void Check_End_Of_Over(double oversTotal, int bowlId)
        {
            oversTotal = Math.Round(oversTotal, 1);
            double Updated_Over_Amount = oversTotal;
            double test_total = Math.Round((oversTotal - Math.Truncate(oversTotal)),1);
            if (test_total == .6)
            {
                Updated_Over_Amount = Math.Ceiling(Updated_Over_Amount);
            }

            if (Updated_Over_Amount - Math.Truncate(Updated_Over_Amount) == 0)
            {
                bowlList[bowlId].Bowl_Overs = Math.Ceiling(bowlList[bowlId].Bowl_Overs);
                InningsList[Innings_Number - 1].Innings_Overs = Math.Ceiling(InningsList[Innings_Number - 1].Innings_Overs);

                // Check if completed over was a maiden, if not set maiden flag back to true for next over
                if (InningsList[Innings_Number - 1].maiden)
                {
                    InningsList[Innings_Number - 1].Bowl_Total_Maidens = InningsList[Innings_Number - 1].Bowl_Total_Maidens + 1;
                    bowlList[bowlId].Bowl_Maidens = bowlList[bowlId].Bowl_Maidens + 1;
                }
                else
                {
                    InningsList[Innings_Number - 1].maiden = true;
                }
                // Convert over number from double to int to allow new line to be added to Over Analysis table
                InningsList[Innings_Number - 1].Over_Analysis_Overs = Convert.ToInt32(InningsList[Innings_Number - 1].Innings_Overs);
                Over over = new Over();
                over.Create_Over(InningsList[Innings_Number - 1].Over_Analysis_Overs, (bowlId) + 1, InningsList[Innings_Number - 1].Over_Analysis_Runs, InningsList[Innings_Number - 1].Over_Analysis_Wickets);
                overAnalsisList.Add(over);
                Update_Innings_Over_Analysis();

                // Get innings notes
                if (Innings_Number == 1)
                {
                    // Save any notes made in the Notes textbox to end of over file
                    notes = First_Inn_Notes_Textbox.Text;
                }
                else
                {
                    // Save any notes made in the Notes textbox to end of over file
                    notes = Second_Inn_Notes_Textbox.Text;
                }

                // Save the over to a new text file
                Innings innings = new Innings();
                over.Save_Over(fallOfWicketList, batList, bowlList,
                    Innings_Number, Innings_Of, InningsList[Innings_Number - 1].Innings_Total, InningsList[Innings_Number - 1].Innings_Overs, InningsList[Innings_Number - 1].Innings_Wickets,
                    Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id, Current_Bowler_Bottom_Id,
                    InningsList[Innings_Number - 1].Extras_Byes, InningsList[Innings_Number - 1].Extras_Leg_Byes, InningsList[Innings_Number - 1].Extras_No_Balls, InningsList[Innings_Number - 1].Extras_Wides, InningsList[Innings_Number - 1].Extras_Penaltys, InningsList[Innings_Number - 1].Extras_Total,
                    Bat_Out, notes);

                // Swap batsmen and bowlers for start of new over
                Swap_Batsman();
                Swap_Bowler();
                // Check if end of innings has been reached
                if (innings.Check_End_Of_Innings(Innings_Number, Target_Total, InningsList[Innings_Number - 1].Innings_Total, Innings_Complete_Reason, InningsList[Innings_Number - 1].Innings_Overs, InningsList[Innings_Number - 1].Max_Overs, InningsList[Innings_Number - 1].Innings_Wickets))
                {
                    End_Of_Innings();
                }
            }
        }

        /*
         * If the last batsman out was in the top row of the batsman table on the Scoring tab.
         * This function swaps the details of the batsman on the bottom row to the top row.
         * This allows the new batsman to be placed on the bottom row to keep the batsman number
         * convention correct.
         */
        private void Wicket_Change_Top_Batsman()
        {
            // Move bottom batsman details to the top row.
            Current_Batsman_Top_Id = Current_Batsman_Bottom_Id;
            Update_Batsman_Top();
        }

        /*
         * If the bowler to be replaced is in the top row of the current bowler table in the Scoring tab,
         * The bowler on the bottom row is moved up to the top row to allow the new bowler's details to be
         * entered on the bottom row.
         */
        private void New_Bowler_Change_Top_Bowler()
        {
            // set current bowler flag of bowler being replaced to false
            bowlList[Current_Bowler_Top_Id].Bowl_Bowling = false;

            // Move bottom bowler details to the top row.
            Current_Bowler_Top_Id = Current_Bowler_Bottom_Id;
            Update_Bowler_Top();
            Current_Bowler_Number_Top.BackColor = Color.Transparent;
        }
        //
        /*
         *  If a run is scored from an extra the runs are added to the relevant row in the extra's table.
         *  If a wide or no ball is bowled no additional balls are added to the bowler, batsman or total overs.
         *  If the batsman scores runs off a no ball, 1 no ball is added to the row and the rest of the runs
         *  are attributed to the batsman.
         */
        private void Runs_Scored(string type, bool batUsed, int runs, int batId, int bowlId)
        {
            Player player = new Player();
            if (type == "runs" || type == "bye" || type == "legBye" || type == "penalty")
            {
                // Add one ball to total over amount
                InningsList[Innings_Number - 1].Innings_Overs = InningsList[Innings_Number - 1].Innings_Overs + 0.1;
                player.Bowling_Add_Ball(bowlList, bowlId);
                player.Batting_Add_Ball(batList, batId);
            }
            
            if (type == "runs" || type == "wide" || type == "noBall" || type == "penalty")
            {
                InningsList[Innings_Number - 1].maiden = false;
                bowlList[bowlId].Bowl_Runs = bowlList[bowlId].Bowl_Runs + runs;
                InningsList[Innings_Number - 1].Bowl_Total_Runs = InningsList[Innings_Number - 1].Bowl_Total_Runs + runs;
            }
            switch (type)
            { 
                case "runs":
                    batList[batId].Bat_Runs = batList[batId].Bat_Runs + runs;
                    if (runs % 2 == 1)
                    {
                        Swap_Batsman();
                    }
                    else if (runs == 4)
                    {
                        batList[batId].Bat_Fours = batList[batId].Bat_Fours + 1;
                    }
                    else if (runs == 6)
                    {
                        batList[batId].Bat_Sixes = batList[batId].Bat_Sixes + 1;
                    }
                    break;
                case "bye":
                    InningsList[Innings_Number - 1].Extras_Byes = InningsList[Innings_Number - 1].Extras_Byes + runs;
                    if (runs % 2 == 1)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "legBye":
                    InningsList[Innings_Number - 1].Extras_Leg_Byes = InningsList[Innings_Number - 1].Extras_Leg_Byes + runs;
                    if (runs % 2 == 1)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "wide":
                    bowlList[bowlId].Bowl_Wides = bowlList[bowlId].Bowl_Wides + runs;
                    InningsList[Innings_Number - 1].Extras_Wides = InningsList[Innings_Number - 1].Extras_Wides + runs;
                    if (runs % 2 == 0)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "noBall":
                    if (batUsed == true)
                    {
                        batList[batId].Bat_Runs = batList[batId].Bat_Runs + (runs - 1);
                        bowlList[bowlId].Bowl_No_Balls = bowlList[bowlId].Bowl_No_Balls + 1;
                        InningsList[Innings_Number - 1].Extras_No_Balls = InningsList[Innings_Number - 1].Extras_No_Balls + 1;
                    }
                    else
                    {
                        InningsList[Innings_Number - 1].Extras_No_Balls = InningsList[Innings_Number - 1].Extras_No_Balls + runs;
                        bowlList[bowlId].Bowl_No_Balls = bowlList[bowlId].Bowl_No_Balls + runs;
                    }

                    if (runs % 2 == 0)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "penalty":
                    InningsList[Innings_Number - 1].Extras_Penaltys = InningsList[Innings_Number - 1].Extras_Penaltys + runs;
                    break;
            };
            InningsList[Innings_Number - 1].Extras_Total = InningsList[Innings_Number - 1].Extras_Byes + InningsList[Innings_Number - 1].Extras_Leg_Byes + InningsList[Innings_Number - 1].Extras_No_Balls + InningsList[Innings_Number - 1].Extras_Penaltys + InningsList[Innings_Number - 1].Extras_Wides;
            InningsList[Innings_Number - 1].Innings_Total = InningsList[Innings_Number - 1].Innings_Total + runs;
            InningsList[Innings_Number - 1].Partnership = InningsList[Innings_Number - 1].Partnership + runs;
            InningsList[Innings_Number - 1].Over_Analysis_Runs = InningsList[Innings_Number - 1].Over_Analysis_Runs + runs;

            if (Innings_Number == 2)
            {
                Runs_Remaining = Runs_Remaining - runs;
            }
            Innings innings = new Innings();
            if (innings.Check_End_Of_Innings(Innings_Number, Target_Total, InningsList[Innings_Number - 1].Innings_Total, Innings_Complete_Reason, InningsList[Innings_Number - 1].Innings_Overs, InningsList[Innings_Number - 1].Max_Overs, InningsList[Innings_Number - 1].Innings_Wickets))
            {
                End_Of_Innings();
            }
        }

        /*
         * When a wicket is taken the application updates the Last Man Out table, Fall Of Wicket table
         * and the batting tables.
         * It:
         *  1. Adds 1 ball to the batsman, bowler and total overs
         *  2. Adds 1 to bowler and total wickets if batsman is 'caught', 'bowled', 'lbw', 'stumped' or 'caught and bowled'
         *  3. Adds 1 to total wickets if batsman is 'run out' or 'retired'
         */
        private void WicketTaken(string wicketType, string fielder_Name, bool crossed, int outBatId, int notOutBatId, int bowlId)
        {
            Player player = new Player();
            string fielderName;
            bool newBatFacing = true;
            // add ball to bowler and out batsman
            player.Bowling_Add_Ball(bowlList, bowlId);
            player.Batting_Add_Ball(batList, outBatId);
            //add wicket to bowler and total innings wickets
            if (wicketType != "runOut")
            {
            bowlList[bowlId].Bowl_Wickets = bowlList[bowlId].Bowl_Wickets + 1;
            }
            InningsList[Innings_Number - 1].Innings_Wickets = InningsList[Innings_Number - 1].Innings_Wickets + 1;

            // Used to update the last man out table in Update_Score()
            Bat_Out = outBatId;
            Bat_Not_Out = notOutBatId;

            // Make fielder name into format = Initial.Surname e.g. Joe Bloggs = J.Bloggs
            string[] fielderFullName = fielder_Name.Split(' ');
            string fielderInitial = fielderFullName[0].Substring(0, 1);
            string fielderLastName = fielderFullName[1];
            fielderName = fielderInitial + "." + fielderLastName;

            // Make bowler name into format = Initial.Surname e.g. Joe Bloggs = J.Bloggs
            string[] bowlerFullName = bowlList[bowlId].Bowl_Name.Split(' ');
            string bowlerInitial = bowlerFullName[0].Substring(0, 1);
            string bowlerLastName = bowlerFullName[1];
            string bowlerName = bowlerInitial + "." + bowlerLastName;
            
            // Checks if the crossed checkbox has been checked
            if (crossed)
            {
                Swap_Batsman();
                newBatFacing = false;
            }
            else
            {
                batList[outBatId].Bat_Facing = false;
                Current_Batsman_Number_Top.BackColor = Color.Transparent;
                Current_Batsman_Number_Bottom.BackColor = Color.White;
            }
            switch (wicketType)
            {
                case "caught":
                    batList[outBatId].Bat_How_Out = "Ct " + fielderName;
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Number - 1].Bowl_Total_Wickets = InningsList[Innings_Number - 1].Bowl_Total_Wickets + 1;

                    break;
                case "runOut":
                    batList[outBatId].Bat_How_Out = "Run Out";
                    batList[outBatId].Bat_Out_Bwlr = fielderName;
                    break;
                case "bowled":
                    batList[outBatId].Bat_How_Out = "Bowled";
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Number - 1].Bowl_Total_Wickets = InningsList[Innings_Number - 1].Bowl_Total_Wickets + 1;
                    break;
                case "stumped":
                    batList[outBatId].Bat_How_Out = "Stumped";
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Number - 1].Bowl_Total_Wickets = InningsList[Innings_Number - 1].Bowl_Total_Wickets + 1;
                    break;
                case "lbw":
                    batList[outBatId].Bat_How_Out = "LBW";
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Number - 1].Bowl_Total_Wickets = InningsList[Innings_Number - 1].Bowl_Total_Wickets + 1;
                    break;
                case "caughtAndBowled":
                    batList[outBatId].Bat_How_Out = "Ct && Bwld";
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    InningsList[Innings_Number - 1].Bowl_Total_Wickets = InningsList[Innings_Number - 1].Bowl_Total_Wickets + 1;
                    break;
                case "retired":
                    batList[outBatId].Bat_How_Out = "Retired";
                    batList[outBatId].Bat_Out_Bwlr = "Out";
                    break;
            }
            FallOfWicket fallOfWicket = new FallOfWicket();
            fallOfWicket.Create_Fall_Of_Wicket(InningsList[Innings_Number - 1].Innings_Wickets, batList, outBatId, notOutBatId, InningsList[Innings_Number - 1].Partnership, InningsList[Innings_Number - 1].Innings_Overs,InningsList[Innings_Number - 1].Innings_Total);
            fallOfWicketList.Add(fallOfWicket);
            fallOfWicket.Save_Fall_Of_Wicket_List(fallOfWicketList, Innings_Number);

            if (InningsList[Innings_Number - 1].Innings_Wickets < 10)
            {
                // Checks if the Current Batsman table rows need to be swapped.
                // Only if the batting side has wickets in hand
                if (outBatId < notOutBatId)
                {
                    Wicket_Change_Top_Batsman();
                }
                // Adds new batsman object into the table and list with Id one greater than the batsman on the bottom row.
                Player newBatsman = new Player();
                newBatsman.Create_Batsman((batList[Current_Batsman_Bottom_Id].Bat_Number + 1), (Wicket_Next_Bat_Combo_Box.SelectedItem.ToString()), newBatFacing);
                batList.Add(newBatsman);
                Current_Batsman_Bottom_Id = Current_Batsman_Bottom_Id + 1;
                Update_Batsman_Bottom();
                InningsList[Innings_Number - 1].Over_Analysis_Wickets = InningsList[Innings_Number - 1].Over_Analysis_Wickets + 1;
            }
            Innings innings = new Innings();
            if (innings.Check_End_Of_Innings(Innings_Number, Target_Total, InningsList[Innings_Number - 1].Innings_Total, Innings_Complete_Reason, InningsList[Innings_Number - 1].Innings_Overs, InningsList[Innings_Number - 1].Max_Overs, InningsList[Innings_Number - 1].Innings_Wickets))
            {
                End_Of_Innings();
            }
        }

        private void GeneralButtonClick(string type, bool batUsed, int runs)
        {
            Player player = new Player();
            Create_Undo_Point();
            Runs_Scored(type, batUsed, runs, player.Check_Batsman_Facing(batList,Current_Batsman_Top_Id,Current_Batsman_Bottom_Id), player.Check_Bowler_Bowling(bowlList,Current_Bowler_Top_Id,Current_Bowler_Bottom_Id));
            Check_End_Of_Over(InningsList[Innings_Number - 1].Innings_Overs, player.Check_Bowler_Bowling(bowlList, Current_Bowler_Top_Id, Current_Bowler_Bottom_Id));
            Update_Score();
            HideAllPanels();
        }

        /*
         *  When a wicket is taken, this function is called to ensure that the correct batsman is selected as out
         *  and that the correct players from the fielding side are referenced for the wicket.
         */
        private void WicketButtonClick(string howOut, string fielder_Name, bool crossed)
        {
            Player player = new Player();
            Create_Undo_Point();
            // Add one ball to total over amount
            InningsList[Innings_Number - 1].Innings_Overs = InningsList[Innings_Number - 1].Innings_Overs + 0.1;
            if (howOut == "runOut")
            {
                if (Radio_Run_Out_Bat_Top.Checked)
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, player.Check_Bowler_Bowling(bowlList,Current_Bowler_Top_Id,Current_Bowler_Bottom_Id));
                }
                else if (Radio_Run_Out_Bat_Bottom.Checked)
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Bottom_Id, Current_Batsman_Top_Id, player.Check_Bowler_Bowling(bowlList, Current_Bowler_Top_Id, Current_Bowler_Bottom_Id));
                }
            }
            else
            {
                if (batList[Current_Batsman_Top_Id].Bat_Facing == true)
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, player.Check_Bowler_Bowling(bowlList,Current_Bowler_Top_Id,Current_Bowler_Bottom_Id));
                }
                else
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Bottom_Id, Current_Batsman_Top_Id, player.Check_Bowler_Bowling(bowlList,Current_Bowler_Top_Id,Current_Bowler_Bottom_Id));
                }
            }
            Check_End_Of_Over(InningsList[Innings_Number - 1].Innings_Overs, player.Check_Bowler_Bowling(bowlList, Current_Bowler_Top_Id, Current_Bowler_Bottom_Id));
            // Updates the FOW table
            Update_Innings_Fall_Of_Wicket();
            Update_Score();
            HideAllPanels();
        }

        /* 
         * This function adds:
         *  1 ball to the batsmans total balls faced
         *  0.1 overs to the bowlers total overs bowled
         *  0.1 overs to the total overs bowled
         */  
        private void Dot_Button_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("runs", true, 0);
        }
 
         /* **** The following functions add runs when the relevant buttons are pressed **** */

        // Adds one run to the batsman, bowler and total runs
        private void One_Button_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("runs", true, 1);
        }

        // Adds two runs to the batsman, bowler and total runs
        private void Two_Button_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("runs", true, 2);
        }

        // Adds three runs to the batsman, bowler and total runs
        private void Three_Button_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("runs", true, 3);
        }

        // Adds four runs to the batsman, bowler and total runs
        private void Four_Button_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("runs", true, 4);
        }

        // Adds six runs to the batsman, bowler and total runs
        private void Six_Button_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("runs", true, 6);
        }

        /* **** The next collection of buttons will allow the user to add byes to the score. **** */

        // Shows the byes flow control panel to enter number of runs
        private void Bye_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_Byes.Show();   
        }

        // Adds one bye to the total
        private void Bye_1_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("bye", false, 1);
        }

        // Adds two byes to the total
        private void Bye_2_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("bye", false, 2);
        }

        // Adds three byes to the total
        private void Bye_3_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("bye", false, 3);
        }

        // Adds four byes to the total
        private void Bye_4_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("bye", false, 4);
        }

        // Adds number of runs selected from the Byes_Combo_Box
        private void Bye_Ok_Click(object sender, EventArgs e)
        {
            int byesToAdd;
            byesToAdd = int.Parse(Bye_Combo_Box.SelectedItem.ToString());
            GeneralButtonClick("bye", false, byesToAdd);
        }

        /* **** The next collection of buttons will allow the user to add leg byes to the score. **** */

        // Shows the leg bye flow control panel
        private void Leg_Bye_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_Leg_Byes.Show();
        }

        // Adds 1 leg bye
        private void Leg_Bye_1_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("legBye", false, 1);
        }

        // Adds 2 leg byes
        private void Leg_Bye_2_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("legBye", false, 2);
        }

        // Adds 3 leg byes
        private void Leg_Bye_3_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("legBye", false, 3);
        }

        // Adds 4 leg byes
        private void Leg_Bye_4_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("legBye", false, 4);
        }

        // Adds the number of leg byes selected in the leg byes combo box
        private void Leg_Bye_Ok_Click(object sender, EventArgs e)
        {
            int legByesToAdd;
            legByesToAdd = int.Parse(Leg_Byes_Combo_Box.SelectedItem.ToString());
            GeneralButtonClick("legBye", false, legByesToAdd);
        }

        /* **** The next collection of buttons will allow the user to add wides to the score. **** */

        //
        private void Wide_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_Wides.Show();
        }

        // Adds 1 wide
        private void Wides_1_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("wide", false, 1);
        }

        // Adds 2 wides
        private void Wides_2_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("wide", false, 2);
        }

        // Adds 3 wides
        private void Wides_3_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("wide", false, 3);
        }

        // Adds 4 wides
        private void Wides_4_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("wide", false, 4);
        }

        // Adds 5 wides
        private void Wides_5_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("wide", false, 5);
        }

        // Adds the number of wides selected in the wides combo box
        private void Wides_Ok_Click(object sender, EventArgs e)
        {
            int widesToAdd;
            widesToAdd = int.Parse(Wides_Combo_Box.SelectedItem.ToString());
            GeneralButtonClick("wide", false, widesToAdd);
        }

        /* **** The next collection of buttons will allow the user to add wides to the score. **** */

        /* 
         * Adds one run to the total runs
         * Adds one to the total number of bowler no balls
         * Adds one to the total number of no balls in the extras table
        */
        private void No_Ball_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_No_Ball_Question.Show();
        }

        /* The next two functions allow the user to add no balls
         *      The first allows the user to add no ball runs when the batsman has hit the ball
         *      The second allows the user to add no ball runs when the batsman has not hit the ball
         */
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

        /* **** The next collection of buttons will allow the user to add no balls without batsman runs to the score. **** */
        
        // Adds 1 run
        private void No_Ball_No_Bat_1_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", false, 1);
        }

        // Adds 2 runs
        private void No_Ball_No_Bat_2_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", false, 2);
        }

        // Adds 3 runs
        private void No_Ball_No_Bat_3_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", false, 3);
        }

        // Adds 4 runs
        private void No_Ball_No_Bat_4_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", false, 4);
        }

        // Adds 5 runs
        private void No_Ball_No_Bat_5_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", false, 5);
        }

        // Adds the number of no balls selected in the no ball no bat combo box
        private void No_Ball_No_Bat_Ok_Click(object sender, EventArgs e)
        {
            int NoBallsToAdd;
            NoBallsToAdd = int.Parse(No_Ball_No_Bat_Combo_Box.SelectedItem.ToString());
            GeneralButtonClick("noBall", false, NoBallsToAdd);
        }

        /* **** The next collection of buttons will allow the user to add no balls with batsman runs to the score. **** */
        
        // Adds 2 runs (1 for batsman, 1 for no ball)
        private void No_Ball_Bat_2_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", true, 2);
        }

        // Adds 3 runs (2 for batsman, 1 for no ball)
        private void No_Ball_Bat_3_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", true, 3);
        }

        // Adds 4 runs (3 for batsman, 1 for no ball)
        private void No_Ball_Bat_4_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", true, 4);
        }

        // Adds 5 runs (4 for batsman, 1 for no ball)
        private void No_Ball_Bat_5_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", true, 5);
        }

        // Adds 6 runs (5 for batsman, 1 for no ball)
        private void No_Ball_Bat_6_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", true, 6);
        }

        // Adds 7 runs (6 for batsman, 1 for no ball)
        private void No_Ball_Bat_7_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("noBall", true, 7);
        }

        // Adds the number of no balls selected in the no ball bat combo box (always 1 no ball + x-1 runs for batsman)
        private void No_Ball_Bat_Ok_Click(object sender, EventArgs e)
        {
            int NoBallsToAdd;
            NoBallsToAdd = int.Parse(No_Ball_Bat_Combo_Box.SelectedItem.ToString());
            GeneralButtonClick("noBall", true, NoBallsToAdd);
        }

        /* 
         * Adds one wicket to the bowler and total wickets
         * Adds one ball to the batsman, bowler and total overs
         * Inserts new row into last man out table
         * Inserts new batsman after user selection
        */
        private void Wicket_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_Wicket.Show();
        }

        /* **** The following set of radio buttons allow the user to select how the batsman was out **** */

        // If batsman was caught, the user must select the fielder who caught the batsman
        private void Radio_Button_Caught_CheckedChanged(object sender, EventArgs e)
        {
            Flow_Panel_Run_Out.Hide();
            Flow_Panel_Fielder.Show();
        }

        // If batsman was run out, the user must select the fielder who ran out the batsman
        private void Radio_Button_Run_Out_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Run_Out_Bat_Top.Text = batList[Current_Batsman_Top_Id].Bat_Number.ToString();
            Radio_Run_Out_Bat_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Number.ToString();
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
         * This function gets the betails from the controls in the flow panel and calls the 
         * relevant function to handle the wicket.
         * 
         * Note that fielder name is only needed for run out and caught
         */
        private void Wicket_Confirm_Button_Click(object sender, EventArgs e)
        {
            bool crossed = false;
            if (Check_Box_Crossed.Checked)
            {
                crossed = true;
            }

            if (Radio_Button_Run_Out.Checked)
            {
                string fielderName;
                fielderName = Run_Out_Fielder_Combo.SelectedItem.ToString();
                WicketButtonClick("runOut", fielderName, crossed);
            }
            else if (Radio_Button_Caught.Checked)
            {
                string fielderName;
                fielderName = Wicket_Fielder_Select_Combo_Box.SelectedItem.ToString();
                WicketButtonClick("caught", fielderName, crossed);
            }
            else if (Radio_Button_Bowled.Checked)
            {
                WicketButtonClick("bowled", "none ",false);
            }
            else if (Radio_Button_Caught_And_Bowled.Checked)
            {
                WicketButtonClick("caughtAndBowled", "none ",false);
            }
            else if (Radio_Button_Stumped.Checked)
            {
                WicketButtonClick("stumped", "none ",false);
            }
            else if (Radio_Button_LBW.Checked)
            {
                WicketButtonClick("lbw", "none ", false);
            }
            else
            {
                WicketButtonClick("retired", "none ", crossed);
            }
        }

        /*
         * If there are penalty runs conceded the application adds these to the score
         */
        private void Penalty_Button_Click(object sender, EventArgs e)
        {
            GeneralButtonClick("penalty", false, 5);
        }

        /*
         * This fuction allows the user to add runs from the other score combo box.
         */
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            int runsToAdd;
            runsToAdd = int.Parse(Other_Score_Combo_Box.SelectedItem.ToString());
            GeneralButtonClick("runs", true, runsToAdd);
        }

        /*
         * This function calls the restore last state function to undo the last action taken by the user.
         */
        private void Undo_Last_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Restore_Last_State();
        }

        /*
         * When the end of innings button if clicked the end of innings flow panel is shown
         */
        private void End_Of_Innings_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_End_Of_Innings.Show();
        }
        private void End_Of_Innings_Select_Button_Click(object sender, EventArgs e)
        {
            Innings_Complete_Reason = End_Of_Innings_Combo_Box.SelectedItem.ToString();
            End_Of_Innings();
        }

        /*
         * When the user needs to enter a new bowler this function shows the combo box to select
         * the next bowler's name,
         * 
         */
        private void New_Bowler_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Flow_Panel_New_Bowler.Show();
        }

        /*
         * When the user selects the new bowler's name and clicks the select button,
         * this function checks if the bowler being replaced is in the top row of the current bowlers
         * tables, if so the function swaps the bottom bowler details to the top row and inserts
         * the new bowler into the bottom row.
         * 
         */
        private void New_Bowler_Select_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            Create_Undo_Point();
            New_Bowler_Id = Current_Bowler_Bottom_Id + 1;

            if (bowlList[Current_Bowler_Top_Id].Bowl_Bowling)
            {
                New_Bowler_Change_Top_Bowler();
                player.Create_Bowler((New_Bowler_Id + 1), (New_Bowler_Combo_Box.SelectedItem.ToString()), true);
            }
            else
            {
                player.Create_Bowler((New_Bowler_Id + 1), (New_Bowler_Combo_Box.SelectedItem.ToString()), true);
            }
            bowlList.Add(player);
            Current_Bowler_Bottom_Id = New_Bowler_Id;
            Update_Bowler_Bottom();
            Current_Bowler_Number_Bottom.BackColor = Color.White;
        }
    }
}