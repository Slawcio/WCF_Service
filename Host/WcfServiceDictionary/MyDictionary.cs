using System;
using System.Collections.Generic;
using System.ServiceModel;

/// <summary>
/// Przestrzeń nazw słownika, autor: Sławomir Stankiewicz 220994
/// </summary>
namespace WcfServiceDictionary
{
    /// <summary>
    /// Klasa słownika implementująca interfejs IMyDictionary, autor: Sławomir Stankiewicz 220994
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyDictionary : IMyDictionary
    {
        private Dictionary<string, string> myDictionary = new Dictionary<string, string>();

        /// <summary>
        /// Metoda dodająca do słownika klucz i odpowiadającą mu wartość
        /// </summary>
        /// <param name="key">Klucz (słowo w języku polskim)</param>
        /// <param name="value">Wartość (słowo w języku angielskim)</param>
        /// <returns>Wartość true, jeżeli dodwanie powiodło się lub false jeżeli nie.</returns>
        public bool Add(string key, string value)
        {
            try
            {
                myDictionary.Add(key, value);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda wyszukująca wartość w słowniku na podstawie klucza
        /// </summary>
        /// <param name="key">Klucz (słowo w języku polskim)</param>
        /// <returns>Wartość odpowiadającą kluczowi lub null jeżeli klucz nie występuje w słowniku</returns>
        public string Find(string key)
        {
            myDictionary.TryGetValue(key, out string result);
            return result;
        }

        /// <summary>
        /// Metoda modyfikująca parę (klucz, wartość) w słowniku
        /// </summary>
        /// <param name="key">Klucz (słowo w języku polskim)</param>
        /// <param name="value">Wartość (słowo w języku angielskim)</param>
        /// <returns>Wartość true, jeżeli modyfikowanie powiodło się lub false jeżeli nie.</returns>
        public bool Edit(string key, string value)
        {
            bool success = myDictionary.Remove(key);
            if (success)
            {
                try
                {
                    myDictionary.Add(key, value);
                }
                catch (Exception e)
                {
                    success = false;
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Metoda znajdująca wartość lub klucz w słowniku zawierającą określone słowo
        /// </summary>
        /// <param name="word">Słowo na podstawie którego szukamy wartości</param>
        /// <returns>Wartości i klucze pasujące do podanego słowa</returns>
        public string FindByWord(string word)
        {
            string results = "";
            foreach (var item in myDictionary)
            {
                if(item.Value.Contains(word) || item.Key.Contains(word))
                {
                    string newEntry = "\n" + item.Key + " ==> " + item.Value;
                    results += newEntry;
                }
            }
            if (results == "")
                return "Brak wartości pasujących do wzorca";
            else
                return results;
        }

        /// <summary>
        /// Metoda zwracająca wszystkie wartości w słowniku
        /// </summary>
        /// <returns>Wszystkie wartości w słowniku w postaci jednej wartości string</returns>
        public string PrintAll()
        {
            string allvalues = "";
            foreach (var item in myDictionary)
            {
                allvalues += item.Key + " ==> " + item.Value + "\n";
            }

            return allvalues;
        }

        /// <summary>
        /// Metoda usuwająca parę (klucz, wartość) ze słownika
        /// </summary>
        /// <param name="key">Klucz (słowo w języku polskim)</param>
        /// <returns>Wartość true, jeżeli usuwanie powiodło się lub false jeżeli nie.</returns>
        public bool Remove(string key)
        {
            bool success = myDictionary.Remove(key);
            return success;
        }
    }

    

      
}
