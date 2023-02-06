using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ghost
{
    class logo
    {
        protected void imprimirLogo(int x, int y)
        {
            StreamReader cargarNombre = new StreamReader(@"Splash\NombreJuego.txt");
            String line;

            Console.CursorVisible = false;
            Console.Clear();
            line = cargarNombre.ReadLine();
            Console.SetCursorPosition(31, 1);
            while (line != null)
            {
                Console.WriteLine(line);
                line = cargarNombre.ReadLine();
            }
            cargarNombre.Close();
        }
        public void gameOver()
        {
            //GAME OVER
            Console.SetCursorPosition(2, 3);
            Console.ForegroundColor = ConsoleColor.Gray;
            StreamReader archivo = new StreamReader(@"GameOver.txt");
            string linea = "";
            ArrayList arrText = new ArrayList();
            while (linea != null)
            {
                linea = archivo.ReadLine();
                if (linea != null)
                    arrText.Add(linea);
            }
            archivo.Close();
            foreach (string salida in arrText)
                Console.WriteLine(salida);
            Thread.Sleep(5000);
        }
        protected void iniciar(int xPosicionMenu)
        {
            Console.SetCursorPosition(xPosicionMenu, 17);
            Console.WriteLine("           __    __   __     ");
            Console.SetCursorPosition(xPosicionMenu, 18);
            Console.WriteLine(" | |\\ | | |   | |__| |__|    ");
            Console.SetCursorPosition(xPosicionMenu, 19);
            Console.WriteLine(" | | \\| | |__ | |  | | |     ");
            Console.SetCursorPosition(xPosicionMenu, 20);
            Console.WriteLine("                             ");
        }
        protected void perfil(int xPosicionMenu)
        {
            Console.SetCursorPosition(xPosicionMenu, 22);
            Console.WriteLine("  __   __  __   __           ");
            Console.SetCursorPosition(xPosicionMenu, 23);
            Console.WriteLine(" |__| |_  |__| |_  | |       ");
            Console.SetCursorPosition(xPosicionMenu, 24);
            Console.WriteLine(" |    |__ | |  |   | |__     ");
            Console.SetCursorPosition(xPosicionMenu, 25);
            Console.WriteLine("                             ");
        }
        protected void salir(int xPosicionMenu)
        {
            Console.SetCursorPosition(xPosicionMenu, 27);
            Console.WriteLine("  __   __         __         ");
            Console.SetCursorPosition(xPosicionMenu, 28);
            Console.WriteLine(" |__  |__| |   | |__|        ");
            Console.SetCursorPosition(xPosicionMenu, 29);
            Console.WriteLine("  __| |  | |__ | | |         ");
            Console.SetCursorPosition(xPosicionMenu, 30);
            Console.WriteLine("                             ");
        }
        protected void registrar(int xPosicionMenu)
        {
            Console.SetCursorPosition(xPosicionMenu, 22);
            Console.WriteLine("  __   __  __     __ ___  __   __   __ ");
            Console.SetCursorPosition(xPosicionMenu, 23);
            Console.WriteLine(" |__| |_  | _  | |__  |  |__| |__| |__|");
            Console.SetCursorPosition(xPosicionMenu, 24);
            Console.WriteLine(" | |  |__ |__| |  __| |  | |  |  | | | ");
            Console.SetCursorPosition(xPosicionMenu, 25);
            Console.WriteLine("                                       ");
        }
        protected void limpiar(int xPosicion)
        {
            for(int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(xPosicion, i + 17);
                Console.WriteLine("                      ");
            }
        }

        protected void dibujar(int x, int y)
        {
            int cont;
            Console.SetCursorPosition(x, y - 1);
            Console.WriteLine("╔");
            Console.SetCursorPosition(x, y);
            Console.WriteLine("║");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("╚");
            Console.SetCursorPosition(x + 20, y - 1);
            Console.WriteLine("╗");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine("║");
            Console.SetCursorPosition(x + 20, y + 1);
            Console.WriteLine("╝");

            cont = 0;
            do
            {
                Console.SetCursorPosition(x + 1 + cont, y - 1);
                Console.WriteLine("═");
                Console.SetCursorPosition(x + 1 + cont, y + 1);
                Console.WriteLine("═");
                cont = cont + 1;
            } while (cont != 19);
        }
    }
}
