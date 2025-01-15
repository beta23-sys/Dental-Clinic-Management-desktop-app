using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class Supplier
    {
        private string _supplierID;
        private string _name;
        private string _contact;
        private string _adderss;

        public Supplier(string id, string name, string contact, string address)
        {
            _supplierID = id;
            _name = name.ToUpper();
            _contact = contact;
            _adderss = address;
        }

        public void DisplaySupplier()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Contact: {_contact}");
        }

        public string Id { get { return _supplierID; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Contact { get { return _contact; } set { _contact = value; } }
        public string Address { get { return _adderss; } set { _adderss = value; } }
    }
}
