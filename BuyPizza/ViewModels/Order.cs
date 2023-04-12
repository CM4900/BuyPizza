namespace BuyPizza.ViewModels
{
    public class Order
    {
    }

    public class OrderDataMode
    {

    }

    public class SetOrderModel
    {
        public bool hasError { get; set; } = false;
        public int errorCode { get; set; }
        public string errorMsg { get; set; }
    }
}
