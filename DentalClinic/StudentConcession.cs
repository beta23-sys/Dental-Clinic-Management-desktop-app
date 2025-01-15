using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class StudentConcession : IConcession
    {
        public string ConcessionCardId { get; set; }

        public StudentConcession(string concessionCardId)
        {
            ConcessionCardId = concessionCardId;
        }

        public double GetDiscountedPrice(double price)
        {
            return price * 0.8; 
        }
    }
}
