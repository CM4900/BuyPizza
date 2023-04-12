using BuyPizza.Models.dbContext;
using BuyPizza.ViewModels;

namespace BuyPizza.DataControllers
{
    public class OrderObject : IOrderObject
    {
        protected readonly IConfiguration _configuration;
        public OrderObject(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public SetOrderModel SetOrder(OrderDataMode model)
        //{
        //    GetItemListModel returnModel = new GetItemListModel();

        //    try
        //    {
        //        pizzaContext ctx = new pizzaContext(_configuration.GetConnectionString("DefaultConnection"));
        //        var lstItem = ctx.Item.ToList();

        //        if (lstItem.Count <= 0)
        //        {
        //            returnModel.hasError = true;
        //            returnModel.errorCode = 1001;
        //            returnModel.errorMsg = "No Pizza Item found!";
        //        }
        //        else
        //        {
        //            returnModel.hasError = false;
        //            returnModel.errorCode = 0;
        //            returnModel.errorMsg = "Pizza Item found!";
        //            returnModel.lstItemListModel = lstItem.Select(z => new ItemListModel()
        //            {
        //                ItemID = z.ItemID,
        //                Name = z.Name,
        //                Description = z.Description,
        //                ImageBase = GetImageBase(z.Image, "item"),
        //                Rate = z.Rate
        //            }).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log error in text file
        //        returnModel.hasError = true;
        //        returnModel.errorCode = 500;
        //        returnModel.errorMsg = "Some internal error occured!";
        //    }

        //    return returnModel;
        //}



    }
}
