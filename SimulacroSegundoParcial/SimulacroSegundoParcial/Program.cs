using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroSegundoParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            Platano platanoUno = new Platano(20, ConsoleColor.Blue, 30);
            Platano platanoDos = new Platano(0.15f, ConsoleColor.DarkYellow, 40);
            Platano platanoTres = new Platano(10.5f, ConsoleColor.Yellow, 20);

            Manzana manzanaUno = new Manzana(10, ConsoleColor.Cyan, 20);
            Manzana manzanaDos = new Manzana(5, ConsoleColor.Red, 10);
            Manzana manzanaTres = new Manzana(20, ConsoleColor.Green, 40);

            Cajon cajonUno = new Cajon(5);

            cajonUno += platanoUno;
            cajonUno += platanoDos;
            cajonUno += platanoTres;
            cajonUno += manzanaUno;
            cajonUno += manzanaDos;
            cajonUno += manzanaTres;

            Console.WriteLine(cajonUno);

            Console.WriteLine("--------ORDENADO POR PESO DESCENDENTE-----------");
            cajonUno.Frutas.Sort(Fruta.OrdenarPorPesoDes);
            Console.WriteLine(cajonUno);

            Console.WriteLine("--------ORDENADO POR PESO ASCENDENTE-----------");
            cajonUno.Frutas.Sort(Fruta.OrdenarPorPesoAsc);
            Console.WriteLine(cajonUno);

            //Serializar(manzanaUno);

            Serializar(cajonUno);

            Console.ReadKey();
        }

        private static bool Serializar(ISerializable obj)
        {
            return obj.SerializarXml();
        }
    }
}
