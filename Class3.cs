using System;
using System.Collections.Generic;

namespace PizzaInternetConsole
{
    public class ContenuJson
    {
        public List<Pizza> pizzas;
        public Reglages reglages;

        public ContenuJson(List<Pizza> pizzas, Reglages reglages)
        {
            this.pizzas = pizzas;
            this.reglages = reglages;
        }
    }
}
