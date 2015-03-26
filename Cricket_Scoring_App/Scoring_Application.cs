﻿using System;
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
        List<Player> Innings1BatsmanList = new List<Player>();
        List<Player> Innings1BowlerList = new List<Player>();
        List<Player> Innings2BatsmanList = new List<Player>();
        List<Player> Innings2BowlerList = new List<Player>();
        List<Player> batList = new List<Player>();
        List<Player> bowlList = new List<Player>();

        // Initialising all match detail variables
        string Date;
        string Home_Team;
        string Away_Team;
        string Ground_Name;
        string Match_Type;
        string Weather;
        string Toss_Winner;
        int Innings_Total;
        int Innings_Wickets;
        double Innings_Overs;
        int Innings_Number;
        string Innings_Of;

        // Initialising all batting variables
        int Bat_Out;
        int Bat_Not_Out;
        int New_Bat_Id;
        int Current_Batsman_Top_Id;
        int Current_Batsman_Bottom_Id;
        int Partnership;

        // Initialising all bowling variables
        bool Maiden;
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
        int Over_Analysis_Runs;
        int Over_Analysis_Overs;

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

        /* Load function to read all text files created in the previous form,
         * information is stored into the applications lists
         */
        private void Scoring_Application_Form_Load(object sender, EventArgs e)
        {
            // On load the innings to be scored is the first innings
            Innings_Number = 1;

            // Storing match details into the MatchDetailsList
            StreamReader MatchDetailsReader = new StreamReader("C:\\Users\\Philip\\Desktop\\MatchDetails.txt");
            try
            {
                do
                {
                    MatchDetailsList.Add(MatchDetailsReader.ReadLine());
                }
                while (MatchDetailsReader.Peek() != -1);
            }
            catch
            {
                MatchDetailsList.Add("Empty File");
            }
            finally
            {
                MatchDetailsReader.Close();
            }

            // Storing home team details into the HomeTeamList
            StreamReader HomeTeamReader = new StreamReader("C:\\Users\\Philip\\Desktop\\" + MatchDetailsList[1] + ".txt");
            try
            {
                do
                {
                    HomeTeamList.Add(HomeTeamReader.ReadLine());
                }
                while (HomeTeamReader.Peek() != -1);
            }
            catch
            {
                HomeTeamList.Add("Empty File");
            }
            finally
            {
                HomeTeamReader.Close();
            }

            // Storing away team details into the AwayTeamList
            StreamReader AwayTeamReader = new StreamReader("C:\\Users\\Philip\\Desktop\\" + MatchDetailsList[2] + ".txt");
            try
            {
                do
                {
                    AwayTeamList.Add(AwayTeamReader.ReadLine());
                }
                while (AwayTeamReader.Peek() != -1);
            }
            catch
            {
                AwayTeamList.Add("Empty File");
            }
            finally
            {
                AwayTeamReader.Close();
            }
            // Insert team names into the Toss Winner combo box on the Opener Selection tab
            Toss_Winner_Combo_Box.Items.Clear();
            Toss_Winner_Combo_Box.Items.Add(MatchDetailsList[1]);
            Toss_Winner_Combo_Box.Items.Add(MatchDetailsList[2]);

            // Insert team names into the Batting Side combo box on the Opener Selection tab
            Open_Select_Bat_Side.Items.Clear();
            Open_Select_Bat_Side.Items.Add(MatchDetailsList[1]);
            Open_Select_Bat_Side.Items.Add(MatchDetailsList[2]);
        }

        private void Populate_Scorecard_Player_Combo_Boxes(string batting, string bowling)
        {
            Wicket_Next_Bat_Combo_Box.Items.Clear();
            Wicket_Fielder_Select_Combo_Box.Items.Clear();
            Run_Out_Fielder_Combo.Items.Clear();
            New_Bowler_Combo_Box.Items.Clear();

            if (batting == Home_Team)
            {
                for (int i = 0; i < HomeTeamList.Count(); i = i + 1)
                {
                    Wicket_Next_Bat_Combo_Box.Items.Add(HomeTeamList[i]);
                }
                for (int j = 0; j < AwayTeamList.Count(); j = j + 1)
                {
                    Wicket_Fielder_Select_Combo_Box.Items.Add(AwayTeamList[j]);
                    Run_Out_Fielder_Combo.Items.Add(AwayTeamList[j]);
                    New_Bowler_Combo_Box.Items.Add(AwayTeamList[j]);
                }
            }
            else
            {
                for (int i = 0; i < AwayTeamList.Count(); i = i + 1)
                {
                    Wicket_Next_Bat_Combo_Box.Items.Add(AwayTeamList[i]);
                }
                for (int j = 0; j < HomeTeamList.Count(); j = j + 1)
                {
                    Wicket_Fielder_Select_Combo_Box.Items.Add(HomeTeamList[j]);
                    Run_Out_Fielder_Combo.Items.Add(HomeTeamList[j]);
                    New_Bowler_Combo_Box.Items.Add(HomeTeamList[j]);
                }
            }
        }

        private void Populate_Bat_Bowl_Select_Combo_Boxes(string batting, string bowling)
        {
            Open_Select_Bat_1.Items.Clear();
            Open_Select_Bat_2.Items.Clear();
            Open_Select_Bowl_1.Items.Clear();
            Open_Select_Bowl_2.Items.Clear();
            Open_Select_Bat_1_Inn_2.Items.Clear();
            Open_Select_Bat_2_Inn_2.Items.Clear();
            Open_Select_Bowl_1_Inn_2.Items.Clear();
            Open_Select_Bowl_2_Inn_2.Items.Clear();

            if (batting == Home_Team)
            {
                for (int i = 0; i < HomeTeamList.Count(); i = i + 1)
                {
                    Open_Select_Bat_1.Items.Add(HomeTeamList[i]);
                    Open_Select_Bat_2.Items.Add(HomeTeamList[i]);
                    Open_Select_Bowl_1_Inn_2.Items.Add(HomeTeamList[i]);
                    Open_Select_Bowl_2_Inn_2.Items.Add(HomeTeamList[i]);
                }
                for (int j = 0; j < AwayTeamList.Count(); j = j + 1)
                {
                    Open_Select_Bowl_1.Items.Add(AwayTeamList[j]);
                    Open_Select_Bowl_2.Items.Add(AwayTeamList[j]);
                    Open_Select_Bat_1_Inn_2.Items.Add(AwayTeamList[j]);
                    Open_Select_Bat_2_Inn_2.Items.Add(AwayTeamList[j]);
                }
            }
            else
            {
                for (int i = 0; i < AwayTeamList.Count(); i = i + 1)
                {
                    Open_Select_Bat_1.Items.Add(AwayTeamList[i]);
                    Open_Select_Bat_2.Items.Add(AwayTeamList[i]);
                    Open_Select_Bowl_1_Inn_2.Items.Add(AwayTeamList[i]);
                    Open_Select_Bowl_2_Inn_2.Items.Add(AwayTeamList[i]);
                }
                for (int j = 0; j < HomeTeamList.Count(); j = j + 1)
                {
                    Open_Select_Bowl_1.Items.Add(HomeTeamList[j]);
                    Open_Select_Bowl_2.Items.Add(HomeTeamList[j]);
                    Open_Select_Bat_1_Inn_2.Items.Add(HomeTeamList[j]);
                    Open_Select_Bat_2_Inn_2.Items.Add(HomeTeamList[j]);
                }
            }
        }

        /*
         *  When the user selects which side is batting in the Batting Side Combo Box,
         *  the application will only show the batting side in the batsman select boxes
         *  and only the bowling side in the bowler select boxes.
         */
        private void Open_Select_Bat_Side_SelectedIndexChanged(object sender, EventArgs e)
        {
            Home_Team = MatchDetailsList[1];
            Away_Team = MatchDetailsList[2];

            if (Open_Select_Bat_Side.SelectedItem.ToString() == Home_Team)
            {
                Populate_Scorecard_Player_Combo_Boxes(Home_Team, Away_Team);
                Populate_Bat_Bowl_Select_Combo_Boxes(Home_Team, Away_Team);
                Innings_Of = Home_Team;
            }
            else
            {
                Populate_Scorecard_Player_Combo_Boxes(Away_Team, Home_Team);
                Populate_Bat_Bowl_Select_Combo_Boxes(Away_Team, Home_Team);
                Innings_Of = Away_Team;
            }

            First_Inn_Innings_Of.Text = Innings_Of;
        }

        //
        private void Create_Batsman(int BatNumber ,string BatsmanName, bool Facing)
        {
            Player Batsman = new Player()
            {
                Bat_Number = BatNumber,
                Bat_Name = BatsmanName,
                Bat_How_Out = "Not",
                Bat_Out_Bwlr = "Out",
                Bat_Fours = 0,
                Bat_Sixes = 0,
                Bat_Balls = 0,
                Bat_Runs = 0,
                Bat_Minutes = 0,
                Bat_Facing = Facing,
            };
            batList.Add(Batsman);
        }

        //
        private void Create_Bowler(int BowlNumber, string BowlerName, bool Bowling)
        {
            Player Bowler = new Player()
            {
                Bowl_Number = BowlNumber,
                Bowl_Name = BowlerName,
                Bowl_Wides = 0,
                Bowl_No_Balls = 0,
                Bowl_Overs = 0.0,
                Bowl_Maidens = 0,
                Bowl_Runs = 0,
                Bowl_Wickets = 0,
                Bowl_Average = 0.0,
                Bowl_Economy = 0.0,
                Bowl_Bowling = Bowling,
            };
            bowlList.Add(Bowler);
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
        }

        private void Set_Default_Variables()
        {
            HideAllPanels();

            First_Innings_Tab.Text = Open_Select_Bat_Side.SelectedItem.ToString();
            if (First_Innings_Tab.Text == Home_Team)
            {
                Second_Inn_Tab.Text = Away_Team;
            }
            else
            {
                Second_Inn_Tab.Text = Home_Team;
            }

            // Set bowler totals to 0
            Maiden = true;
            Bowl_Total_Maidens = 0;
            Bowl_Total_Runs = 0;
            Bowl_Total_Wickets = 0;

            // Set fall of wicket variables to 0
            Partnership = 0;

            // Set over analysis variables to 0
            Over_Analysis_Runs = 0;
            Over_Analysis_Overs = 0;

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
            Date = MatchDetailsList[0];
            Ground_Name = MatchDetailsList[3];
            Match_Type = MatchDetailsList[4];
            Weather = MatchDetailsList[5];
            Toss_Winner = Toss_Winner_Combo_Box.SelectedItem.ToString();

            // Sets Extra table details
            Wides_Total_Value.Text = Extras_Wides.ToString();
            No_Balls_Total_Value.Text = Extras_No_Balls.ToString();
            Byes_Total_Value.Text = Extras_Byes.ToString();
            Leg_Byes_Total_Value.Text = Extras_Leg_Byes.ToString();
            Penaltys_Total_Value.Text = Extras_Penaltys.ToString();
            Total_Extras_Value.Text = Extras_Total.ToString();

            // Sets match details
            Scoring_Date_Value.Text = Date;
            Scoring_Home_Team_Name_Value.Text = Home_Team;
            Scoring_Away_Team_Name_Value.Text = Away_Team;
            Scoring_Innings_Of_Value.Text = Innings_Of;
            Scoring_Total_Value.Text = Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = Innings_Overs.ToString();

            // Initialise opening player objects
            Current_Batsman_Top_Id = 0;
            Current_Batsman_Bottom_Id = 1;
            Current_Bowler_Top_Id = 0;
            Current_Bowler_Bottom_Id = 1;
            Create_Batsman((Current_Batsman_Top_Id + 1), Open_Select_Bat_1.SelectedItem.ToString(), true);
            Create_Batsman((Current_Batsman_Bottom_Id + 1), Open_Select_Bat_2.SelectedItem.ToString(), false);
            Create_Bowler((Current_Bowler_Top_Id + 1), Open_Select_Bowl_1.SelectedItem.ToString(), true);
            Create_Bowler((Current_Bowler_Bottom_Id + 1), Open_Select_Bowl_2.SelectedItem.ToString(), false);
        }

        private void Set_Initial_Batsman(int batIdTop, int batIdBottom)
        {
            // Sets top batsman details in Scoring tab and Innings 1 tab
            Current_Batsman_Name_Top.Text = batList[batIdTop].Bat_Name;
            Current_Batsman_Number_Of_Fours_Top.Text = batList[batIdTop].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = batList[batIdTop].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Top.Text = batList[batIdTop].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Top.Text = batList[batIdTop].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Top.Text = batList[batIdTop].Bat_Minutes.ToString();
            Current_Batsman_Facing_Top.BackColor = Color.Red;

            // Sets bottom batsman details in Scoring tab and Innings 1 tab
            Current_Batsman_Name_Bottom.Text = batList[batIdBottom].Bat_Name;
            Current_Batsman_Number_Of_Fours_Bottom.Text = batList[batIdBottom].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = batList[batIdBottom].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = batList[batIdBottom].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = batList[batIdBottom].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Bottom.Text = batList[batIdBottom].Bat_Minutes.ToString();
            Current_Batsman_Facing_Bottom.BackColor = Color.Transparent;

            Update_Innings_Bat_Rows();
        }

        private void Set_Initial_Bowlers(int bowlIdTop, int bowlIdBottom)
        {
            // Sets top bowler details in Scoring tab and Innings 1 tab
            Current_Bowler_Name_Top.Text = bowlList[bowlIdTop].Bowl_Name;
            Current_Bowler_Wides_Conceded_Top.Text = bowlList[bowlIdTop].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = bowlList[bowlIdTop].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = bowlList[bowlIdTop].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = bowlList[bowlIdTop].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = bowlList[bowlIdTop].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = bowlList[bowlIdTop].Bowl_Wickets.ToString();
            Current_Bowler_Top.BackColor = Color.Red;

            // Sets bottom bowler details in Scoring tab and Innings 1 tab
            Current_Bowler_Name_Bottom.Text = bowlList[bowlIdBottom].Bowl_Name;
            Current_Bowler_Wides_Conceded_Bottom.Text = bowlList[bowlIdBottom].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = bowlList[bowlIdBottom].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = bowlList[bowlIdBottom].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = bowlList[bowlIdBottom].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = bowlList[bowlIdBottom].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = bowlList[bowlIdBottom].Bowl_Wickets.ToString();
            Current_Bowler_Bottom.BackColor = Color.Transparent;

            Update_Innings_Bowl_Rows();
        }
        /* 
         * This function handles the assignment of batsman and bowlers into
         * the batting and bowling tables in the first innings tab
         */
        private void First_Inn_Openers_Confirm_Button_Click(object sender, EventArgs e)
        {
            List<Player> batList = Innings1BatsmanList;
            List<Player> bowlList = Innings1BowlerList;

            // Sets all variables, creates opening player objects and sets all table
            // information for first innings
            Set_Default_Variables();
            Set_Initial_Batsman(0, 1);
            Set_Initial_Bowlers(0, 1);

            // Set Innings 1 tab table totals
            First_Inn_Bat_Total_Runs.Text = (Innings_Total - Extras_Total).ToString(); ;

            // Switch to the scoring tab
            Scoring_App_Tab_Set.SelectedTab = Scoring_Tab;
        }

        private void Second_Inn_Openers_Confirm_Button_Click(object sender, EventArgs e)
        {

            List<Player> batList = Innings2BatsmanList;
            List<Player> bowlList = Innings2BowlerList;

            // Sets all variables, creates opening player objects and sets all table
            // information for second innings

            Set_Default_Variables();
            Set_Initial_Bowlers(0, 1);
            Set_Initial_Bowlers(0, 1);

            // Set Innings 2 tab table totals
            Second_Inn_Bat_Total_Runs.Text = (Innings_Total - Extras_Total).ToString(); ;

            // Switch to the scoring tab
            Scoring_App_Tab_Set.SelectedTab = Scoring_Tab; 
        }

        /* Triggered when the first innings is completed, either by:
         *      1. declaration
         *      2. no more wickets left
         *      3. no more overs left
         *      4. bad weather
         */
        private void End_Of_Innings(string reason)
        {
            if (Innings_Number == 1)
            {
                Innings_Number = 2;

                Open_Select_Bat_1_Inn_2.Items.Clear();
                Open_Select_Bat_2_Inn_2.Items.Clear();
                Open_Select_Bowl_1_Inn_2.Items.Clear();
                Open_Select_Bowl_2_Inn_2.Items.Clear();

                if (Open_Select_Bat_Side.SelectedItem.ToString() == Home_Team)
                {
                    Populate_Scorecard_Player_Combo_Boxes(Away_Team, Home_Team);
                    Innings_Of = Away_Team;
                }
                else
                {
                    Populate_Scorecard_Player_Combo_Boxes(Home_Team, Away_Team);
                    Innings_Of = Home_Team;
                }

                Second_Inn_Innings_Of.Text = Innings_Of;
                Scoring_App_Tab_Set.SelectedTab = Second_Inn_Select_Tab;
            }   
        }

        private void Create_Temp_Batsmen(int batTop, int batBottom) 
        {
            // Stores top batsman details
            Temp_Current_Batsman_Number_Top = batList[batTop].Bat_Number;
            Temp_Current_Batsman_Name_Top = batList[batTop].Bat_Name;
            Temp_Current_Batsman_Number_Of_Fours_Top = batList[batTop].Bat_Fours;
            Temp_Current_Batsman_Number_Of_Sixes_Top = batList[batTop].Bat_Sixes;
            Temp_Current_Batsman_Balls_Faced_Top = batList[batTop].Bat_Balls;
            Temp_Current_Batsman_Runs_Scored_Top = batList[batTop].Bat_Runs;
            Temp_Current_Batsman_Minutes_Batted_Top = batList[batTop].Bat_Minutes;
            Temp_Current_Batsman_Facing_Top = batList[batTop].Bat_Facing;

            // Stores bottom batsman details
            Temp_Current_Batsman_Number_Bottom = batList[batBottom].Bat_Number;
            Temp_Current_Batsman_Name_Bottom = batList[batBottom].Bat_Name;
            Temp_Current_Batsman_Number_Of_Fours_Bottom = batList[batBottom].Bat_Fours;
            Temp_Current_Batsman_Number_Of_Sixes_Bottom = batList[batBottom].Bat_Sixes;
            Temp_Current_Batsman_Balls_Faced_Bottom = batList[batBottom].Bat_Balls;
            Temp_Current_Batsman_Runs_Scored_Bottom = batList[batBottom].Bat_Runs;
            Temp_Current_Batsman_Minutes_Batted_Bottom = batList[batBottom].Bat_Minutes;
            Temp_Current_Batsman_Facing_Bottom = batList[batBottom].Bat_Facing;
        }

        private void Create_Temp_Bowlers(int bowlTop, int bowlBottom)
        {
            // Stores top bowler details 
            Temp_Current_Bowler_Number_Top = bowlList[bowlTop].Bowl_Number;
            Temp_Current_Bowler_Name_Top = bowlList[bowlTop].Bowl_Name;
            Temp_Current_Bowler_Wides_Conceded_Top = bowlList[bowlTop].Bowl_Wides;
            Temp_Current_Bowler_No_Balls_Conceded_Top = bowlList[bowlTop].Bowl_No_Balls;
            Temp_Current_Bowler_Overs_Bowled_Top = bowlList[bowlTop].Bowl_Overs;
            Temp_Current_Bowler_Maidens_Bowled_Top = bowlList[bowlTop].Bowl_Maidens;
            Temp_Current_Bowler_Runs_Conceded_Top = bowlList[bowlTop].Bowl_Runs;
            Temp_Current_Bowler_Wickets_Taken_Top = bowlList[bowlTop].Bowl_Wickets;
            Temp_Current_Bowler_Top = bowlList[bowlTop].Bowl_Bowling;

            // Stores bottom bowler details
            Temp_Current_Bowler_Number_Bottom = bowlList[bowlBottom].Bowl_Number;
            Temp_Current_Bowler_Name_Bottom = bowlList[bowlBottom].Bowl_Name;
            Temp_Current_Bowler_Wides_Conceded_Bottom = bowlList[bowlBottom].Bowl_Wides;
            Temp_Current_Bowler_No_Balls_Conceded_Bottom = bowlList[bowlBottom].Bowl_No_Balls;
            Temp_Current_Bowler_Overs_Bowled_Bottom = bowlList[bowlBottom].Bowl_Overs;
            Temp_Current_Bowler_Maidens_Bowled_Bottom = bowlList[bowlBottom].Bowl_Maidens;
            Temp_Current_Bowler_Runs_Conceded_Bottom = bowlList[bowlBottom].Bowl_Runs;
            Temp_Current_Bowler_Wickets_Taken_Bottom = bowlList[bowlBottom].Bowl_Wickets;
            Temp_Current_Bowler_Bottom = bowlList[bowlBottom].Bowl_Bowling;
        }

        private void Create_Temp_Last_Man_Out()
        {
            // Stores Last Man Out table
            Temp_Out_Batsman_Number_Value = batList[Temp_Bat_Out].Bat_Number;
            Temp_Out_Batsman_Name = batList[Temp_Bat_Out].Bat_Name;
            Temp_Out_Batsman_How_Out_Value = batList[Temp_Bat_Out].Bat_How_Out;
            Temp_Out_Batsman_Bowler_Value = batList[Temp_Bat_Out].Bat_Out_Bwlr;
            Temp_Out_Batsman_Total_Runs_Scored_Value = batList[Temp_Bat_Out].Bat_Runs;
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

            if (Innings_Number == 1)
            {
                Create_Temp_Batsmen(Temp_Current_Batsman_Top_Id, Temp_Current_Batsman_Bottom_Id);
                Create_Temp_Bowlers(Temp_Current_Bowler_Top_Id, Temp_Current_Bowler_Bottom_Id);
                Create_Temp_Last_Man_Out();
            }
            else
            {
                Create_Temp_Batsmen(Temp_Current_Batsman_Top_Id, Temp_Current_Batsman_Bottom_Id);
                Create_Temp_Bowlers(Temp_Current_Bowler_Top_Id, Temp_Current_Bowler_Bottom_Id);
                Create_Temp_Last_Man_Out();
            }
            // Stores Extra table details
            Temp_Wides_Total_Value = Extras_Wides;
            Temp_No_Balls_Total_Value = Extras_No_Balls;
            Temp_Byes_Total_Value = Extras_Byes;
            Temp_Leg_Byes_Total_Value = Extras_Leg_Byes;
            Temp_Penaltys_Total_Value = Extras_Penaltys;
            Temp_Total_Extras_Value = Extras_Total;

            // Stores match details
            Temp_Scoring_Total_Value = Innings_Total;
            Temp_Scoring_Wickets_Down_Value = Innings_Wickets;
            Temp_Scoring_Total_Overs_Value = Innings_Overs;
        }

        private void Restore_Batsmen(int batIdTop, int batIdBottom)
        {
            // Update batsman objects
            batList[batIdTop].Bat_Fours = Temp_Current_Batsman_Number_Of_Fours_Top;
            batList[batIdTop].Bat_Sixes = Temp_Current_Batsman_Number_Of_Sixes_Top;
            batList[batIdTop].Bat_Balls = Temp_Current_Batsman_Balls_Faced_Top;
            batList[batIdTop].Bat_Runs = Temp_Current_Batsman_Runs_Scored_Top;
            batList[batIdTop].Bat_Minutes = Temp_Current_Batsman_Minutes_Batted_Top;
            batList[batIdTop].Bat_Facing = Temp_Current_Batsman_Facing_Top;

            batList[batIdBottom].Bat_Fours = Temp_Current_Batsman_Number_Of_Fours_Bottom;
            batList[batIdBottom].Bat_Sixes = Temp_Current_Batsman_Number_Of_Sixes_Bottom;
            batList[batIdBottom].Bat_Balls = Temp_Current_Batsman_Balls_Faced_Bottom;
            batList[batIdBottom].Bat_Runs = Temp_Current_Batsman_Runs_Scored_Bottom;
            batList[batIdBottom].Bat_Minutes = Temp_Current_Batsman_Minutes_Batted_Bottom;
            batList[batIdBottom].Bat_Facing = Temp_Current_Batsman_Facing_Bottom;
        }
        private void Restore_Bowlers(int bowlIdTop, int bowlIdBottom)
        {
            // Restores bowler objects
            bowlList[bowlIdTop].Bowl_Wides = Temp_Current_Bowler_Wides_Conceded_Top;
            bowlList[bowlIdTop].Bowl_No_Balls = Temp_Current_Bowler_No_Balls_Conceded_Top;
            bowlList[bowlIdTop].Bowl_Overs = Temp_Current_Bowler_Overs_Bowled_Top;
            bowlList[bowlIdTop].Bowl_Maidens = Temp_Current_Bowler_Maidens_Bowled_Top;
            bowlList[bowlIdTop].Bowl_Runs = Temp_Current_Bowler_Runs_Conceded_Top;
            bowlList[bowlIdTop].Bowl_Wickets = Temp_Current_Bowler_Wickets_Taken_Top;
            bowlList[bowlIdTop].Bowl_Bowling = Temp_Current_Bowler_Top;

            bowlList[bowlIdBottom].Bowl_Wides = Temp_Current_Bowler_Wides_Conceded_Bottom;
            bowlList[bowlIdBottom].Bowl_No_Balls = Temp_Current_Bowler_No_Balls_Conceded_Bottom;
            bowlList[bowlIdBottom].Bowl_Overs = Temp_Current_Bowler_Overs_Bowled_Bottom;
            bowlList[bowlIdBottom].Bowl_Maidens = Temp_Current_Bowler_Maidens_Bowled_Bottom;
            bowlList[bowlIdBottom].Bowl_Runs = Temp_Current_Bowler_Runs_Conceded_Bottom;
            bowlList[bowlIdBottom].Bowl_Wickets = Temp_Current_Bowler_Wickets_Taken_Bottom;
            bowlList[bowlIdBottom].Bowl_Bowling = Temp_Current_Bowler_Bottom;
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

            if (Innings_Number == 1)
            {
                Restore_Batsmen(Current_Batsman_Top_Id, Current_Batsman_Bottom_Id);
                Restore_Bowlers(Current_Bowler_Top_Id, Current_Bowler_Bottom_Id);
            }
            else
            {
                Restore_Batsmen(Current_Batsman_Top_Id, Current_Batsman_Bottom_Id);
                Restore_Bowlers(Current_Bowler_Top_Id, Current_Bowler_Bottom_Id);
            }

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

            // Set the current batsman flag
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

                for (int i = 0; i < (Innings_Wickets + 2); i = i + 1)
                {
                    First_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 0, batList[i].Bat_Number);
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

                for (int i = 0; i < (Innings_Wickets + 2); i = i + 1)
                {
                    Second_Inn_Bat_Table.Controls.Add(new Label() { Text = batList[i].Bat_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 0, batList[i].Bat_Number);
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

                for (int i = 0; i < (Innings_Wickets + 2); i = i + 1)
                {
                    First_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 0, bowlList[i].Bowl_Number);
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

                for (int i = 0; i < (Innings_Wickets + 2); i = i + 1)
                {
                    Second_Inn_Bowl_Table.Controls.Add(new Label() { Text = bowlList[i].Bowl_Number.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, 0, bowlList[i].Bowl_Number);
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
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = Innings_Total.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 1);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = ((batList[Bat_Out].Bat_Number.ToString()) + "//" + (batList[Bat_Out].Bat_Runs.ToString())), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 2);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = ((batList[Bat_Not_Out].Bat_Number.ToString()) + "//" + (batList[Bat_Not_Out].Bat_Runs.ToString())), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 3);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = Partnership.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 4);
                First_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = Innings_Overs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 5);

                //Sets column size of the table
                First_Inn_Fall_Of_Wckt_Table.ColumnStyles.Clear();
                for (int i = 0; i < First_Inn_Fall_Of_Wckt_Table.ColumnCount; i = i + 1)
                {
                    if (i == 1)
                    {
                        First_Inn_Fall_Of_Wckt_Table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                    else
                    {
                        First_Inn_Fall_Of_Wckt_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    }
                }
            }
            else
            {
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = Innings_Total.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 1);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = ((batList[Bat_Out].Bat_Number.ToString()) + "//" + (batList[Bat_Out].Bat_Runs.ToString())), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 2);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = ((batList[Bat_Not_Out].Bat_Number.ToString()) + "//" + (batList[Bat_Not_Out].Bat_Runs.ToString())), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 3);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = Partnership.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 4);
                Second_Inn_Fall_Of_Wckt_Table.Controls.Add(new Label() { Text = Innings_Overs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Regular) }, Innings_Wickets, 5);

                //Sets column size of the table
                Second_Inn_Fall_Of_Wckt_Table.ColumnStyles.Clear();
                for (int i = 0; i < Second_Inn_Fall_Of_Wckt_Table.ColumnCount; i = i + 1)
                {
                    if (i == 1)
                    {
                        Second_Inn_Fall_Of_Wckt_Table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                    else
                    {
                        Second_Inn_Fall_Of_Wckt_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    }
                }
            }
            Partnership = 0;
        }

        //
        private void Update_Innings_Over_Analysis(int current_bowler)
        {
            if (Innings_Number == 1)
            {
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = Over_Analysis_Overs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, Over_Analysis_Overs, 0);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = current_bowler.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, Over_Analysis_Overs, 1);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = Over_Analysis_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, Over_Analysis_Overs, 2);
                First_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = Innings_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, Over_Analysis_Overs, 3);
            }
            else
            {
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = Over_Analysis_Overs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, Over_Analysis_Overs, 0);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = current_bowler.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, Over_Analysis_Overs, 1);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = Over_Analysis_Runs.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, Over_Analysis_Overs, 2);
                Second_Inn_Over_Analysis_Table.Controls.Add(new Label() { Text = Innings_Wickets.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 9, FontStyle.Regular) }, Over_Analysis_Overs, 3);
            }
            Over_Analysis_Runs = 0;
        }

        /*
         */
        private void Save_Over()
        {
            // Initialise all writers
            StreamWriter endOfOverWriter = new StreamWriter("C:\\Users\\Philip\\Desktop\\Inn" + Innings_Number + "." + Innings_Overs + ".txt");
            StreamWriter batDetailsWriter = new StreamWriter("C:\\Users\\Philip\\Desktop\\Inn" + Innings_Number + ".BatDetails.txt");
            StreamWriter bowlDetailWriter = new StreamWriter("C:\\Users\\Philip\\Desktop\\Inn" + Innings_Number + ".BowlDetails.txt");
            
            // Save all match totals and id's to end of over file
            endOfOverWriter.WriteLine(Innings_Of);
            endOfOverWriter.WriteLine(Current_Batsman_Top_Id);
            endOfOverWriter.WriteLine(Current_Batsman_Bottom_Id);
            endOfOverWriter.WriteLine(Current_Bowler_Top_Id);
            endOfOverWriter.WriteLine(Current_Bowler_Bottom_Id);
            endOfOverWriter.WriteLine(Extras_Byes);
            endOfOverWriter.WriteLine(Extras_Leg_Byes);
            endOfOverWriter.WriteLine(Extras_No_Balls);
            endOfOverWriter.WriteLine(Extras_Wides);
            endOfOverWriter.WriteLine(Extras_Penaltys);
            endOfOverWriter.WriteLine(Extras_Total);
            endOfOverWriter.WriteLine(Bat_Out);
            endOfOverWriter.WriteLine(Innings_Total);
            endOfOverWriter.WriteLine(Innings_Overs);
            endOfOverWriter.WriteLine(Innings_Wickets);

            // Saves batsman details to bat details file
            for (int i = 0; i < batList.Count; i = i + 1)
            {
                batDetailsWriter.WriteLine(batList[i].Bat_Number);
                batDetailsWriter.WriteLine(batList[i].Bat_Name);
                batDetailsWriter.WriteLine(batList[i].Bat_How_Out);
                batDetailsWriter.WriteLine(batList[i].Bat_Out_Bwlr);
                batDetailsWriter.WriteLine(batList[i].Bat_Fours);
                batDetailsWriter.WriteLine(batList[i].Bat_Sixes);
                batDetailsWriter.WriteLine(batList[i].Bat_Balls);
                batDetailsWriter.WriteLine(batList[i].Bat_Runs);
                batDetailsWriter.WriteLine(batList[i].Bat_Minutes);
                batDetailsWriter.WriteLine(batList[i].Bat_Facing);
            }

            // Saves bowler details to bowl details file
            for (int j = 0; j < batList.Count; j = j + 1)
            {
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Number);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Name);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Wides);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_No_Balls);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Overs);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Maidens);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Runs);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Wickets);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Average);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Economy);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Bowling);
            } 

            if(Innings_Number == 1)
            {
                // Save any notes made in the Notes textbox to end of over file
                endOfOverWriter.WriteLine(First_Inn_Notes_Textbox.Text);
            }
            else
            {
                // Save any notes made in the Notes textbox to end of over file
                endOfOverWriter.WriteLine(Second_Inn_Notes_Textbox.Text);
            }
            // Close open writers
            endOfOverWriter.Close();
            batDetailsWriter.Close();
            bowlDetailWriter.Close();
          
        }
        private void Update_Batsman_Score(int batIdTop, int batIdBottom)
        {
            Current_Batsman_Number_Of_Fours_Top.Text = batList[batIdTop].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = batList[batIdTop].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Top.Text = batList[batIdTop].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Top.Text = batList[batIdTop].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Top.Text = batList[batIdTop].Bat_Minutes.ToString();

            Current_Batsman_Number_Of_Fours_Bottom.Text = batList[batIdBottom].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = batList[batIdBottom].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = batList[batIdBottom].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = batList[batIdBottom].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Bottom.Text = batList[batIdBottom].Bat_Minutes.ToString();
        }

        private void Update_Bowler_Score(int bowlIdTop, int bowlIdBottom)
        {
            Current_Bowler_Wides_Conceded_Top.Text = bowlList[bowlIdTop].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = bowlList[bowlIdTop].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = bowlList[bowlIdTop].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = bowlList[bowlIdTop].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = bowlList[bowlIdTop].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = bowlList[bowlIdTop].Bowl_Wickets.ToString();

            Current_Bowler_Wides_Conceded_Bottom.Text = bowlList[bowlIdBottom].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = bowlList[bowlIdBottom].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = bowlList[bowlIdBottom].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = bowlList[bowlIdBottom].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = bowlList[bowlIdBottom].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = bowlList[bowlIdBottom].Bowl_Wickets.ToString();
        }

        private void Update_Last_Man_Out()
        {
            // Updates Last Man Out table, if no wickets taken then table is blank
            if (Innings_Wickets == 0)
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
            Update_Batsman_Score(Current_Batsman_Top_Id,Current_Batsman_Bottom_Id);
            Update_Bowler_Score(Current_Bowler_Top_Id, Current_Bowler_Bottom_Id);
            Update_Last_Man_Out();

            // Updates Extra table details
            Wides_Total_Value.Text = Extras_Wides.ToString();
            No_Balls_Total_Value.Text = Extras_No_Balls.ToString();
            Byes_Total_Value.Text = Extras_Byes.ToString();
            Leg_Byes_Total_Value.Text = Extras_Leg_Byes.ToString();
            Penaltys_Total_Value.Text = Extras_Penaltys.ToString();
            Total_Extras_Value.Text = Extras_Total.ToString();

            // Updates match details
            Scoring_Total_Value.Text = Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = Innings_Overs.ToString();

            if (Innings_Number == 1)
            {
                // Updates the batting table
                Update_Innings_Bat_Rows();

                // Updates the bowling table
                Update_Innings_Bowl_Rows();

                // Updates Extras table
                First_Inn_Wides_Value.Text = Extras_Wides.ToString();
                First_Inn_No_Balls_Value.Text = Extras_No_Balls.ToString();
                First_Inn_Byes_Value.Text = Extras_Byes.ToString();
                First_Inn_Leg_Byes_Value.Text = Extras_Leg_Byes.ToString();
                First_Inn_Penaltys_Value.Text = Extras_Penaltys.ToString();
                First_Inn_Extras_Total_Value.Text = Extras_Total.ToString();

                // Updates table totals
                First_Inn_Bat_Total_Runs.Text = (Innings_Total - Extras_Total).ToString();
                First_Inn_Bwl_Ttls_Wds.Text = Extras_Wides.ToString();
                First_Inn_Bwl_Ttls_Nbs.Text = Extras_No_Balls.ToString();
                First_Inn_Bwl_Ttls_Ovrs.Text = Innings_Overs.ToString();
                First_Inn_Bwl_Ttls_Mdns.Text = Bowl_Total_Maidens.ToString();
                First_Inn_Bwl_Ttls_Runs.Text = Bowl_Total_Runs.ToString();
                First_Inn_Bwl_Ttls_Wkts.Text = Bowl_Total_Wickets.ToString();

                // Updates match totals
                First_Inn_Total_Runs.Text = Innings_Total.ToString();
                First_Inn_Total_Wickets.Text = Innings_Wickets.ToString();
                First_Inn_Total_Overs.Text = Innings_Overs.ToString();
            }
            else
            {
                // Updates the batting table
                Update_Innings_Bat_Rows();

                // Updates the bowling table
                Update_Innings_Bowl_Rows();

                // Updates Extras table
                Second_Inn_Wides_Value.Text = Extras_Wides.ToString();
                Second_Inn_No_Balls_Value.Text = Extras_No_Balls.ToString();
                Second_Inn_Byes_Value.Text = Extras_Byes.ToString();
                Second_Inn_Leg_Byes_Value.Text = Extras_Leg_Byes.ToString();
                Second_Inn_Penaltys_Value.Text = Extras_Penaltys.ToString();
                Second_Inn_Extras_Total_Value.Text = Extras_Total.ToString();

                // Updates table totals
                Second_Inn_Bat_Total_Runs.Text = (Innings_Total - Extras_Total).ToString();
                Second_Inn_Bwl_Ttls_Wds.Text = Extras_Wides.ToString();
                Second_Inn_Bwl_Ttls_Nbs.Text = Extras_No_Balls.ToString();
                Second_Inn_Bwl_Ttls_Ovrs.Text = Innings_Overs.ToString();
                Second_Inn_Bwl_Ttls_Mdns.Text = Bowl_Total_Maidens.ToString();
                Second_Inn_Bwl_Ttls_Runs.Text = Bowl_Total_Runs.ToString();
                Second_Inn_Bwl_Ttls_Wkts.Text = Bowl_Total_Wickets.ToString();

                // Updates match totals
                Second_Inn_Total_Runs.Text = Innings_Total.ToString();
                Second_Inn_Total_Wickets.Text = Innings_Wickets.ToString();
                Second_Inn_Total_Overs.Text = Innings_Overs.ToString();
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
                Current_Batsman_Facing_Top.BackColor = Color.Transparent;

                // Set non facing batsman to true and change indicator colour
                batList[Current_Batsman_Bottom_Id].Bat_Facing = true;
                Current_Batsman_Facing_Bottom.BackColor = Color.Red;
            }
            else
            {
                // Set current facing batsman to false and change indicator colour
                batList[Current_Batsman_Bottom_Id].Bat_Facing = false;
                Current_Batsman_Facing_Bottom.BackColor = Color.Transparent;

                // Set non facing batsman to true and change indicator colour
                batList[Current_Batsman_Top_Id].Bat_Facing = true;
                Current_Batsman_Facing_Top.BackColor = Color.Red;
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
                Current_Bowler_Top.BackColor = Color.Transparent;

                // Set other bowler to bowling and change indicator colour
                bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling = true;
                Current_Bowler_Bottom.BackColor = Color.Red;
            }
            else
            {
                // Set current bowler to not bowling and change indicator colour
                bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling = false;
                Current_Bowler_Bottom.BackColor = Color.Transparent;

                // Set other bowler to bowling and change indicator colour
                bowlList[Current_Bowler_Top_Id].Bowl_Bowling = true;
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

            if ((Updated_Over_Amount - Math.Truncate(Updated_Over_Amount) == 0) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                bowlList[Current_Bowler_Top_Id].Bowl_Overs = Math.Ceiling(bowlList[Current_Bowler_Top_Id].Bowl_Overs);
                Innings_Overs = Math.Ceiling(Innings_Overs);

                // Check if completed over was a maiden, if not set maiden flag back to true for next over
                if (Maiden)
                {
                    Bowl_Total_Maidens = Bowl_Total_Maidens + 1;
                    bowlList[Current_Bowler_Top_Id].Bowl_Maidens = bowlList[Current_Bowler_Top_Id].Bowl_Maidens + 1;
                }
                else
                {
                    Maiden = true;
                }
                // Convert over number from double to int to allow new line to be added to Over Analysis table
                Over_Analysis_Overs = Convert.ToInt32(Innings_Overs);
                Update_Innings_Over_Analysis(Current_Bowler_Top_Id);
                
                // Save the over to a new text file
                Save_Over();
                Swap_Batsman();
                Swap_Bowler();
            }
            else if ((Updated_Over_Amount - Math.Truncate(Updated_Over_Amount) == 0) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                bowlList[Current_Bowler_Bottom_Id].Bowl_Overs = Math.Ceiling(bowlList[Current_Bowler_Bottom_Id].Bowl_Overs);
                Innings_Overs = Math.Ceiling(Innings_Overs);
                // Check if completed over was a maiden, if not set maiden flag back to true for next over
                if (Maiden)
                {
                    Bowl_Total_Maidens = Bowl_Total_Maidens + 1;
                    bowlList[Current_Bowler_Bottom_Id].Bowl_Maidens = bowlList[Current_Bowler_Bottom_Id].Bowl_Maidens + 1;
                }
                else
                {
                    Maiden = true;
                }
                // Convert over number from double to int to allow new line to be added to Over Analysis table
                Over_Analysis_Overs = Convert.ToInt32(Innings_Overs);
                Update_Innings_Over_Analysis(Current_Bowler_Bottom_Id);

                // Save the over to a new text file
                Save_Over();
                // Swap batsmen and bowlers for start of new over
                Swap_Batsman();
                Swap_Bowler();
            }
        }

        /*
         *  This function adds an extra ball to the batsman's number of balls faced
         */
        private void Batting_Add_Ball(int bat_id)
        {
            batList[bat_id].Bat_Balls = batList[bat_id].Bat_Balls + 1;
        }

        /*
         *  This function adds an extra ball to the bowlers's overs bowled
         */
        private void Bowling_Add_Ball(int bowl_Id)
        {
            bowlList[bowl_Id].Bowl_Overs = bowlList[bowl_Id].Bowl_Overs + 0.1;
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
            batList.Add(newBatsman);
            Current_Batsman_Bottom_Id = bottomBatId;

            Current_Batsman_Number_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Number.ToString();
            Current_Batsman_Name_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Name;
            Current_Batsman_Number_Of_Fours_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Bottom.Text = batList[Current_Batsman_Bottom_Id].Bat_Minutes.ToString();
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
            Current_Batsman_Number_Top.Text = batList[Current_Batsman_Bottom_Id].Bat_Number.ToString();
            Current_Batsman_Name_Top.Text = batList[Current_Batsman_Bottom_Id].Bat_Name.ToString();
            Current_Batsman_Number_Of_Fours_Top.Text = batList[Current_Batsman_Bottom_Id].Bat_Fours.ToString();
            Current_Batsman_Number_Of_Sixes_Top.Text = batList[Current_Batsman_Bottom_Id].Bat_Sixes.ToString();
            Current_Batsman_Balls_Faced_Top.Text = batList[Current_Batsman_Bottom_Id].Bat_Balls.ToString();
            Current_Batsman_Runs_Scored_Top.Text = batList[Current_Batsman_Bottom_Id].Bat_Runs.ToString();
            Current_Batsman_Minutes_Batted_Top.Text = batList[Current_Batsman_Bottom_Id].Bat_Minutes.ToString();

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
            bowlList.Add(newBowler);
            Current_Bowler_Bottom_Id = newBowlerId;

            Current_Bowler_Number_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Number.ToString();
            Current_Bowler_Name_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Name;
            Current_Bowler_Wides_Conceded_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Bottom.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Wickets.ToString();
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
            bowlList[Current_Bowler_Top_Id].Bowl_Bowling = false;

            // Move bottom bowler details to the top row.
            Current_Bowler_Top_Id = Current_Bowler_Bottom_Id;
            Current_Bowler_Name_Top.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Name;
            Current_Bowler_Wides_Conceded_Top.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Wides.ToString();
            Current_Bowler_No_Balls_Conceded_Top.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_No_Balls.ToString();
            Current_Bowler_Overs_Bowled_Top.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Overs.ToString();
            Current_Bowler_Maidens_Bowled_Top.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Maidens.ToString();
            Current_Bowler_Runs_Conceded_Top.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Runs.ToString();
            Current_Bowler_Wickets_Taken_Top.Text = bowlList[Current_Bowler_Bottom_Id].Bowl_Wickets.ToString();
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
            Maiden = false;
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
                    batList[batId].Bat_Fours = batList[batId].Bat_Fours + 1;
                    break;
                case 6:
                    runsScored = 6;
                    batList[batId].Bat_Sixes = batList[batId].Bat_Sixes + 1;
                    break;
            };
            
            Batting_Add_Ball(batId);
            batList[batId].Bat_Runs = batList[batId].Bat_Runs + runsScored;
            bowlList[bowlId].Bowl_Runs = bowlList[bowlId].Bowl_Runs + runsScored;
            Innings_Total = Innings_Total + runsScored;
            Bowl_Total_Runs = Bowl_Total_Runs + runsScored;
            Partnership = Partnership + runsScored;
            Over_Analysis_Runs = Over_Analysis_Runs + runsScored;
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
                    Maiden = false;
                    bowlList[bowlId].Bowl_Runs = bowlList[bowlId].Bowl_Runs + runs;
                    bowlList[bowlId].Bowl_Wides = bowlList[bowlId].Bowl_Wides + runs;
                    Extras_Wides = Extras_Wides + runs;
                    Bowl_Total_Runs = Bowl_Total_Runs + runs;
                    if (runs % 2 == 0)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "noBall":
                    Maiden = false;
                    if (batUsed == true)
                    {
                        batList[batId].Bat_Runs = batList[batId].Bat_Runs + (runs - 1);
                        bowlList[bowlId].Bowl_No_Balls = bowlList[bowlId].Bowl_No_Balls + 1;
                        Extras_No_Balls = Extras_No_Balls + 1;
                    }
                    else
                    {
                    Extras_No_Balls = Extras_No_Balls + runs;
                    bowlList[bowlId].Bowl_No_Balls = bowlList[bowlId].Bowl_No_Balls + runs;
                    }
                    bowlList[bowlId].Bowl_Runs = bowlList[bowlId].Bowl_Runs + runs;

                    Bowl_Total_Runs = Bowl_Total_Runs + runs;
                    if (runs % 2 == 0)
                    {
                        Swap_Batsman();
                    }
                    break;
                case "penalty":
                    Maiden = false;
                    bowlList[bowlId].Bowl_Runs = bowlList[bowlId].Bowl_Runs + runs;
                    Extras_Penaltys = Extras_Penaltys + runs;
                    Bowl_Total_Runs = Bowl_Total_Runs + runs;
                    break;
            };
            Extras_Total = Extras_Byes + Extras_Leg_Byes + Extras_No_Balls + Extras_Penaltys + Extras_Wides;
            Innings_Total = Innings_Total + runs;
            Partnership = Partnership + runs;
            Over_Analysis_Runs = Over_Analysis_Runs + runs;
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
            bowlList[bowlId].Bowl_Wickets = bowlList[bowlId].Bowl_Wickets + 1;
            }
            Innings_Wickets = Innings_Wickets + 1;

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
                Current_Batsman_Facing_Top.BackColor = Color.Transparent;
                Current_Batsman_Facing_Bottom.BackColor = Color.Red;
            }
            switch (wicketType)
            {
                case "caught":
                    batList[outBatId].Bat_How_Out = "Ct " + fielderName;
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    Bowl_Total_Wickets = Bowl_Total_Wickets + 1;

                    break;
                case "runOut":
                    batList[outBatId].Bat_How_Out = "Run Out";
                    batList[outBatId].Bat_Out_Bwlr = fielderName;
                    break;
                case "bowled":
                    batList[outBatId].Bat_How_Out = "Bowled";
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    Bowl_Total_Wickets = Bowl_Total_Wickets + 1;
                    break;
                case "stumped":
                    batList[outBatId].Bat_How_Out = "Stumped";
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    Bowl_Total_Wickets = Bowl_Total_Wickets + 1;
                    break;
                case "lbw":
                    batList[outBatId].Bat_How_Out = "LBW";
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    Bowl_Total_Wickets = Bowl_Total_Wickets + 1;
                    break;
                case "caughtAndBowled":
                    batList[outBatId].Bat_How_Out = "Ct && Bwld";
                    batList[outBatId].Bat_Out_Bwlr = bowlerName;
                    Bowl_Total_Wickets = Bowl_Total_Wickets + 1;
                    break;
                case "retired":
                    batList[outBatId].Bat_How_Out = "Retired";
                    batList[outBatId].Bat_Out_Bwlr = "Out";
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
            if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((batList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
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
            if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("bye", false, runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("bye", false, runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else if ((batList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
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
            if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("legBye", false, runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("legBye", false, runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else if ((batList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
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
            if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("wide", false, runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
            }
            else if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("wide", false, runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
            }
            else if ((batList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
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
            if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("noBall", batUsed, runs, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
            }
            else if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("noBall", batUsed, runs, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
            }
            else if ((batList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
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
                if ((Radio_Run_Out_Bat_Top.Checked) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                }
                else if ((Radio_Run_Out_Bat_Top.Checked) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                }
                else if ((Radio_Run_Out_Bat_Bottom.Checked) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
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
                if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                }
                else if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Top_Id, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                }
                else if ((batList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Bottom_Id, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                }
                else
                {
                    WicketTaken(howOut, fielder_Name, crossed, Current_Batsman_Bottom_Id, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                }
            }
            Check_End_Of_Over(Innings_Overs);
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
            Create_Undo_Point();
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            // Adds extra run to batsman facing's total balls faced
            if (batList[Current_Batsman_Top_Id].Bat_Facing == true)
            {
                Batting_Add_Ball(Current_Batsman_Top_Id);
            }
            else
            {
                Batting_Add_Ball(Current_Batsman_Bottom_Id);
            }

            if (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true)
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
            Create_Undo_Point();
            Innings_Overs = Innings_Overs + 0.1;
            if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("penalty", false, 5, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
            }
            else if ((batList[Current_Batsman_Top_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("penalty", false, 5, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
            }
            else if ((batList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (bowlList[Current_Bowler_Top_Id].Bowl_Bowling == true))
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

            if (bowlList[Current_Bowler_Top_Id].Bowl_Bowling)
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