﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            messageDebut();
            menu();
            bool recommencer = false, toucheMenu = false, partie = true, recommencerTouche = false;
            int valeurATrouver = 0, saisieNombre, tentative = 0;
            while (partie)
            {
                while (!toucheMenu)
                {
                    ConsoleKeyInfo touche = Console.ReadKey(true);
                    if (touche.Key == ConsoleKey.F1)
                    {
                        valeurATrouver = configurationDebut("FACILE", 100);
                        recommencer = true;
                        toucheMenu = true;
                    }
                    else if (touche.Key == ConsoleKey.F2)
                    {
                        valeurATrouver = configurationDebut("MOYEN", 500);
                        recommencer = true;
                        toucheMenu = true;
                    }
                    else if (touche.Key == ConsoleKey.F3)
                    {
                        valeurATrouver = configurationDebut("DIFFICILE", 1000);
                        recommencer = true;
                        toucheMenu = true;
                    }
                    else if (touche.Key == ConsoleKey.F4)
                    {
                        valeurATrouver = configurationDebut("EXTREME", 10000);
                        recommencer = true;
                        toucheMenu = true;
                    }
                    else
                        Console.WriteLine("Mauvaise touche !");
                }
            
                while (recommencer)
                {
                    Console.WriteLine("Saississez un nombre :");
                    tentative++;
                    string saisie = Console.ReadLine();
                    if (int.TryParse(saisie, out saisieNombre))
                        if (saisieNombre == valeurATrouver)
                        {
                            Console.Clear();
                            messageDebut();
                            Console.WriteLine("Vous avez gagné !");
                            Console.WriteLine("Vous avez trouvé le nombre en "+tentative+" essais!");
                            Console.WriteLine("Appuyez sur O pour rejouer et N pour quitter");
                            recommencer = false;
                        }
                        else if (saisieNombre > valeurATrouver)
                            Console.WriteLine("C'est moins !");
                        else if (saisieNombre < valeurATrouver)
                            Console.WriteLine("C'est plus !");

                }
                while (!recommencerTouche)
                {
                    ConsoleKeyInfo touche2 = Console.ReadKey(true);
                    if (touche2.Key == ConsoleKey.N)
                    {
                        recommencer = false;
                        recommencerTouche = true;
                        partie = false;
                    }
                    else if (touche2.Key == ConsoleKey.O)
                    {
                        recommencer = true;
                        recommencerTouche = true;
                    }
                    else
                        Console.WriteLine("Mauvaise touche !");
                }

                recommencer = false;
                toucheMenu = false;
                recommencerTouche = false;
                Console.Clear();
                messageDebut();
                menu();
                tentative = 0;
            }

        }

        static void messageDebut()
        {
            CentrerLeTexte("/|---------------------------------------------------|\\");
            CentrerLeTexte("Voici le jeu du PLUS OU MOINS");
            CentrerLeTexte(" Créer par Sauvajohn");
            CentrerLeTexte("/|---------------------------------------------------|\\\n\n");
        }
        static void menu()
        {
            CentrerLeTexte("/****************************************************\\");
            CentrerLeTexte("Voici le menu du jeu, Veuillez choisir une difficulté :");
            CentrerLeTexte("<F1> - Facile    (1-100)");
            CentrerLeTexte("<F2> - Moyen     (1-500)");
            CentrerLeTexte("<F3> - Difficile (1-1000)");
            CentrerLeTexte("<F4> - Extrème   (1-10000)");
            CentrerLeTexte("\\****************************************************/");

        }
        static int configurationDebut(string difficulter, int nombreMaxi)
        {
            Console.Clear();
            messageDebut();
            CentrerLeTexte("**"+difficulter+"**");
            int valeurATrouver = new Random().Next(0, nombreMaxi);
            return valeurATrouver;
        }

        private static void CentrerLeTexte(string texte)
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.WriteLine(texte);
        }
    }
}
