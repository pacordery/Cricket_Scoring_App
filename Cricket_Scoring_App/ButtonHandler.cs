using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Scoring_App
{
    public class ButtonHandler
    {
        // When a button is clicked in the scoring tab, this method is called to handle the updating of the correct lists and tables.
        public void GeneralButtonClickHandler(List<Player> batList, List<Player> bowlList, List<Innings> inningsList, List<Over> overAnalysisList, List<FallOfWicket> fallOfWicketList, int inningsId, string folderName, string type, bool batUsed, int runs)
        {
            Player player = new Player();
            int batId = player.Check_Batsman_Facing(batList, inningsList[inningsId].topBatId, inningsList[inningsId].bottomBatId);
            int bowlId = player.Check_Bowler_Bowling(bowlList, inningsList[inningsId].topBowlId, inningsList[inningsId].bottomBowlId);
            Runs_Scored(batList, bowlList, inningsList, overAnalysisList, fallOfWicketList, inningsId, folderName, type, batUsed, runs, batId, bowlId);
        }

        // All runs are added to the relevant objects in the lists based upon innings id and bat/bowl id's
        public void Runs_Scored(List<Player> batList, List<Player> bowlList, List<Innings> inningsList, List<Over> overAnalysisList, List<FallOfWicket> fallOfWicketList, int inningsId, string folderName, string type, bool batUsed, int runs, int batId, int bowlId)
        {
            // Initialise new player object to be used in the method.
            Player player = new Player();
            // Add ball to innings, bowler and batsman if ball is legal.
            if (type == "runs" || type == "bye" || type == "legBye" || type == "penalty")
            {
                // Add one ball to total over amount.
                inningsList[inningsId].Innings_Overs = inningsList[inningsId].Innings_Overs + 0.1;
                player.Bowling_Add_Ball(bowlList, bowlId);
                player.Batting_Add_Ball(batList, batId);
            }
            // Add runs to bowler and mark maiden as false, unless runs = 0.
            if ((type == "runs" && runs != 0) || type == "wide" || type == "noBall" || type == "penalty")
            {
                inningsList[inningsId].maiden = false;
                bowlList[bowlId].Bowl_Runs = bowlList[bowlId].Bowl_Runs + runs;
                inningsList[inningsId].Bowl_Total_Runs = inningsList[inningsId].Bowl_Total_Runs + runs;
            }
            switch (type)
            {
                case "runs":
                    batList[batId].Bat_Runs = batList[batId].Bat_Runs + runs;
                    if (runs == 4 && type == "runs")
                    {
                        batList[batId].Bat_Fours = batList[batId].Bat_Fours + 1;
                    }
                    else if (runs == 6 && type == "runs")
                    {
                        batList[batId].Bat_Sixes = batList[batId].Bat_Sixes + 1;
                    }
                    break;
                case "bye":
                    inningsList[inningsId].Extras_Byes = inningsList[inningsId].Extras_Byes + runs;
                    break;
                case "legBye":
                    inningsList[inningsId].Extras_Leg_Byes = inningsList[inningsId].Extras_Leg_Byes + runs;
                    break;
                case "wide":
                    bowlList[bowlId].Bowl_Wides = bowlList[bowlId].Bowl_Wides + runs;
                    inningsList[inningsId].Extras_Wides = inningsList[inningsId].Extras_Wides + runs;
                    break;
                case "noBall":
                    if (batUsed == true)
                    {
                        // Add runs - 1 no ball to batsman's total, 1 to the no ball totals
                        batList[batId].Bat_Runs = batList[batId].Bat_Runs + (runs - 1);
                        bowlList[bowlId].Bowl_No_Balls = bowlList[bowlId].Bowl_No_Balls + 1;
                        inningsList[inningsId].Extras_No_Balls = inningsList[inningsId].Extras_No_Balls + 1;
                        if (runs == 5)
                        {
                            batList[batId].Bat_Fours = batList[batId].Bat_Fours + 1;
                        }
                        else if (runs == 7)
                        {
                            batList[batId].Bat_Sixes = batList[batId].Bat_Sixes + 1;
                        }
                    }
                    else
                    {
                        inningsList[inningsId].Extras_No_Balls = inningsList[inningsId].Extras_No_Balls + runs;
                        bowlList[bowlId].Bowl_No_Balls = bowlList[bowlId].Bowl_No_Balls + runs;
                    }
                    break;
                case "penalty":
                    inningsList[inningsId].Extras_Penaltys = inningsList[inningsId].Extras_Penaltys + runs;
                    break;
            };
            // Totals the new extra's variables
            inningsList[inningsId].Extras_Total = inningsList[inningsId].Extras_Byes + inningsList[inningsId].Extras_Leg_Byes + inningsList[inningsId].Extras_No_Balls + inningsList[inningsId].Extras_Penaltys + inningsList[inningsId].Extras_Wides;
            inningsList[inningsId].Innings_Total = inningsList[inningsId].Innings_Total + runs;
            inningsList[inningsId].Partnership = inningsList[inningsId].Partnership + runs;
            inningsList[inningsId].Over_Analysis_Runs = inningsList[inningsId].Over_Analysis_Runs + runs;

            if (inningsId == 1)
            {
                inningsList[inningsId].runsRemaining = inningsList[inningsId].runsRemaining - runs;
            }
        }

        // When 20 Over button clicked, this sets the required variables for the last 20 overs of the match.
        public void Twenty_Over_Start(List<Innings> inningsList)
        {
            inningsList[1].ballsRemaining = 120;
            inningsList[1].Max_Overs = inningsList[1].Innings_Overs + 20.0;
            inningsList[1].startOfTwentyOvers = Convert.ToInt32(inningsList[1].Innings_Overs);
        }
    }
}