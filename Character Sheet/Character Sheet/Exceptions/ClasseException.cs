using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : ClasseException.cs
Role ........ : Gestion de l'exception concernant les erreurs de classe.
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    public class ClasseException : Exception
    {
        public ClasseException()
        {
        }

        public ClasseException(string message) : base(message)
        {
        }

        public ClasseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClasseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
