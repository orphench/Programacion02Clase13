using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimulacroSegundoParcial
{
    [XmlInclude(typeof(Manzana))]
    public class Manzana:Fruta
    {
        public double precio;

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public string Tipo
        {
            get { return "Manzana"; }
        }

        public Manzana()
        { }

        public Manzana(float peso, ConsoleColor color, double precio)
            : base(peso, color)
        {
            this.precio = precio;
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString() + "\nPrecio: " + this.precio + "\nTipo De Fruta: " + this.Tipo;
        }

        public override string ToString()
        {
            return FrutaToString();
        }


    }
}
