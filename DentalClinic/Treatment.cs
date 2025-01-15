using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class Treatment
    {
        private string _treatmentID;
        private string _name;
        private double _cost;
        static private Dentist _dentist;
        private Dictionary<string, int> _treatmentsupplies;
        public Treatment(string id, string name, double cost)
        {
            _treatmentID = id;
            _name = name.ToUpper();
            _cost = cost;
            _treatmentsupplies = new Dictionary<string, int>();
        }

        public void AddSupply(string supplyId, int quantity)
        {
            if (_treatmentsupplies.ContainsKey(supplyId))
            {
                _treatmentsupplies[supplyId] += quantity;
            }
            else
            {
                _treatmentsupplies[supplyId] = quantity;
            }
        }

        public void RemoveSupply(string supplyId)
        {
            if (_treatmentsupplies.ContainsKey(supplyId))
            {
                _treatmentsupplies.Remove(supplyId);
            }
        }

        public void UpdateDentistTreatment(Dentist dentist)
        {
            _dentist = dentist;
        }

      

        public void DisplayTreatment()
        {
            if (_dentist != null)
            {
                Console.WriteLine($"ID: { Id}, Name: { Name}, Dentist: {_dentist.Name}");
            }
            else
            {
                Console.WriteLine($"ID: { Id}, Name: { Name}, Dentist: Not assigned");
            }
            
          
               
        }

        public string Id
        {
            get { return _treatmentID; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public Dictionary<string, int> TreatmentSupplpies
        {
            get { return _treatmentsupplies; }
        }
    }
}
