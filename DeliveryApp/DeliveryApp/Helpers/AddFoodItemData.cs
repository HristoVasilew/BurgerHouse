using DeliveryApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryApp.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;

        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://foodorderappforabs-default-rtdb.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ImageUrl = "MainBurger",
                    Name = "Burger Big Menu",
                    Description = "Burger Breakfast",
                    Rating = " 5",
                    RatingDetail = " (121 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 15
                },
                new FoodItem
                {
                    ProductID = 2,
                    CategoryID = 1,
                    ImageUrl = "Teleshki",
                    Name = "Burger of beef",
                    Description = "Burger Lunch",
                    Rating = " 4.6",
                    RatingDetail = " (114 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 14
                },
                new FoodItem
                {
                    ProductID = 3,
                    CategoryID = 1,
                    ImageUrl = "pileshki",
                    Name = "Chicken Burger",
                    Description = "Burger Dinner",
                    Rating = " 4.9",
                    RatingDetail = " (19 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 12
                },
                new FoodItem
                {
                    ProductID = 4,
                    CategoryID = 1,
                    ImageUrl = "daImaOshEdin",
                    Name = "Burger BigMac",
                    Description = "Burger Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (76 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 18
                },
                new FoodItem
                {
                    ProductID = 5,
                    CategoryID = 2,
                    ImageUrl = "peperony",
                    Name = "Pizza Peperony",
                    Description = "Pizza peperony",
                    Rating = " 4.4",
                    RatingDetail = " (120 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 20
                },
                new FoodItem
                {
                    ProductID = 6,
                    CategoryID = 2,
                    ImageUrl = "Pizza",
                    Name = "Pizza Cheese House",
                    Description = "Pizza House CHeese",
                    Rating = " 4.8",
                    RatingDetail = " (156 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 22
                },
                new FoodItem
                {
                    ProductID = 7,
                    CategoryID = 3,
                    ImageUrl = "MainIceCream",
                    Name = "Ice Creams",
                    Description = "Icecream - Breakfast",
                    Rating = " 5",
                    RatingDetail = " (399 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 37
                },
                new FoodItem
                {
                    ProductID = 8,
                    CategoryID = 3,
                    ImageUrl = "cake",
                    Name = "Chocolate Fantasy",
                    Description = "Cool Chocolate Fantasy",
                    Rating = " 5",
                    RatingDetail = " (420 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 39
                }
             };
        }

        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        Description = item.Description,
                        HomeSelected = item.HomeSelected,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Price = item.Price,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

    }
}
