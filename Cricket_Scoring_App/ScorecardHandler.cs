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
           Temp_MatchDetailsList = Get_String_List(matchDetailsList);
           Temp_HomeTeamList  = Get_String_List(homeTeamList);
           Temp_AwayTeamList = Get_String_List(awayTeamList);
           Temp_NextBatsmanList = Get_String_List(nextBatsmanList);
           Temp_NewBowlerList = Get_String_List(newBowlerList);
           Temp_InningsList = Get_Innings_List(inningsList);
           Temp_BatList = Get_Player_List(batList);
           Temp_BowlList = Get_Player_List(bowlList);
           Temp_FallOfWicketList = Get_Fall_Of_Wicket_List(fallOfWicketList);
           Temp_GraphSeriesList = Get_String_List(graphSeriesList);
           Temp_OverAnalysisList = Get_Over_Analysis_List(overAnalysisList);
           Temp_Innings1BatsmanList = Get_Player_List(innings1BatsmanList);
           Temp_Innings1BowlerList = Get_Player_List(innings1BowlerList);
           Temp_Innings1OverList  = Get_Over_Analysis_List(innings1OverList);
           Temp_Innings1FallOfWicketList = Get_Fall_Of_Wicket_List(innings1FallOfWicketList);
           Temp_InningsId = inningsId;
           Temp_HomeTeamName = homeTeamName;
           Temp_AwayTeamName = awayTeamName;
           Temp_LastBatOut = lastBatOut;
        }

        // Takes the elements of the input list and adds them to the return list
        public List<string> Get_String_List(List<string> stringListName)
        {
            List<string> stringList = new List<string>();
            for (int i = 0; i < stringListName.Count; i = i + 1)
            {
                stringList.Add(stringListName[i]);
            }
            return stringList;
        }

        // Takes the elements of the input list and adds them to the return list
        public List<Player> Get_Player_List(List<Player> playerListName)
        {
            List<Player> playerList = new List<Player>();
            for (int i = 0; i < playerListName.Count; i = i + 1)
            {
                playerList.Add(playerListName[i]);
            }
            return playerList;
        }

        // Takes the elements of the input list and adds them to the return list
        public List<Over> Get_Over_Analysis_List(List<Over> overAnalysisListName)
        {
            List<Over> overAnalysisList = new List<Over>();
            for (int i = 0; i < overAnalysisListName.Count; i = i + 1)
            {
                overAnalysisList.Add(overAnalysisListName[i]);
            }
            return overAnalysisList;
        }

        // Takes the elements of the input list and adds them to the return list
        public List<Innings> Get_Innings_List(List<Innings> inningsListName)
        {
            List<Innings> inningsList = new List<Innings>();
            for (int i = 0; i < inningsListName.Count; i = i + 1)
            {
                inningsList.Add(inningsListName[i]);
            }
            return inningsList;
        }

        // Takes the elements of the input list and adds them to the return list
        public List<FallOfWicket> Get_Fall_Of_Wicket_List(List<FallOfWicket> FOWListName)
        {
            List<FallOfWicket> fallOfWicketList = new List<FallOfWicket>();
            for (int i = 0; i < FOWListName.Count; i = i + 1)
            {
                fallOfWicketList.Add(FOWListName[i]);
            }
            return fallOfWicketList;
        }
    }
}