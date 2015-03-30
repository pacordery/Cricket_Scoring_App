using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cricket_Scoring_App
{
    class Over
    {
        public int over_Number { get; set; }
        public int over_Bowler_Number { get; set; }
        public int over_Runs { get; set; }
        public int over_Wickets { get; set; }

        //
        public void Create_Over(int overNumber, int overBowlerNumber, int overRuns, int overWickets)
        {
            over_Number = overNumber;
            over_Bowler_Number = overBowlerNumber;
            over_Runs = overRuns;
            over_Wickets = overWickets;
        }

        //
        public void Save_Over(List<FallOfWicket> fallOfWicketList, List<Player> batList, List<Player> bowlList,
            int inningsNumber, string inningsOf, int inningsTotal, double inningsOvers, int inningsWickets,
            int batTopId, int batBottomId, int bowlTopId, int bowlBottomId,
            int byes, int legByes, int noBalls, int wides, int penaltys, int extrasTotal,
            int batOut,
            string notes)
        {
            // Initialise all writers
            StreamWriter endOfOverWriter = new StreamWriter("C:\\Users\\Philip\\Desktop\\Inn" + inningsNumber + "." + inningsNumber + ".txt");

            Player player = new Player();
            player.Save_Batsmen(batList, inningsNumber);
            player.Save_Bowlers(bowlList, inningsNumber);

            FallOfWicket fallOfWicket = new FallOfWicket();
            fallOfWicket.Save_Fall_Of_Wicket_List(fallOfWicketList, inningsNumber);

            // Save all match totals and id's to end of over file
            endOfOverWriter.WriteLine(inningsOf);
            endOfOverWriter.WriteLine(batTopId);
            endOfOverWriter.WriteLine(batBottomId);
            endOfOverWriter.WriteLine(bowlTopId);
            endOfOverWriter.WriteLine(bowlBottomId);
            endOfOverWriter.WriteLine(byes);
            endOfOverWriter.WriteLine(legByes);
            endOfOverWriter.WriteLine(noBalls);
            endOfOverWriter.WriteLine(wides);
            endOfOverWriter.WriteLine(penaltys);
            endOfOverWriter.WriteLine(extrasTotal);
            endOfOverWriter.WriteLine(batOut);
            endOfOverWriter.WriteLine(inningsTotal);
            endOfOverWriter.WriteLine(inningsOvers);
            endOfOverWriter.WriteLine(inningsWickets);
            endOfOverWriter.WriteLine(notes);

            // Close open writer
            endOfOverWriter.Close();
        }
    }
}
