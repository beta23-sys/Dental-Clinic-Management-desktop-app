using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class DentalTool : DentalSupplies
    {
        public DentalTool(string id, string name, int qty)
       : base(id, name, qty)
        {
        }
    }
}
