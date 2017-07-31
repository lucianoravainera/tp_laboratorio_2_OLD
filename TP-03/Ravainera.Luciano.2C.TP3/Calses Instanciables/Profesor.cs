using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #region Métodos
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)(Profesor._random.Next(0, 4)));
            this._clasesDelDia.Enqueue((Universidad.EClases)(Profesor._random.Next(0, 4)));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DíA:");
            sb.AppendLine(this._clasesDelDia.ElementAtOrDefault(0).ToString());
            sb.AppendLine(this._clasesDelDia.ElementAtOrDefault(1).ToString());

            return sb.ToString();

        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool aux = false;

            if (i._clasesDelDia.Contains(clase)) 
                aux = true;

            return aux;
        }
        #endregion

        #region Constructores
        public Profesor()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this()
        {
            this._legajo = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.StringToDni = dni;
            this.Nacionalidad = nacionalidad;
        }
        #endregion

    }
}

