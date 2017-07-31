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

        public Numero() 
        {
            this._numero = 0;
        }

        public Numero(double num)
        {
            this._numero = num;
        }

        public Numero(string num)
        {
            this.SetNumero(num);
        }

        private static double ValidarNumero(string numString)
        {
            double num,aux = 0;
            if (double.TryParse(numString, out num))
            {
                aux = num;
            }
            return aux;
        }

        private void SetNumero(string num)
        {
            this._numero = Numero.ValidarNumero(num);
        }


        public double getNumero()
        {
            return this._numero;
        }
    }
}
