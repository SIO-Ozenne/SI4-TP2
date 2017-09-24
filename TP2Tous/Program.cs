using System;

// ReSharper disable TooWideLocalVariableScope
// ReSharper disable InlineOutVariableDeclaration
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable ArrangeTypeModifiers
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable InconsistentNaming
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable JoinDeclarationAndInitializer

namespace TP2Tous
{
    class Program
    {
        const string SEPARATEUR = "==========================";

        static void Main()
        {
            Console.Title = "Exos TP2";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool stop = false;
            do
            {
                Console.Clear();
                AfficherMenu();

                bool valid = false;
                while (!valid)
                {
                    Console.Write("> ");
                    ConsoleKeyInfo selection = Console.ReadKey(true);
                    switch(selection.Key)
                    {
                        case ConsoleKey.NumPad0:
                            valid = true;
                            stop = true;
                            break;
                        case ConsoleKey.NumPad1:
                            Console.Clear();
                            CalculMoyenne();
                            valid = true;
                            break;
                        case ConsoleKey.NumPad2:
                            Console.Clear();
                            EchangeValeurs();
                            valid = true;
                            break;
                        case ConsoleKey.NumPad3:
                            Console.Clear();
                            PrixBouteilles();
                            valid = true;
                            break;
                        case ConsoleKey.NumPad4:
                            Console.Clear();
                            CalculPrime();
                            valid = true;
                            break;
                        case ConsoleKey.NumPad5:
                            Console.Clear();
                            ProduitNombres();
                            valid = true;
                            break;
                        default:
                            ColorWrite(ConsoleColor.Red, "Saisie erronée.");
                            break;
                    }
                }

                Console.Clear();
                if (!stop)
                {
                    ColorWrite(ConsoleColor.Cyan, "Revenir au menu? (O/N)");
                    ConsoleKeyInfo response = Console.ReadKey(true);

                    if (response.Key == ConsoleKey.N)
                        stop = true;
                }
            }
            while (!stop);

            Console.Clear();
            ColorWrite(ConsoleColor.Green, "Programme terminé, appuyez sur une touche pour continuer...");
            Console.ReadKey(true);
        }

        public static void AfficherMenu()
        {
            Console.Title = "Menu";

            ColorWrite(ConsoleColor.Cyan, SEPARATEUR);
            ColorWrite(ConsoleColor.Yellow, "Appuyez sur une touche du pavé numérique pour choisir un programme:");
            ColorWrite(ConsoleColor.Cyan, SEPARATEUR);
            ColorWrite(ConsoleColor.Yellow, "1- Calcul Moyennes");
            ColorWrite(ConsoleColor.Yellow, "2- Echange de valeurs");
            ColorWrite(ConsoleColor.Yellow, "3- Prix Bouteilles");
            ColorWrite(ConsoleColor.Yellow, "4- Saisie d'informations, calcul de prime");
            ColorWrite(ConsoleColor.Yellow, "5- Produit de nombres");
            ColorWrite(ConsoleColor.Cyan, SEPARATEUR);
            ColorWrite(ConsoleColor.Yellow, "0- Quitter");
            ColorWrite(ConsoleColor.Cyan, SEPARATEUR);
        }

        public static void CalculMoyenne()
        {
            Console.Title = "Calcul de moyenne";

            double note1, note2, note3, note4, note5, moyenne;
            string strNote1, strNote2, strNote3, strNote4, strNote5;

            Console.WriteLine("Entrez vos 5 notes: ");
            Console.Write("Note 1: ");
            strNote1 = Console.ReadLine();
            Console.Write("Note 2: ");
            strNote2 = Console.ReadLine();
            Console.Write("Note 3: ");
            strNote3 = Console.ReadLine();
            Console.Write("Note 4: ");
            strNote4 = Console.ReadLine();
            Console.Write("Note 5: ");
            strNote5 = Console.ReadLine();

            if (strNote1 == null || strNote2 == null || strNote3 == null || strNote4 == null || strNote5 == null)
            {
                ColorWrite(ConsoleColor.Red, "Erreur de saisie des notes.");
                Console.WriteLine();
                return;
            }

            try
            {
                if (!double.TryParse(strNote1, out note1))
                    throw new FormatException();

                if (!double.TryParse(strNote2, out note2))
                    throw new FormatException();

                if (!double.TryParse(strNote3, out note3))
                    throw new FormatException();

                if (!double.TryParse(strNote4, out note4))
                    throw new FormatException();

                if (!double.TryParse(strNote5, out note5))
                    throw new FormatException();
            }
            catch
            {
                ColorWrite(ConsoleColor.Red, "Erreur de conversion des notes.");
                Console.ReadKey(true);
                return;
            }

            moyenne = (note1 + note2 + note3 + note4 + note5) / 5;

            Console.WriteLine();
            Console.WriteLine("Moyenne des notes ({0}, {1}, {2}, {3}, {4})", note1, note2, note3, note4, note5);
            Console.WriteLine(moyenne);

            Console.ReadKey();
        }

        public static void EchangeValeurs()
        {
            Console.Title = "Echange de valeurs";

            int nb1, nb2, tmp;
            string strNb1, strNb2;

            Console.Write("Entrez le nombre 1: ");
            strNb1 = Console.ReadLine();
            Console.Write("Entrez le nombre 2: ");
            strNb2 = Console.ReadLine();

            try
            {
                if (!int.TryParse(strNb1, out nb1))
                    throw new FormatException();

                if(!int.TryParse(strNb2, out nb2))
                    throw new FormatException();
            }
            catch
            {
                ColorWrite(ConsoleColor.Red, "Erreur de conversion des notes.");
                Console.ReadKey(true);
                return;
            }

            Console.Clear();

            Console.WriteLine("Avant échange:");
            Console.WriteLine(SEPARATEUR);
            Console.WriteLine("nb1: " + nb1);
            Console.WriteLine("nb2: " + nb2);
            Console.WriteLine();

            tmp = nb2;
            nb2 = nb1;
            nb1 = tmp;

            Console.WriteLine("Après échange:");
            Console.WriteLine(SEPARATEUR);
            Console.WriteLine("nb1: " + nb1);
            Console.WriteLine("nb2: " + nb2);

            Console.ReadKey();
        }

        public static void PrixBouteilles()
        {
            Console.Title = "Prix des bouteilles";

            double prix1_5, prix1_0, prixPack6, prixPack50;
            string strPrix;

            Console.Write("Entrez le prix en euros d'une bouteille d'eau (1.5L): ");
            strPrix = Console.ReadLine();

            if (!double.TryParse(strPrix, out prix1_5))
            {
                ColorWrite(ConsoleColor.Red, "Erreur de saisie du prix.");
                Console.ReadKey(true);
                return;
            }

            prix1_0 = prix1_5 - prix1_5 / 3;
            prixPack6 = prix1_5 * 5;
            prixPack50 = prix1_5 * 45;

            Console.WriteLine();
            Console.WriteLine("Prix:");
            Console.WriteLine(" - au litre:\t\t\t\t{0}€", prix1_0);
            Console.WriteLine(" - d'un pack de 6 (1 offerte):\t\t{0}€", prixPack6);
            Console.WriteLine(" - d'un pack de 50 (5 offertes):\t{0}€", prixPack50);

            Console.ReadKey();
        }

        public static void CalculPrime()
        {
            Console.Title = "Calcul de prime";

            bool valid = false;

            string nom, prenom;
            int annee;
            double salaire;
            char cadre = '\0';

            string strAnnee, strSalaire;
            ConsoleKeyInfo repCadre;

            Console.WriteLine("Saisir les informations:");
            Console.WriteLine(SEPARATEUR);
            Console.Write("\t\tNom: ");
            nom = Console.ReadLine();
            Console.Write("\t\tPrénom: ");
            prenom = Console.ReadLine();

            do
            {
                Console.Write("\t\tCadre (O/N): ");
                repCadre = Console.ReadKey();
                Console.Write('\n');
                if (repCadre.Key == ConsoleKey.O || repCadre.Key == ConsoleKey.N)
                {
                    cadre = repCadre.KeyChar;
                    valid = true;
                }
                else
                {
                    ColorWrite(ConsoleColor.Red, "Saisie erronée.");
                }
            } while (!valid);

            valid = false;

            do
            {
                Console.Write("\t\tAnnée embauche: ");
                strAnnee = Console.ReadLine();
                if (int.TryParse(strAnnee, out annee))
                    valid = true;
                else
                    ColorWrite(ConsoleColor.Red, "Saisie erronée.");
            } while (!valid);

            valid = false;

            do
            {
                Console.Write("\t\tSalaire: ");
                strSalaire = Console.ReadLine();
                if (double.TryParse(strSalaire, out salaire))
                    valid = true;
                else
                    ColorWrite(ConsoleColor.Red, "Saisie erronée.");
            } while (!valid);

            Console.WriteLine();
            Console.WriteLine("Calcul:");
            Console.WriteLine(SEPARATEUR);
            Console.WriteLine("\t\tNom:\t\t{0} {1}", nom?.ToUpper(), prenom);
            Console.WriteLine("\t\tCadre:\t\t{0}", cadre.ToString().ToUpper());
            Console.WriteLine("\t\tAnnée embauche:\t{0}", annee);
            Console.WriteLine("\t\tSalaire:\t{0}", salaire);
            Console.WriteLine("\t\tPrime:\t\t{0}", salaire * 0.08);

            Console.ReadKey();
        }

        public static void ProduitNombres()
        {
            Console.Title = "Produits de nombres";

            int nombreA, nombreB, resultat;
            string strNombreA, strNombreB;
            bool valid = false;

            do
            {
                Console.Write("Entrez le nombre 1: ");
                strNombreA = Console.ReadLine();
                if (int.TryParse(strNombreA, out nombreA))
                    valid = true;
                else
                    ColorWrite(ConsoleColor.Red, "Saisie erronée.");
            } while (!valid);

            Console.WriteLine();
            valid = false;

            do
            {
                Console.Write("Entrez le nombre 2: ");
                strNombreB = Console.ReadLine();
                if (int.TryParse(strNombreB, out nombreB))
                    valid = true;
                else
                    ColorWrite(ConsoleColor.Red, "Saisie erronée.");
            } while (!valid);

            resultat = nombreA * nombreB;

            Console.WriteLine();
            Console.WriteLine("Calcul:");
            Console.WriteLine(SEPARATEUR);
            Console.WriteLine("{0} * {1} = {2}", nombreA, nombreB, resultat);

            Console.ReadKey();
        }

        public static void ColorWrite(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
