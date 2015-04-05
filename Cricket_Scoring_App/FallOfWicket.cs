using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cricket_Scoring_App
{
    public class FallOfWicket
    {
        // Initialises the windows directory for read/write access
        string winDir = System.Environment.GetEnvironmentVariable("windir");

        //Initialises all fall of wicket lists and variables
        List<FallOfWicket> fallOfWicketList = new List<FallOfWicket>();
        public int wicket_Number { get; set; }
        public int total_Score { get; set; }
        public string bat_Out_Detail { get; set; }
        public string bat_Not_Out_Detail { get; set; }
        public int partnership { get; set; }
        public double over_Number { get; set; }

        // Creates a new fall of wicket object.
        public void Create_Fall_Of_Wicket(List<Innings> inningsList, List<Player> batList, int inningsId, int batOutNumber, int batNotOutNumber)
        {
            wicket_Number = inningsList[inningsId].Innings_Wickets;
            total_Score = inningsList[inningsId].Innings_Total;
            bat_Out_Detail = (batList[batOutNumber].Bat_Number.ToString()) + "/" + (batList[batOutNumber].Bat_Runs.ToString());
            bat_Not_Out_Detail = (batList[batNotOutNumber].Bat_Number.ToString()) + "/" + (batList[batNotOutNumber].Bat_Runs.ToString());
            partnership = inningsList[inningsId].Partnership;
            over_Number = inningsList[inningsId].Innings_Overs;
        }

        // Saves each innings fall of wicket information, each innings gets a separate file
        public void Save_Fall_Of_Wicket_List(List<FallOfWicket> fallOfWicketList, string inningsOf, string folderName)
        {
            StreamWriter fallOfWicketWriter = new StreamWriter(folderName + "\\" + inningsOf + "\\FallOfWicket.txt");

            for (int i = 0; i < fallOfWicketList.Count; i = i + 1)
            {
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].wicket_Number);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].total_Score);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].bat_Out_Detail);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].bat_Not_Out_Detail);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].partnership);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].over_Number);
            }
            fallOfWicketWriter.Close();
        }
    }
}
