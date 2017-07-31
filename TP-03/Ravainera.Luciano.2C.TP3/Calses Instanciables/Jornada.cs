using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        } 
        #endregion

        #region Métodos

        public static bool Guardar(Jornada jornada)
        {
         
            Texto txt = new Texto();
            txt.guardar("Jornada.txt", jornada.ToString());

            return true;
        }


        public static string Leer()
        {

            string aux;

            Texto txt = new Texto();
            txt.leer("Jornada.txt", out aux);

            return aux;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}", this._clase, this._instructor);

            sb.AppendLine("ALUMNOS:");
            foreach (Alumno al in this._alumnos)
            {
                sb.AppendFormat(al.ToString());
            }
            sb.AppendLine("<--------------------------------------------------->");
            return sb.ToString();
        }
        
        #endregion

        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        } 
        #endregion

        #region Operadores

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);

            return j;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool aux = false;

            foreach (Alumno al in j._alumnos)
            {
                if (al.Equals(a))
                    aux = true;
                break;
            }

            return aux;
        } 
        #endregion
    }
}
