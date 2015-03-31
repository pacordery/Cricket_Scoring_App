using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cricket_Scoring_App
{
    public partial class Scoring_App_Form : Form
    {
        public Scoring_App_Form()
        {
            InitializeComponent();
        }

        string winDir=System.Environment.GetEnvironmentVariable("windir");

        bool DateChanged = false;
        private string MatchDate;
        private string HomeTeamNameText;
        private string AwayTeamNameText;
        private string VenueName;
        private string MatchType;
        private string MatchWeather;
        private string TossWonBy;
        int currentTableRowAway = 1;
        int currentTableRowHome = 1;
        List<string> HomeTeamList = new List<string>();
        List<string> AwayTeamList = new List<string>();
        List<string> MatchDetailsList = new List<string>();

        // ******* Code for Home tab *******

        /* Initialises the Main scoring application form to allow it to be 
           shown in Begin_Match_Button_Click() is called.*/
        Scoring_Application_Form ScoringApplicationForm = new Scoring_Application_Form();

        private void Start_New_Match_Button_Click(object sender, EventArgs e)
        {
            Details_Tab_Set.SelectedTab = Match_Details_Tab;
        }
        // *******  Code for Match Details tab *******

        // Gets date of the match
        private void Match_Date_Picker_ValueChanged(object sender, EventArgs e)
        {
            DateChanged = true;
            MatchDate = Match_Date_Picker.Value.ToShortDateString();
        }
        
        // When Next button pressed on Match Details Tab, go to Team Details Tab.
        private void Next_Tab_Button_Click(object sender, EventArgs e)
        {
            HomeTeamNameText = Home_Team_Name.Text;
            Home_Team_Heading.Text = HomeTeamNameText;
            AwayTeamNameText = Away_Team_Name.Text;
            Away_Team_Heading.Text = AwayTeamNameText;
            VenueName = Venue_Name.Text;
            MatchType = Match_Type_Selector.SelectedItem.ToString();
            MatchWeather = Weather_Selector.SelectedItem.ToString();

            if (DateChanged == false)
            {
                MatchDate = DateTime.Now.ToShortDateString();
            }
            // Add all match details into MatchDetailsList ready to write to file
            MatchDetailsList.Add(MatchDate);
            MatchDetailsList.Add(HomeTeamNameText);
            MatchDetailsList.Add(AwayTeamNameText);
            MatchDetailsList.Add(VenueName);
            MatchDetailsList.Add(MatchType);
            MatchDetailsList.Add(MatchWeather);

            StreamWriter matchDetailsWriter = new StreamWriter("C:\\Users\\Philip\\Desktop\\MatchDetails.txt");

            for (int i = 0; i < MatchDetailsList.Count(); i = i + 1)
            {
                matchDetailsWriter.WriteLine(MatchDetailsList[i]);
            }
            matchDetailsWriter.Close();
            Details_Tab_Set.SelectedTab = Team_Details_Tab;
        }

        // ******* Code for Team Details tab *******

        // Adds an extra row for the user to add away team members
        private void Add_Player_Away_Click(object sender, EventArgs e)
        {
            if (currentTableRowAway < 11)
            {
                tableLayoutPanel_Away.Controls.Add(new Label() { Text = (currentTableRowAway + 1).ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, currentTableRowAway);
                tableLayoutPanel_Away.Controls.Add(new TextBox() { Text = "Enter Player Name", Dock = DockStyle.Fill }, 1, currentTableRowAway);
                tableLayoutPanel_Away.GetControlFromPosition(1, currentTableRowAway).Select();
                currentTableRowAway = currentTableRowAway + 1;
            }
        }

        // Adds an extra row for the user to add home team members
        private void Add_Player_Home_Click(object sender, EventArgs e)
        {
            if (currentTableRowHome < 11)
            {
                tableLayoutPanel_Home.Controls.Add(new Label() { Text = (currentTableRowHome + 1).ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, currentTableRowHome);
                tableLayoutPanel_Home.Controls.Add(new TextBox() { Text = "Enter Player Name", Dock = DockStyle.Fill }, 1, currentTableRowHome);
                tableLayoutPanel_Home.GetControlFromPosition(1, currentTableRowHome).Select();
                currentTableRowHome = currentTableRowHome + 1;
            }
        }

        // Shows the main scoring application when button is clicked.
        // this will be read by the scoring application to complete the relevant fields.
        private void Begin_Match_Button_Click(object sender, EventArgs e)
        {
            StreamWriter AwayWriter = new StreamWriter("C:\\Users\\Philip\\Desktop\\" + AwayTeamNameText + ".txt");

            // Write player names to away team file
            for (int i = 0; i < currentTableRowAway; i = i + 1)
            {
                Control c = tableLayoutPanel_Away.GetControlFromPosition(1,i);
                AwayWriter.WriteLine(c.Text);
            }
            AwayWriter.Close();

            StreamWriter HomeWriter = new StreamWriter("C:\\Users\\Philip\\Desktop\\" + HomeTeamNameText + ".txt");

            // Write player names to home team file
            for (int j = 0; j < currentTableRowHome; j = j + 1)
            {
                Control d = tableLayoutPanel_Home.GetControlFromPosition(1, j);
                HomeWriter.WriteLine(d.Text);
            }
            HomeWriter.Close();

           ScoringApplicationForm.Show();
        }

        private void Load_Match_Details_Button_Click(object sender, EventArgs e)
        {
            DialogResult loadMatch = Load_Match_Details_Dialog.ShowDialog();
            if (loadMatch == DialogResult.OK)
            {
                string file = Load_Match_Details_Dialog.FileName;
                try
                {
                    StreamReader matchDetailsReader = new StreamReader(file);
                    try
                    {
                        do
                        {
                            MatchDetailsList.Add(matchDetailsReader.ReadLine());
                        }
                        while (matchDetailsReader.Peek() != -1);
                    }
                    catch
                    {
                        MatchDetailsList.Add("File is empty");
                    }
                    finally
                    {
                        matchDetailsReader.Close();
                    }
                    Match_Date_Picker.Value = Convert.ToDateTime(MatchDetailsList[0]);
                    Home_Team_Name.Text = MatchDetailsList[1];
                    Home_Team_Heading.Text = HomeTeamNameText;
                    Away_Team_Name.Text = MatchDetailsList[2];
                    Away_Team_Heading.Text = AwayTeamNameText;
                    Venue_Name.Text = MatchDetailsList[3];
                    Match_Type_Selector.SelectedItem = MatchDetailsList[4];
                    Weather_Selector.SelectedItem = MatchDetailsList[5];
                }
                catch (IOException)
                {
                }
            }
        }

        private void Load_Away_Team_Click(object sender, EventArgs e)
        {
            DialogResult loadAwayTeam = Load_Away_Team_Dialog.ShowDialog();
            if (loadAwayTeam == DialogResult.OK)
            {
                string file = Load_Away_Team_Dialog.FileName;
                try
                {
                    StreamReader awayTeamReader = new StreamReader(file);
                    try
                    {
                        do
                        {
                            AwayTeamList.Add(awayTeamReader.ReadLine());
                        }
                        while (awayTeamReader.Peek() != -1);
                    }
                    catch
                    {
                        AwayTeamList.Add("File is empty");
                    }
                    finally
                    {
                        awayTeamReader.Close();
                    }
                    currentTableRowAway = 0;
                    tableLayoutPanel_Away.Controls.Clear();
                    for (int i = 0; i < AwayTeamList.Count; i = i + 1)
                    {
                        tableLayoutPanel_Away.Controls.Add(new Label(){ Text = (i+1).ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, i);
                        tableLayoutPanel_Away.Controls.Add(new TextBox() { Text = AwayTeamList[i], Dock = DockStyle.Fill });
                        currentTableRowAway = currentTableRowAway + 1;
                    }
                }
                catch (IOException)
                {
                }
            }
        }

        private void Load_Home_Team_Click(object sender, EventArgs e)
        {
            DialogResult loadHomeTeam = Load_Home_Team_Dialog.ShowDialog();
            if (loadHomeTeam == DialogResult.OK)
            {
                string file = Load_Home_Team_Dialog.FileName;
                try
                {
                    StreamReader HomeTeamReader = new StreamReader(file);
                    try
                    {
                        do
                        {
                            HomeTeamList.Add(HomeTeamReader.ReadLine());
                        }
                        while (HomeTeamReader.Peek() != -1);
                    }
                    catch
                    {
                        HomeTeamList.Add("File is empty");
                    }
                    finally
                    {
                        HomeTeamReader.Close();
                    }
                    currentTableRowHome = 0;
                    tableLayoutPanel_Home.Controls.Clear();
                    for (int i = 0; i < HomeTeamList.Count; i = i + 1)
                    {
                        tableLayoutPanel_Home.Controls.Add(new Label() { Text = (i + 1).ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, i);
                        tableLayoutPanel_Home.Controls.Add(new TextBox() { Text = HomeTeamList[i], Dock = DockStyle.Fill });
                        currentTableRowHome =  currentTableRowHome + 1;
                    }
                }
                catch (IOException)
                {
                }
            }
        }  
    }
}
