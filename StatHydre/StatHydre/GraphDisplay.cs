using System.Collections.Generic;
using System.Windows.Forms;

namespace StatHydre
{
    /*author : ndurieux*/
    public partial class GraphDisplay : Form
    {
        private readonly Utils utils;

        private int startDate;
        private readonly string dataType;
        private readonly int endDate;
        private readonly bool isRegression;
        private readonly List<string> countries;

        public GraphDisplay(string dataType, int startDate, int endDate, bool isRegression, List<string> countries)
        {
            utils = new Utils();

            this.dataType = dataType;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isRegression = isRegression;
            this.countries = countries;

            InitializeComponent();

            utils.RunGraphScript(GenerateParams());
            utils.DisplayImage(graphBox, utils.graphImage);
        }

        public string GenerateParams()
        {
            int regr = isRegression ? 1 : 0;
            startDate = startDate > endDate ? endDate : startDate; //Avoids potential errors. To be removed afterward if deprecated.
            string countriesSpaced = " ";
            foreach (string country in countries)
            {
                countriesSpaced += country + " ";
            }
            // graph data_type date_debut date_fin regression country1 country2 country3...
            string p = dataType + " " + startDate + " " + endDate + " " + regr + countriesSpaced;
            return p;
        }

        public static string GenerateParams(string dtype, int sDate, int eDate, int regression, List<string> countries)
        {
            sDate = sDate > eDate ? eDate : sDate; //Avoids potential errors. To be removed afterward if deprecated.
            string countriesSpaced = " ";
            foreach (string country in countries)
            {
                string c = country.Replace(" ", ";");
                countriesSpaced += c + " ";
            }
            // graph data_type date_debut date_fin regression country1 country2 country3...
            string p = dtype + " " + sDate + " " + eDate + " " + regression + countriesSpaced;
            return p;
        }
    }
}
