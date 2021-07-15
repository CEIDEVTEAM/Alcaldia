using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Constants
{
    public class CGlobals
    {
        public const string ESTADO_ACTIVO = "A";
        public const string ESTADO_INACTIVO = "I";

        //Se guarda si el usuario está en Ingresar o Actualizar una entidad, de esta mandera se reutiliza
        //el campo validateNombre que se dispara con el mismo dto pero en un caso es necesario que no
        //exista (Ingresar) pero en otro valida que si (Actulizar)
        public const string USER_ACTION = "ACTION";


        public const string USER_ALERT = "ALERT";
        public const string USER_ACTION_ADD = "ADD";
        public const string USER_ACTION_MOD = "MOD";
        public const string USER_MESSAGE = "MESSAGE";

    }
}
