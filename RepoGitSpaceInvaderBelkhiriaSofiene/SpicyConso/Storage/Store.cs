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
        public List<Store> storageScore = new List<Store>();
        public  int score = 0;
        public  string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
        public  string selection = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
        public  int points;
        public string name;
        public Store(string name, int point)
        {
            this.name = name;
            this.points = point;
        }
        public  void StoreAlien(Alien alain)
        {
            Debug.WriteLine("C'est dans la db que je mets " + alain.ToString());
        }
        public  void StoreDbResult()
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
                            Store record = new Store(nom,points);
                           this.storageScore.Add(record);

                        }
                    }
                }
                connection.Close();
            }
             
        }
        public List<Store> LoadingDbResult()
        {
            List<Store> storageScore2 = new List<Store>();
            foreach (Store record in storageScore)
            {
                storageScore2.Add(record);
            }
            return storageScore2;
        }



    }
}
