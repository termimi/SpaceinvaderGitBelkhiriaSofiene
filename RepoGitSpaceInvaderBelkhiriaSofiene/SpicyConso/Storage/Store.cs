using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Storage
{
    public class Store
    {
       public static int score = 0;
       public static void StoreAlien (Alien alain)
       {
            Debug.WriteLine("C'est dans la db que je mets "+alain.ToString ());
       }
    }
}
