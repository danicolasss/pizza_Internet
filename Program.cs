using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace PizzaInternetConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            // https://codeavecjonathan.com/res/pizzas1.json

            const string URL = "https://codeavecjonathan.com/res/pizzas4.json";

            //string pizzasJson = "[{\"nom\":\"4 fromages\",\"prix\":9,\"ingredients\":[\"bleu\",\"emmental\",\"brie\",\"reblochon\"]},{\"nom\":\"Végétarienne\",\"prix\":7,\"ingredients\":[\"tomates\",\"poivrons\"]}]";

            string pizzasJson = "";

            Console.Write("Téléchargement... ");

            using (var webclient = new WebClient())
            {
                try
                {
                    pizzasJson = webclient.DownloadString(URL);
                    Console.WriteLine("OK");
                }
                catch (WebException ex)
                {
                    string message = ex.Message;
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        message = "Vérifiez votre URL";
                    }
                    if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                    {
                        message = "Vérifiez votre accès réseau";
                    }

                    Console.WriteLine("ERREUR: " + message);
                    return;
                }


            }

            // ContenuJson
            // pizzas -> List<Pizza>
            // reglages -> "tri" string


            ContenuJson contenuJson = JsonConvert.DeserializeObject<ContenuJson>(pizzasJson);

            List<Pizza> pizzas = contenuJson.pizzas;


            // Tri
            if (contenuJson.reglages.tri.Equals("prix"))
            {
                pizzas.Sort((p1, p2) => { return p2.Prix.CompareTo(p1.Prix); });
            }
            else if (contenuJson.reglages.tri.Equals("nom"))
            {
                pizzas.Sort((p1, p2) => { return p1.Nom.CompareTo(p2.Nom); });
            }


            foreach (Pizza p in pizzas)
            {
                p.Afficher();
            }
        }
    }
}
