using System;
namespace PizzaInternetConsole
{
    public class Pizza
    {
        private string nom;
        private int prix;
        private string[] ingredients;
        private bool vegetarienne;

        // Constructeur
        public Pizza(string nom, int prix, string[] ingredients, bool vegetarienne)
        {
            this.nom = nom;
            this.prix = prix;
            this.ingredients = ingredients;
            this.vegetarienne = vegetarienne;
        }

        public void Afficher()
        {
            string isVegeStr = vegetarienne ? " (V)" : "";

            Console.WriteLine("Pizza: " + nom + isVegeStr + " - " + prix + "€");
            Console.WriteLine(String.Join(", ", ingredients));
            Console.WriteLine("");
        }

        public int Prix
        {
            get { return prix; }
        }

        public string Nom
        {
            get { return nom; }
        }
    }
}
