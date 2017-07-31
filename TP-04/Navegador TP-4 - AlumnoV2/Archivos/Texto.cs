using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
//using System.Windows.Forms;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        public bool guardar(string datos)
        {
            bool aux = false;
            try
            {
                StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + this.archivo, true);
                sw.WriteLine(datos.ToString());
                sw.Close();
                aux = true;
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error al guardar el archivo","Error");
            }

            return aux;
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();

            try
            {
                StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + this.archivo);

                while (!sr.EndOfStream)
                {
                    datos.Add(sr.ReadLine());
                }

                sr.Close();

                return true;
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error al leer el archivo","Error");
            }

            return false;
        }
    }
}

