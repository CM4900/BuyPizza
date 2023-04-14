using BuyPizza.Models.dbContext;
using BuyPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BuyPizza.DataControllers
{
    public class ItemObject : IItemObject
    {
        protected readonly IConfiguration _configuration;
        public ItemObject(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public GetItemListModel GetItemList(long itemID)
        {
            GetItemListModel returnModel = new GetItemListModel();

            try
            {
                using (pizzaContext ctx = new pizzaContext(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var lstItem = new List<Models.Item>();
                    if (itemID <= 0)
                    {
                        lstItem = ctx.Item.ToList();
                    }
                    else
                    {
                        lstItem = ctx.Item.Where(z => z.ItemID == itemID).ToList();
                    }

                    if (lstItem.Count <= 0)
                    {
                        returnModel.hasError = true;
                        returnModel.errorCode = 1001;
                        returnModel.errorMsg = "No Pizza Item found!";
                    }
                    else
                    {
                        returnModel.hasError = false;
                        returnModel.errorCode = 0;
                        returnModel.errorMsg = "Pizza Item found!";
                        returnModel.lstItemListModel = lstItem.Select(z => new ItemListModel()
                        {
                            itemID = z.ItemID,
                            name = z.Name,
                            description = z.Description,
                            imageBase = GetImageBase(z.Image, "item"),
                            rate = z.Rate
                        }).ToList();
                    }
                }
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

        public GetItemToppingListModel GetItemToppingList(long itemID)
        {
            GetItemToppingListModel returnModel = new GetItemToppingListModel();

            try
            {
                using (pizzaContext ctx = new pizzaContext(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var lstItemTopping = ctx.ItemTopping.Where(x => x.ItemID == itemID)
                                            .Include(s => s.Item)
                                            .Include(s => s.Topping)
                                            .ToList();

                    if (lstItemTopping.Count <= 0)
                    {
                        returnModel.hasError = true;
                        returnModel.errorCode = 1002;
                        returnModel.errorMsg = "No Pizza Item Topping found!";
                    }
                    else
                    {
                        returnModel.hasError = false;
                        returnModel.errorCode = 0;
                        returnModel.errorMsg = "Pizza Item Topping found!";
                        returnModel.lstItemToppingListModel = lstItemTopping.Select(z => new ItemToppingListModel()
                        {
                            itemToppingID = z.ItemToppingID,
                            itemID = z.ItemID,
                            toppingID = z.ToppingID,
                            itemName = z.Item.Name,
                            itemDescription = z.Item.Description,
                            toppingName = z.Topping.Name,
                            imageBase = GetImageBase(z.Topping.Image, "topping"),
                            rate = z.Topping.Rate
                        }).ToList();
                    }
                }
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

        private String GetImageBase(string imgName, string imgDir)
        {
            try
            {
                //Byte[] b = System.IO.File.ReadAllBytes(@"E:\\Test.jpg");   // You can use your own method over here.         
                //var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64String)));
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string filePath = Path.Combine(currentDirectory, "Images", imgDir, imgName);
                if (!File.Exists(filePath))
                {
                    return string.Empty;
                }

                byte[] imageArray = System.IO.File.ReadAllBytes(filePath);
                return Convert.ToBase64String(imageArray);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
