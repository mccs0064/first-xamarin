using RaysHotDogs.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup()
            {
                HotDogGroupId = 1, Title = "Meat Lovers", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogId = 1,
                        Name = "Regular Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "REgular hot dog with cheese.  MAde with Paperika",
                        ImagePath = "hotdog1",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() { "Regular bun", "Susage", "Ketchup", "Mustard"},
                        Price = 8,
                        IsFavorite = true
                    },

                     new HotDog()
                    {
                        HotDogId = 2,
                        Name = "New York Dog",
                        ShortDescription = "started hotdogs in NY",
                        Description = "Hotdog made simple with mustard and onions",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime = 5,
                        Ingredients = new List<string>() { "Regular bun", "Susage", "Onion", "Mustard"},
                        Price = 5,
                        IsFavorite = false
                    },
                     new HotDog()
                    {
                        HotDogId = 3,
                        Name = "Fancy Dog",
                        ShortDescription = "most expensive dog around",
                        Description = "Hotdog made with truffles and gold",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime = 25,
                        Ingredients = new List<string>() { "Regular bun", "Susage", "Truffle SHavings", "Gold Leaf", "Spicy Mayo"},
                        Price = 85,
                        IsFavorite = true
                    }
                }

            },
            new HotDogGroup()
            {
                HotDogGroupId = 2, Title = "Veggie Lovers", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogId = 4,
                        Name = "Tofu Hot Dog",
                        ShortDescription = "Vegimatics approved tofu dog",
                        Description = "Hot Dog made from the worlds finest Tofu",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime = 9,
                        Ingredients = new List<string>() { "Gluten free bun", "Tofu Hot Dog", "Ketchup", "Lettuce"},
                        Price = 14,
                        IsFavorite = true
                    },

                     new HotDog()
                    {
                        HotDogId = 5,
                        Name = "Organic Dog",
                        ShortDescription = "Healthiest Dog out there",
                        Description = "Hotdog made with all organic ingredients include a eggplant dog",
                        ImagePath = "hotdog5",
                        Available = true,
                        PrepTime = 23,
                        Ingredients = new List<string>() { "Regular bun", "Egg PLant Dog", "Onion", "Mustard", "Lettuce"},
                        Price = 45,
                        IsFavorite = false
                    },
                     new HotDog()
                    {
                        HotDogId = 6,
                        Name = "Protien Dog",
                        ShortDescription = "Hotdog for bodybuilders",
                        Description = "Hotdog made with protien powder and cheese 21 g of protien per serving",
                        ImagePath = "hotdog6",
                        Available = true,
                        PrepTime = 25,
                        Ingredients = new List<string>() { "Regular bun", "Protien Dog", "Cheese", "Basil Leaf", "Spicy Mayo"},
                        Price = 25,
                        IsFavorite = false
                    }
                }

            }
        };

        //return all hotdogs
        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          select hotDog;
            return hotDogs.ToList<HotDog>();
        }

        //return hotdog by id
        public HotDog GetHotDogById(int hotDogId)
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.HotDogId == hotDogId
                                          select hotDog;

            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

            if (group != null)
            {
                return group.HotDogs;
            }

            return null;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.IsFavorite
                                          select hotDog;
            return hotDogs.ToList<HotDog>();
        }

    }
}
