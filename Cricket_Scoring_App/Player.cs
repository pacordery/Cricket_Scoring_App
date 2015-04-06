using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cricket_Scoring_App
{
    public class Player
    {
        // Initialises the windows directory for read/write access.
        string winDir = System.Environment.GetEnvironmentVariable("windir");

        // Initialising all batting variables
        public int Bat_Number { get; set; }
        public string Bat_Name { get; set; }
        public string Bat_How_Out { get; set; }
        public string Bat_Out_Bwlr { get; set; }
        public int Bat_Fours { get; set; }
        public int Bat_Sixes { get; set; }
        public int Bat_Balls { get; set; }
        public int Bat_Runs { get; set; }
        public int Bat_Minutes { get; set; }
        public bool Bat_Facing { get; set; }

        // Initialising all bowling variables.
        public int Bowl_Number { get; set; }
        public string Bowl_Name { get; set; }
        public int Bowl_Wides { get; set; }
        public int Bowl_No_Balls { get; set; }
        public double Bowl_Overs { get; set; }
        public int Bowl_Maidens { get; set; }
        public int Bowl_Runs { get; set; }
        public int Bowl_Wickets { get; set; }
        public double Bowl_Average { get; set; }
        public double Bowl_Economy { get; set; }
        public bool Bowl_Bowling { get; set; }

        // Creates a new batsman object, all values are defaulted to 0 or 'not out'.
        public void Create_Batsman(int BatNumber, string BatsmanName, bool Facing)
        {
            Bat_Number = BatNumber;
            Bat_Name = BatsmanName;
            Bat_How_Out = "Not";
            Bat_Out_Bwlr = "Out";
            Bat_Fours = 0;
            Bat_Sixes = 0;
            Bat_Balls = 0;
            Bat_Runs = 0;
            Bat_Minutes = 0;
            Bat_Facing = Facing;
        }

        // Creates a new bowler object, all values are defaulted to 0.
        public void Create_Bowler(int BowlNumber, string BowlerName, bool Bowling)
        {
            Bowl_Number = BowlNumber;
            Bowl_Name = BowlerName;
            Bowl_Wides = 0;
            Bowl_No_Balls = 0;
            Bowl_Overs = 0.0;
            Bowl_Maidens = 0;
            Bowl_Runs = 0;
            Bowl_Wickets = 0;
            Bowl_Average = 0.0;
            Bowl_Economy = 0.0;
            Bowl_Bowling = Bowling;
        }

        // Gets the name of the player in the form Initial.Surname e.g. Joe Bloggs = J.Bloggs
        // If player does not have a surname e.g. Pele (if he ever decided to play cricket) then 
        // this method returns only the singlular name.
        public string Get_Player_Short_Name(string player_Name)
        {
            int spaceIndex = player_Name.IndexOf(" ");
            string playerName;
            if (player_Name.IndexOf(' ') > -1)
            {
                string initial = player_Name.Substring(0, 1);
                string surname = player_Name.Substring(spaceIndex, ((player_Name.Length - 1)-spaceIndex));
                playerName = initial + "." + surname;
            }
            else
            {
                playerName = player_Name;
            }
            return playerName;
        }

        // Checks if the bowler name provided is currently in the bowling list, if so it returns the bowlers Id.
        public int Get_Bowler_Id(List<Player> bowlList, string bowlerName)
        {
            /* Initialise the bowler Id as -1 to allow new bowler to be created in the main method */  
            int bowlId = -1;
            for (int i = 0; i < bowlList.Count; i = i + 1)
            {
                if (bowlList[i].Bowl_Name == bowlerName)
                {
                    // bowler Id is set if name provided = a bowler in the list.
                    bowlId = i;
                }
            }
            return bowlId;
        }
        // Adds a ball to the batsman facing the last deleivery.
        public void Batting_Add_Ball(List<Player> batList, int batid)
        {
            batList[batid].Bat_Balls = batList[batid].Bat_Balls + 1;
        }

        // Add a ball to the bowler whom bowled the last delivery.
        public void Bowling_Add_Ball(List<Player> bowlList, int bowlId)
        {
            bowlList[bowlId].Bowl_Overs = bowlList[bowlId].Bowl_Overs + 0.1;
        }

        // Check which batsman is curently facing the bowler and return their id.
        public int Check_Batsman_Facing(List<Player> batList, int batTopId, int batBottomId)
        {
            int batsmanId;

            if (batList[batTopId].Bat_Facing == true)
            {
                batsmanId = batTopId;
            }
            else
            {
                batsmanId = batBottomId;
            }
            return batsmanId;
        }

        // Check which bowler is curently bowling and return their id.
        public int Check_Bowler_Bowling(List<Player> bowlList, int bowlTopId, int bowlBottomId)
        {
            int bowlerId;

            if (bowlList[bowlTopId].Bowl_Bowling == true)
            {
                bowlerId = bowlTopId;
            }
            else
            {
                bowlerId = bowlBottomId;
            }
            return bowlerId;
        }

        // Save all batsmen whom have batted or are currently batting to a file, one file per team.
        public void Save_Batsmen(List<Player> batList, string inningsOf, string folderName)
        {
            StreamWriter batDetailsWriter = new StreamWriter(folderName + "\\" + inningsOf + "\\BatDetails.txt");
            
            for (int i = 0; i < batList.Count; i = i + 1)
            {
                batDetailsWriter.WriteLine(batList[i].Bat_Number);
                batDetailsWriter.WriteLine(batList[i].Bat_Name);
                batDetailsWriter.WriteLine(batList[i].Bat_How_Out);
                batDetailsWriter.WriteLine(batList[i].Bat_Out_Bwlr);
                batDetailsWriter.WriteLine(batList[i].Bat_Fours);
                batDetailsWriter.WriteLine(batList[i].Bat_Sixes);
                batDetailsWriter.WriteLine(batList[i].Bat_Balls);
                batDetailsWriter.WriteLine(batList[i].Bat_Runs);
                batDetailsWriter.WriteLine(batList[i].Bat_Minutes);
                batDetailsWriter.WriteLine(batList[i].Bat_Facing);
            }
            batDetailsWriter.Close();
        }

        // Save all bowlers whom have bowled or are currently bowling to a file, one file per team.
        public void Save_Bowlers(List<Player> bowlList, string inningsOf, string folderName)
        {
            StreamWriter bowlDetailWriter = new StreamWriter(folderName + "\\" + inningsOf + "\\BowlDetails.txt");
            for (int j = 0; j < bowlList.Count; j = j + 1)
            {
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Number);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Name);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Wides);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_No_Balls);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Overs);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Maidens);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Runs);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Wickets);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Average);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Economy);
                bowlDetailWriter.WriteLine(bowlList[j].Bowl_Bowling);
            }
            bowlDetailWriter.Close();
        }

        // Load all batsman objects into the batting list, enables a match to be recoverd.
        public List<Player> Load_Batsman()
        {
            List<Player> batsman = new List<Player>();
            return batsman;
        }

        // Load all bowler objects into the bowling list, enables a match to be recoverd.
        public List<Player> Load_Bowlers()
        {
            List<Player> bowler = new List<Player>();
            return bowler;
        }
    }
}