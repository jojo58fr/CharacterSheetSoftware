using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : EquipementException.cs
Role ........ : Gestion de l'exception concernant les erreurs d'équipement.
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    public class EquipementException : Exception
    {
        public EquipementException()
        {
        }

        public EquipementException(string message) : base(message)
        {
        }

        public EquipementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EquipementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
