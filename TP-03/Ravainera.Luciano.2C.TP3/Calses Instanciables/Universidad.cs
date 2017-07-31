using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        protected List<Alumno> _alumnos;
        protected List<Profesor> _profesores;
        protected List<Jornada> _jornada;

        public enum EClases { Laboratorio,Programacion,Legislacion,SPD };
        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                try
                {
                    return this._jornada[i];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            set
            {
                try
                {
                    this._jornada[i] = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        #endregion

        #region Constructores
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }
        #endregion

        #region Métodos

        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xmlgim = new Xml<Universidad>();
            xmlgim.guardar("Universidad.xml", gim);
            return true;
        }

        public static Universidad Leer()
        {
            Universidad uniAux = null;

            Xml<Universidad> xmlgim = new Xml<Universidad>();
            xmlgim.leer("Universidad.xml", out uniAux);

            return uniAux;
        }
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada j in gim._jornada)
            {
                sb.AppendLine(j.ToString());
            }

            return sb.ToString();

        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor pro in g._profesores)
            {
                if (pro != clase)
                {
                    return pro;
                }
            }


            throw new SinProfesorException();
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
                g._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return g;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            bool bandera = false;
            Profesor proAux = null;
            Jornada j = null;

            foreach (Profesor pro in g._profesores)
            {
                if (pro == clase)
                {
                    proAux = pro;
                    bandera = true;
                    break;
                }
            }

            if (bandera)
            {
                j = new Jornada(clase, proAux);
            }
            else
            {
                throw new SinProfesorException();
            }

            foreach (Alumno al in g._alumnos)
            {
                if (al == clase)
                {
                    j += al;
                }
            }

            g._jornada.Add(j);

            return g;
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g._profesores.Add(i);

            return g;
        }


        public static bool operator ==(Universidad g, Alumno a)
        {
            bool aux = false;

            foreach (Alumno al in g._alumnos)
            {
                if (al == a)
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor pro in g._profesores)
            {
                if (pro == clase)
                {
                    return pro;
                }
            }

            throw new SinProfesorException();
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool aux = false;

            foreach (Profesor pro in g._profesores)
            {
                if (pro == i)
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }
        #endregion

    }
}
