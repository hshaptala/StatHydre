using System.Data.SqlClient;
using System.Windows.Forms;

namespace StatHydre
{
    internal class DatabaseManager
    {
        public string server;
        public string database;

        public DatabaseManager()
        {
            server = "info-mssql-etd";
            database = "E10_StatHydre";
        }

        public bool Auth(string username, string password)
        {
            string connectionString = $"server={server};user={username};password={password};database={database}";
            try
            {
                using (SqlConnection cnxn = new SqlConnection(connectionString))
                {
                    cnxn.Open();
                    MessageBox.Show("Login successful!");
                    return true;
                }
            }
            catch (SqlException ex)
            {
                AuthenticationException(ex);
            }
            return false;
        }

        public void PerformSearch(TextBox txtSearch, ListBox countriesListBox, string username, string password)
        {
            string searchText = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    string connectionString = $"server={server};user={username};password={password};database={database}";
                    string query = "SELECT DISTINCT CT_name FROM T_Country_CT WHERE CT_name LIKE @SearchText + '%';";

                    using (SqlConnection cnxn = new SqlConnection(connectionString))
                    {
                        cnxn.Open();

                        using (SqlCommand command = new SqlCommand(query, cnxn))
                        {
                            command.Parameters.AddWithValue("@SearchText", searchText);

                            // Clear previous search results
                            countriesListBox.Items.Clear();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string country = reader["CT_name"].ToString();
                                    countriesListBox.Items.Add(country);
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void AuthenticationException(SqlException ex)
        {
            switch (ex.Number)
            {
                case -1:
                    MessageBox.Show("Unknown error occurred during authentication.");
                    break;
                case 18456:
                    MessageBox.Show("Incorrect user credentials.");
                    break;
                default:
                    MessageBox.Show("Error occurred during authentication: " + ex.Message);
                    break;
            }
        }

    }
}
