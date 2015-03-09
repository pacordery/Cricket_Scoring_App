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
    public partial class Scoring_Application_Form : Form
    {
        public Scoring_Application_Form()
        {
            InitializeComponent();
        }

        /* TODO
         1. Add code functions for all buttons
         2. When new bowler is added, add new row to the bowlers table on the
            scorecard tab
         3. Push data for team batting, weather, home and away teams, and venue
            into the relevent labels on scoring and scorecard tabs
         */

        private void New_Bowler_Button_Click(object sender, EventArgs e)
        {
            New_Bowler NewBowler = new New_Bowler();
            NewBowler.Show();
        }

        private void Dot_Button_Click(object sender, EventArgs e)
        {

        }

        private void One_Button_Click(object sender, EventArgs e)
        {

        }

        private void Two_Button_Click(object sender, EventArgs e)
        {

        }

        private void Three_Button_Click(object sender, EventArgs e)
        {

        }

        private void Four_Button_Click(object sender, EventArgs e)
        {

        }

        private void Six_Button_Click(object sender, EventArgs e)
        {

        }

        private void Bye_Button_Click(object sender, EventArgs e)
        {

        }

        private void Leg_Bye_Button_Click(object sender, EventArgs e)
        {

        }

        private void Wide_Button_Click(object sender, EventArgs e)
        {

        }

        private void No_Ball_Button_Click(object sender, EventArgs e)
        {

        }

        private void Wicket_Button_Click(object sender, EventArgs e)
        {

        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
