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

        /* TODO
         1. Add code functions for all buttons
         2. When new bowler is added, add new row to the bowlers table on the
            scorecard tab
         3. Push data for team batting, weather, home and away teams, and venue
            into the relevent labels on scoring and scorecard tabs
         */
        List<Player> Innings1BatsmanList = new List<Player>();
        List<Player> Innings1BowlerList = new List<Player>();
        List<Player> Innings2BatsmanList = new List<Player>();
        List<Player> Innings2BowlerList = new List<Player>();

        /* Initialising all match detail variables */
        DateTime Date;
        string Home_Team;
        string Away_Team;
        string Innings_Of;
        string Ground_Name;
        string Weather;
        int    Innings_Total;
        int    Innings_Wickets;
        double  Innings_Overs;

        /* Initialising all batting variables */
        bool Bat_Facing;
        bool Bat_Out;
        int Bat_Total_Runs;
        int Current_Batsman_Top_Id;
        int Current_Batsman_Bottom_Id;

        /* Initialising all bowling variables */
        bool Bowl_Bowling;
        int Bowl_Total_Wides;
        int Bowl_Total_No_Balls;
        double Bowl_Total_Overs;
        int Bowl_Total_Maidens;
        int Bowl_Total_Runs;
        int Bowl_Total_Wickets;
        int Current_Bowler_Top_Id;
        int Current_Bowler_Bottom_Id;
        
        /* Initialising all extras variables */
        int Extras_Wides;
        int Extras_No_Balls;
        int Extras_Byes;
        int Extras_Leg_Byes;
        int Extras_Penaltys;
        int Extras_Total;

        /* Initialising all over analysis variables */
        int Over_Anlysis_Over;
        int Over_Anlysis_Bowler;
        int Over_Anlysis_Runs;
        int Over_Anlysis_Wickets;

        private void Open_Select_Bat_Side_SelectedIndexChanged(object sender, EventArgs e)
        {
            Innings_Of = Open_Select_Bat_Side.SelectedItem.ToString();
            First_Inn_Innings_Of.Text = Open_Select_Bat_Side.SelectedItem.ToString();
            // Add function to only show batting side names in the batsmen drop downs
            // Add function to only show bowling side names in bowler drop downs
        }

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

            if (Innings1BatsmanList.Count < 1)
            {
                // Add two batsman 2 objects into the list to ensure that list order is preserved
                // if batsman 2 is selected before batsman 1.
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
            if (Innings1BatsmanList.Count < 1)
            {
                // Add two batsman 2 objects into the list to ensure that list order is preserved
                // if batsman 2 is selected before batsman 1.
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

        /* When opening batsmen/bowlers confirmed by buton click
         * the scoring tab is selected ready to start scoring the match */
        private void Confirm_Openers_Button_Click(object sender, EventArgs e)
        {
            /* TODO
             * Put date into date fields
             * Get Home/Away team names
             * Get Weather
             * Get Venue
             * 
             * Add functions to insert batsman and bowlers details into the tables
             */
            // Add a function that adds all batsmen and bowlers at start
            // It should then also have a function to update the table as wickets fall

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
            Scoring_Weather_Value.Text = Weather;
            Scoring_Venue_Value.Text = Ground_Name;
            Scoring_Innings_Of_Value.Text = Innings_Of;
            Scoring_Total_Value.Text = Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = Innings_Overs.ToString();        

            // Switch to the scoring tab
            Scoring_App_Tab_Set.SelectedTab = Scoring_Tab;

        }

        /* Initialises and shows the new bowler form which allows the scorer
         * to select the next bowler from the list of players in the fielding side
         */
        private void New_Bowler_Button_Click(object sender, EventArgs e)
        {
            New_Bowler NewBowler = new New_Bowler();
            NewBowler.Show();
        }

        private void Update_Score()
        {
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

            // Updates match details
            Scoring_Total_Value.Text = Innings_Total.ToString();
            Scoring_Wickets_Down_Value.Text = Innings_Wickets.ToString();
            Scoring_Total_Overs_Value.Text = Innings_Overs.ToString();
        }

        /* This function swaps the batsman at the following points in the scoring process:
            Batsman swapped at:
                1. End of over where last ball = Dot,2,4,6 or 8
                2. Run scored = 1,3,5,7,9
                3. Bye/leg bye with odd amount  
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

        // When an over is completed this function swaps to the other bowler
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

        // Checks if the last deliveery was the last in the over
        // if so it updates the total overs number to a round number.
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

        // Adds extra run to batsman facing's total balls faced
        private void Batting_Add_Ball(int bat_id)
        {
            Innings1BatsmanList[bat_id].Bat_Balls = Innings1BatsmanList[bat_id].Bat_Balls + 1;
        }

        // Adds extra ball to bowlers current over total
        private void Bowling_Add_Ball(int bowl_Id)
        {
            Innings1BowlerList[bowl_Id].Bowl_Overs = Innings1BowlerList[bowl_Id].Bowl_Overs + 0.1;
        }

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

        private void Extra_Run_Scored(string extraId, int batId, int bowlId)
        {
            int runsScored = 0;
            switch (extraId)
            {
                case "bye":
                    runsScored = 1;
                    Extras_Byes = Extras_Byes + runsScored;
                    Swap_Batsman();
                    break;
                case "legBye":
                    runsScored = 1;
                    Extras_Leg_Byes = Extras_Leg_Byes + runsScored;
                    Swap_Batsman();
                    break;
                case "wide":
                    runsScored = 1;
                    Innings1BowlerList[bowlId].Bowl_Runs = Innings1BowlerList[bowlId].Bowl_Runs + runsScored;
                    Extras_Wides = Extras_Wides + runsScored;
                    break;
                case "noBall":
                    runsScored = 1;
                    Innings1BowlerList[bowlId].Bowl_Runs = Innings1BowlerList[bowlId].Bowl_Runs + runsScored;
                    Extras_No_Balls = Extras_No_Balls + runsScored;
                    break;
                case "penalty":
                    runsScored = 5;
                    Innings1BowlerList[bowlId].Bowl_Runs = Innings1BowlerList[bowlId].Bowl_Runs + runsScored;
                    Extras_Penaltys = Extras_Penaltys + runsScored;
                    break;
            };            
            Innings_Total = Innings_Total + runsScored;
        }

        /* This function adds:
         *  1 ball to the batsmans total balls faced
         *  0.1 overs to the bowlers total overs bowled
         *  0.1 overs to the total overs bowled
         */  
        private void Dot_Button_Click(object sender, EventArgs e)
        {
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
        }

        /* Adds one run to the batsman, bowler and total runs
         * Adds one ball to the batsman, bowler and total overs
        */
        private void One_Button_Click(object sender, EventArgs e)
        {
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(1, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(1, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(1, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Run_ScoredOffBat(1, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
        }

        /* Adds two runs to the batsman, bowler and total runs
         * Adds one ball to the batsman, bowler and total overs
        */
        private void Two_Button_Click(object sender, EventArgs e)
        {
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(2, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(2, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(2, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Run_ScoredOffBat(2, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
        }

        /* Adds three runs to the batsman, bowler and total runs
         * Adds one ball to the batsman, bowler and total overs
        */
        private void Three_Button_Click(object sender, EventArgs e)
        {
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(3, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(3, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(3, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Run_ScoredOffBat(3, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
        }

        /* Adds four runs to the batsman, bowler and total runs
         * Adds one ball to the batsman, bowler and total overs
         * Adds one to the total number of fours scored by the batsman
        */
        private void Four_Button_Click(object sender, EventArgs e)
        {
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(4, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(4, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(4, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Run_ScoredOffBat(4, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
        }

        /* Adds six runs to the batsman, bowler and total runs
         * Adds one ball to the batsman, bowler and total overs
         * Adds one to the total number of sixes scored by the batsman
        */
        private void Six_Button_Click(object sender, EventArgs e)
        {
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(6, Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(6, Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Run_ScoredOffBat(6, Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Run_ScoredOffBat(6, Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }

            Check_End_Of_Over(Innings_Overs);
            Update_Score();
        }

        /* Adds one run to the total runs
         * Adds one ball to the batsman, bowler and total overs
         * Adds one to the total number of byes in the extras table
        */
        private void Bye_Button_Click(object sender, EventArgs e)
        {
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
               Extra_Run_Scored("bye", Current_Batsman_Top_Id, Current_Bowler_Top_Id);
               Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("bye", Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("bye", Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Extra_Run_Scored("bye", Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
        }

        /* Adds one run to the total runs
         * Adds one ball to the batsman, bowler and total overs
         * Adds one to the total number of leg byes in the extras table
        */
        private void Leg_Bye_Button_Click(object sender, EventArgs e)
        {
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
            if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("legBye", Current_Batsman_Top_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Top_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Bottom_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("legBye", Current_Batsman_Top_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            else if ((Innings1BatsmanList[Current_Batsman_Bottom_Id].Bat_Facing == true) && (Innings1BowlerList[Current_Bowler_Top_Id].Bowl_Bowling == true))
            {
                Extra_Run_Scored("legBye", Current_Batsman_Bottom_Id, Current_Bowler_Top_Id);
                Bowling_Add_Ball(Current_Bowler_Top_Id);
            }
            else
            {
                Extra_Run_Scored("legBye", Current_Batsman_Bottom_Id, Current_Bowler_Bottom_Id);
                Bowling_Add_Ball(Current_Bowler_Bottom_Id);
            }
            Check_End_Of_Over(Innings_Overs);
            Update_Score();
        }

        /* Adds one run to the total runs
         * Adds one to the total number of bowler wides
         * Adds one to the total number of wides in the extras table
        */
        private void Wide_Button_Click(object sender, EventArgs e)
        {

        }

        /* Adds one run to the total runs
         * Adds one to the total number of bowler no balls
         * Adds one to the total number of no balls in the extras table
        */
        private void No_Ball_Button_Click(object sender, EventArgs e)
        {

        }

        /* Adds one wicket to the bowler and total wickets
         * Adds one ball to the batsman, bowler and total overs
         * Inserts new row into last man out table
         * Inserts new batsman after user selection
        */
        private void Wicket_Button_Click(object sender, EventArgs e)
        {
            // Add one ball to total over amount
            Innings_Overs = Innings_Overs + 0.1;
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {

        }


    }
}
