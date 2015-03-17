using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cricket_Scoring_App
{
    public partial class Scoring_App_Form : Form
    {
        public Scoring_App_Form()
        {
            InitializeComponent();
        }

        private DateTime MatchDate;
        private string HomeTeamName;
        private string AwayTeamName;
        private string VenueName;
        private string MatchType;
        private string MatchWeather;
        private string TossWonBy;

        // ******* Handlers *******


        // ******* Code for Home tab *******

        /* Initialises the Main scoring application form to allow it to be 
           shown in Begin_Match_Button_Click() is called.*/
        Scoring_Application_Form ScoringApplicationForm = new Scoring_Application_Form();

        // When Start New Match Button Clicked, go to Match Details Tab.
        private void Start_Match_Button_Click(object sender, EventArgs e)
        {
            Details_Tab_Set.SelectedTab = Match_Details_Tab;
        }

        // *******  Code for Match Details tab *******

        // Gets date of the match
        private void Match_Date_Picker_ValueChanged(object sender, EventArgs e)
        {
            MatchDate = Match_Date_Picker.Value;
        }

        // Gets name of home side
        private void Home_Team_Name_TextChanged(object sender, EventArgs e)
        {
            HomeTeamName = "";
            HomeTeamName = Home_Team_Name.Text;
            Toss_Winner_Selector.Items.Add(HomeTeamName);
            Home_Team_Heading.Text = HomeTeamName;
        }

        // Gets name of away side
        private void Away_Team_Name_TextChanged(object sender, EventArgs e)
        {
            AwayTeamName = "";
            AwayTeamName = Away_Team_Name.Text;
            Toss_Winner_Selector.Items.Add(AwayTeamName);
            Away_Team_Heading.Text = AwayTeamName;
        }

        // Gets name of venue
        private void Venue_Name_TextChanged(object sender, EventArgs e)
        {
            VenueName = "";
            VenueName = Venue_Name.Text;
        }

        // Gets match type
        private void Match_Type_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchType = Match_Type_Selector.SelectedItem.ToString();
        }

        // Gets match weather
        private void Weather_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchWeather = Weather_Selector.SelectedItem.ToString();
        }

        // Gets name of team that won toss
        private void Toss_Winner_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            TossWonBy = Toss_Winner_Selector.SelectedItem.ToString();
        }
        
        // When Next button pressed on Match Details Tab, go to Team Details Tab.
        // TODO add fuctionality to send team names to the next tab.
        // Add validation for each input before moving to next tab
        private void Match_Details_Button_Click(object sender, EventArgs e)
        {
            Details_Tab_Set.SelectedTab = Team_Details_Tab;
        }

        // ******* Code for Team Details tab *******

        // Shows the add player form.
        // TODO need to give it a counter to check how many home and away players have been added
        private void Add_Player_Button_Click(object sender, EventArgs e)
        {
            // Initialises the add player form.
            Player_Addition_Form AddPlayerForm = new Player_Addition_Form();
            AddPlayerForm.Show();
        }

        // Shows the main scoring application when button is clicked.
        // TODO create a csv file with the match and team details,
        // this will be read by the scoring application to complete the relevant fields.
        private void Begin_Match_Button_Click(object sender, EventArgs e)
        {
            ScoringApplicationForm.Show();
            // TODO Add extra tab to allow user to save the completed match result/scorecard to file
            // Make the application default to this tab once button pressed, but do it behind the new form
        }
       
    }
}
