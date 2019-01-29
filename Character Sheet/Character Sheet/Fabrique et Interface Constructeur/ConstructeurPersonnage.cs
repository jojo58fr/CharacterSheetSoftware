using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : ConstructeurPersonnage.cs
Role ........ : Crée une interface constructeur virtuelle permettant le rajout dans la fabrique virtuel
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    public interface ConstructeurPersonnage
    {
        Personnage Construit(string nom, Genre genre);
    }
}
