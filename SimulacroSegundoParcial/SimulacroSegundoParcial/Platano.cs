using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimulacroSegundoParcial
{
    [XmlInclude(typeof(Platano))]
    public class Platano:Fruta
    {
        public double precio;

        public override bool TieneCarozo
        {
            get { return false; }
        }

        public string Tipo
        {
            get { return "Platano"; }
        }

        public Platano()
        { }

        public Platano(float peso, ConsoleColor color, double precio)
            : base(peso, color)
        {
            this.precio = precio;
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString() + "\nPrecio: " + this.precio + "\nTipo de Fruta: " + this.Tipo;
        }

        public override string ToString()
        {
            return FrutaToString();
        }
    }
}
