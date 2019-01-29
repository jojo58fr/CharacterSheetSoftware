using Character_Sheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Sheet_Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            Personnage personnage = new Personnage("Saber",Genre.Femme);
            personnage.AjoutEquipement(new Equipement("Excalibur", 50000, 5));
            Console.WriteLine("Détails des personnages :");
            Console.WriteLine(personnage.ToString());
            Console.Read();

        }
    }
}
