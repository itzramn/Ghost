using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost///
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Instancia las clases
            pantallaDeCarga pantallaDeCarga = new pantallaDeCarga();
            musica reproducir = new musica();
            Usuarios usuarios = new Usuarios();
            Prologo prologo = new Prologo();
            Flappy flappy = new Flappy(75, 20);
            menu menu = new menu();
            int opcion = 3;
            string nombreJugador = "";
            Console.SetWindowSize(120, 31);
            pantallaDeCarga.Splash();
            reproducir.musicafondo();
            do
                {
                    Console.SetWindowSize(120, 31);
                    if (opcion == 3)
                    {
                        (opcion, nombreJugador) = menu.menuPrincipal();
                    }
                    else if (opcion == 0)
                    {
                        Console.SetWindowSize(120, 31);
                         prologo.prologo();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Title = " Console The ghost";
                        Console.CursorVisible = false;
                        flappy.Run(nombreJugador);
                        opcion = 3;
                    }
                    else if (opcion == 1)
                    {
                        (opcion, nombreJugador) = menu.nuevoPerfil();
                    }
                    else if (opcion == 2)
                    {
                        Environment.Exit(1);
                    }
                    Console.Clear();
                } while (true);
            
        }
    }
}
