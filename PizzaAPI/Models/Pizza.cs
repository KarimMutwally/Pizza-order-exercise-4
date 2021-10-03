using System;
using System.Collections.Generic;
using System.Linq;

namespace PIZZAAPI
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Topping> Toppings { get; set; } = new();
        public string PizzaSize { get; set; }
        public double Price { get; set; }
        public double DefaultPrice { get; set; }
        public Boolean IsCustomed { get; set; }

        public Pizza (int id, string name, List<Topping> toppings, string pizzaSize, Boolean isCustomed)
        {
            this.Id = id;
            this.Name = name;
            this.Toppings = toppings;
            this.PizzaSize = pizzaSize;
            this.DefaultPrice = toppings.Sum(topping => topping.Price);
            this.IsCustomed = isCustomed;
            var priceFactor = 0;
            switch (this.PizzaSize)
            {
                case "Small":
                priceFactor = 120;
                break;
                case "Medium":
                priceFactor = 150;
                break;
                case "Large":
                priceFactor = 175;
                break;
                default: 
                priceFactor = 0;
                break;
            }
            this.Price = this.DefaultPrice * priceFactor / 100;
        }

        public override string ToString()
        {
            return $"{this.Name} S:{this.DefaultPrice * ((double)Size.Small) / 100} " + 
                   $"M:{this.DefaultPrice * ((double)Size.Medium) / 100} " + 
                   $"L:{this.DefaultPrice * ((double)Size.Large) / 100} LE";
        }  
    }

    public class Topping
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }

        public Topping(int id, String name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Price} LE";
        }  
    }
}