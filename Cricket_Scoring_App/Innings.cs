using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cricket_Scoring_App
{
    public class Innings
    {
        // Initialises the windows directory for read/write access
        public string winDir = System.Environment.GetEnvironmentVariable("windir");

        // Batting variables
        public int topBatId { get; set; }
        public int bottomBatId { get; set; }
        public int topBowlId { get; set; }
        public int bottomBowlId { get; set; }

        //Bowling variables
        public string Team_Name { get; set; }
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
        public string Notes { get; set; }
        public string reason { get; set; }
        public int runsRemaining { get; set; }
        public int targetTotal { get; set; }
        public int ballsRemaining { get; set; }
        public int oversRemaining { get; set; }
        public int startOfTwentyOvers { get; set; }
        public bool twentyOvers { get; set; }

        // Creates a new innings object when called, all initialised numeric values are 0
        public void Create_Innings(List<string> MatchDetailsList, string tossWinner, string inningsOf)
        {
            // Set batsman id's
            topBatId = 0 ;
            bottomBatId = 1;
            topBowlId = 0;
            bottomBowlId = 1;

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
            Team_Name = inningsOf;
            runsRemaining = 0;
            targetTotal = 0;
            ballsRemaining = 0;
            twentyOvers = false;
            startOfTwentyOvers = 100;


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

        // Checks if the innings has been completed after the last button click
        public bool Check_End_Of_Innings(int inningsId, List<Innings> inningsList)
        {
            bool endOfInnings = false;
            if ((inningsId == 1) && (inningsList[inningsId].targetTotal <= inningsList[inningsId].Innings_Total))
            {
                reason = "Target Reached";
                endOfInnings = true;
            }
            else if (inningsList[inningsId].Innings_Overs == inningsList[inningsId].Max_Overs)
            {
                reason = "No More Overs";
                endOfInnings = true;
            }
            else if (inningsList[inningsId].Innings_Wickets == 10)
            {
                reason = "All Out";
                endOfInnings = true;
            }
            return endOfInnings;
        }

        // Saves each innings object to a separate file, this allows them to be recoverd if there is a system issue
        public void Save_Innings(string folderName, int inningsId, List<Innings> inningsList, List<FallOfWicket> fallOfWicketList)
        {
            // Initialise inningsWriter
            StreamWriter inningsWriter = new StreamWriter(folderName + "\\" + inningsList[inningsId].Team_Name + "\\Over " + (inningsList[inningsId].Innings_Overs.ToString()) + ".txt");

            // Writes all innings information to a file
            for (int i = 0; i < inningsList.Count; i = i + 1)
            {
                // Save all match totals and id's to end of over file
                inningsWriter.WriteLine(inningsList[i].Team_Name);
                inningsWriter.WriteLine(inningsList[i].topBatId);
                inningsWriter.WriteLine(inningsList[i].bottomBatId);
                inningsWriter.WriteLine(inningsList[i].topBowlId);
                inningsWriter.WriteLine(inningsList[i].bottomBowlId);
                inningsWriter.WriteLine(inningsList[i].Extras_Byes);
                inningsWriter.WriteLine(inningsList[i].Extras_Leg_Byes);
                inningsWriter.WriteLine(inningsList[i].Extras_No_Balls);
                inningsWriter.WriteLine(inningsList[i].Extras_Wides);
                inningsWriter.WriteLine(inningsList[i].Extras_Penaltys);
                inningsWriter.WriteLine(inningsList[i].Extras_Total);
                if (fallOfWicketList.Count != 0 && fallOfWicketList.Count<9)
                {
                    inningsWriter.WriteLine(Convert.ToInt32(fallOfWicketList.Last().bat_Out_Detail.Substring(0, 1)) - 1);
                }
                else if(fallOfWicketList.Count>9)
                {
                    inningsWriter.WriteLine(Convert.ToInt32(fallOfWicketList.Last().bat_Out_Detail.Substring(0, 2)) - 1);
                }
                inningsWriter.WriteLine(inningsList[i].Innings_Total);
                inningsWriter.WriteLine(inningsList[i].Innings_Overs);
                inningsWriter.WriteLine(inningsList[i].Innings_Wickets);
                
                inningsWriter.WriteLine(inningsList[i].Bowl_Total_Maidens);
                inningsWriter.WriteLine(inningsList[i].Bowl_Total_Runs);
                inningsWriter.WriteLine(inningsList[i].Bowl_Total_Wickets);
                inningsWriter.WriteLine(inningsList[i].maiden);
                inningsWriter.WriteLine(inningsList[i].Max_Overs);
                inningsWriter.WriteLine(inningsList[i].Partnership);
                inningsWriter.WriteLine(inningsList[i].Toss_Winner);
                inningsWriter.WriteLine(inningsList[i].reason);
                inningsWriter.WriteLine(inningsList[i].Notes);
            }
            // Close inningsWriter
            inningsWriter.Close();
        }
    }
}