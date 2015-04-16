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
        int currentTableRowAway = 1;
        int currentTableRowHome = 1;
        public static string folderName;
        List<string> HomeTeamList = new List<string>();
        List<string> AwayTeamList = new List<string>();
        List<string> MatchDetailsList = new List<string>();

        // ******* Code for Home tab *******

        private void Start_New_Match_Button_Click(object sender, EventArgs e)
        {
            DialogResult selectFolderResult = Select_Folder_Dialog.ShowDialog();
            if (selectFolderResult == DialogResult.OK)
            {
                folderName = Select_Folder_Dialog.SelectedPath;
                Begin_Match_Confirm_Table.Hide();
                Details_Tab_Set.SelectedTab = Match_Details_Tab;
            }
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
            if (DateChanged == false)
            {
                MatchDate = DateTime.Now.ToShortDateString();
            }
            if (Verify_Table_Entrys(tableLayoutPanel_Match))
            {
                // Get match details from the text and combo boxes.
                HomeTeamNameText = Home_Team_Name.Text;
                Home_Team_Heading.Text = HomeTeamNameText;
                AwayTeamNameText = Away_Team_Name.Text;
                Away_Team_Heading.Text = AwayTeamNameText;
                VenueName = Venue_Name.Text;
                MatchType = Match_Type_Selector.SelectedItem.ToString();
                MatchWeather = Weather_Selector.SelectedItem.ToString();

                // Clear the match details list of any loaded inputs to allow new inputs to be written correctly.
                MatchDetailsList.Clear();

                // Add all match details into MatchDetailsList ready to write to file.
                MatchDetailsList.Add(MatchDate);
                MatchDetailsList.Add(HomeTeamNameText);
                MatchDetailsList.Add(AwayTeamNameText);
                MatchDetailsList.Add(VenueName);
                MatchDetailsList.Add(MatchType);
                MatchDetailsList.Add(MatchWeather);

                folderName = folderName + "\\" + MatchDate.Substring(5, 5) + " Season\\" + MatchDate.Replace('/', '.') + "." + HomeTeamNameText;
                Directory.CreateDirectory(folderName);
                Directory.CreateDirectory(folderName + "\\" + HomeTeamNameText);
                Directory.CreateDirectory(folderName + "\\" + AwayTeamNameText);
                StreamWriter matchDetailsWriter = new StreamWriter(folderName + "\\MatchDetails.txt");

                for (int i = 0; i < MatchDetailsList.Count(); i = i + 1)
                {
                    matchDetailsWriter.WriteLine(MatchDetailsList[i]);
                }
                matchDetailsWriter.Close();
                Details_Tab_Set.SelectedTab = Team_Details_Tab;
            }
        }

        // ******* Code for Team Details tab *******

        // Adds an extra row for the user to add away team members
        private void Add_Player_Away_Click(object sender, EventArgs e)
        {
            if (currentTableRowAway < 11)
            {
                tableLayoutPanel_Away.Controls.Add(new Label() { Text = (currentTableRowAway + 1).ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, currentTableRowAway);
                tableLayoutPanel_Away.Controls.Add(new TextBox() { Text = "Enter Player Name", Dock = DockStyle.Fill }, 1, currentTableRowAway);
                tableLayoutPanel_Away.Controls.Add(new Label() { Text = "", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new Font("Serif", 20, FontStyle.Regular), ForeColor = Color.White }, 2, currentTableRowAway);
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
                tableLayoutPanel_Home.Controls.Add(new Label() { Text = "", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new Font("Serif", 20, FontStyle.Regular), ForeColor = Color.White }, 2, currentTableRowHome);
                tableLayoutPanel_Home.GetControlFromPosition(1, currentTableRowHome).Select();
                currentTableRowHome = currentTableRowHome + 1;
            }
        }

        // Checks all inputs in the named table to find any that have not been filled in.
        private bool Verify_Table_Entrys(TableLayoutPanel tableName)
        {
            bool verified = true;
            int numberOfRows = 0;
            if (tableName.Name == "tableLayoutPanel_Match")
            {
                numberOfRows = tableName.RowCount;
            }
            else if (tableName.Name == "tableLayoutPanel_Away")
            {
                numberOfRows = currentTableRowAway;
            }
            else if (tableName.Name == "tableLayoutPanel_Home")
            {
                numberOfRows = currentTableRowHome;
            }

            // Check away team table entries
            for (int i = 0; i < numberOfRows; i = i + 1)
            {
                // Gets the name of the control from the table
                Control c = tableName.GetControlFromPosition(1, i);
                Control d = tableName.GetControlFromPosition(2, i);

                // If the control is in the Match table and is empty the method 
                if (String.IsNullOrWhiteSpace(c.Text))
                {
                    d.Text = "*";
                    c.BackColor = Color.DarkOrange;
                    verified = false;
                }
                else
                {
                    c.BackColor = Color.White;
                    d.Text = "";
                }
            }
            return verified;
        }

        // Checks if both teams have 11 players, if less than this it shows the confirmation buttons.
        // This makes sure that the user has input the correct number of players.
        private void Begin_Match_Button_Click(object sender, EventArgs e)
        {
            if (currentTableRowAway < 11 || currentTableRowHome < 11)
            {
                if (currentTableRowAway < 8 || currentTableRowHome < 8)
                {
                    Begin_Match_Confirm_Label.Text = "Each team must have a minimum of 8 players";
                    Begin_Match_Confirm_Table.Show();
                    Begin_Match_Cancel_Button.Hide();
                    Begin_Match_Confirm_Button.Hide();
                }
                else
                {
                Begin_Match_Button.Hide();
                Begin_Match_Confirm_Label.Text = AwayTeamNameText + " has " + currentTableRowAway + " players, " + HomeTeamNameText + " has " + currentTableRowHome + " players";
                Begin_Match_Confirm_Table.Show();
                Begin_Match_Cancel_Button.Show();
                Begin_Match_Confirm_Button.Show();
                }
            }
            else
            {
                BeginMatch();
            }
        }

        // Reads the match details from a pre-made match details file, uses an open file dialog.
        private void Load_Match_Details_Button_Click(object sender, EventArgs e)
        {
            MatchDetailsList.Clear();
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

        // Reads the away team details from a pre-made away team file, uses an open file dialog.
        private void Load_Away_Team_Click(object sender, EventArgs e)
        {
            Load_Away_Team_Dialog.Title = AwayTeamNameText + " team selection";
            DialogResult loadAwayTeam = Load_Away_Team_Dialog.ShowDialog();
            if (loadAwayTeam == DialogResult.OK)
            {
                AwayTeamList.Clear();
                tableLayoutPanel_Away.Controls.Clear();
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
                    for (int i = 0; i < AwayTeamList.Count; i = i + 1)
                    {
                        tableLayoutPanel_Away.Controls.Add(new Label(){ Text = (i+1).ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, i);
                        tableLayoutPanel_Away.Controls.Add(new TextBox() { Text = AwayTeamList[i], Dock = DockStyle.Fill },1,i);
                        tableLayoutPanel_Away.Controls.Add(new Label() { Text = "", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new Font("Serif", 20, FontStyle.Regular), ForeColor = Color.White }, 2, i);
                        currentTableRowAway = currentTableRowAway + 1;
                    }
                }
                catch (IOException)
                {
                }
            }
        }

        // Reads the home team details from a pre-made home team file, uses an open file dialog
        private void Load_Home_Team_Click(object sender, EventArgs e)
        {
            Load_Home_Team_Dialog.Title = HomeTeamNameText + " team selection";
            DialogResult loadHomeTeam = Load_Home_Team_Dialog.ShowDialog();
            if (loadHomeTeam == DialogResult.OK)
            {
                HomeTeamList.Clear();
                tableLayoutPanel_Home.Controls.Clear();
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
                    for (int i = 0; i < HomeTeamList.Count; i = i + 1)
                    {
                        tableLayoutPanel_Home.Controls.Add(new Label() { Text = (i + 1).ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Font = new Font("Serif", 10, FontStyle.Bold) }, 0, i);
                        tableLayoutPanel_Home.Controls.Add(new TextBox() { Text = HomeTeamList[i], Dock = DockStyle.Fill },1,i);
                        tableLayoutPanel_Home.Controls.Add(new Label() { Text = "", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new Font("Serif", 20, FontStyle.Regular), ForeColor = Color.White }, 2, i);
                        currentTableRowHome =  currentTableRowHome + 1;
                    }
                }
                catch (IOException)
                {
                }
            }
        }

        // Shows the main scoring application if all table entrys are verified.
        private void BeginMatch()
        {
            // Checks if both player tables have values in all the text boxes.
            if ((Verify_Table_Entrys(tableLayoutPanel_Away)) || (Verify_Table_Entrys(tableLayoutPanel_Home)))
            {
                // Create away team file.
                StreamWriter AwayWriter = new StreamWriter(folderName + "\\" + AwayTeamNameText + ".txt");

                // Write player names to away team file.
                for (int i = 0; i < currentTableRowAway; i = i + 1)
                {
                    Control c = tableLayoutPanel_Away.GetControlFromPosition(1, i);
                    AwayWriter.WriteLine(c.Text);
                }
                AwayWriter.Close();

                // Create home team file.
                StreamWriter HomeWriter = new StreamWriter(folderName + "\\" + HomeTeamNameText + ".txt");

                // Write player names to home team file.
                for (int j = 0; j < currentTableRowHome; j = j + 1)
                {
                    Control d = tableLayoutPanel_Home.GetControlFromPosition(1, j);
                    HomeWriter.WriteLine(d.Text);
                }
                HomeWriter.Close();

                // Initialises the Main scoring application form object.
                Scoring_Application_Form ScoringApplicationForm = new Scoring_Application_Form(folderName);
                // Passes the folder name to the scoring application and opens the form.
                ScoringApplicationForm.folderName = folderName;
                ScoringApplicationForm.Show();
            }
        }

        // Calls the begin match function when the user confirms that the team lists are correct.
        private void Begin_Match_Confirm_Button_Click(object sender, EventArgs e)
        {
            BeginMatch();
        }

        // Hides the confirmation table and allows the user to make changes to the team lists.
        private void Begin_Match_Cancel_Button_Click(object sender, EventArgs e)
        {
            Begin_Match_Confirm_Table.Hide();
            Begin_Match_Button.Show();
        }
    }
}