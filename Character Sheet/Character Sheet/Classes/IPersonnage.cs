using System.Collections.Generic;

namespace Character_Sheet
{
    public interface IPersonnage
    {
        int Argent { get; set; }
        string Classe { get; set; }
        List<Equipement> Inventaire { get; }
        string Nom { get; set; }
        Genre Sexe { get; set; }
        int Vie { get; set; }
        int Force { get; set; }

        void AjoutEquipement(Equipement equipement);
        int CalculPoidsInventaire();
        string statsToString();
    }
}