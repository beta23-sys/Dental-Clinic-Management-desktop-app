using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class SeniorConcession : IConcession
    {
        public string ConcessionCardId { get; set; }

        public SeniorConcession(string concessionCardId)
        {
            ConcessionCardId = concessionCardId;
        }

        public double GetDiscountedPrice(double price)
        {
            return price * 0.7; 
        }
    }
}
