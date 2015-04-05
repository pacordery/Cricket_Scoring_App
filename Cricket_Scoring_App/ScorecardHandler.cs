using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Scoring_App
{
    public class ScorecardHandler
    {
        // Initialise all lists and variables to store temporary information to allow undo button to work
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

        // Populates the temporary variables with current live values. Called before any information is updated
        public void Create_Temp_Variables(List<FallOfWicket> fallOfWicketList, List<Player> batList, List<Player> bowlList, List<Innings> inningsList, List<Over> overAnalysisList, List<string> matchDetailsList, int inningsId)
        {
            // Stores batsman, bowler and last batsman out details
            Temp_Current_Batsman_Top_Id = inningsList[inningsId].topBatId;
            Temp_Current_Batsman_Bottom_Id = inningsList[inningsId].bottomBatId;
            Temp_Current_Bowler_Top_Id = inningsList[inningsId].topBowlId;
            Temp_Current_Bowler_Bottom_Id = inningsList[inningsId].bottomBowlId;
            if (fallOfWicketList.Count != 0)
            {
                Temp_Bat_Out = (Convert.ToInt32(fallOfWicketList.Last().bat_Out_Detail.Substring(0, 1)) - 1);
            }
            else if (fallOfWicketList.Count > 9)
            {
                Temp_Bat_Out = (Convert.ToInt32(fallOfWicketList.Last().bat_Out_Detail.Substring(0, 2)) - 1);
            }
            TempBatList = batList;
            TempBowList = bowlList;
            TempFallOfWicketList = fallOfWicketList;
            TempInningsList = inningsList;
            TempOverAnalysisList = overAnalysisList;
            TempMatchDetailsList = matchDetailsList;

            Temp_Out_Batsman_Number_Value = batList[Temp_Bat_Out].Bat_Number;
            Temp_Out_Batsman_Name = batList[Temp_Bat_Out].Bat_Name;
            Temp_Out_Batsman_How_Out_Value = batList[Temp_Bat_Out].Bat_How_Out;
            Temp_Out_Batsman_Bowler_Value = batList[Temp_Bat_Out].Bat_Out_Bwlr;
            Temp_Out_Batsman_Total_Runs_Scored_Value = batList[Temp_Bat_Out].Bat_Runs;

            // Stores Extra table details
            Temp_Wides_Total_Value = inningsList[inningsId].Extras_Wides;
            Temp_No_Balls_Total_Value = inningsList[inningsId].Extras_No_Balls;
            Temp_Byes_Total_Value = inningsList[inningsId].Extras_Byes;
            Temp_Leg_Byes_Total_Value = inningsList[inningsId].Extras_Leg_Byes;
            Temp_Penaltys_Total_Value = inningsList[inningsId].Extras_Penaltys;
            Temp_Total_Extras_Value = inningsList[inningsId].Extras_Total;

            // Stores match details
            Temp_Scoring_Total_Value = inningsList[inningsId].Innings_Total;
            Temp_Scoring_Wickets_Down_Value = inningsList[inningsId].Innings_Wickets;
            Temp_Scoring_Total_Overs_Value = inningsList[inningsId].Innings_Overs;
        }
    }
}