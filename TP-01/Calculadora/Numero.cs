using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraTP1
{
    public class Numero
    {
        private double _numero;

        /// <summary>
        /// Constructor por defecto, inicializa numero en 0
        /// </summary>
        public Numero() 
        {
            this._numero = 0;
        }
        /// <summary>
        /// Constructor que recibe un double y lo carga en numero
        /// </summary>
        /// <param name="num"></param>
        public Numero(double num)
        {
            this._numero = num;
        }
        /// <summary>
        /// Constructor que recibe un string, valida y carga en numero.
        /// </summary>
        /// <param name="num"></param>
        public Numero(string num)
        {
            this.SetNumero(num);
        }
        /// <summary>
        /// Metodo privado y de clase que recibe un string, valida y devuelve un numero (double)
        /// </summary>
        /// <param name="numString"></param>
        /// <returns>Devuelve un numero double</returns>
        private static double ValidarNumero(string numString)
        {
            double num,aux = 0;
            if (double.TryParse(numString, out num))
            {
                aux = num;
            }
            return aux;
        }

        /// <summary>
        /// Metodo que recibe un string, y lo envia a numero
        /// </summary>
        /// <param name="num"></param>
        private void SetNumero(string num)
        {
            this._numero = Numero.ValidarNumero(num);
        }

        /// <summary>
        /// Metodo que devuelve el numero.
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this._numero;
        }
    }
}
