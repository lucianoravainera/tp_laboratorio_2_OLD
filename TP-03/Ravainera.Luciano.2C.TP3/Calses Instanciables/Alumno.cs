using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Constructores
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            if (this._estadoCuenta == EEstadoCuenta.AlDia)
                sb.AppendLine("ESTADO DE CUENTA: Cuota al día");
            else
                sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);

            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            //si el alumno no toma la clase, ya es distinto a la clase.
            return !(a == clase);
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool aux = false;

            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                aux = true;
            }

            return aux;
        }
        #endregion

        public enum EEstadoCuenta { AlDia, Becado, Deudor }
    }
}
