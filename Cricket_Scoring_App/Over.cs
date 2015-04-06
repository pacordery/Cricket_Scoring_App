using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cricket_Scoring_App
{
    public class Over
    {
        // Initialises the windows directory for read/write access
        string winDir = System.Environment.GetEnvironmentVariable("windir");

        public int over_Number { get; set; }
        public int over_Bowler_Number { get; set; }
        public int over_Runs { get; set; }
        public int over_Wickets { get; set; }

        // Creates an over object when called
        public void Create_Over(int overNumber, int overBowlerNumber, int overRuns, int overWickets)
        {
            over_Number = overNumber;
            over_Bowler_Number = overBowlerNumber;
            over_Runs = overRuns;
            over_Wickets = overWickets;
        }

        // Saves all objects into separate text files to create a backup for the system
        public void Save_Over(List<FallOfWicket> fallOfWicketList, List<Player> batList, List<Player> bowlList,
                              List<Innings> inningsList, List<Over> overAnalysisList, int inningsId, string folderName)
        {
            // Save player objects to file
            Player player = new Player();
            player.Save_Batsmen(batList, inningsList[inningsId].Team_Name, folderName);
            player.Save_Bowlers(bowlList, inningsList[inningsId].Team_Name, folderName);

            // Save fall of wicket objects to file
            FallOfWicket fallOfWicket = new FallOfWicket();
            fallOfWicket.Save_Fall_Of_Wicket_List(fallOfWicketList, inningsList[inningsId].Team_Name, folderName);

            // Save over analysis objects to file
            Save_Over_Analysis(overAnalysisList, inningsList[inningsId].Team_Name, folderName);

            // Save innings objects to file
            Innings innings = new Innings();
            innings.Save_Innings(folderName, inningsId, inningsList, fallOfWicketList);
        }

        // Saves all over analysis objects into a file, one file per team
        private void Save_Over_Analysis(List<Over> overAnalysisList, string teamName, string folderName)
        {
            StreamWriter overAnalysisWriter = new StreamWriter(folderName + "\\" + teamName + "\\FallOfWicket.txt");

            for (int i = 0; i < overAnalysisList.Count; i = i + 1)
            {
                overAnalysisWriter.WriteLine(overAnalysisList[i].over_Number);
                overAnalysisWriter.WriteLine(overAnalysisList[i].over_Bowler_Number);
                overAnalysisWriter.WriteLine(overAnalysisList[i].over_Runs);
                overAnalysisWriter.WriteLine(overAnalysisList[i].over_Wickets);
            }
            overAnalysisWriter.Close();

        }

        // Checks if the last delivery completed the over, if so the total overs are updated to the next highest round number */
        public bool Check_End_Of_Over(List<Player> batList, List<Player> bowlList, List<Innings> inningsList, List<Over> overAnalysisList, List<FallOfWicket> fallOfWicketList, int inningsId, string folderName)
        {
            bool endOfOver = false;
            Player player = new Player();
            int bowlId = player.Check_Bowler_Bowling(bowlList, inningsList[inningsId].topBowlId, inningsList[inningsId].bottomBowlId);
            double oversTotal = Math.Round(inningsList[inningsId].Innings_Overs, 1);
            double Updated_Over_Amount = oversTotal;
            double test_total = Math.Round((oversTotal - Math.Truncate(oversTotal)), 1);
            if (test_total == .6)
            {
                Updated_Over_Amount = Math.Ceiling(Updated_Over_Amount);
            }

            if (Updated_Over_Amount - Math.Truncate(Updated_Over_Amount) == 0)
            {
                bowlList[bowlId].Bowl_Overs = Math.Ceiling(bowlList[bowlId].Bowl_Overs);
                inningsList[inningsId].Innings_Overs = Math.Ceiling(inningsList[inningsId].Innings_Overs);

                // Check if completed over was a maiden, if not set maiden flag back to true for next over
                if (inningsList[inningsId].maiden)
                {
                    // Add 1 to the innings and bowler's maidens
                    inningsList[inningsId].Bowl_Total_Maidens = inningsList[inningsId].Bowl_Total_Maidens + 1;
                    bowlList[bowlId].Bowl_Maidens = bowlList[bowlId].Bowl_Maidens + 1;
                }
                else
                {
                    inningsList[inningsId].maiden = true;
                }
                // Convert over number from double to int to allow new line to be added to Over Analysis table
                inningsList[inningsId].Over_Analysis_Overs = Convert.ToInt32(inningsList[inningsId].Innings_Overs);

                Over over = new Over();
                over.Create_Over(inningsList[inningsId].Over_Analysis_Overs, (bowlId) + 1, inningsList[inningsId].Over_Analysis_Runs, inningsList[inningsId].Over_Analysis_Wickets);
                overAnalysisList.Add(over);

                // Save the over to a new text file
                over.Save_Over(fallOfWicketList, batList, bowlList, inningsList, overAnalysisList, inningsId, folderName);
                endOfOver = true;
            }
            return endOfOver;
        }
    }
}
