using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        protected int _legajo;

        #region Métodos

        public override bool Equals(object obj)
        {
            bool aux = false;

            if (obj.GetType() == this.GetType())
            {
                aux = (this == ((Universitario)obj));
            }

            return aux;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this._legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool aux = false;

            if ((pg1.DNI == pg2.DNI) || (pg1._legajo == pg2._legajo))
                aux = true;

            return aux;
        }
        #endregion

        #region Constructores
        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion
    }
}
