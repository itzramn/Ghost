using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ghost
{
    class pantallaDeCarga
    {
        public void Splash()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            int cont;
            cont = 0;

            String line, GhostDerecha, GhostIzquierda;
            StreamReader cargarGhostD = new StreamReader(@"Splash\DibujosGhostDerecha.txt");
            GhostDerecha = cargarGhostD.ReadLine();
            Console.SetCursorPosition(0, 1);
            while (GhostDerecha != null)
            {
                Console.WriteLine(GhostDerecha);
                GhostDerecha = cargarGhostD.ReadLine();
            }
            cargarGhostD.Close();

            StreamReader cargarNombre = new StreamReader(@"Splash\NombreJuego.txt");
            line = cargarNombre.ReadLine();
            Console.SetCursorPosition(31, 3);
            while (line != null)
            {
                Console.WriteLine(line);
                line = cargarNombre.ReadLine();
            }
            cargarNombre.Close();

            StreamReader cargarGhostI = new StreamReader(@"Splash\DibujosGhostIzquierda.txt");
            GhostIzquierda = cargarGhostI.ReadLine();
            Console.SetCursorPosition(0, 1);
            while (GhostIzquierda != null)
            {
                Console.WriteLine(GhostIzquierda);
                GhostIzquierda = cargarGhostI.ReadLine();
            }
            cargarGhostI.Close();

            Console.SetCursorPosition(69, 24);
            Console.WriteLine("Loading...");
            Console.SetCursorPosition(30, 21);
            Console.WriteLine("╔");
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("║");
            Console.SetCursorPosition(30, 23);
            Console.WriteLine("╚");
            Console.SetCursorPosition(84, 21);
            Console.WriteLine("╗");
            Console.SetCursorPosition(84, 22);
            Console.WriteLine("║");
            Console.SetCursorPosition(84, 23);
            Console.WriteLine("╝");

            cont = 0;
            do
            {
                Console.SetCursorPosition(31 + cont, 21);
                Console.WriteLine("═");
                Console.SetCursorPosition(31 + cont, 23);
                Console.WriteLine("═");
                cont = cont + 1;
            } while (cont != 53);

            cont = 0;
            do
            {
                Console.SetCursorPosition(32 + cont, 22);
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(15);
                Console.WriteLine("█");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(80, 24);
                Thread.Sleep(15);
                Console.WriteLine(cont * 2 + " %");
                cont = cont + 1;
            } while (cont != 51);
        }
    }
}
