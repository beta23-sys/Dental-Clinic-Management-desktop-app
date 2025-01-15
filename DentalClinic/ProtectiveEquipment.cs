using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class ProtectiveEquipment:DentalSupplies
    {
        public ProtectiveEquipment(string id, string name, int qty)
        : base(id, name, qty)
        {
        }
    }
}
