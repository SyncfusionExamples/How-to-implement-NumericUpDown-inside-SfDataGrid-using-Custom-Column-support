using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDatagridDemo
{
    public class ViewModel
    {
        public ViewModel()
        {
            OrdersListDetails = new OrderInfoRepository().GetListOrdersDetails(10);
        }

        private List<OrderInfo> _ordersListDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public List<OrderInfo> OrdersListDetails
        {
            get { return _ordersListDetails; }
            set { _ordersListDetails = value; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {
            if (this.OrdersListDetails != null)
            {
                this.OrdersListDetails.Clear();
            }
        }
    }

    public class OrderInfoRepository
    {
        int customerIdCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoRepository"/> class.
        /// </summary>
        public OrderInfoRepository()
        {
        }

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public List<OrderInfo> GetListOrdersDetails(int count)
        {
            List<OrderInfo> ordersDetails = new List<OrderInfo>();
           
            for (int i = 1000; i < count + 1000; i++)
            {
                ordersDetails.Add(GetOrder(i));
            }

            return ordersDetails;
        }

        Random r = new Random(1);


        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        private OrderInfo GetOrder(int i)
        {
            
            var order = new OrderInfo();
            order.OrderID = i;
            order.CustomerID = GetCustomerID(i);
            order.Quantity = r.Next(i % 60);
            order.NumericUpDown = r.Next(i % 9);
            return order;
        }

        string GetCustomerID(int i)
        {
            if (i % 4 != 0 || i == 0)
            {
                return CustomerID[customerIdCount];
            }
            else
            {
                if (i % 4 == 0)
                    customerIdCount++;

                if (customerIdCount > 9)
                    customerIdCount = 0;

                return CustomerID[customerIdCount];
            }
        }




        string[] CustomerID = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG",
            "SHIWL",
            "ASDFI",
            "YIWOL",
            "SIEPZ",
            "UIKOC",
            "BNUTQ",
            "FDKIO",
            "UJIKW",
            "QOLPX",
            "WJXKO",
            "SXEWD",
            "ZXSOL",
            "KKMJU",
            "QMICP",
            "SJWII",
            "WDOPO",
            "SAIOP",
            "SSOLE",
            "CUEMC",
            "HWIMQ"
        };
    }
}
