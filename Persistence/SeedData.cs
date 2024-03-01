using Domain.Models;
using Persistence.SqlDataBase;

namespace Persistence
{
    public static class SeedData
    {
        public static async Task Initialize(CoffeeBackEndDbContext db)
        {
            var coffeeShops = new List<CoffeeBrand>()
            {
                new CoffeeBrand()
                {
                    Name = "Lavazza",
                    Image = "LavazzaLogo.png"
                },
                new CoffeeBrand()
                {
                    Name = "Starbucks",
                    Image = "starbucksLogo.png"
                },
                new CoffeeBrand()
                {
                    Name = "Coprisette",
                    Image = "CoprisetteLogo.png"
                }
            };
            var menuItems = new List<MenuItem>()
            {
                new MenuItem()
                {
                    CoffeeBrandId = 4,
                    Description = "A soft, rounded, inviting blend principally composed of high-quality Arabica and Robusta. The perfect harmony between body and spicy top notes. Ideal for milk-based preparations.rab a cup of coffee and enjoy the Lavazza Experience. Whether your favourite is A Modo Mio capsules or Qualità Rossa ground or whole beans, the important thing is to live sustainably, even as you sip that very first coffee of the day. ",
                    ImageUrl = "LZ-CremaEGustoImg.png",
                    Name = "Crema e Gusto",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "Italy"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 4,
                    Description = "Espresso Barista Gran Crema is the expression of Lavazza's expertise in crafting superior quality coffee, to make you feel like a barista. Enjoy authentic Italian espresso.Grab a cup of coffee and enjoy the Lavazza Experience. Whether your favourite is A Modo Mio capsules or Qualità Rossa ground or whole beans, the important thing is to live sustainably, even as you sip that very first coffee of the day. ",
                    ImageUrl = "LZ-EspressoImg.png",
                    Name = "Espresso Barista Gran",
                    SmallPackagePrice = 30,
                    MediumPackagePrice = 50,
                    LargePackagePrice = 70,
                    Origin = "Italy"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 4,
                    Description = "Espresso Ricco 700 is an intensely flavoured blend being full bodied and creamy when savoured. It is made up frm the finest washed and partially washed Arabica from Central America and from Robusta from plantations that give an unsurpassable body to the blend, in keeping with true Italian tradition.",
                    ImageUrl = "LZ-SettecentoImg.png",
                    Name = "Settecento Ricco",
                    SmallPackagePrice = 15,
                    MediumPackagePrice = 35,
                    LargePackagePrice = 70,
                    Origin = "Italy"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 4,
                    Description = "Explore the wonders of nature with ¡Tierra! for Planet: a blend from Africa and Central-South America where we are teaching farmers to manage the effects of climate change.Grab a cup of coffee and enjoy the Lavazza Experience. Whether your favourite is A Modo Mio capsules or Qualità Rossa ground or whole beans, the important thing is to live sustainably, even as you sip that very first coffee of the day.",
                    ImageUrl = "LZ-ForPlanetBeansImg.png",
                    Name = "For planet Beans",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "Italy"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 4,
                    Description = "Full-bodied and creamy blend with a persistent aroma of bitter cocoa and nuts, as well as a pleasant note of dark chocolate. rab a cup of coffee and enjoy the Lavazza Experience. Whether your favourite is A Modo Mio capsules or Qualità Rossa ground or whole beans, the important thing is to live sustainably, even as you sip that very first coffee of the day.",
                    ImageUrl = "LZ-CremaEGustoTradizione.png",
                    Name = "Crema e Gusto Tradizione",
                    SmallPackagePrice = 50,
                    MediumPackagePrice = 100,
                    LargePackagePrice = 200,
                    Origin = "Italy"
                },

                new MenuItem()
                {
                    CoffeeBrandId = 5,
                    Description = "We introduced this blend in 1998 for those who prefer a milder cup. A shade lighter than most of our offerings—more toasty than roasty—it was the result of playing with roasting techniques and taste profiles, creating a cup brimming with brown sugar and sweet orange notes. Perfect if you want to wake up to a less intense coffee but still want a lot of character, it's light and lively with a soft sweetness.",
                    ImageUrl = "SB-BreakfastBlendImg.png",
                    Name = "Breakfast Blend",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "USA"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 5,
                    Description = "From our first store in Seattle’s Pike Place Market to our coffeehouses around the world, customers requested a freshly brewed coffee they could enjoy throughout the day. So in 2008, our master blenders and roasters worked together with customers to create it for you. The result was Pike Place® Roast, a blend so consistent and harmonious that no single characteristic dominates—or disappears.",
                    ImageUrl = "SB-PikePlaceRoastImg.png",
                    Name = "Pike Place Roast",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "USA"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 5,
                    Description="We’ve always loved coffee from Colombia. And we’re never reminded of that love more than when we’re traveling to the coffee farms. Driving treacherous dirt roads with a sheer mountain wall to one side—nothing but air for thousands of feet to the other. Sitting at 6,500 feet of elevation, nestled among the beautiful and distinctive Colombian countryside, these farms produce amazing coffee. For us, the toasted walnut and herbal notes of this 100% Colombian coffee are worth the journey every time",
                    ImageUrl = "SB-VerandaBlendImg.png",
                    Name = "Veranda Blend",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "USA"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 5,
                    Description = "It’s deceptively simple. A blend of fine Latin American beans roasted to a glistening, dark chestnut color. Loaded with flavor, balancing notes of toffee and dusted cocoa, just a touch of sweetness from the roast. This coffee is our beginning, the very first blend we ever created for you back in 1971. And this one blend set the course for the way our master blenders and roasters work even today. A true reflection of us and a delicious cup of coffee, period. It all starts from here.",
                    ImageUrl = "SB-HouseBlendImg.png",
                    Name = "House Blend",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "USA"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 5,
                    Description = "This fall coffee is bright with notes of pumpkin, cinnamon and nutmeg​ together with our lightest roast. Add a​ splash of cream and a little sugar to​ awaken deliciously familiar flavors​ reminiscent of our Pumpkin Spice Latte.​",
                    ImageUrl = "SB-PumpkinSpiceImg.png",
                    Name = "Pumpkin Spice",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "USA"
                },

                new MenuItem()
                {
                    CoffeeBrandId = 6,
                    Description = "Coffee of a truly royal taste, packed in a bag so beautiful it’s quite literally fit for a king?.. Yes, that’s the one! This thick, rich and naturally sweet blend is sure to please fans of traditional coffee flavours who want to feel like royalty from time to time. Just brew a cup, sit back and let yourself be enveloped by exquisite tasting notes that are as smooth as finest silk…",
                    ImageUrl = "CA-RoyaleImg.png",
                    Name = "Royale",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "Belgium"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 6,
                    Description = "Your favourite coffee with a new, fun name, packed in an upgraded, modern bag. Straight from an Italian roasting house, this is the perfect choice for sworn fans of Italian coffees!This 100% arabica blend combines beans from Brazil, Mexico, India and Ethiopia. Treat your palate to sweet notes of caramel, hints of gourmet liqueur and a sprinkle of the finest cacao. ",
                    ImageUrl = "CA-ItalianoImg.png",
                    Name = "Italiano",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "Belgium"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 6,
                    Description = "Your favourite coffee with a new, fun name, packed in an upgraded, modern bag. This blend of coffee beans from Brazil and Honduras (80% arabica and 20% robusta) is sure to impress the fans of traditional coffee flavours. It’s characterised by an intense aroma and a full body. Once the drink’s been finished, a long-lasting aftertaste of dark chocolate and sweet caramel envelops the palate.",
                    ImageUrl = "CA-BelgiqueImg.png",
                    Name = "Belgique",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "Belgium"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 6,
                    Description = "Your favourite coffee with a new, fun name, packed in an upgraded, modern bag.This blend of Brazilian coffee beans (80% arabica and 20% robusta) is sure to impress the fans of traditional coffee flavours. Its aroma is marked by the sweetness of peanut butter and chocolate candies, while in its taste, notes of milk chocolate are unveiled. Once the drink’s been finished, a subtle aftertaste of walnuts envelops the palate. ",
                    ImageUrl = "CA-FragranteImg.png",
                    Name = "Fragrante",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "Belgium"
                },
                new MenuItem()
                {
                    CoffeeBrandId = 6,
                    Description = "Your favourite coffee with a new, fun name, packed in an upgraded, modern bag.This blend of 100% arabica coffee beans originating from Brazil and Honduras is sure to impress the fans of subtle coffee flavours. It smells of berries and caramel, and boasts delicate notes of dark chocolate ",
                    ImageUrl = "CA-ProfessionalImg.png",
                    Name = "Professional",
                    SmallPackagePrice = 20,
                    MediumPackagePrice = 40,
                    LargePackagePrice = 60,
                    Origin = "Belgium"
                }
            };

         //   await db.CoffeeBrands.AddRangeAsync(coffeeShops);
            await db.MenuItems.AddRangeAsync(menuItems);
            await db.SaveChangesAsync();
        }
    }
}
