using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Scoring_App
{
    public class ScorecardHandler
    {
        public List<string> Temp_MatchDetailsList = new List<string>();
        public List<string> Temp_HomeTeamList = new List<string>();
        public List<string> Temp_AwayTeamList = new List<string>();
        public List<string> Temp_NextBatsmanList = new List<string>();
        public List<string> Temp_NewBowlerList = new List<string>();
        public List<Innings> Temp_InningsList = new List<Innings>();
        public List<Player> Temp_BatList = new List<Player>();
        public List<Player> Temp_BowlList = new List<Player>();
        public List<FallOfWicket> Temp_FallOfWicketList = new List<FallOfWicket>();
        public List<string> Temp_GraphSeriesList = new List<string>();
        public List<Over> Temp_OverAnalysisList = new List<Over>();
        public List<Player> Temp_Innings1BatsmanList = new List<Player>();
        public List<Player> Temp_Innings1BowlerList = new List<Player>();
        public List<Over> Temp_Innings1OverList = new List<Over>();
        public List<FallOfWicket> Temp_Innings1FallOfWicketList = new List<FallOfWicket>();
        public int Temp_InningsId { get; set; }
        public string Temp_HomeTeamName { get; set; }
        public string Temp_AwayTeamName { get; set; }
        public int Temp_LastBatOut { get; set; }

        // Populates the temporary lists and variables with current live values. Called before any information is updated.
        public void Create_Temp_Variables(List<string> matchDetailsList, List<string> homeTeamList, List<string> awayTeamList, List<string> nextBatsmanList,
                                          List<string> newBowlerList, List<Innings> inningsList, List<Player> batList, List<Player> bowlList,
                                          List<FallOfWicket> fallOfWicketList, List<string> graphSeriesList, List<Over> overAnalysisList, List<Player> innings1BatsmanList,
                                          List<Player> innings1BowlerList, List<Over> innings1OverList, List<FallOfWicket> innings1FallOfWicketList, int inningsId,
                                          string homeTeamName, string awayTeamName, int lastBatOut)
        {
           Temp_MatchDetailsList = matchDetailsList;
           Temp_HomeTeamList  = homeTeamList;
           Temp_AwayTeamList = awayTeamList;
           Temp_NextBatsmanList = nextBatsmanList;
           Temp_NewBowlerList = newBowlerList;
           Temp_InningsList = inningsList;
           Temp_BatList = batList;
           Temp_BowlList = bowlList;
           Temp_FallOfWicketList = fallOfWicketList;
           Temp_GraphSeriesList = graphSeriesList;
           Temp_OverAnalysisList = overAnalysisList;
           Temp_Innings1BatsmanList = innings1BatsmanList;
           Temp_Innings1BowlerList = innings1BowlerList;
           Temp_Innings1OverList  = innings1OverList;
           Temp_Innings1FallOfWicketList = innings1FallOfWicketList;
           Temp_InningsId = inningsId;
           Temp_HomeTeamName = homeTeamName;
           Temp_AwayTeamName = awayTeamName;
           Temp_LastBatOut = lastBatOut;
        }
    }
}