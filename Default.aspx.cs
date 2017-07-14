using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamProjectWebForms
{
    public partial class _Default : Page
    {
        public void Page_Load(object sender, EventArgs e)
        {


            //Player p11 = new Player("Kelton", "Kelton's Dreamers", 0);
            //Player p22 = new Player()
            //{
            //    PlayerName = "Sean",
            //    TeamName = "Sean's Killers",
            //    TotalScores = 0
            //};


            //p11.Foul(p22, 37);















            string connectionString = "Data Source =.\\SQLEXPRESS; Initial Catalog = TeamProject; Integrated Security = True; MultipleActiveResultSets = True";

            string querystring = "RosterMake";

            // define the list
            var values = new List<Dictionary<string, object>>();

            using (SqlConnection connection = 
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(querystring, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    List<Player> roster = new List<Player>();

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // define the dictionary
                            //var fieldValues = new Dictionary<string, object>();

                            string playername = reader["PlayerName"].ToString();
                            string teamname = reader["TeamName"].ToString();
                            int totalscores = Convert.ToInt32(reader["TotalScores"]);

                            Player p1 = new Player(playername, teamname, totalscores);
                            roster.Add(p1);
                            //Player p2 = new Player();
                            //Player p3 = new Player()
                            //{
                            //    PlayerName = "Sean",
                            //    TeamName = "Kelton's Team",
                            //    TotalScores = 3
                            //};




                            //// fill up each column and values on the dictionary                 
                            //for (int i = 0; i < reader.FieldCount; i++)
                            //{
                                
                            //    fieldValues.Add(reader.GetName(i), reader[i]);
                            //}

                            //// add the dictionary on the values list
                            //values.Add(fieldValues);
                        }
                    }

                    //roster[5].Shoot();
                    //roster[4].Foul();

                    //string json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    string json = JsonConvert.SerializeObject(roster, Formatting.Indented);
                    ///
                    ///jsonlabel.Text = json;
                    ///

                    //Write json to debug log to verify
                    //System.Diagnostics.Debug.WriteLine(json);
                }


                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("oops");
                }
            }

            
        }
    }
}