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
        List<FallOfWicket> fallOfWicketList = new List<FallOfWicket>();
        public int wicket_Number { get; set; }
        public int total_Score { get; set; }
        public string bat_Out_Detail { get; set; }
        public string bat_Not_Out_Detail { get; set; }
        public int partnership { get; set; }
        public double over_Number { get; set; }

        public void Create_Fall_Of_Wicket(int wicketNumber, List<Player> batList, int batOutNumber, int batNotOutNumber, int _partnership, double overNumber, int totalScore)
        {
            wicket_Number = wicketNumber;
            total_Score = totalScore;
            bat_Out_Detail = (batList[batOutNumber].Bat_Number.ToString()) + "/" + (batList[batOutNumber].Bat_Runs.ToString());
            bat_Not_Out_Detail = (batList[batNotOutNumber].Bat_Number.ToString()) + "/" + (batList[batNotOutNumber].Bat_Runs.ToString());
            partnership = _partnership;
            over_Number = overNumber;
        }

        public void Save_Fall_Of_Wicket_List(List<FallOfWicket> fallOfWicketList, int InningsNumber)
        {
            StreamWriter fallOfWicketWriter = new StreamWriter("C:\\Users\\Philip\\Desktop\\Inn" + InningsNumber + ".FallOfWicket.txt");

            for (int i = 0; i < fallOfWicketList.Count; i = i + 1)
            {
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].wicket_Number);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].bat_Out_Detail);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].bat_Not_Out_Detail);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].partnership);
                fallOfWicketWriter.WriteLine(fallOfWicketList[i].over_Number);
            }
            fallOfWicketWriter.Close();
        }
    }
}
