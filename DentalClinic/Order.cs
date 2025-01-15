using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{

    public class Order
    {
        private string _orderID;
        private Supplier _supplier;
        private DateTime _orderdate;
        private List<OrderDetail> _listitems;
        private double _totalAmoutofOrder;

        public Order(string id, Supplier supplier, DateTime orderDate, List<OrderDetail> listorderofitems, double totalAmoutofOder)
        {
            _orderID = id;
            _supplier = supplier;
            _orderdate = orderDate;
            _listitems = listorderofitems;
            _totalAmoutofOrder = totalAmoutofOder;
        }

        public void UpdateInventoryIncrease(List<DentalSupplies> dentalSupplies)
        {
            foreach(OrderDetail i in _listitems)
            {
                foreach(DentalSupplies d in dentalSupplies)
                {
                    if(i.Item.Id==d.Id)
                    {
                        d.IncreaseQuantity(i.Quantity);
                    }
                }
            }
        }

        public double TotalAmountofOrder { get { return _totalAmoutofOrder; } }

        public string Id { get { return _orderID; } }        

        public Supplier OrderSupplier
        {
            get { return _supplier; }
        }

        public DateTime OrderDate
        {
            get { return _orderdate; }
        }
    

        public List<OrderDetail> Listitem
        {
            get { return _listitems; }
        }

        
    }
}
