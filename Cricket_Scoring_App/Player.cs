using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Scoring_App
{
    public class Player
    {
        /* Initialising all batting variables */
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
        //int Bat_Total_Runs;

        /* Initialising all bowling variables */
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
    }
}
