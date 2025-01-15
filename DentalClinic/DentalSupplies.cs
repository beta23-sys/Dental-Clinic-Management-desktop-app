using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class DentalSupplies
    {
        private string _dentalsupplyID;
        private string _name;
        private int _qty;

        public DentalSupplies(string id, string name, int qty)
        {
            _dentalsupplyID = id;
            _name = name.ToUpper();
            _qty = qty;
        }

        public void IncreaseQuantity(int quantity)
        {
            _qty += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            if (_qty >= quantity)
            {
                _qty -= quantity;
            }
            else
            {
                Console.WriteLine("Error - Insufficient stock to decrease.");
            }
        }

        public void DisplaySupplies()
        {
            if (_qty < 20)
            {
                Console.WriteLine($"ID: {Id}, Name: {Name}, Quantity: {Quantity} | [Low Stock!]");
            }
            else
            {
                Console.WriteLine($"ID: {Id}, Name: {Name}, Quantity: {Quantity} ");
            }
        }

        public string Id
        {
            get { return _dentalsupplyID; }
        }

        public string Name { get { return _name; } }

        public int Quantity 
        { 
            get { return _qty; } 
            set { _qty = value; } 
        }
    }
}
