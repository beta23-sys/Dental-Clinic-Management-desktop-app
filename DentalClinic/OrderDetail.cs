using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class OrderDetail
    {
        private string _orderdetailID;
        private int _qty;
        private double _cost;
        private DentalSupplies _item;
        public OrderDetail(string id, DentalSupplies item, int qty, double cost)
        {
            _orderdetailID = id;
            _qty = qty;
            _cost = cost;
            _item = item;
        }

        public DentalSupplies Item { get { return _item; } }
        public string Id { get { return _orderdetailID; } }
        public int Quantity { get { return _qty; } }
        public double Cost { get { return _cost; } }
        
    }
}
