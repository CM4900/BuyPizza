using BuyPizza.Models;
using BuyPizza.Models.dbContext;
using BuyPizza.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BuyPizza.DataControllers
{
    public class OrderObject : IOrderObject
    {
        protected readonly IConfiguration _configuration;
        public OrderObject(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PlaceOrderModel PlaceOrder(OrderDataMode model)
        {
            PlaceOrderModel returnModel = new PlaceOrderModel();

            try
            {
                using (pizzaContext ctx = new pizzaContext(_configuration.GetConnectionString("DefaultConnection")))
                {
                    Models.Order objOrder = new Models.Order();
                    objOrder.OrderAmount = model.orderAmount;
                    objOrder.CreatedDate = DateTime.UtcNow;
                    ctx.Order.Add(objOrder);
                    ctx.SaveChanges();
                    if (objOrder.OrderID <= 0)
                    {
                        returnModel.hasError = true;
                        returnModel.errorCode = 1003;
                        returnModel.errorMsg = "Order not placed!";
                    }

                    foreach (var orderItem in model.lstOrderItem)
                    {
                        Models.OrderItem objOrderItem = new Models.OrderItem();
                        objOrderItem.ItemID = orderItem.itemID;
                        objOrderItem.OrderID = objOrder.OrderID;
                        objOrderItem.Quentity = orderItem.quentity;
                        objOrderItem.Price = orderItem.itemRate;
                        objOrderItem.CreatedDate = DateTime.UtcNow;
                        ctx.OrderItem.Add(objOrderItem);
                        ctx.SaveChanges();

                        foreach (var orderItemorderItem in orderItem.lstOrderItemTopping)
                        {
                            Models.OrderItemTopping objOrderItemTopping = new Models.OrderItemTopping();
                            objOrderItemTopping.ToppingID = orderItemorderItem.toppingID;
                            objOrderItemTopping.OrderItemID = objOrderItem.OrderItemID;
                            objOrderItemTopping.Price = orderItemorderItem.toppingRate;
                            objOrderItemTopping.CreatedDate = DateTime.UtcNow;
                            ctx.OrderItemTopping.Add(objOrderItemTopping);
                            ctx.SaveChanges();
                        }
                    }
                }

                returnModel.hasError = false;
                returnModel.errorCode = 0;
                returnModel.errorMsg = "Order placed!";
            }
            catch (Exception ex)
            {
                // Log error in text file
                returnModel.hasError = true;
                returnModel.errorCode = 500;
                returnModel.errorMsg = "Some internal error occured!";
            }

            return returnModel;
        }

        public GetOrderDetailsModel GetOrderDetails(long orderID)
        {
            GetOrderDetailsModel returnModel = new GetOrderDetailsModel();

            try
            {
                using (pizzaContext ctx = new pizzaContext(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var order = ctx.Order.FirstOrDefault(z => z.OrderID == orderID);
                    if (order == null)
                    {
                        returnModel.hasError = true;
                        returnModel.errorCode = 1005;
                        returnModel.errorMsg = "Order not exist!";
                    }

                    returnModel.orderDetailsModel = new OrderDetailsModel()
                    {
                        orderID = order.OrderID,
                        orderAmount = order.OrderAmount,
                        createdDate = order.CreatedDate,
                        lstOrderItemDetailsModel = new List<OrderItemDetailsModel>()
                    };

                    var orderItem = ctx.OrderItem.Where(z => z.OrderID == orderID).Include(z => z.Item);
                    foreach (var item in orderItem)
                    {
                        var lstOrderItemToppingModel = new List<OrderItemToppingDetailsModel>();
                        var orderItemTopping = ctx.OrderItemTopping.Where(z => z.OrderItemID == item.OrderItemID).Include(z => z.Topping);
                        foreach (var orderTopping in orderItemTopping)
                        {
                            lstOrderItemToppingModel.Add(new OrderItemToppingDetailsModel()
                            {
                                orderItemToppingID = orderTopping.OrderItemToppingID,
                                toppingID = orderTopping.ToppingID,
                                name = orderTopping.Topping.Name,
                                price = orderTopping.Price,
                                createdDate = orderTopping.CreatedDate
                            });
                        }

                        returnModel.orderDetailsModel.lstOrderItemDetailsModel.Add(new OrderItemDetailsModel()
                        {
                            orderItemID = item.OrderItemID,
                            itemID = item.ItemID,
                            name = item.Item.Name,
                            quentity = item.Quentity,
                            price = item.Price,
                            createdDate = item.CreatedDate,
                            lstOrderItemToppingDetailsModel = lstOrderItemToppingModel
                        });
                    }
                }

                returnModel.hasError = false;
                returnModel.errorCode = 0;
                returnModel.errorMsg = "";
            }
            catch (Exception ex)
            {
                // Log error in text file
                returnModel.hasError = true;
                returnModel.errorCode = 500;
                returnModel.errorMsg = "Some internal error occured!";
            }

            return returnModel;
        }
    }
}
