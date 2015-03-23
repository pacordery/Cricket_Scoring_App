using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cricket_Scoring_App
{
    public partial class Scoring_Application_Form : Form
    {
        public Scoring_Application_Form()
        {
            InitializeComponent();
        }
        List<Player> Innings1BatsmanList = new List<Player>();
        List<Player> Innings1BowlerList = new List<Player>();
        List<Player> Innings2BatsmanList = new List<Player>();
        List<Player> Innings2BowlerList = new List<Player>();

        // Initialising all match detail variables
        DateTime Date;
        string Home_Team;
        string Away_Team;
        string Innings_Of;
        string Ground_Name;
        string Weather;
        int    Innings_Total;
        int    Innings_Wickets;
        double  Innings_Overs;

        // Initialising all batting variables
        int Bat_Out;
        int Bat_Total_Runs;
        int New_Bat_Id;
        int Current_Batsman_Top_Id;
        int Current_Batsman_Bottom_Id;

        // Initialising all bowling variables
        int Bowl_Total_Wides;
        int Bowl_Total_No_Balls;
        double Bowl_Total_Overs;
        int Bowl_Total_Maidens;
        int Bowl_Total_Runs;
        int Bowl_Total_Wickets;
        int Current_Bowler_Top_Id;
        int Current_Bowler_Bottom_Id;
        int New_Bowler_Id;
        
        // Initialising all extras variables
        int Extras_Wides;
        int Extras_No_Balls;
        int Extras_Byes;
        int Extras_Leg_Byes;
        int Extras_Penaltys;
        int Extras_Total;

        // Initialising all over analysis variables
        int Over_Anlysis_Over;
        int Over_Anlysis_Bowler;
        int Over_Anlysis_Runs;
        int Over_Anlysis_Wickets;

        // **** Set of temporary variables to allow the application to undo the last action ****
        int Temp_Current_Batsman_Top_Id;
        int Temp_Current_Batsman_Bottom_Id;
        int Temp_Current_Bowler_Top_Id;
        int Temp_Current_Bowler_Bottom_Id;
        int Temp_Bat_Out;

        // Stores top batsman details
        int Temp_Current_Batsman_Number_Top;
        string Temp_Current_Batsman_Name_Top;
        int Temp_Current_Batsman_Number_Of_Fours_Top;
        int Temp_Current_Batsman_Number_Of_Sixes_Top;
        int Temp_Current_Batsman_Balls_Faced_Top;
        int Temp_Current_Batsman_Runs_Scored_Top;
        int Temp_Current_Batsman_Minutes_Batted_Top;
        bool Temp_Current_Batsman_Facing_Top;

        // Stores bottom batsman details
        int Temp_Current_Batsman_Number_Bottom;
        string Temp_Current_Batsman_Name_Bottom;
        int Temp_Current_Batsman_Number_Of_Fours_Bottom;
        int Temp_Current_Batsman_Number_Of_Sixes_Bottom;
        int Temp_Current_Batsman_Balls_Faced_Bottom;
        int Temp_Current_Batsman_Runs_Scored_Bottom;
        int Temp_Current_Batsman_Minutes_Batted_Bottom;
        bool Temp_Current_Batsman_Facing_Bottom;

        // Stores top bowler details 
        int Temp_Current_Bowler_Number_Top;
        string Temp_Current_Bowler_Name_Top;
        int Temp_Current_Bowler_Wides_Conceded_Top;
        int Temp_Current_Bowler_No_Balls_Conceded_Top;
        double Temp_Current_Bowler_Overs_Bowled_Top;
        int Temp_Current_Bowler_Maidens_Bowled_Top;
        int Temp_Current_Bowler_Runs_Conceded_Top;
        int Temp_Current_Bowler_Wickets_Taken_Top;
        bool Temp_Current_Bowler_Top;

        // Stores bottom bowler details
        int Temp_Current_Bowler_Number_Bottom;
        string Temp_Current_Bowler_Name_Bottom;
        int Temp_Current_Bowler_Wides_Conceded_Bottom;
        int Temp_Current_Bowler_No_Balls_Conceded_Bottom;
        double Temp_Current_Bowler_Overs_Bowled_Bottom;
        int Temp_Current_Bowler_Maidens_Bowled_Bottom;
        int Temp_Current_Bowler_Runs_Conceded_Bottom;
        int Temp_Current_Bowler_Wickets_Taken_Bottom;
        bool Temp_Current_Bowler_Bottom;

        // Stores Extra table details
        int Temp_Wides_Total_Value;
        int Temp_No_Balls_Total_Value;
        int Temp_Byes_Total_Value;
        int Temp_Leg_Byes_Total_Value;
        int Temp_Penaltys_Total_Value;
        int Temp_Total_Extras_Value;

        // Stores Last Man Out table
        int Temp_Out_Batsman_Number_Value;
        string Temp_Out_Batsman_Name;
        string Temp_Out_Batsman_How_Out_Value;
        string Temp_Out_Batsman_Bowler_Value;
        int Temp_Out_Batsman_Total_Runs_Scored_Value;

        // Stores match details
        int Temp_Scoring_Total_Value;
        int Temp_Scoring_Wickets_Down_Value;
        double Temp_Scoring_Total_Overs_Value;

        // **** End of temporary variables to allow the application to undo the last action ****

        /*
         *  When the user selects which side is batting in the Batting Side Combo Box,
         *  the application will only show the batting side in the batsman select boxes
         *  and only the bowling side in the bowler select boxes.
         */
        private void Open_Select_Bat_Side_SelectedIndexChanged(object sender, EventArgs e)
        {
            Innings_Of = Open_Select_Bat_Side.SelectedItem.ToString();
            First_Inn_Innings_Of.Text = Open_Select_Bat_Side.SelectedItem.ToString();
        }

        /*
         * When the user selects the first batsman from the Select Batsman 1 combo box
         * the application creates a new player object and adds it to the batting list
         */
        private void Open_Select_Bat_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player Batsman_1 = new Player()
            {
                Bat_Number = 1,
                Bat_Name = Open_Select_Bat_1.SelectedItem.ToString(),
                Bat_How_Out = "Not",
                Bat_Out_Bwlr = "Out",
                Bat_Fours = 0,
                Bat_Sixes = 0,
                Bat_Balls = 0,
                Bat_Runs = 0,
                Bat_Minutes = 0,
                Bat_Facing = true,
            };
            if (Innings1BatsmanList.Count < 1)
            {
                Innings1BatsmanList.Add(Batsman_1);
            }
            else
            {
                Innings1BatsmanList.RemoveAt(0);
                Innings1BatsmanList.Insert(0,Batsman_1);
            }
            Current_Batsman_Top_Id = 0;
        }

        /*
         * When the user selects the second batsman from the Select Batsman 2 combo box
         * the application creates a new player object and adds it to the batting list
         */
        private void Open_Select_Bat_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player Batsman_2 = new Player()
            {
                Bat_Number = 2,
                Bat_Name = Open_Select_Bat_2.SelectedItem.ToString(),
                Bat_How_Out = "Not",
                Bat_Out_Bwlr = "Out",
                Bat_Fours = 0,
                Bat_Sixes = 0,
                Bat_Balls = 0,
                Bat_Runs = 0,
                Bat_Minutes = 0,
                Bat_Facing = false,
            };

            /* Add two batsman 2 objects into the list to ensure that list order is preserved
             * if batsman 2 is selected before batsman 1.
             */
            if (Innings1BatsmanList.Count < 1)
            {
                
                Innings1BatsmanList.Add(Batsman_2);
                Innings1BatsmanList.Add(Batsman_2);
            }
            else if (Innings1BatsmanList.Count == 2)
            {
                Innings1BatsmanList.RemoveAt(1);
                Innings1BatsmanList.Insert(1, Batsman_2);
            }
            else
            {
                Innings1BatsmanList.Add(Batsman_2);
            }
            Current_Batsman_Bottom_Id = 1;
        }

        /*
         * When the user selects the first bowler from the Select Bowler 1 combo box
         * the application creates a new player object and adds it to the bowling list
         */
        private void Open_Select_Bowl_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player Bowler_1 = new Player()
            {
                Bowl_Number = 1,
                Bowl_Name = Open_Select_Bowl_1.SelectedItem.ToString(),
                Bowl_Wides = 0,
                Bowl_No_Balls = 0,
                Bowl_Overs = 0.0,
                Bowl_Maidens = 0,
                Bowl_Runs = 0,
                Bowl_Wickets = 0,
                Bowl_Average = 0.0,
                Bowl_Economy = 0.0,
                Bowl_Bowling = true,
            };
            if (Innings1BowlerList.Count < 1)
            {
                Innings1BowlerList.Add(Bowler_1);
            }
            else
            {
                Innings1BowlerList.RemoveAt(0);
                Innings1BowlerList.Insert(0, Bowler_1);
            }
            Current_Bowler_Top_Id = 0;
        }

        /*
         * When the user selects the second bowler from the Select Bowler 2 combo box
         * the application creates a new player object and adds it to the bowling list
         */
        private void Open_Select_Bowl_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player Bowler_2 = new Player()
            {
                Bowl_Number = 2,
                Bowl_Name = Open_Select_Bowl_2.SelectedItem.ToString(),
                Bowl_Wides = 0,
                Bowl_No_Balls = 0,
                Bowl_Overs = 0.0,
                Bowl_Maidens = 0,
                Bowl_Runs = 0,
                Bowl_Wickets = 0,
                Bowl_Average = 0.0,
                Bowl_Economy = 0.0,
                Bowl_Bowling = false,
            };

            /*
             * Add two bowler 2 objects into the list to ensure that list order is
             * preserved if bowler 2 is selected before batsman 1.
            */
            if (Innings1BatsmanList.Count < 1)
            {
                Innings1BowlerList.Add(Bowler_2);
                Innings1BowlerList.Add(Bowler_2);
            }
            else if (Innings1BowlerList.Count == 2)
            {
                Innings1BowlerList.RemoveAt(1);
                Innings1BowlerList.Insert(1, Bowler_2);
            }
            else
            {
                Innings1BowlerList.Add(Bowler_2);
            }
            Current_Bowler_Bottom_Id = 1;
        }

        /*
         * This dunction hides all of the flow control panels for extras and wickets
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
        }

        /* 
         * This function handles the initialisation of the scorecard tab.
         * It hides all of the flow panels
         * Assigns batsman and bowlers into the batting and bowling tables
         * Sets all extras to 0
         * sets all totals to 0
         */
        private void Confirm_Openers_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();

            // Set Extras table values to 0
            Extras_Wides = 0;
            Extras_No_Balls = 0;
            Extras_Byes = 0;
            Extras_Leg_Byes = 0;
            Extras_Penaltys = 0;
            Extras_Total = 0;

            // Set match details
            Innings_Total = 0;
            Innings_Overs = 0;
            Innings_Wickets = 0;
            Date = DateTime.Now;
            Home_Team = "";
            Away_Team = "";
            Weather = "";
            Ground_Name = "";

            // TODO move this code into the scorecard handler class
            // Sets top batsman details
            Current_Batsman_Name_Top.Text = Innings1BatsmanList[0].Bat_Name;
            Current_Batsman_Number_Of_Fours_Top.Text = Innings1BatsmanList[0].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = Innings1BatsmanList[0].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Top.Text = Innings1BatsmanList[0].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Top.Text = Innings1BatsmanList[0].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Top.Text = Innings1BatsmanList[0].Bat_Minutes.ToString();
            Current_Batsman_Facing_Top.BackColor = Color.Red;

            // Sets bottom batsman details
            Current_Batsman_Name_Bottom.Text = Innings1BatsmanList[1].Bat_Name;
            Current_Batsman_Number_Of_Fours_Bottom.Text = Innings1BatsmanList[1].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = Innings1BatsmanList[1].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = Innings1BatsmanList[1].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = Innings1BatsmanList[1].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Bottom.Text = Innings1BatsmanList[1].Bat_Minutes.ToString();
            Current_Batsman_Facing_Bottom.BackColor = Color.Transparent;

            // Sets top bowler details 
            Current_Bowler_Name_Top.Text = Innings1BowlerList[0].Bowl_Name;
            Current_Bowler_Wides_Conceded_Top.Text = Innings1BowlerList[0].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = Innings1BowlerList[0].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = Innings1BowlerList[0].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = Innings1BowlerList[0].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = Innings1BowlerList[0].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = Innings1BowlerList[0].Bowl_Wickets.ToString();
            Current_Bowler_Top.BackColor = Color.Red;

            // Sets bottom bowler details
            Current_Bowler_Name_Bottom.Text = Innings1BowlerList[1].Bowl_Name;
            Current_Bowler_Wides_Conceded_Bottom.Text = Innings1BowlerList[1].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = Innings1BowlerList[1].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = Innings1BowlerList[1].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = Innings1BowlerList[1].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = Innings1BowlerList[1].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = Innings1BowlerList[1].Bowl_Wickets.ToString();
            Current_Bowler_Bottom.BackColor = Color.Transparent;

            //Scorecard_Handler ScorecardHandler = new Scorecard_Handler();
            //ScorecardHandler.Scorecard_Initialise(Innings1BatsmanList, Innings1BowlerList);

            // Sets Extra table details
            Wides_Total_Value.Text = Extras_Wides.ToString();
            No_Balls_Total_Value.Text = Extras_No_Balls.ToString();
            Byes_Total_Value.Text = Extras_Byes.ToString();
            Leg_Byes_Total_Value.Text = Extras_Leg_Byes.ToString();
            Penaltys_Total_Value.Text = Extras_Penaltys.ToString();
            Total_Extras_Value.Text = Extras_Total.ToString();

            // Sets match details
            Scoring_Date_Value.Text = Date.ToShortDateString();
            Scoring_Home_Team_Name_Value.Text = Home_Team;
            Scoring_Away_Team_Name_Value.Text = Away_Team;
            Scoring_Innings_Of_Value.Text = Innings_Of;
            Scoring_Total_Value.Text = Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = Innings_Overs.ToString();        

            // Switch to the scoring tab
            Scoring_App_Tab_Set.SelectedTab = Scoring_Tab;
        }
        
        /*
         *  This function creates an unto point to allow the user to undo their last
         *  operation.
         *  It stores all of the current values into temporary variables which are recalled
         *  when Restore_Last_State() is called
         */
        private void Create_Undo_Point()
        {
            // Stores batsman, bowler and last batsman out id's
            Temp_Current_Batsman_Top_Id = Current_Batsman_Top_Id;
            Temp_Current_Batsman_Bottom_Id = Current_Batsman_Bottom_Id;
            Temp_Current_Bowler_Top_Id = Current_Bowler_Top_Id;
            Temp_Current_Bowler_Bottom_Id = Current_Bowler_Bottom_Id;
            Temp_Bat_Out = Bat_Out;

            // Stores top batsman details
            Temp_Current_Batsman_Name_Top = Innings1BatsmanList[Temp_Current_Batsman_Top_Id].Bat_Name;
            Temp_Current_Batsman_Number_Of_Fours_Top = Innings1BatsmanList[Temp_Current_Batsman_Top_Id].Bat_Fours;
            Temp_Current_Batsman_Number_Of_Sixes_Top = Innings1BatsmanList[Temp_Current_Batsman_Top_Id].Bat_Sixes;
            Temp_Current_Batsman_Balls_Faced_Top = Innings1BatsmanList[Temp_Current_Batsman_Top_Id].Bat_Balls;
            Temp_Current_Batsman_Runs_Scored_Top = Innings1BatsmanList[Temp_Current_Batsman_Top_Id].Bat_Runs;
            Temp_Current_Batsman_Minutes_Batted_Top = Innings1BatsmanList[Temp_Current_Batsman_Top_Id].Bat_Minutes;
            Temp_Current_Batsman_Facing_Top = Innings1BatsmanList[Temp_Current_Batsman_Top_Id].Bat_Facing;

            // Stores bottom batsman details
            Temp_Current_Batsman_Name_Bottom = Innings1BatsmanList[Temp_Current_Batsman_Bottom_Id].Bat_Name;
            Temp_Current_Batsman_Number_Of_Fours_Bottom = Innings1BatsmanList[Temp_Current_Batsman_Bottom_Id].Bat_Fours;
            Temp_Current_Batsman_Number_Of_Sixes_Bottom = Innings1BatsmanList[Temp_Current_Batsman_Bottom_Id].Bat_Sixes;
            Temp_Current_Batsman_Balls_Faced_Bottom = Innings1BatsmanList[Temp_Current_Batsman_Bottom_Id].Bat_Balls;
            Temp_Current_Batsman_Runs_Scored_Bottom = Innings1BatsmanList[Temp_Current_Batsman_Bottom_Id].Bat_Runs;
            Temp_Current_Batsman_Minutes_Batted_Bottom = Innings1BatsmanList[Temp_Current_Batsman_Bottom_Id].Bat_Minutes;
            Temp_Current_Batsman_Facing_Bottom = Innings1BatsmanList[Temp_Current_Batsman_Bottom_Id].Bat_Facing;

            // Stores top bowler details 
            Temp_Current_Bowler_Name_Top = Innings1BowlerList[Temp_Current_Bowler_Top_Id].Bowl_Name;
            Temp_Current_Bowler_Wides_Conceded_Top = Innings1BowlerList[Temp_Current_Bowler_Top_Id].Bowl_Wides;
            Temp_Current_Bowler_No_Balls_Conceded_Top = Innings1BowlerList[Temp_Current_Bowler_Top_Id].Bowl_No_Balls;
            Temp_Current_Bowler_Overs_Bowled_Top = Innings1BowlerList[Temp_Current_Bowler_Top_Id].Bowl_Overs;
            Temp_Current_Bowler_Maidens_Bowled_Top = Innings1BowlerList[Temp_Current_Bowler_Top_Id].Bowl_Maidens;
            Temp_Current_Bowler_Runs_Conceded_Top = Innings1BowlerList[Temp_Current_Bowler_Top_Id].Bowl_Runs;
            Temp_Current_Bowler_Wickets_Taken_Top = Innings1BowlerList[Temp_Current_Bowler_Top_Id].Bowl_Wickets;
            Temp_Current_Bowler_Top = Innings1BowlerList[Temp_Current_Bowler_Top_Id].Bowl_Bowling;

            // Stores bottom bowler details
            Temp_Current_Bowler_Name_Bottom = Innings1BowlerList[Temp_Current_Bowler_Bottom_Id].Bowl_Name;
            Temp_Current_Bowler_Wides_Conceded_Bottom = Innings1BowlerList[Temp_Current_Bowler_Bottom_Id].Bowl_Wides;
            Temp_Current_Bowler_No_Balls_Conceded_Bottom = Innings1BowlerList[Temp_Current_Bowler_Bottom_Id].Bowl_No_Balls;
            Temp_Current_Bowler_Overs_Bowled_Bottom = Innings1BowlerList[Temp_Current_Bowler_Bottom_Id].Bowl_Overs;
            Temp_Current_Bowler_Maidens_Bowled_Bottom = Innings1BowlerList[Temp_Current_Bowler_Bottom_Id].Bowl_Maidens;
            Temp_Current_Bowler_Runs_Conceded_Bottom = Innings1BowlerList[Temp_Current_Bowler_Bottom_Id].Bowl_Runs;
            Temp_Current_Bowler_Wickets_Taken_Bottom = Innings1BowlerList[Temp_Current_Bowler_Bottom_Id].Bowl_Wickets;
            Temp_Current_Bowler_Bottom = Innings1BowlerList[Temp_Current_Bowler_Bottom_Id].Bowl_Bowling;

            // Stores Extra table details
            Temp_Wides_Total_Value = Extras_Wides;
            Temp_No_Balls_Total_Value = Extras_No_Balls;
            Temp_Byes_Total_Value = Extras_Byes;
            Temp_Leg_Byes_Total_Value = Extras_Leg_Byes;
            Temp_Penaltys_Total_Value = Extras_Penaltys;
            Temp_Total_Extras_Value = Extras_Total;

            // Stores Last Man Out table
            Temp_Out_Batsman_Number_Value = Innings1BatsmanList[Temp_Bat_Out].Bat_Number;
            Temp_Out_Batsman_Name = Innings1BatsmanList[Temp_Bat_Out].Bat_Name;
            Temp_Out_Batsman_How_Out_Value = Innings1BatsmanList[Temp_Bat_Out].Bat_How_Out;
            Temp_Out_Batsman_Bowler_Value = Innings1BatsmanList[Temp_Bat_Out].Bat_Out_Bwlr;
            Temp_Out_Batsman_Total_Runs_Scored_Value = Innings1BatsmanList[Temp_Bat_Out].Bat_Runs;

            // Stores match details
            Temp_Scoring_Total_Value = Innings_Total;
            Temp_Scoring_Wickets_Down_Value = Innings_Wickets;
            Temp_Scoring_Total_Overs_Value = Innings_Overs;
        }

        /*
         * Restores the score back to the state before the incorrect operation was carried out.
         * It:
         *      Updates the batsman and bowler objects, extras totals and match totals
         *      Updates all tables
         */
        private void Restore_Last_State()
        {
            Current_Batsman_Top_Id = Temp_Current_Batsman_Top_Id;
            Current_Batsman_Bottom_Id = Temp_Current_Batsman_Bottom_Id;
            Current_Bowler_Top_Id = Temp_Current_Bowler_Top_Id;
            Current_Bowler_Bottom_Id = Temp_Current_Bowler_Bottom_Id ;
            Bat_Out = Temp_Bat_Out ;

            // Update batsman objects
            Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Fours = Temp_Current_Batsman_Number_Of_Fours_Top;
            Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Sixes = Temp_Current_Batsman_Number_Of_Sixes_Top;
            Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Balls = Temp_Current_Batsman_Balls_Faced_Top;
            Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Runs = Temp_Current_Batsman_Runs_Scored_Top;
            Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Minutes = Temp_Current_Batsman_Minutes_Batted_Top;
            Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing = Temp_Current_Batsman_Facing_Top;

            Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Fours = Temp_Current_Batsman_Number_Of_Fours_Bottom;
            Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Sixes = Temp_Current_Batsman_Number_Of_Sixes_Bottom;
            Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Balls = Temp_Current_Batsman_Balls_Faced_Bottom;
            Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Runs = Temp_Current_Batsman_Runs_Scored_Bottom;
            Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Minutes = Temp_Current_Batsman_Minutes_Batted_Bottom;
            Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing = Temp_Current_Batsman_Facing_Bottom;

            // Restores batsman table details
            Current_Batsman_Number_Top.Text = Temp_Current_Batsman_Number_Top.ToString();
            Current_Batsman_Name_Top.Text = Temp_Current_Batsman_Name_Top;
            Current_Batsman_Number_Of_Fours_Top.Text = Temp_Current_Batsman_Number_Of_Fours_Top.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = Temp_Current_Batsman_Number_Of_Sixes_Top.ToString();
            Current_Batsman_Balls_Faced_Top.Text = Temp_Current_Batsman_Balls_Faced_Top.ToString();
            Current_Batsman_Runs_Scored_Top.Text = Temp_Current_Batsman_Runs_Scored_Top.ToString();
            Current_Batsman_Minutes_Batted_Top.Text = Temp_Current_Batsman_Minutes_Batted_Top.ToString();

            Current_Batsman_Number_Bottom.Text = Temp_Current_Batsman_Number_Bottom.ToString();
            Current_Batsman_Name_Bottom.Text = Temp_Current_Batsman_Name_Bottom;
            Current_Batsman_Number_Of_Fours_Bottom.Text = Temp_Current_Batsman_Number_Of_Fours_Bottom.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = Temp_Current_Batsman_Number_Of_Sixes_Bottom.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = Temp_Current_Batsman_Balls_Faced_Bottom.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = Temp_Current_Batsman_Runs_Scored_Bottom.ToString();
            Current_Batsman_Minutes_Batted_Bottom.Text = Temp_Current_Batsman_Minutes_Batted_Bottom.ToString();

            // Set the current bowler flag
            if (Temp_Current_Batsman_Facing_Top)
            {
                Current_Batsman_Facing_Top.BackColor = Color.Red;
                Current_Batsman_Facing_Bottom.BackColor = Color.Transparent;  
            }
            else
            {
                Current_Batsman_Facing_Top.BackColor = Color.Transparent;
                Current_Batsman_Facing_Bottom.BackColor = Color.Red;
            }

            // Restores bowler objects
            Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Wides = Temp_Current_Bowler_Wides_Conceded_Top;
            Innings1BowlerList[Current_Bowler_Top_Id].Bowl_No_Balls = Temp_Current_Bowler_No_Balls_Conceded_Top;
            Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Overs = Temp_Current_Bowler_Overs_Bowled_Top;
            Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Maidens = Temp_Current_Bowler_Maidens_Bowled_Top;
            Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Runs = Temp_Current_Bowler_Runs_Conceded_Top;
            Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Wickets = Temp_Current_Bowler_Wickets_Taken_Top;
            Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling = Temp_Current_Bowler_Top;

            Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Wides = Temp_Current_Bowler_Wides_Conceded_Bottom;
            Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_No_Balls = Temp_Current_Bowler_No_Balls_Conceded_Bottom;
            Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Overs = Temp_Current_Bowler_Overs_Bowled_Bottom;
            Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Maidens = Temp_Current_Bowler_Maidens_Bowled_Bottom;
            Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Runs = Temp_Current_Bowler_Runs_Conceded_Bottom;
            Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Wickets = Temp_Current_Bowler_Wickets_Taken_Bottom;
            Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling = Temp_Current_Bowler_Bottom;

            // Restores bowler table details 
            Current_Bowler_Number_Top.Text = Temp_Current_Bowler_Number_Top.ToString();
            Current_Bowler_Name_Top.Text = Temp_Current_Bowler_Name_Top;
            Current_Bowler_Wides_Conceded_Top.Text = Temp_Current_Bowler_Wides_Conceded_Top.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = Temp_Current_Bowler_No_Balls_Conceded_Top.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = Temp_Current_Bowler_Overs_Bowled_Top.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = Temp_Current_Bowler_Maidens_Bowled_Top.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = Temp_Current_Bowler_Runs_Conceded_Top.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = Temp_Current_Bowler_Wickets_Taken_Top.ToString();

            Current_Bowler_Number_Bottom.Text = Temp_Current_Bowler_Number_Bottom.ToString();
            Current_Bowler_Name_Bottom.Text = Temp_Current_Bowler_Name_Bottom;
            Current_Bowler_Wides_Conceded_Bottom.Text = Temp_Current_Bowler_Wides_Conceded_Bottom.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = Temp_Current_Bowler_No_Balls_Conceded_Bottom.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = Temp_Current_Bowler_Overs_Bowled_Bottom.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = Temp_Current_Bowler_Maidens_Bowled_Bottom.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = Temp_Current_Bowler_Runs_Conceded_Bottom.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = Temp_Current_Bowler_Wickets_Taken_Bottom.ToString();

            // Set the current bowler flag
            if (Temp_Current_Bowler_Top)
            {
                Current_Bowler_Top.BackColor = Color.Red;
                Current_Bowler_Bottom.BackColor = Color.Transparent;
            }
            else
            {
                Current_Bowler_Top.BackColor = Color.Transparent;
                Current_Bowler_Bottom.BackColor = Color.Red;
            }

            // Restore extra totals
            Extras_Wides = Temp_Wides_Total_Value;
            Extras_No_Balls = Temp_No_Balls_Total_Value;
            Extras_Byes = Temp_Byes_Total_Value;
            Extras_Leg_Byes = Temp_Leg_Byes_Total_Value;
            Extras_Penaltys = Temp_Penaltys_Total_Value;
            Extras_Total = Temp_Total_Extras_Value;

            // Restores Extra table details
            Wides_Total_Value.Text = Temp_Wides_Total_Value.ToString();
            No_Balls_Total_Value.Text = Temp_No_Balls_Total_Value.ToString();
            Byes_Total_Value.Text = Temp_Byes_Total_Value.ToString();
            Leg_Byes_Total_Value.Text = Temp_Leg_Byes_Total_Value.ToString();
            Penaltys_Total_Value.Text = Temp_Penaltys_Total_Value.ToString();
            Total_Extras_Value.Text = Temp_Total_Extras_Value.ToString();

            /* Restores Last Man Out table details,
             * if no wickets have been taken then the table should be blank
             */
            if (Innings_Wickets == 0)
            {
                Out_Batsman_Number_Value.Text = "-";
                Out_Batsman_Name.Text = "-";
                Out_Batsman_How_Out_Value.Text = "-";
                Out_Batsman_Bowler_Value.Text = "-";
                Out_Batsman_Total_Runs_Scored_Value.Text = "-";
            }
            else
            {
                Out_Batsman_Number_Value.Text = Temp_Out_Batsman_Number_Value.ToString();
                Out_Batsman_Name.Text = Temp_Out_Batsman_Name;
                Out_Batsman_How_Out_Value.Text = Temp_Out_Batsman_How_Out_Value;
                Out_Batsman_Bowler_Value.Text = Temp_Out_Batsman_Bowler_Value;
                Out_Batsman_Total_Runs_Scored_Value.Text = Temp_Out_Batsman_Total_Runs_Scored_Value.ToString();
            }

            // Restores match details values
            Innings_Overs = Temp_Scoring_Total_Overs_Value;
            Innings_Total = Temp_Scoring_Total_Value;
            Innings_Wickets = Temp_Scoring_Wickets_Down_Value;

            // Restores match details table
            Scoring_Total_Value.Text = Temp_Scoring_Total_Value.ToString();
            Scoring_Wickets_Down_Value.Text = Temp_Scoring_Wickets_Down_Value.ToString();
            Scoring_Total_Overs_Value.Text = Temp_Scoring_Total_Overs_Value.ToString();
        }
        
        /*
         *  This function updates all tables in the application after every button click
         *  The first set of statements update the Scoring Tab
         *  The second set of statements update the Innings 1 tab
         *  The third set of statements update the Innings 2 tab
         */
        private void Update_Score()
        {
            // ******* The next set of statements updates the data on the Scoring tab *******
            // Updates top batsman details
            Current_Batsman_Number_Of_Fours_Top.Text = Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Top.Text = Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Top.Text = Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Top.Text = Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Minutes.ToString();

            // Updates bottom batsman details
            Current_Batsman_Number_Of_Fours_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Minutes.ToString();

            // Updates top bowler details 
            Current_Bowler_Wides_Conceded_Top.Text = Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = Innings1BowlerList[Current_Bowler_Top_Id].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Wickets.ToString();

            // Updates bottom bowler details
            Current_Bowler_Wides_Conceded_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Wickets.ToString();

            // Updates Extra table details
            Wides_Total_Value.Text = Extras_Wides.ToString();
            No_Balls_Total_Value.Text = Extras_No_Balls.ToString();
            Byes_Total_Value.Text = Extras_Byes.ToString();
            Leg_Byes_Total_Value.Text = Extras_Leg_Byes.ToString();
            Penaltys_Total_Value.Text = Extras_Penaltys.ToString();
            Total_Extras_Value.Text = Extras_Total.ToString();

            /* 
             * Updates Last Man Out table, if no wickets taken then table is blank
             */
            if (Innings_Wickets == 0)
            {
                Out_Batsman_Number_Value.Text = "-";
                Out_Batsman_Name.Text = "-";
                Out_Batsman_How_Out_Value.Text = "-";
                Out_Batsman_Bowler_Value.Text = "-";
                Out_Batsman_Total_Runs_Scored_Value.Text = "-";
            }
            else
            {
                Out_Batsman_Number_Value.Text = Innings1BatsmanList[Bat_Out].Bat_Number.ToString();
                Out_Batsman_Name.Text = Innings1BatsmanList[Bat_Out].Bat_Name;
                Out_Batsman_How_Out_Value.Text = Innings1BatsmanList[Bat_Out].Bat_How_Out;
                Out_Batsman_Bowler_Value.Text = Innings1BatsmanList[Bat_Out].Bat_Out_Bwlr;
                Out_Batsman_Total_Runs_Scored_Value.Text = Innings1BatsmanList[Bat_Out].Bat_Runs.ToString();
            }

            // Updates match details
            Scoring_Total_Value.Text = Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = Innings_Overs.ToString();
        }

        /* 
         *  This function swaps the batsman during the match either after runs being scored,
         *  wicket being taken or the end of the over.
        */
        private void Swap_Batsman()
        {
            if (Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true)
            {
                // Set current facing batsman to not facing and change indicator colour
                Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing = false;
                Current_Batsman_Facing_Top.BackColor = Color.Transparent;

                // Set non facing batsman to true and change indicator colour
                Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing = true;
                Current_Batsman_Facing_Bottom.BackColor = Color.Red;
            }
            else
            {
                // Set current facing batsman to false and change indicator colour
                Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing = false;
                Current_Batsman_Facing_Bottom.BackColor = Color.Transparent;

                // Set non facing batsman to true and change indicator colour
                Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing = true;
                Current_Batsman_Facing_Top.BackColor = Color.Red;
            }
        }

        /*
         *  When an over is completed this function swaps to the other bowler in the bowling table
         */
        private void Swap_Bowler()
        {
            if (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true)
            {
                // Set current bowler to not bowling and change indicator colour
                Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling = false;
                Current_Bowler_Top.BackColor = Color.Transparent;

                // Set other bowler to bowling and change indicator colour
                Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling = true;
                Current_Bowler_Bottom.BackColor = Color.Red;
            }
            else
            {
                // Set current bowler to not bowling and change indicator colour
                Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling = false;
                Current_Bowler_Bottom.BackColor = Color.Transparent;

                // Set other bowler to bowling and change indicator colour
                Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling = true;
                Current_Bowler_Top.BackColor = Color.Red;
            }
        }

        /*
         *  Checks if the last deliveery was the last in the over
         *  if so it updates the total overs number to the next highest round number
         */
        private void Check_End_Of_Over(double oversTotal)
        {
            oversTotal = Math.Round(oversTotal, 1);
            double Updated_Over_Amount = oversTotal;
            double test_total = Math.Round((oversTotal - Math.Truncate(oversTotal)),1);
            if (test_total == .6)
            {
                Updated_Over_Amount = Math.Ceiling(Updated_Over_Amount);
            }

            if ((Updated_Over_Amount - Math.Truncate(Updated_Over_Amount) == 0) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Overs = Math.Ceiling(Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Overs);
                Innings_Overs = Math.Ceiling(Innings_Overs);
                Swap_Batsman();
                Swap_Bowler();
            }
            else if ((Updated_Over_Amount - Math.Truncate(Updated_Over_Amount) == 0) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Overs = Math.Ceiling(Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Overs);
                Innings_Overs = Math.Ceiling(Innings_Overs);
                Swap_Batsman();
                Swap_Bowler();
            }
        }

        /*
         *  This function adds an extra ball to the batsman's number of balls faced
         */
        private void Batting_Add_Ball(int bat_id)
        {
            Innings1BatsmanList[bat_id].Bat_Balls = Innings1BatsmanList[bat_id].Bat_Balls + 1;
        }

        /*
         *  This function adds an extra ball to the bowlers's overs bowled
         */
        private void Bowling_Add_Ball(int bowl_Id)
        {
            Innings1BowlerList[bowl_Id].Bowl_Overs = Innings1BowlerList[bowl_Id].Bowl_Overs + 0.1;
        }

        /*
         *  This function creates a new player object.
         *  It is called when the Wicket Confirm button is pressed.
         *  It uses the selected name from the wicket combo box to create a new player
         *  and adds it to the batsman list. The function then updates the batsman tables
         *  with the new batsman's information
         */
        private void Enter_New_Batsman(int bottomBatId, bool facing)
        {
            Player newBatsman = new Player()
            {
                Bat_Number = bottomBatId + 1,
                Bat_Name = Wicket_Next_Bat_Combo_Box.SelectedItem.ToString(),
                Bat_How_Out = "Not",
                Bat_Out_Bwlr = "Out",
                Bat_Fours = 0,
                Bat_Sixes = 0,
                Bat_Balls = 0,
                Bat_Runs = 0,
                Bat_Minutes = 0,
                Bat_Facing = facing,
            };
            Innings1BatsmanList.Add(newBatsman);
            Current_Batsman_Bottom_Id = bottomBatId;

            Current_Batsman_Number_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Number.ToString();
            Current_Batsman_Name_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Name;
            Current_Batsman_Number_Of_Fours_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Bottom.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Minutes.ToString();
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
            Current_Batsman_Number_Top.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Number.ToString();
            Current_Batsman_Name_Top.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Name.ToString();
            Current_Batsman_Number_Of_Fours_Top.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Top.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Top.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Top.Text = Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Minutes.ToString();

        }

        /*
         * When the New Bowler button is pressed, this function is called.
         * It creates a new player object with the details in the New Bowler Combo Box
         * The new player is then added to the bowler list and entered into the bottom row of the bowling 
         * table.
         */
        private void Enter_New_Bowler(int newBowlerId)
        { 
            Player newBowler = new Player()
            {
                Bowl_Number = newBowlerId + 1,
                Bowl_Name = New_Bowler_Combo_Box.SelectedItem.ToString(),
                Bowl_Wides = 0,
                Bowl_No_Balls = 0,
                Bowl_Overs = 0.0,
                Bowl_Maidens = 0,
                Bowl_Runs = 0,
                Bowl_Wickets = 0,
                Bowl_Average = 0.0,
                Bowl_Economy = 0.0,
                Bowl_Bowling = true,
            };
            Innings1BowlerList.Add(newBowler);
            Current_Bowler_Bottom_Id = newBowlerId;

            Current_Bowler_Number_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Number.ToString();
            Current_Bowler_Name_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Name;
            Current_Bowler_Wides_Conceded_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Wickets.ToString();
            Current_Bowler_Bottom.BackColor = Color.Red;

        }

        /*
         * If the bowler to be replaced is in the top row of the current bowler table in the Scoring tab,
         * The bowler on the bottom row is moved up to the top row to allow the new bowler's details to be
         * entered on the bottom row.
         */
        private void New_Bowler_Change_Top_Bowler()
        {
            // set current bowler flag of bowler being replaced to false
            Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling = false;

            // Move bottom bowler details to the top row.
            Current_Bowler_Top_Id = Current_Bowler_Bottom_Id;
            Current_Bowler_Name_Top.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Name;
            Current_Bowler_Wides_Conceded_Top.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Wickets.ToString();
            Current_Bowler_Top.BackColor = Color.Transparent;
        }

        /*
         *  If a run is scored by the batsman off a legal delivery the runs are added to:
         *      1. the bastman's score
         *      2. the bowlers runs conceded
         *      3. the total score
         */
        private void Run_ScoredOffBat(int numberOfRuns,int batId, int bowlId)
        {
            int runsScored = 0;
            switch (numberOfRuns)
            {
                case 1:
                    runsScored = 1;
                    Swap_Batsman();
                    break;
                case 2:
                    runsScored = 2;
                    break;
                case 3:
                    runsScored = 3;
                    Swap_Batsman();
                    break;
                case 4:
                    runsScored = 4;
                    Innings1BatsmanList[batId].Bat_Fours = Innings1BatsmanList[batId].Bat_Fours + 1;
                    break;
                case 6:
                    runsScored = 6;
                    Innings1BatsmanList[batId].Bat_Sixes = Innings1BatsmanList[batId].Bat_Sixes + 1;
                    break;
            };
            
            Batting_Add_Ball(batId);
            Innings1BatsmanList[batId].Bat_Runs = Innings1BatsmanList[batId].Bat_Runs + runsScored;
            Innings1BowlerList[bowlId].Bowl_Runs = Innings1BowlerList[bowlId].Bowl_Runs + runsScored;
            Innings_Total = Innings_Total + runsScored;
        }

        /*
         *  If a run is scored from an extra the runs are added to the relevant row in the extra's table.
         *  If a wide or no ball is bowled no additional balls are added to the bowler, batsman or total overs.
         *  If the batsman scores runs off a no ball, 1 no ball is added to the row and the rest of the runs
         *  are attributed to the batsman.
         */
        private void Extra_Run_Scored(string extraId, bool batUsed, int runs, int batId, int bowlId)
        {
            switch (extraId)
            {
                case "bye":
                    Extras_Byes = Extras_Byes + runs;
                    if (runs % 2 == 1)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "legBye":
                    Extras_Leg_Byes = Extras_Leg_Byes + runs;
                    if (runs % 2 == 1)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "wide":
                    Innings1BowlerList[bowlId].Bowl_Runs = Innings1BowlerList[bowlId].Bowl_Runs + runs;
                    Innings1BowlerList[bowlId].Bowl_Wides = Innings1BowlerList[bowlId].Bowl_Wides + runs;
                    Extras_Wides = Extras_Wides + runs;
                    if (runs % 2 == 0)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "noBall":
                    if (batUsed == true)
                    {
                        Innings1BatsmanList[batId].Bat_Runs = Innings1BatsmanList[batId].Bat_Runs + (runs - 1);
                    }
                    Innings1BowlerList[bowlId].Bowl_Runs = Innings1BowlerList[bowlId].Bowl_Runs + runs;
                    Innings1BowlerList[bowlId].Bowl_No_Balls = Innings1BowlerList[bowlId].Bowl_No_Balls + 1;
                    Extras_No_Balls = Extras_No_Balls + runs;
                    if (runs % 2 == 0)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "penalty":
                    Innings1BowlerList[bowlId].Bowl_Runs = Innings1BowlerList[bowlId].Bowl_Runs + runs;
                    Extras_Penaltys = Extras_Penaltys + runs;
                    break;
            };
            Innings_Total = Innings_Total + runs;
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
            string fielderName;
            bool newBatFacing = true;
            // add ball to bowler and out batsman
            Batting_Add_Ball(outBatId);
            Bowling_Add_Ball(bowlId);
            //add wicket to bowler and total innings wickets
            if (wicketType != "runOut")
            {
            Innings1BowlerList[bowlId].Bowl_Wickets = Innings1BowlerList[bowlId].Bowl_Wickets + 1;
            }
            Innings_Wickets = Innings_Wickets + 1;
            // Bat_Out used to update the last man out table in Update_Score()
            Bat_Out = outBatId;

            // Make fielder name into format = Initial.Surname e.g. Joe Bloggs = J.Bloggs
            string[] fielderFullName = fielder_Name.Split(' ');
            string fielderInitial = fielderFullName[0].Substring(0, 1);
            string fielderLastName = fielderFullName[1];
            fielderName = fielderInitial + "." + fielderLastName;

            // Make bowler name into format = Initial.Surname e.g. Joe Bloggs = J.Bloggs
            string[] bowlerFullName = Innings1BowlerList[bowlId].Bowl_Name.Split(' ');
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
                Innings1BatsmanList[outBatId].Bat_Facing = false;
                Current_Batsman_Facing_Top.BackColor = Color.Transparent;
                Current_Batsman_Facing_Bottom.BackColor = Color.Red;
            }
            switch (wicketType)
            {
                case "caught":
                    Innings1BatsmanList[outBatId].Bat_How_Out = "Ct " + fielderName;
                    Innings1BatsmanList[outBatId].Bat_Out_Bwlr = bowlerName;
                    break;
                case "runOut":
                    Innings1BatsmanList[outBatId].Bat_How_Out = "Run Out";
                    Innings1BatsmanList[outBatId].Bat_Out_Bwlr = fielderName;
                    break;
                case "bowled":
                    Innings1BatsmanList[outBatId].Bat_How_Out = "Bowled";
                    Innings1BatsmanList[outBatId].Bat_Out_Bwlr = bowlerName;
                    break;
                case "stumped":
                    Innings1BatsmanList[outBatId].Bat_How_Out = "Stumped";
                    Innings1BatsmanList[outBatId].Bat_Out_Bwlr = bowlerName;
                    break;
                case "lbw":
                    Innings1BatsmanList[outBatId].Bat_How_Out = "LBW";
                    Innings1BatsmanList[outBatId].Bat_Out_Bwlr = bowlerName;
                    break;
                case "caughtAndBowled":
                    Innings1BatsmanList[outBatId].Bat_How_Out = "Ct && Bwld";
                    Innings1BatsmanList[outBatId].Bat_Out_Bwlr = bowlerName;
                    break;
                case "retired":
                    Innings1BatsmanList[outBatId].Bat_How_Out = "Retired";
                    Innings1BatsmanList[outBatId].Bat_Out_Bwlr = "Out";
                    break;
            }

            // Checks if the Current Batsman table rows need to be swapped.
            if (Innings_Wickets < 10 && outBatId < notOutBatId)
            {
                New_Bat_Id = notOutBatId + 1;
                Wicket_Change_Top_Batsman();
                Enter_New_Batsman(New_Bat_Id, newBatFacing);
            }
            else if (Innings_Wickets < 10 && notOutBatId < outBatId)
            {
                New_Bat_Id = outBatId + 1;
                Enter_New_Batsman(New_Bat_Id,newBatFacing);
            }
        }

        /*
         * When a run is scored from a legal ball the user presses one of the run buttons or
         * selects the score from the combo box.
         * This function is called to update the correct batsman and bowler's details
         */
        private void GeneralRunButtonClick(int runs)
        {
            Create_Undo_Point();
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(runs, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Run_ScoredOffBat(runs, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
            HideAllPanels();
        }

        /*
         *  When a bye is scored the user clicks on one of the bye buttons or selects the amount
         *  from the byes combo box.
         *  This function is called to update the correct batsman and bowlers details.
         */
        private void GeneralByeButtonClick(int runs)
        {
            Create_Undo_Point();
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("bye", false, runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("bye", false, runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("bye", false, runs, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
                Batting_Add_Ball(Current_Batsman_Bottom_Id);
            }
            else
            {
                Extra_Run_Scored("bye", false, runs, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
                Batting_Add_Ball(Current_Batsman_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
            Flow_Panel_Byes.Hide();
        }

        /*
         *  When a leg bye is scored the user clicks on one of the leg bye buttons or selects the amount
         *  from the leg byes combo box.
         *  This function is called to update the correct batsman and bowlers details.
         */
        private void GeneralLegByeButtonClick(int runs)
        {
            Create_Undo_Point();
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("legBye", false, runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("legBye", false, runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("legBye", false, runs, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
                Batting_Add_Ball(Current_Batsman_Bottom_Id);
            }
            else
            {
                Extra_Run_Scored("legBye", false, runs, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
                Batting_Add_Ball(Current_Batsman_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
            Flow_Panel_Leg_Byes.Hide();
        }

        /*
         *  When a wide is scored the user clicks on one of the wides buttons or selects the amount
         *  from the wides combo box.
         *  This function is called to update the correct bowlers details and swap batsmen if required.
         */
        private void GeneralWideButtonClick(int runs)
        {
            Create_Undo_Point();
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("wide", false, runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("wide", false, runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("wide", false, runs, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
            }
            else
            {
                Extra_Run_Scored("wide", false, runs, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
            }
            Update_Score();
            Flow_Panel_Wides.Hide();
        }

        /*
         *  When a no ball is scored the user clicks on one of the no ball buttons or selects the amount
         *  from the no balls combo box.
         *  This function is called to update the correct bowlers and batsmen's details.
         */
        private void GeneralNoBallButtonClick(bool batUsed, int runs)
        {
            Create_Undo_Point();
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("noBall", batUsed, runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("noBall", batUsed, runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("noBall", batUsed, runs, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
            }
            else
            {
                Extra_Run_Scored("noBall", batUsed, runs, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
            }
            Update_Score();
            if (batUsed == true)
            {
                Flow_Panel_No_Ball_Bat.Hide();
            }
            else
            {
                Flow_Panel_No_Ball_No_Bat.Hide();
            }
        }

        /*
         *  When a wicket is taken, this function is called to ensure that the correct batsman is selected as out
         *  and that the correct players from the fielding side are referenced for the wicket.
         */
        private void WicketButtonClick(string howOut, string fielder_Name, bool crossed)
        {
            Create_Undo_Point();
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if (howOut == "runOut")
            {
                if ((Radio_Run_Out_Bat_Top.Checked) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                }
                else if ((Radio_Run_Out_Bat_Top.Checked) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                }
                else if ((Radio_Run_Out_Bat_Bottom.Checked) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Bottom_Id, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                }
                else
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Bottom_Id, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                }
            }
            else
            {
                if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                }
                else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                }
                else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Bottom_Id, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                }
                else
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Bottom_Id, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                }
            }
            Check_End_Of_Over(Innings_Overs);
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
            Create_Undo_Point();
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;

            // Adds extra run to batsman facing's total balls faced
            if (Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true)
            {
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else
            {
                Batting_Add_Ball(Current_Batsman_Bottom_Id);
            }

            if (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true)
            {
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);        
            Update_Score();
            HideAllPanels();
        }
 
         /* **** The following functions add runs when the relevant buttons are pressed **** */

        // Adds one run to the batsman, bowler and total runs
        private void One_Button_Click(object sender, EventArgs e)
        {
            GeneralRunButtonClick(1);
        }

        // Adds two runs to the batsman, bowler and total runs
        private void Two_Button_Click(object sender, EventArgs e)
        {
            GeneralRunButtonClick(2);
        }

        // Adds three runs to the batsman, bowler and total runs
        private void Three_Button_Click(object sender, EventArgs e)
        {
            GeneralRunButtonClick(3);
        }

        // Adds four runs to the batsman, bowler and total runs
        private void Four_Button_Click(object sender, EventArgs e)
        {
            GeneralRunButtonClick(4);
        }

        // Adds six runs to the batsman, bowler and total runs
        private void Six_Button_Click(object sender, EventArgs e)
        {
            GeneralRunButtonClick(6);
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
            GeneralByeButtonClick(1);
        }

        // Adds two byes to the total
        private void Bye_2_Click(object sender, EventArgs e)
        {
            GeneralByeButtonClick(2);
        }

        // Adds three byes to the total
        private void Bye_3_Click(object sender, EventArgs e)
        {
            GeneralByeButtonClick(3);
        }

        // Adds four byes to the total
        private void Bye_4_Click(object sender, EventArgs e)
        {
            GeneralByeButtonClick(4);
        }

        // Adds number of runs selected from the Byes_Combo_Box
        private void Bye_Ok_Click(object sender, EventArgs e)
        {
            int byesToAdd;
            byesToAdd = int.Parse(Bye_Combo_Box.SelectedItem.ToString());
            GeneralByeButtonClick(byesToAdd);
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
            GeneralLegByeButtonClick(1);
        }

        // Adds 2 leg byes
        private void Leg_Bye_2_Click(object sender, EventArgs e)
        {
            GeneralLegByeButtonClick(2);
        }

        // Adds 3 leg byes
        private void Leg_Bye_3_Click(object sender, EventArgs e)
        {
            GeneralLegByeButtonClick(3);
        }

        // Adds 4 leg byes
        private void Leg_Bye_4_Click(object sender, EventArgs e)
        {
            GeneralLegByeButtonClick(4);
        }

        // Adds the number of leg byes selected in the leg byes combo box
        private void Leg_Bye_Ok_Click(object sender, EventArgs e)
        {
            int legByesToAdd;
            legByesToAdd = int.Parse(Leg_Byes_Combo_Box.SelectedItem.ToString());
            GeneralLegByeButtonClick(legByesToAdd);
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
            GeneralWideButtonClick(1);
        }

        // Adds 2 wides
        private void Wides_2_Click(object sender, EventArgs e)
        {
            GeneralWideButtonClick(2);
        }

        // Adds 3 wides
        private void Wides_3_Click(object sender, EventArgs e)
        {
            GeneralWideButtonClick(3);
        }

        // Adds 4 wides
        private void Wides_4_Click(object sender, EventArgs e)
        {
            GeneralWideButtonClick(4);
        }

        // Adds 5 wides
        private void Wides_5_Click(object sender, EventArgs e)
        {
            GeneralWideButtonClick(5);
        }

        // Adds the number of wides selected in the wides combo box
        private void Wides_Ok_Click(object sender, EventArgs e)
        {
            int widesToAdd;
            widesToAdd = int.Parse(Wides_Combo_Box.SelectedItem.ToString());
            GeneralWideButtonClick(widesToAdd);
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
            GeneralNoBallButtonClick(false, 1);
        }

        // Adds 2 runs
        private void No_Ball_No_Bat_2_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(false, 2);
        }

        // Adds 3 runs
        private void No_Ball_No_Bat_3_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(false, 3);
        }

        // Adds 4 runs
        private void No_Ball_No_Bat_4_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(false, 4);
        }

        // Adds 5 runs
        private void No_Ball_No_Bat_5_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(false, 5);
        }

        // Adds the number of no balls selected in the no ball no bat combo box
        private void No_Ball_No_Bat_Ok_Click(object sender, EventArgs e)
        {
            int NoBallsToAdd;
            NoBallsToAdd = int.Parse(No_Ball_No_Bat_Combo_Box.SelectedItem.ToString());
            GeneralNoBallButtonClick(false,NoBallsToAdd);
        }

        /* **** The next collection of buttons will allow the user to add no balls with batsman runs to the score. **** */
        
        // Adds 2 runs (1 for batsman, 1 for no ball)
        private void No_Ball_Bat_2_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(true, 2);
        }

        // Adds 3 runs (2 for batsman, 1 for no ball)
        private void No_Ball_Bat_3_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(true, 3);
        }

        // Adds 4 runs (3 for batsman, 1 for no ball)
        private void No_Ball_Bat_4_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(true, 4);
        }

        // Adds 5 runs (4 for batsman, 1 for no ball)
        private void No_Ball_Bat_5_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(true, 5);
        }

        // Adds 6 runs (5 for batsman, 1 for no ball)
        private void No_Ball_Bat_6_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(true, 6);
        }

        // Adds 7 runs (6 for batsman, 1 for no ball)
        private void No_Ball_Bat_7_Click(object sender, EventArgs e)
        {
            GeneralNoBallButtonClick(true, 7);
        }

        // Adds the number of no balls selected in the no ball bat combo box (always 1 no ball + x-1 runs for batsman)
        private void No_Ball_Bat_Ok_Click(object sender, EventArgs e)
        {
            int NoBallsToAdd;
            NoBallsToAdd = int.Parse(No_Ball_Bat_Combo_Box.SelectedItem.ToString());
            GeneralNoBallButtonClick(true, NoBallsToAdd);
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
            Create_Undo_Point();
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("penalty", false, 5, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("penalty", false, 5, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("penalty", false, 5, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
            }
            else
            {
                Extra_Run_Scored("penalty", false, 5, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
            HideAllPanels();
        }

        /*
         * This fuction allows the user to add runs from the other score combo box.
         */
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            int runsToAdd;
            runsToAdd = int.Parse(Other_Score_Combo_Box.SelectedItem.ToString());
            GeneralNoBallButtonClick(true, runsToAdd);
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
            Create_Undo_Point();
            New_Bowler_Id = Current_Bowler_Bottom_Id + 1;

            if (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling)
            {
                New_Bowler_Change_Top_Bowler();
                Enter_New_Bowler(New_Bowler_Id);
            }
            else
            {
                Enter_New_Bowler(New_Bowler_Id);
            }
        }
    }
}
