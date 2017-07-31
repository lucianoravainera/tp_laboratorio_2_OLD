using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad { Argentino, Extranjero }

        #region Propiedades

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = Persona.ValidarDni(this._nacionalidad, value); }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = Persona.ValidarNombreApellido(value); }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = Persona.ValidarNombreApellido(value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string StringToDni
        {
            set { this._dni = Persona.ValidarDni(this._nacionalidad, value); }
        }
        #endregion

        #region Constructores
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Métodos

        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            string aux = "El número de DNI: " + dato.ToString() + " no pertenece a los rangos de la nacionalidad: " + nacionalidad.ToString();

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException(aux);
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }

            return dato;
        }

        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length < 1 || dato.Length > 8)
            {
                throw new DniInvalidoException("El Dni debe tener entre 1 y 8 caracteres, usted ingresó: " + dato);
            }

            int aux = 0;

            if (!int.TryParse(dato, out aux))
            {
                throw new DniInvalidoException();
            }

            return Persona.ValidarDni(nacionalidad, aux);
        }

        private static string ValidarNombreApellido(string dato)
        {
            string aux = dato;

            foreach (char letra in dato)
            {
                if (!char.IsLetter(letra))
                {
                    aux = "";
                    break;
                }
            }

            return aux;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + " " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);

            return sb.ToString();
        }
        #endregion

    }
}