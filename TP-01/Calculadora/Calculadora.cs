using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraTP1
{
    public class Calculadora
    {
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double aux = 0;
            switch (operador)
            {
                case "+":
                    aux = n1.getNumero() + n2.getNumero();
                    break;
                case "-":
                    aux = n1.getNumero() - n2.getNumero();
                    break;
                case "*":
                    aux = n1.getNumero() * n2.getNumero();
                    break;
                case "/":
                    if (n2.getNumero() == 0)
                    { break; }
                    else
                    { aux = n1.getNumero() / n2.getNumero(); }
                    break;
            }
            return aux;
        }

        public static string ValidarOperador(string operador)
        {
            string aux = "+";
            if (operador == "-" || operador == "/" || operador == "*")
            {
                aux = operador;
            }
            return aux;
        }
    }
}
