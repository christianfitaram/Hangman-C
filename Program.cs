using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BootcampNET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine(@"
            Selecciona una opcion:
            1-> Jugar ahorcado
            2-> Salir");
            string menuOpt = Console.ReadLine();

            switch (menuOpt)
            {
                case "1":
					do
					{ 
						Game();
					}
					while(FinalQuestion());

                    break;
                case "2":
                    Console.WriteLine("Gracias por pasarte por aqui :) , Hasta la proxima.");
                    break;
                default:
                    Console.WriteLine("Un error a sucedido");
                    break;
            }


        }

        static void Game()
        {       
            //bool control = true;		// Counts tries and errors         
            int errores = 0;			// number of errors         
            string incorrectLetters = "";	// incorrect letters          
            string correctLetters = "";	// correct letters

            // Ask for a word
            Console.WriteLine("Bienvenido al juego, introduce una palabra: ");
            string palabra = Console.ReadLine();

            // Word is trimmed to avoid errors
            palabra = palabra.Trim();
            int longitud = palabra.Length;

            // Variable which stores dashes as much as there is letters in the original word
            string palabraNueva = new string('_', longitud);
            Console.WriteLine(palabraNueva);

            while (true)
            {
                // Print number of tries left
                Console.WriteLine("Tienes " + (7 - errores) + " intentos");

                ShowDraw(errores);

                // Ask for a letter
                Console.WriteLine("Introduce una letra: ");
                char letraIn = Console.ReadLine()[0];

                // Verify that introduced letter is not empty
                while (letraIn == ' ')
                {
                    Console.WriteLine("Introduce un caracter válido");
                    letraIn = Console.ReadLine()[0];
                }

                // Verifying that introduced letter is in the original word
                if (palabra.IndexOf(letraIn) > -1)
                {
					correctLetters += letraIn;

                    // In case the letter is in the original word, replace dashes with said letter
                    for (int i = 0; i < longitud; i++)
                    {
                        if (palabra[i] == letraIn)
                            palabraNueva = palabraNueva.Substring(0, i) + letraIn + palabraNueva.Substring(i + 1, longitud - (i + 1));
                    }
                    Console.WriteLine(palabraNueva);
                }
                else if (registroInc.IndexOf(letraIn) > -1)
                {
					// In case the letter is incorrect and has already been introduced, show a message
                    Console.WriteLine("Ya has intentado con la letra " + letraIn + " prueba otra.");
                }
                else
                {
					// In case an incorrect letter is introduced for the first time, add an error and store said letter
                    errores++;
					incorrectLetters += letraIn;
                    Console.WriteLine("Letra equivocada.");
                }

                // In case number of errors reaches 7
                if (errores == 7)
                {
                    Console.WriteLine("Has agotado todos tus intentos");
                    Console.WriteLine("La palabra era: " + palabra);
                    break;
                }

                // If the word is guessed
                if (palabra.Equals(palabraNueva))
                {
                    Console.WriteLine("Has ganado");
                    Console.WriteLine("La palabra era: " + palabra);
                    break;
                }            
            }
            
        }

        static void ShowDraw(int errores)
        {
            // Print a drawing according to number of mistakes
            if (errores == 1)
            {
                Console.WriteLine("====");
            }
            else if (errores == 2)
            {
                Console.WriteLine("====");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
            }
            else if (errores == 3)
            {
                Console.WriteLine("====");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" O");
            }
            else if (errores == 4)
            {
                Console.WriteLine("====");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" O");
                Console.WriteLine(" |");
            }
            else if (errores == 5)
            {
                Console.WriteLine("====");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" O");
                Console.WriteLine("/|");
            }

            else if (errores == 6)
            {
                Console.WriteLine("====");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" O");
                Console.WriteLine("/|\\");
            }
            else if (errores == 7)
            {
                Console.WriteLine("====");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" O");
                Console.WriteLine("/|\\");
                Console.WriteLine(" ^");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al dibujar el grafico.");
            }
        }

        static bool FinalQuestion()
        {
            // Ask if play again
            Console.WriteLine("Deseas volver a jugar y/n");
            string respuesta = Console.ReadLine().ToLower();
            char charRespuesta = respuesta[0];

            // Verify if introduced character is valid
            while (charRespuesta == ' ' || (charRespuesta != 'y' && charRespuesta != 'n'))
            {
                Console.WriteLine("Introduce un caracter valido:");
                respuesta = Console.ReadLine().ToLower();
                charRespuesta = respuesta[0];
            }

            // Exit the game or play again
            if (charRespuesta == 'y')
            {
				return true;
            }
            else if (charRespuesta == 'n')
            {
				return false;
			}
            //else
            //{
            //    Console.WriteLine("Ha ocurrido un error, intentalo despues.");
            //    Menu();
            //}
        }
    }


}


