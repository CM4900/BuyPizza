using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BuyPizza.ViewModels
{
    public class Order
    {
    }

    public class OrderItemToppingDataModel
    {
        public long toppingID { get; set; }
        public Decimal toppingRate { get; set; }
    }
    public class OrderItemDataModel
    {
        public long itemID { get; set; }
        public int quentity { get; set; }
        public Decimal itemRate { get; set; }
        public List<OrderItemToppingDataModel> lstOrderItemTopping { get; set; }

    }
    public class OrderDataMode
    {
        public Decimal orderAmount { get; set; }
        public List<OrderItemDataModel> lstOrderItem { get; set; }
    }
    public class PlaceOrderModel
    {
        public bool hasError { get; set; } = false;
        public int errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class OrderItemToppingDetailsModel
    {
        public long orderItemToppingID { get; set; }
        public long toppingID { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public DateTime createdDate { get; set; }
    }
    public class OrderItemDetailsModel
    {
        public long orderItemID { get; set; }
        public long itemID { get; set; }
        public string name { get; set; }
        public int quentity { get; set; }
        public decimal price { get; set; }
        public DateTime createdDate { get; set; }
        public List<OrderItemToppingDetailsModel> lstOrderItemToppingDetailsModel { get; set; }

    }
    public class OrderDetailsModel
    {
        public long orderID { get; set; }
        public decimal orderAmount { get; set; }
        public DateTime createdDate { get; set; }
        public List<OrderItemDetailsModel> lstOrderItemDetailsModel { get; set; }
    }
    public class GetOrderDetailsModel
    {
        public bool hasError { get; set; } = false;
        public int errorCode { get; set; }
        public string errorMsg { get; set; }
        public OrderDetailsModel orderDetailsModel { get; set; }
    }
}
