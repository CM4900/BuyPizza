using BuyPizza.DataControllers;
using BuyPizza.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderObject _iOrderObject;
        private readonly IItemObject _iItemObject;
        public OrderController(ILogger<OrderController> logger, IOrderObject iOrderObject, IItemObject iItemObject)
        {
            _logger = logger;
            _iOrderObject = iOrderObject;
            _iItemObject = iItemObject;
        }

        [HttpPost]
        public PlaceOrderModel MakeOrder(OrderDataMode model)
        {
            decimal orderAmount = 0;
            foreach (var orderItem in model.lstOrderItem)
            {
                var lstItem = _iItemObject.GetItemList(orderItem.itemID);
                if (!lstItem.hasError)
                {
                    var item = lstItem.lstItemListModel.FirstOrDefault(z => z.itemID == orderItem.itemID);
                    if (item != null)
                    {
                        orderAmount += item.rate * orderItem.quentity;
                    }

                }

                var lstItemTopping = _iItemObject.GetItemToppingList(orderItem.itemID);
                if (!lstItemTopping.hasError)
                {
                    foreach (var orderItemTopping in orderItem.lstOrderItemTopping)
                    {
                        var itemTopping = lstItemTopping.lstItemToppingListModel.FirstOrDefault(z => z.toppingID == orderItemTopping.toppingID);
                        if (itemTopping != null)
                        {
                            orderAmount += itemTopping.rate;
                        }
                    }
                }
            }

            if (orderAmount != model.orderAmount)
            {
                return new PlaceOrderModel()
                {
                    hasError = true,
                    errorCode = 1004,
                    errorMsg = "Invalid Order details!"
                };
            }

            return _iOrderObject.PlaceOrder(model);
        }

        [HttpGet]
        public GetOrderDetailsModel GetOrder(long orderId)
        {
            return _iOrderObject.GetOrderDetails(orderId);
        }
    }
}
