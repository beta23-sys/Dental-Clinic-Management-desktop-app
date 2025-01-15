using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class Medication : DentalSupplies
    {
        private string _dosage;
       public Medication(string id, string name, int qty, string dosage):base(id,name,qty)
        {
            _dosage = dosage;
        }
    }
}
