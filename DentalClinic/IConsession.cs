using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public interface IConcession
    {
        string ConcessionCardId { get; set; }
        double GetDiscountedPrice(double price);
    }
}
