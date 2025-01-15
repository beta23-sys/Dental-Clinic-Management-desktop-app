using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    class VeteranConcession : IConcession
    {
        public string ConcessionCardId { get; set; }

        public VeteranConcession(string concessionCardId)
        {
            ConcessionCardId = concessionCardId;
        }

        public double GetDiscountedPrice(double price)
        {
            return price * 0.75; 
        }

      
    }
}
