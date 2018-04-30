using System;
using WcfServiceClientRsi3.ServiceReference1;

/// <summary>
/// Przestrzeń nazw Klienta, autor: Sławomir Stankiewicz 220994
/// </summary>
namespace WcfServiceClientRsi3
{
    /// <summary>
    /// Klasa Klienta, autor: Sławomir Stankiewicz 220994
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Główna klasa programu klienta
        /// </summary>
        /// <param name="args">parametry dla klasy Main, domyślny argument</param>
        public static void Main(string[] args)
        {
            bool exit = false;
            MyDictionaryClient dictionary = new MyDictionaryClient("WSHttpBinding_IMyDictionary");
            while (!exit)
            {
                Console.WriteLine("Opcje: ");
                Console.WriteLine("1. Dodaj parę (klucz, wartość) do słownika");
                Console.WriteLine("2. Znajdź w słowniku");
                Console.WriteLine("3. Zmień wartość w słowniku");
                Console.WriteLine("4. Usuń parę (klucz, wartość) ze słownika");
                Console.WriteLine("5. Znajdź w słowniku po wycinku klucza");
                Console.WriteLine("6. Wyswietl słownik");
                Console.WriteLine("7. Wyjdź");
                int option = 0;
                var input = Console.ReadLine();
                //kontrola poprawności wejścia
                try
                {
                    option = Int32.Parse(input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Podana opcja nie istnieje.");
                }
                //wybór opcji
                switch (option)
                {
                    case 1:
                    {
                        Console.WriteLine("Podaj klucz: ");
                        string key = Console.ReadLine();
                        Console.WriteLine("Podaj wartość: ");
                        string value = Console.ReadLine();
                        bool added = dictionary.Add(key, value);
                        if (added)
                            Console.WriteLine("Dodano nową parę (klucz, wartość).");
                        else
                            Console.WriteLine("Dodawanie nie powiodło się.");
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Podaj klucz: ");
                        string key = Console.ReadLine();
                        var value = dictionary.Find(key);
                        if (value != null)
                            Console.WriteLine("Znaleziono wartość: " + value);
                        else
                            Console.WriteLine("Nie znaleziono wartości dla klucza " + key);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Podaj klucz: ");
                        string key = Console.ReadLine();
                        Console.WriteLine("Podaj wartość: ");
                        string value = Console.ReadLine();
                        bool edited = dictionary.Edit(key, value);
                        if (edited)
                            Console.WriteLine("Zmodyfikowano wartość.");
                        else
                            Console.WriteLine("Modyfikacja nie powiodła się.");
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Podaj klucz: ");
                        string key = Console.ReadLine();
                        var removed = dictionary.Remove(key);
                        if (removed)
                            Console.WriteLine($"Usunięto wartość.");
                        else
                            Console.WriteLine("Usuwanie nie powiodło się.");
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Podaj słowo: ");
                        string word = Console.ReadLine();
                        string success = dictionary.FindByWord(word);
                        Console.WriteLine(success);
                        break;
                    }
                    case 6:
                    {
                        string all = dictionary.PrintAll();
                        Console.WriteLine(all);
                        break;
                    }
                    case 7:
                    {
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Podano złą wartość.");
                        break;
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
