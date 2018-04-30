using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfServiceDictionary;

/// <summary>
/// Przestrzeń nazw hosta, autor: Sławomir Stankiewicz 220994
/// </summary>
namespace WcfServiceHostRsi3
{
    /// <summary>
    /// Głowna klasa programu hosta, autor: Sławomir Stankiewicz 220994
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Metoda Main, uruchamiająca hosta
        /// </summary>
        /// <param name="args">parametry dla klasy Main, domyślny argument</param>
        public static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MyDictionary));
            try
            {
                ServiceEndpoint endpoint1 = host.Description.Endpoints.Find(typeof(IMyDictionary));
                Console.WriteLine("\n---> Endpointy:");
                Console.WriteLine("\nService endpoint {0}:", endpoint1.Name);
                Console.WriteLine("Binding: {0}", endpoint1.Binding.ToString());
                Console.WriteLine("ListenUri: {0}", endpoint1.ListenUri.ToString());

                host.Open();
                Console.WriteLine("\n--> Service1 jest uruchomiony.");

                ContractDescription cd = ContractDescription.GetContract(typeof(IMyDictionary));
                Console.WriteLine("Informacje o kontrakcie:");
                Type contractType = cd.ContractType;
                Console.WriteLine("\tContract type: {0}", contractType.ToString());
                string name = cd.Name;
                Console.WriteLine("\tName: {0}", name);
                OperationDescriptionCollection odc = cd.Operations;
                Console.WriteLine("\tOperacje:");
                foreach (OperationDescription od in odc)
                {
                    Console.WriteLine("\t\t" + od.Name);
                }

                Console.WriteLine("\n--> Nacisnij <ENTER> aby zakonczyc.");
                Console.WriteLine();
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", ce.Message);
                host.Abort();
            }
        }
    }
}
