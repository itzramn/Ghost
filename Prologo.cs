using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ghost
{
    class Prologo
    {
        public void prologo()
        {  
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            TextReader Leer_archivoF;
            Leer_archivoF = new StreamReader("dibujoFantasma.txt");
            Console.WriteLine(Leer_archivoF.ReadToEnd());
            Leer_archivoF.Close();

            TextReader Leer_archivo;
            Console.SetCursorPosition(0, 1);
            Leer_archivo = new StreamReader("mensaje1.txt");
            Thread.Sleep(1000);
            Console.WriteLine(Leer_archivo.ReadToEnd());
            Leer_archivo.Close();

            TextReader Leer_archivo2;
            Console.SetCursorPosition(0, 7);
            Leer_archivo2 = new StreamReader("mensaje2.txt");
            Thread.Sleep(3000);
            Console.WriteLine(Leer_archivo2.ReadToEnd());
            Leer_archivo.Close();
           
            TextReader Leer_archivo3;
            Console.SetCursorPosition(0, 13);
            Leer_archivo3 = new StreamReader("mensaje3.txt");
            Thread.Sleep(3000);
            Console.WriteLine(Leer_archivo3.ReadToEnd());
            Leer_archivo.Close();
            Console.SetCursorPosition(20, 21);
            Console.WriteLine("Presiona 'Enter', para continuar");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            TextReader Leer_archivo4;
            Leer_archivo4 = new StreamReader("mensaje4.txt");
            Thread.Sleep(1000);
            Console.WriteLine(Leer_archivo4.ReadToEnd());
            Leer_archivo4.Close();
            Console.WriteLine(" ");
            Console.ReadKey();
        }

    }

}
