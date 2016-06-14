using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SimulacroSegundoParcial
{
    [XmlInclude(typeof(Cajon))]
    public class Cajon:ISerializable
    {
        private int _capacidad;
        private List<Fruta> _frutas;
        private string _ruta;

        public List<Fruta> Frutas { get { return this._frutas; } }

        public double PrecioDeManzanas { get { return ObtenerTotal(EtipoFruta.Manzana); } }

        public double PrecioDePlantanos { get { return ObtenerTotal(EtipoFruta.Platano); } }

        public double PrecioTotal { get { return ObtenerTotal(EtipoFruta.Todo); } }

        public string RutaArchivo 
        {
            get { return this._ruta; }
            set { this._ruta = value; }
        }

        public Cajon()
        {
            this._frutas = new List<Fruta>();
        }

        public Cajon(int capacidad):this()
        {
            this._capacidad = capacidad;
        }

        private double ObtenerTotal(EtipoFruta tipo)
        {
            double total = 0;

            if (tipo == EtipoFruta.Todo)
            {
                for (int i = 0; i < this._frutas.Count; i++)
                {
                    if (this._frutas[i] is Platano)
                    {
                        total += ((Platano)this._frutas[i]).precio;
                    }

                    else
                    {
                        total += ((Manzana)this._frutas[i]).precio;
                    }
                }
            }

            else
            {
                for (int i = 0; i < this._frutas.Count; i++)
                {
                    if ((this._frutas[i] is Platano) && (tipo == EtipoFruta.Platano))
                    {
                        total += ((Platano)this._frutas[i]).precio;
                    }
                    if ((this._frutas[i] is Manzana) && (tipo == EtipoFruta.Manzana))
                    {
                        total += ((Manzana)this._frutas[i]).precio;
                    }
                }
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----------DATOS DEL CAJON------------");
            sb.AppendLine("Capacidad del Cajon: " + this._capacidad);
            sb.AppendLine("Detalles del Cajon: ");

            foreach (Fruta item in _frutas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public static Cajon operator +(Cajon c, Fruta f)
        {
            if (c._capacidad > c.Frutas.Count )
            {
                c.Frutas.Add(f);
            }

            return c;
        }

        public bool SerializarXml()
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(this.RutaArchivo + "Cajon.xml",Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(Cajon));
                    serializador.Serialize(escritor, this);
                    Console.WriteLine("Cajon Serializado Correctamente");
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
