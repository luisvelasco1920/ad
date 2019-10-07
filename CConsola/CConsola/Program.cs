using System;

namespace CConsola
{
    class MainClass
    {
        public static void Main(string[] args) {
            //int entero = readInteger("Introduce un entero: ");
            //Console.WriteLine("entero={0}", entero);
            //int opcion = readOption("Elige opción [012]: ", "012");

            Menu.Create("Menú Categorías")
                .Add("1 - Nuevo", nuevo)
                .Add("2 - Editar", editar)
                .Add("3 - Borrar", borrar)
                .ExitWhen("0 - Salir")
                .Loop();

        }

        private static void nuevo() {
            Console.WriteLine("Ha entrado en nuevo");
            Console.ReadLine();
        }

        private static void editar() {
            Console.WriteLine("Ha entrado en editar");
            Console.ReadLine();

        }

        private static void borrar() {
            Console.WriteLine("Ha entrado en borrar");
            Console.ReadLine();

        }

        public static int readInteger(string label) {
            while (true) {
                Console.Write(label);
                string linea = Console.ReadLine();
                try {
                    return Int32.Parse(linea);
                } catch {
                    Console.WriteLine("Formato inválido. Vuelve a introducir.");
                }
            };

        }

        public static int readOption(string label, string options) {
            while (true) {
                Console.Write(label);
                string option = Console.ReadLine();
                if (option == "0")
                    return 0;
            }
        }
    }
}
