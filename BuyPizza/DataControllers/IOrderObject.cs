using BuyPizza.ViewModels;

namespace BuyPizza.DataControllers
{
    public interface IOrderObject
    {
        PlaceOrderModel PlaceOrder(OrderDataMode model);
        GetOrderDetailsModel GetOrderDetails(long orderID);
    }
}
