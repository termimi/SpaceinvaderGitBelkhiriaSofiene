using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Storage
{
    public class Store
    {
        public static int score = 0;
        public static string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
        public static string selection = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
        public static int points;
        public static void StoreAlien(Alien alain)
        {
            Debug.WriteLine("C'est dans la db que je mets " + alain.ToString());
        }
        public static int StoreDbResult()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(selection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Traitez chaque ligne de résultat ici.
                            // Vous pouvez accéder aux colonnes par leur nom ou leur indice./
                            string nom = reader.GetString("jouPseudo");
                            points = reader.GetInt32("jouNombrePoints");

                        }
                    }
                }
                connection.Close();
            }
            return points;
        }
    }
}
