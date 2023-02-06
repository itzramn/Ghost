using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost
{
    class menu : logo
    {
        private int xPosicionMenu = 33;
        private string nombreJugador = ""; 
        private int jugadoresEnLista = 4;
        private Usuarios Jugadores = new Usuarios();

        public (int, string) menuPrincipal()
        {
            int menu = 0;
            int posicion = 0;
            int posicionJugador = 1;

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            imprimirLogo(31, 1);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Jugadores.imprimirMejoresJugadores(xPosicionMenu + 40, 15, jugadoresEnLista,0);

            ConsoleKeyInfo Letra;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            iniciar(xPosicionMenu);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            perfil(xPosicionMenu);
            salir(xPosicionMenu);

            do
            {
                Letra = Console.ReadKey();
                if (Letra.Key == ConsoleKey.DownArrow && menu == 0)
                {
                    posicion++;
                    //posicionJugador++;
                }
                else if (Letra.Key == ConsoleKey.UpArrow && menu == 0)
                {
                    posicion--;
                    //posicionJugador--;
                }
                else if (Letra.Key == ConsoleKey.DownArrow && menu == 1)
                {
                    posicionJugador++;
                }
                else if (Letra.Key == ConsoleKey.UpArrow && menu == 1)
                {
                    posicionJugador--;
                }
                else if (Letra.Key == ConsoleKey.RightArrow)
                {
                    menu = 1;
                }
                else if(Letra.Key == ConsoleKey.LeftArrow)
                {
                    menu = 0;
                }
                //////////////////////////////////
                if (posicion < 0)
                {
                    posicion = 2;
                }
                if (posicion > 2)
                {
                    posicion = 0;
                }
                /////////////////////////////////
                if (posicionJugador < 1)
                {
                    posicionJugador = jugadoresEnLista;
                }
                if (posicionJugador > jugadoresEnLista)
                {
                    posicionJugador = 1;
                }

                if (menu == 0)
                {
                    //Jugadores.imprimirMejoresJugadores(xPosicionMenu + 40, 15, jugadoresEnLista, 0);
                    switch (posicion)
                    {
                        case 0: //Iniciar
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            iniciar(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            perfil(xPosicionMenu);
                            salir(xPosicionMenu);
                            break;
                        case 1: //Perfil
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            iniciar(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.Black;
                            perfil(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            salir(xPosicionMenu);
                            break;
                        case 2: //terminar el juego
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            iniciar(xPosicionMenu);
                            perfil(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            salir(xPosicionMenu);
                            if (Letra.Key == ConsoleKey.Enter)
                            {
                                Environment.Exit(1);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Jugadores.imprimirMejoresJugadores(xPosicionMenu + 40, 15, jugadoresEnLista, posicionJugador);
                    nombreJugador = Jugadores.usuarioJugando;
                }
            } while (Letra.Key != ConsoleKey.Enter);

            return (posicion, nombreJugador);
        }
        public (int, string) nuevoPerfil()
        {
            int menu = 0;
            int posicion = 0;
            int posicionJugador = 1;

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            ConsoleKeyInfo Letra;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            imprimirLogo(31, 1);

            Jugadores.imprimirMejoresJugadores(xPosicionMenu + 40, 15, jugadoresEnLista, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            iniciar(xPosicionMenu);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            registrar(xPosicionMenu);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            salir(xPosicionMenu);

            do
            {
                Letra = Console.ReadKey();
                if (Letra.Key == ConsoleKey.DownArrow && menu == 0)
                {
                    posicion++;
                    //posicionJugador++;
                }
                else if (Letra.Key == ConsoleKey.UpArrow && menu == 0)
                {
                    posicion--;
                    //posicionJugador--;
                }
                else if (Letra.Key == ConsoleKey.DownArrow && menu == 1)
                {
                    posicionJugador++;
                }
                else if (Letra.Key == ConsoleKey.UpArrow && menu == 1)
                {
                    posicionJugador--;
                }
                else if (Letra.Key == ConsoleKey.RightArrow)
                {
                    menu = 1;
                }
                else if (Letra.Key == ConsoleKey.LeftArrow)
                {
                    menu = 0;
                }
                //////////////////////////////////
                if (posicion < 0)
                {
                    posicion = 2;
                }
                if (posicion > 2)
                {
                    posicion = 0;
                }
                /////////////////////////////////
                if (posicionJugador < 1)
                {
                    posicionJugador = jugadoresEnLista;
                }
                if (posicionJugador > jugadoresEnLista)
                {
                    posicionJugador = 1;
                }
                if(menu == 0)
                {
                    Jugadores.imprimirMejoresJugadores(xPosicionMenu + 40, 15, jugadoresEnLista, 5);
                    switch (posicion)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            iniciar(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            registrar(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            salir(xPosicionMenu);
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            iniciar(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.Black;
                            registrar(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            salir(xPosicionMenu);
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            iniciar(xPosicionMenu);
                            registrar(xPosicionMenu);
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            salir(xPosicionMenu);
                            if (Letra.Key == ConsoleKey.Enter)
                            {
                                Environment.Exit(1);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if(posicion != 1)
                    {
                        Jugadores.imprimirMejoresJugadores(xPosicionMenu + 40, 15, jugadoresEnLista, posicionJugador);
                        nombreJugador = Jugadores.usuarioJugando;
                    }
                }
                if(posicion == 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    limpiar(xPosicionMenu + 40);
                    if(menu == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPosicionMenu + 40, 17);
                        Console.Write("REGISTRAR USUARIO");
                        dibujar(xPosicionMenu + 40, 20);
                        Console.SetCursorPosition(xPosicionMenu + 41, 20);
                        Console.Write("Name: ");
                        nombreJugador =  Console.ReadLine();
                        Jugadores.registrarUsuario(nombreJugador);
                        Console.SetCursorPosition(xPosicionMenu + 41, 20);
                        Console.Write("REGISTRO EXISTOSO");
                        limpiar(xPosicionMenu + 40);
                        posicion = 0;
                        menu = 0;
                        break;
                    }
                    
                }

            } while (Letra.Key != ConsoleKey.Enter);
            if(posicion == 2)
            {
                posicion = 3;
            }
            return (posicion, nombreJugador);
        }
    }
}
