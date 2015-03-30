using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Scoring_App
{
    class ScorecardHandler
    {
        public List<string> TempMatchDetailsList = new List<string>();
        public List<Player> TempBatList = new List<Player>();
        public List<Player> TempBowList = new List<Player>();
        public List<FallOfWicket> TempFallOfWicketList = new List<FallOfWicket>();
        public List<Innings> TempInningsList = new List<Innings>();
        public List<Over> TempOverAnalysisList = new List<Over>();
        

        public int Temp_Current_Batsman_Top_Id { get; set; }
        public int Temp_Current_Batsman_Bottom_Id { get; set; }
        public int Temp_Current_Bowler_Top_Id { get; set; }
        public int Temp_Current_Bowler_Bottom_Id { get; set; }
        public int Temp_Bat_Out { get; set; }

        // Stores Extra table details
        public int Temp_Wides_Total_Value { get; set; }
        public int Temp_No_Balls_Total_Value { get; set; }
        public int Temp_Byes_Total_Value { get; set; }
        public int Temp_Leg_Byes_Total_Value { get; set; }
        public int Temp_Penaltys_Total_Value { get; set; }
        public int Temp_Total_Extras_Value { get; set; }

        // Stores Last Man Out table
        public int Temp_Out_Batsman_Number_Value { get; set; }
        public string Temp_Out_Batsman_Name { get; set; }
        public string Temp_Out_Batsman_How_Out_Value { get; set; }
        public string Temp_Out_Batsman_Bowler_Value { get; set; }
        public int Temp_Out_Batsman_Total_Runs_Scored_Value { get; set; }

        // Stores match details
        public int Temp_Scoring_Total_Value { get; set; }
        public int Temp_Scoring_Wickets_Down_Value { get; set; }
        public double Temp_Scoring_Total_Overs_Value { get; set; }

        //
        public void Create_Temp_Bat_Bowl(List<FallOfWicket> fallOfWicketList, List<Player> batList, List<Player> bowlList, List<Innings> inningsList, List<Over> overAnalysisList, List<string> matchDetailsList, int batOut, int batTopId, int batIdBottom, int bowlIdTop, int bowlIdBottom)
        {
            // Stores batsman, bowler and last batsman out details
            Temp_Current_Batsman_Top_Id = batTopId;
            Temp_Current_Batsman_Bottom_Id = batIdBottom;
            Temp_Current_Bowler_Top_Id = bowlIdTop;
            Temp_Current_Bowler_Bottom_Id = bowlIdBottom;
            Temp_Bat_Out = batOut;
            TempBatList = batList;
            TempBowList = bowlList;
            TempFallOfWicketList = fallOfWicketList;
            TempInningsList = inningsList;
            TempOverAnalysisList = overAnalysisList;
            TempMatchDetailsList = matchDetailsList;

            Temp_Out_Batsman_Number_Value = batList[batOut].Bat_Number;
            Temp_Out_Batsman_Name = batList[batOut].Bat_Name;
            Temp_Out_Batsman_How_Out_Value = batList[batOut].Bat_How_Out;
            Temp_Out_Batsman_Bowler_Value = batList[batOut].Bat_Out_Bwlr;
            Temp_Out_Batsman_Total_Runs_Scored_Value = batList[batOut].Bat_Runs;
        }

        //
        public void Create_Temp_Extras(int extrasWides, int extrasNoBalls, int extrasByes, int extrasLegByes, int extrasPenaltys, int extrasTotal)
        {
            // Stores Extra table details
            Temp_Wides_Total_Value = extrasWides;
            Temp_No_Balls_Total_Value = extrasNoBalls;
            Temp_Byes_Total_Value = extrasByes;
            Temp_Leg_Byes_Total_Value = extrasLegByes;
            Temp_Penaltys_Total_Value = extrasPenaltys;
            Temp_Total_Extras_Value = extrasTotal;
        }

        //
        public void Create_Temp_Match_Totals(int inningsTotal, int inningsWickets, double inningsOvers )
        {
            // Stores match details
            Temp_Scoring_Total_Value = inningsTotal;
            Temp_Scoring_Wickets_Down_Value = inningsWickets;
            Temp_Scoring_Total_Overs_Value = inningsOvers;
        }
    }
}