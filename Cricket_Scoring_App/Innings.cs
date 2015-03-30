using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Scoring_App
{
    class Innings
    {
        //Bowling variables
        public bool maiden { get; set; }
        public int Bowl_Total_Maidens { get; set; }
        public int Bowl_Total_Runs { get; set; }
        public int Bowl_Total_Wickets { get; set; }

        // Fall of wicket variables
        public int Partnership { get; set; }

        // Over analysis variables
        public int Over_Analysis_Runs { get; set; }
        public int Over_Analysis_Overs { get; set; }
        public int Over_Analysis_Wickets { get; set; }

        // Extras variables
        public int Extras_Wides { get; set; }
        public int Extras_No_Balls { get; set; }
        public int Extras_Byes { get; set; }
        public int Extras_Leg_Byes { get; set; }
        public int Extras_Penaltys { get; set; }
        public int Extras_Total { get; set; }

        // Match details variables
        public int Innings_Total { get; set; }
        public double Innings_Overs { get; set; }
        public int Innings_Wickets { get; set; }
        public string Date { get; set; }
        public string Ground_Name { get; set; }
        public string Match_Type { get; set; }
        public string Weather { get; set; }
        public string Toss_Winner { get; set; }
        public double Max_Overs { get; set; }

        public void Create_Innings(List<string> MatchDetailsList, string tossWinner)
        {
            // Set bowler totals
            maiden = true;
            Bowl_Total_Maidens = 0;
            Bowl_Total_Runs = 0;
            Bowl_Total_Wickets = 0;

            // Set fall of wicket variables
            Partnership = 0;

            // Set over analysis variables
            Over_Analysis_Runs = 0;
            Over_Analysis_Overs = 0;
            Over_Analysis_Wickets = 0;

            // Set Extras table values
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
            Toss_Winner = tossWinner;

            if (Match_Type == "T20")
            {
                Max_Overs = 20;
            }
            else if (Match_Type == "40 Over")
            {
                Max_Overs = 40;
            }
            else if (Match_Type == "Friendly")
            {
                Max_Overs = 100;
            }
        }

        public bool Check_End_Of_Innings(int inningsNumber, int targetTotal, int inningsTotal, string reason, double inningsOver, double maxOvers, int inningsWickets)
        {
            bool endOfInnings = false;
            if ((inningsNumber == 2) && (targetTotal <= inningsTotal))
            {
                reason = "Target Reached";
                endOfInnings = true;
            }
            else if (inningsOver == maxOvers)
            {
                reason = "No More Overs";
                endOfInnings = true;
            }
            else if (inningsWickets == 10)
            {
                reason = "All Out";
                endOfInnings = true;
            }
            return endOfInnings;
        }
    }
}
