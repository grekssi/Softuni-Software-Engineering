using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;
        protected Table(int tableNumber, decimal pricePerPerson, int capacity)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public IReadOnlyCollection<IFood> FoodOrders => this.foodOrders.AsReadOnly();
        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders.AsReadOnly();

        public int TableNumber
        {
            get => this.tableNumber;
            set => this.tableNumber = value;
        }
        public int Capacity
        {
            get => this.capacity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson
        {
            get => this.pricePerPerson;
            set => this.pricePerPerson = value; 
        }
        public bool IsReserved
        {
            get => this.isReserved;
            set => this.isReserved = value;
        }

        public decimal Price => this.numberOfPeople * this.pricePerPerson;
        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal sum = (this.drinkOrders.Sum(x => x.Price) + this.foodOrders.Sum(x => x.Price)) + this.Price;
            return sum;
        }

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {this.tableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {this.tableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            if (!foodOrders.Any())
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");
                foreach (var foodOrder in foodOrders)
                {
                    sb.AppendLine(foodOrder.ToString());
                }
            }

            if (!drinkOrders.Any())
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");
                foreach (var drinkOrder in drinkOrders)
                {
                    sb.AppendLine(drinkOrder.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
