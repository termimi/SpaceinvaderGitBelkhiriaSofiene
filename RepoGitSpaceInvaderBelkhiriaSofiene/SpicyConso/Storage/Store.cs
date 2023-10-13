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
        static List<Scores> fiveBestScore = new List<Scores>();
        
        public  int score = 0;
        public  string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
        public  string selection = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
        public  int points;
        public  void StoreAlien(Alien alain)
        {
            Debug.WriteLine("C'est dans la db que je mets " + alain.ToString());
        }
        public  void StoreDbResult(Scores fiveScore)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(selection, connection)) // Associez la connexion à la commande ici
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Traitez chaque ligne de résultat ici.
                            // Vous pouvez accéder aux colonnes par leur nom ou leur indice.
                            string nom = reader.GetString("jouPseudo");
                            int points = reader.GetInt32("jouNombrePoints");
                            Scores scoreDB = new Scores(nom,points);
                            fiveBestScore.Add(scoreDB);
                        }
                    }
                }
                connection.Close();
            }
             
        }
        public  void LoadingDbResult()
        {
            foreach(Scores scores in fiveBestScore)
            {

            }
        }
        

    }
}
