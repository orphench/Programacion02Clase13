using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimulacroSegundoParcial
{
    [XmlInclude(typeof(Fruta))]
    [XmlInclude(typeof(Manzana))]
    [XmlInclude(typeof(Platano))]
    public abstract class Fruta
    {
        protected ConsoleColor _color;
        protected float _peso;

        public abstract bool TieneCarozo { get; }

        public Fruta()
        { }

        public Fruta(float peso, ConsoleColor color)
        {
            this._peso = peso;
            this._color = color;
        }

        protected virtual string FrutaToString()
        {
            return "\nPeso: " + this._peso + "\nColor: " + this._color + "\nTiene Carozo: " + this.TieneCarozo;
        }

        public static int OrdenarPorPesoAsc(Fruta f1, Fruta f2)
        {
            //PUNTERO A FUNCION           
            return (int)(f1._peso.CompareTo(f2._peso));
        }

        public static int OrdenarPorPesoDes(Fruta f1, Fruta f2)
        {
            return (int)(f2._peso.CompareTo(f1._peso));
        }

        public static int OrdenarPorColor(Fruta f1, Fruta f2)
        {
            return f1._color.CompareTo(f2);
        }
    }
}
