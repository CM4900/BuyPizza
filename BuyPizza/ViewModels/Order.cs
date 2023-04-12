using System.Text;

namespace BuyPizza.ViewModels
{
    public class Order
    {
    }

    public class OrderDataMode
    {
        public long itemID { get; set; }
        public int quentity { get; set; }
        public Decimal itemRate { get; set; }
        public long toppingID { get; set; }
        public Decimal toppingRate { get; set; }
        public Decimal orderAmount { get; set; }
    }

    public class SetOrderModel
    {
        public bool hasError { get; set; } = false;
        public int errorCode { get; set; }
        public string errorMsg { get; set; }
    }
}
