using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {

        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                StreamWriter sw = new StreamWriter(archivo);
                xs.Serialize(sw, datos);
                sw.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(archivo);
                datos = (T)xs.Deserialize(sr);
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }
    }
}
