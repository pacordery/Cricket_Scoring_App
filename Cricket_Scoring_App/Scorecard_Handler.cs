using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Scoring_App
{
    // This class is designed to handle all updates to the scorecard
    // It also initialises the values in each table when match starts
    class Scorecard_Handler
    {
        public void Scorecard_Initialise(List<Player> Batsmen,List<Player> Bowlers){

            /*Scoring_Application_Form.Scoring_App_Tab_Set.Current_Batsman_Number_Top.Text = Batsmen[0].Bat_Number.ToString();
            string Current_Batsman_Name_Top.Text = Batsmen[0].Bat_Name;
            string Current_Batsman_Number_Of_Fours_Top.Text = Batsmen[0].Bat_Fours.ToString();
            string Current_Batsman_Number_Of_Sixes_Top.Text = Batsmen[0].Bat_Sixes.ToString();
            string Current_Batsman_Balls_Faced_Top.Text = Batsmen[0].Bat_Balls.ToString();
            string Current_Batsman_Runs_Scored_Top.Text = Batsmen[0].Bat_Runs.ToString();
            string Current_Batsman_Minutes_Batted_Top.Text = Batsmen[0].Bat_Minutes.ToString();
            string Current_Batsman_Facing_Top.BackColor = Color.Red;*/
        }
    }
}
