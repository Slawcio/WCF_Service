using System.ServiceModel;

/// <summary>
/// Przestrzeń nazw słownika, autor: Sławomir Stankiewicz 220994
/// </summary>
namespace WcfServiceDictionary
{
    /// <summary>
    /// Interfejs słownika, autor: Sławomir Stankiewicz 220994
    /// </summary>
    [ServiceContract]
    public interface IMyDictionary
    {
        /// <summary>
        /// Metoda dodająca do słownika klucz i odpowiadającą mu wartość
        /// </summary>
        /// <param name="key">Klucz (słowo w języku polskim)</param>
        /// <param name="value">Wartość (słowo w języku angielskim)</param>
        /// <returns>Wartość true, jeżeli dodwanie powiodło się lub false jeżeli nie.</returns>
        [OperationContract]
        bool Add(string key, string value);

        /// <summary>
        /// Metoda usuwająca parę (klucz, wartość) ze słownika
        /// </summary>
        /// <param name="key">Klucz (słowo w języku polskim)</param>
        /// <returns>Wartość true, jeżeli usuwanie powiodło się lub false jeżeli nie.</returns>
        [OperationContract]
        bool Remove(string key);

        /// <summary>
        /// Metoda modyfikująca parę (klucz, wartość) w słowniku
        /// </summary>
        /// <param name="key">Klucz (słowo w języku polskim)</param>
        /// <param name="value">Wartość (słowo w języku angielskim)</param>
        /// <returns>Wartość true, jeżeli modyfikowanie powiodło się lub false jeżeli nie.</returns>
        [OperationContract]
        bool Edit(string key, string value);

        /// <summary>
        /// Metoda wyszukująca wartość po kluczu w słowniku
        /// </summary>
        /// <param name="key">Klucz (słowo w języku polskim)</param>
        /// <returns>Wartość dopasowaną do klucza(string) lub null jeżeli nie znaleziono</returns>
        [OperationContract]
        string Find(string key);

        /// <summary>
        /// Metoda znajdująca wartość lub klucz w słowniku zawierającą określone słowo
        /// </summary>
        /// <param name="word">Słowo na podstawie którego szukamy wartości</param>
        /// <returns>Wartości i klucze pasujące do podanego słowa</returns>
        [OperationContract]
        string FindByWord(string word);

        /// <summary>
        /// Metoda zwracająca wszystkie wartości w słowniku
        /// </summary>
        /// <returns>Wszystkie wartości w słowniku w postaci jednej wartości string</returns>
        [OperationContract]
        string PrintAll();
    }

}
