using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StatHydre
{
    public partial class Analyse : Form
    {
        private readonly DatabaseManager db;
        private readonly Utils utils;

        private readonly string username;
        private readonly string password;

        private List<string> selectedCountries = new List<string>();

        private readonly string mapImage;
        private readonly string graphImage;

        private string dataType;
        private bool isPie;

        private bool inRemoval;

        public Analyse(string user, string pass)
        {
            InitializeComponent();
            db = new DatabaseManager();
            utils = new Utils();

            username = user;
            password = pass;

            isPie = false;
            inRemoval = false;

            // Display map by default
            mapImage = utils.mapImage;
            utils.DisplayImage(mapPictureBox, mapImage);

            // Display graph by default
            graphImage = utils.graphImage;

            // Remove cursor focus from textbox
            this.ActiveControl = graphPictureBox;
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            utils.ShowCountriesListBox(txtSearch, countriesListBox);
            db.PerformSearch(txtSearch, countriesListBox, username, password);
        }

        private void OpenButton_Click(object sender, System.EventArgs e)
        {
            int yearStart = ((int)yearStartUpDown.Value);
            int yearEnd = ((int)yearEndUpDown.Value);
            if (yearStart > yearEnd)
            {
                MessageBox.Show("Invalid year choice");
            }
            else
            {
                List<string> countriesToUse = new List<string>();

                foreach (string countries in selectedCountries)
                {
                    countriesToUse.Add(countries.Replace(' ', ','));
                }

                utils.RunMapScript($"{dataType} {yearEnd}");

                int reg = regressionCheck.Checked ? 1 : 0;
                if (isPie)
                {
                    List<string> plist = new List<string>();
                    plist.Add(countriesToUse[0]);
                    utils.RunGraphScript(
                        GraphDisplay.GenerateParams(dataType, yearEnd, yearEnd, reg, plist)
                        );
                }
                else if (regressionCheck.Checked)
                {
                    List<string> plist = new List<string>();
                    plist.Add(countriesToUse[0]);
                    utils.RunGraphScript(
                        GraphDisplay.GenerateParams(dataType, yearStart, yearEnd, reg, countriesToUse)
                        );
                }
                else
                {
                    utils.RunGraphScript(
                        GraphDisplay.GenerateParams(dataType, yearStart, yearEnd, reg, countriesToUse)
                        );
                }

                utils.DisplayImage(mapPictureBox, mapImage);
                utils.DisplayImage(graphPictureBox, graphImage);
            }
        }

        private void OpenWindowButton_Click(object sender, System.EventArgs e)
        {
            if (yearStartUpDown.Value > yearEndUpDown.Value)
            {
                MessageBox.Show("Invalid year choice");
            }
            else
            {
                List<string> countriesToUse = new List<string>();

                foreach (string countries in selectedCountries)
                {
                    countriesToUse.Add(countries.Replace(' ', ','));
                }
                GraphDisplay gd = null;
                if (isPie)
                {
                    List<string> plist = new List<string>();
                    plist.Add(countriesToUse[0]);
                    gd = new GraphDisplay(dataType,
                        decimal.ToInt32(yearEndUpDown.Value),
                        decimal.ToInt32(yearEndUpDown.Value),
                        regressionCheck.Checked, plist);
                }
                else if (regressionCheck.Checked)
                {
                    List<string> plist = new List<string>();
                    plist.Add(countriesToUse[0]);
                    gd = new GraphDisplay(dataType,
                        decimal.ToInt32(yearStartUpDown.Value),
                        decimal.ToInt32(yearEndUpDown.Value),
                        regressionCheck.Checked, plist);
                }
                else
                {
                    gd = new GraphDisplay(dataType,
                        decimal.ToInt32(yearStartUpDown.Value),
                        decimal.ToInt32(yearEndUpDown.Value),
                        regressionCheck.Checked, countriesToUse);
                }
                gd.Show();
            }
        }

        private void GraphStatListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            isPie = false;
            for (int ix = 0; ix < graphStatListBox.Items.Count; ++ix)
                if (ix != e.Index) graphStatListBox.SetItemChecked(ix, false);

            switch (graphStatListBox.Items[e.Index].ToString())
            {
                case "emissions":
                    dataType = "GHG";
                    break;

                case "population":
                    dataType = "population";
                    break;

                case "pluviometry":
                    dataType = "precipitation";
                    break;

                case "temperature":
                    dataType = "temperature";
                    break;

                case "GDP":
                    dataType = "GDP";
                    break;

                case "GDP per capita":
                    dataType = "GDP/capita";
                    break;

            }
            if (e.NewValue == CheckState.Checked)
            {
                pieCheckList.Enabled = false;
                if (startLabel.Enabled == false && yearStartUpDown.Enabled == false)
                {
                    startLabel.Enabled = true;
                    yearStartUpDown.Enabled = true;
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                pieCheckList.Enabled = true;
            }
        }

        private void PieCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            isPie = true;
            for (int ix = 0; ix < pieCheckList.Items.Count; ++ix)
                if (ix != e.Index) pieCheckList.SetItemChecked(ix, false);
            if (e.Index < 3)
            {
                switch (pieCheckList.Items[e.Index].ToString())
                {
                    case "energy produced":
                        dataType = "energy/prod";
                        break;

                    case "energy consumed":
                        dataType = "energy/consump";
                        break;

                    case "emissions by sector":
                        dataType = "GHG/domain";
                        break;
                }
            }
            if (e.NewValue == CheckState.Checked)
            {
                graphStatListBox.Enabled = false;
                regressionCheck.Enabled = false;

                if (startLabel.Enabled == true && yearStartUpDown.Enabled == true)
                {
                    startLabel.Enabled = false;
                    yearStartUpDown.Enabled = false;
                }
            }
            if (e.NewValue == CheckState.Unchecked)
            {
                regressionCheck.Enabled = true;
                graphStatListBox.Enabled = true;
                startLabel.Enabled = true;
                yearStartUpDown.Enabled = true;
            }
        }

        private void CountriesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (countriesListBox.SelectedItem != null && !selectedCountries.Contains(countriesListBox.SelectedItem.ToString()))
            {
                selectedCountries.Add(countriesListBox.SelectedItem.ToString());
                selectedCountriesListBox.Items.Add(countriesListBox.SelectedItem.ToString());
                txtSearch.Text = countriesListBox.SelectedItem.ToString();

                Console.WriteLine(selectedCountries);

                selectedCountriesListBox.Visible = true;
                countriesListBox.Visible = false;
                panel3.Visible = true;
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Please select country")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.WindowText;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Please select country";
                txtSearch.ForeColor = SystemColors.InactiveCaption;
            }
        }

        private void SelectedCountriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedCountriesListBox.SelectedItem != null && !inRemoval)
            {
                inRemoval = true;
                string toRemove = selectedCountriesListBox.SelectedItem.ToString();
                selectedCountries.Remove(toRemove);
                selectedCountriesListBox.Items.Remove(toRemove);
            }
            inRemoval = false;
        }
    }
}
